namespace Pesel.Validator
{
    public class DateValidator
    {
        private const int MinValidYear = 1900;
        private const int MaxValidYear = 2099;

        /// <summary>
        /// Check if inputs are in given range. Handles February with leap year.
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <returns>True if given date is valid.</returns>
        public static bool IsDateValid(int year, int month, int day)
        {
            return ValidateYear(year) && ValidateMonth(month) && ValidateDay(year, month, day);
        }

        /// <summary>
        /// Check year is in given range.
        /// </summary>
        /// <param name="year"></param>
        /// <returns>True if given year is in the valid range.</returns>
        private static bool ValidateYear(int year)
        {
            return year >= MinValidYear && year <= MaxValidYear;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="month"></param>
        /// <returns>True if given month is in valid range.</returns>
        private static bool ValidateMonth(int month)
        {
            return month >= 1 && month <= 12;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <returns>True if given day is in the valid range.</returns>
        private static bool ValidateDay(int year, int month, int day)
        {
            if (day < 1 || day > 31)
                return false;

            switch ((Month)month)
            {
                case Month.February:
                    return IsLeapYear(year) ? day <= 29 : day <= 28;
                case Month.April:
                case Month.June:
                case Month.September:
                case Month.November:
                    return (day <= 30);
                default:
                    // Already verified that the day is less or equal than 31
                    return true;
            }
        }

        /// <summary>
        /// Checks if year is a multiple of 4 and not multiple of 100, or year is multiple of 400.
        /// </summary>
        /// <param name="year"></param>
        /// <returns>True if year is a leap year.</returns>
        private static bool IsLeapYear(int year)
        {
            return (((year % 4 == 0) && (year % 100 != 0)) ||
                    (year % 400 == 0));
        }
    }
}
