﻿namespace FirstProject_RP.CoreLayer.Utilities
{
    public static class TextHelper
    {
        public static string ToSlug(this string value)
        {
            return value.Trim().ToLower()
                .Replace("~","")
                .Replace("@", "")
                .Replace("#", "")
                .Replace("$", "")
                .Replace("%", "")
                .Replace("^", "")
                .Replace("&", "")
                .Replace("*", "")
                .Replace("(", "")
                .Replace(")", "")
                .Replace("+", "")
                .Replace(" ", "-")
                .Replace(">", "")
                .Replace("<", "")
                .Replace(@"\", "")
                .Replace("/", "");
        }
    }
}