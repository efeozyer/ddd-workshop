using System;

namespace DDD.Workshop.SharedKernel.Helpers
{
    public static class DateTimeHelper
    {
        public static int CalculateAge(DateTime dateOfBirh, DateTimeKind kind = DateTimeKind.Local)
        {
            var now = kind == DateTimeKind.Utc ? DateTime.UtcNow : DateTime.Now;

            return (int)((now - dateOfBirh).TotalDays / 365.242199);
        }
    }
}
