#nullable disable

using Microsoft.Diagnostics.Tracing.AutomatedAnalysis;
using TraceEventTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Register the provider at the assembly level.
[assembly: AnalyzerProvider(typeof(TestEventTests.Analyzers.TestAnalyzerProvider))]

namespace TestEventTests.Analyzers
{
    internal sealed class TestAnalyzerProvider : IAnalyzerProvider
    {
        // Execution tests.
        public static readonly SingleIssueAnalyzer ExecutionTests_SingleIssueAnalyzer = new SingleIssueAnalyzer();

        // Resolver tests.
        public static readonly ResolverTests_AnalyzerOne ResolverTests_AnalyzerOne = new ResolverTests_AnalyzerOne();
        public static readonly ResolverTests_AnalyzerTwo ResolverTests_AnalyzerTwo = new ResolverTests_AnalyzerTwo();

        internal static readonly Analyzer[] Analyzers = new Analyzer[]
        {
            ExecutionTests_SingleIssueAnalyzer,
            ResolverTests_AnalyzerOne,
            ResolverTests_AnalyzerTwo
        };

        IEnumerable<Analyzer> IAnalyzerProvider.GetAnalyzers()
        {
            foreach (Analyzer analyzer in Analyzers)
            {
                yield return analyzer;
            }
        }
    }

    internal sealed class ResolverTests_AnalyzerOne : Analyzer
    {
        protected override AnalyzerExecutionResult Execute(AnalyzerExecutionContext executionContext)
        {
            return AnalyzerExecutionResult.Success;
        }
    }

    internal sealed class ResolverTests_AnalyzerTwo : Analyzer
    {
        protected override AnalyzerExecutionResult Execute(AnalyzerExecutionContext executionContext)
        {
            return AnalyzerExecutionResult.Success;
        }
    }
}