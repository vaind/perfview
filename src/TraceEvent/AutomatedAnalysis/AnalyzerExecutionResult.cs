#nullable disable

namespace Microsoft.Diagnostics.Tracing.AutomatedAnalysis
{
    /// <summary>
    /// A result returned after execution of an Analyzer.
    /// </summary>
    internal enum AnalyzerExecutionResult
    {
        Success,
        Fail,
        Skip
    };
}
