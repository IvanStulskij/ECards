using System;

namespace ECardsLib
{
    public static class StringsExtensions
    {
        public static string CheckForUncorrect(this string value, string exceptionMessage)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new InvalidOperationException(exceptionMessage);
            }

            return value;
        }
    }
}
