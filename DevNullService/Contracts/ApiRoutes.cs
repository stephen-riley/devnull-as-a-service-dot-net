using System.Diagnostics.CodeAnalysis;

namespace DevNullService.Contracts
{
    public static class ApiRoutes
    {
        public const string Root = "api";

        public const string Version = "v1";

        public const string Base = Root + "/" + Version;

        [SuppressMessage("Microsoft.Performance", "CA1034:NestedTypesShouldNotBeVisible")]
        public static class Posts
        {
            public const string PostData = Base + "/dev/null";
        }

        [SuppressMessage("Microsoft.Performance", "CA1034:NestedTypesShouldNotBeVisible")]
        public static class Gets
        {
            public const string GetNulls = Base + "/dev/null";
        }
    }
}