#nullable disable

using System;
using System.Collections.Generic;

namespace Microsoft.Diagnostics.Tracing.AutomatedAnalysis
{
    /// <summary>
    /// A common set of supported stacks.
    /// </summary>
    internal static class StackTypes
    {
        /// <summary>
        /// Stacks representing execution on one or more CPUs.
        /// </summary>
        public static string CPU { get; } = "CPU";

        /// <summary>
        /// Stacks representing time spent on threads but not executing on CPUs.
        /// </summary>
        public static string Blocked { get; } = "Blocked";
    }

    /// <summary>
    /// The common interface for all supported trace formats.
    /// </summary>
    internal interface ITrace
    {
        /// <summary>
        /// The set of processes contained within the trace.
        /// </summary>
        IEnumerable<Process> Processes { get; }

        /// <summary>
        /// Get a StackView containing stacks for the specified process and stack type.
        /// </summary>
        /// <param name="process">The process to filter stacks by.</param>
        /// <param name="stackType">The type of stacks for the request.</param>
        /// <returns>A StackView containing the requested stacks.</returns>
        StackView GetStacks(Process process, string stackType);
    }
}
