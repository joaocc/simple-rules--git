using System;

namespace SimpleRules
{
    public static class IntegerTimeExtensions
    {
        public static DateTime minutes_ago(this int number)
        {
            return DateTime.Now.AddMinutes(-number);
        }

        public static DateTime minutes_ago(this double number)
        {
            return DateTime.Now.AddMinutes(-number);
        }
    }
}
