namespace NKS.Movies.API.Extensions
{
    using System;

    public static class DateTimeExtensions
    {
        public static bool IsValidTimeFormat(this string input)
        {
            TimeSpan dummyOutput;
            return TimeSpan.TryParse(input, out dummyOutput);
        }
    }
}