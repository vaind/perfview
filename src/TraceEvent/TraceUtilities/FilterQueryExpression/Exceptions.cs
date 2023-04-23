#nullable disable

using System;

namespace Microsoft.Diagnostics.Tracing.TraceUtilities.FilterQueryExpression
{
    internal sealed class FilterQueryExpressionParsingException : ArgumentException  
    {
        public FilterQueryExpressionParsingException(string message, string query)
            : base($"FilterQueryExpressionTree: {query} failed to parse: {message}") {}
    }

    internal sealed class FilterQueryExpressionTreeParsingException : ArgumentException  
    {
        public FilterQueryExpressionTreeParsingException(string message, string query)
            : base($"FilterQueryExpressionTree: {query} failed to parse: {message}") {}
    }

    internal sealed class FilterQueryExpressionTreeMatchingException : ArgumentException  
    {
        public FilterQueryExpressionTreeMatchingException(string message, string query)
            : base($"FilterQueryExpressionTree: {query} failed to parse: {message}") {}
    }
}










