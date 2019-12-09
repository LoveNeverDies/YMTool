using System;

namespace YMTool
{
    public static class CurrentUser
    {
        public static string UserName { get; set; } = string.Empty;

        public static DateTime LoginTime { get; set; } = DateTime.MinValue;

        public static int PageIndex { get; set; }

        public static int PageSize { get; set; }
    }
}
