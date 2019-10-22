namespace JobService.Core.Builders
{
    using System.Collections.Generic;

    public static class SqlStoredProcedureStringBuilder
    {
        private const string Prefix = "EXEC";
        private const char Seperator = ',';

        public static string Build(string storedProcedureName, IEnumerable<string> parameterKeys)
        {
            return $"{Prefix} {storedProcedureName} {BuildParameters(parameterKeys)}";
        }

        private static string BuildParameters(IEnumerable<string> parameterKeys)
        {
            return string.Join(Seperator, parameterKeys);
        }
    }
}
