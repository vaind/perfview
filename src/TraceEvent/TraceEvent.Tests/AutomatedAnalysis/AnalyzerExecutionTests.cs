#nullable disable

using Microsoft.Diagnostics.Tracing.AutomatedAnalysis;
using Microsoft.Diagnostics.Symbols;
using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Diagnostics.Tracing.Etlx;
using System.IO;
using PerfView.TestUtilities;
using Xunit;
using Xunit.Abstractions;
using TestEventTests.Analyzers;
using System.Linq;

namespace TraceEventTests
{
    [UseCulture("en-US")]
    internal class AnalyzerExecutionTests : AutomatedAnalysisTestBase
    {
        public AnalyzerExecutionTests(ITestOutputHelper output)
            : base(output)
        {
        }

        [Fact]
        public void DetectSingleIssue()
        {
            PrepareTestData();

            string inputTestFile = "SimpleAllocator-dotnet6.etl";
            string inputFilePath = Path.Combine(UnZippedDataDir, inputTestFile);
            using (TraceLog traceLog = TraceLog.OpenOrConvert(inputFilePath))
            {
                AutomatedAnalysisTraceLog automatedAnalysisTraceLog = new AutomatedAnalysisTraceLog(traceLog, new SymbolReader(TextWriter.Null));
                TraceProcessor traceProcessor = new TraceProcessor(new AnalyzerExecutionTestResolver());
                TraceProcessorResult result = traceProcessor.ProcessTrace(automatedAnalysisTraceLog);

                // Get the process.
                Process process = ((ITrace)automatedAnalysisTraceLog).Processes
                    .Where(p => p.DisplayID == SingleIssueAnalyzer.PID && p.Description == SingleIssueAnalyzer.ProcessDescription)
                    .FirstOrDefault();
                Assert.NotNull(process);

                // Get the issues for the process and confirm that only one issue exists in the list.
                List<AnalyzerIssue> issues = result.Issues[process];
                Assert.Single(issues);

                // Get the issue and confirm its the right one.
                AnalyzerIssue issue = issues[0];
                Assert.Equal(SingleIssueAnalyzer.Issue, issue);
                Assert.Equal(SingleIssueAnalyzer.Issue.Analyzer, TestAnalyzerProvider.ExecutionTests_SingleIssueAnalyzer);
                Assert.Equal(SingleIssueAnalyzer.TestIssueId, issue.Id);

                // Make sure the expected Analyzer was run.
                IEnumerable<Analyzer> executedAnalyzers = result.ExecutedAnalyzers;
                Assert.Single(executedAnalyzers);
                Assert.Equal(executedAnalyzers.Single(), TestAnalyzerProvider.ExecutionTests_SingleIssueAnalyzer);
            }
        }
    }

    internal sealed class AnalyzerExecutionTestResolver : TestAnalyzerResolver
    {
        protected override void OnAnalyzerLoaded(AnalyzerLoadContext loadContext)
        {
            if (loadContext.Analyzer.GetType() != typeof(SingleIssueAnalyzer))
            {
                loadContext.ShouldRun = false;
            }
        }
    }

    internal sealed class SingleIssueAnalyzer : ProcessAnalyzer
    {
        internal static readonly Guid TestIssueId = Guid.Parse("06e26d5a-14e5-455e-9266-7303857c11c7");
        internal static AnalyzerIssue Issue;
        internal const int PID = 106800;
        internal const string ProcessDescription = "SimpleAllocator.exe";

        protected override AnalyzerExecutionResult Execute(AnalyzerExecutionContext executionContext, ProcessContext processContext)
        {
            if (processContext.Process.DisplayID == PID && ProcessDescription.Equals(processContext.Process.Description))
            {
                Assert.Null(Issue);
                Issue = new AnalyzerIssue(TestIssueId, "Test Title", "Test Description", "http://test-url");
                processContext.AddIssue(Issue);
            }

            return AnalyzerExecutionResult.Success;
        }
    }
}
