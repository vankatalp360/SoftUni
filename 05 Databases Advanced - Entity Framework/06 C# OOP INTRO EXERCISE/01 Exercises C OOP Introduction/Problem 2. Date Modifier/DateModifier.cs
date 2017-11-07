using System;
using System.Globalization;

namespace Problem_2.Date_Modifier
{
    public class DateModifier
    {
        private int days;

        public DateModifier(string firstDateString, string secondDateString)
        {
            this.days = CalculateDateDiffInDays(firstDateString, secondDateString);
        }

        public int CalculateDateDiffInDays(string firstDateString, string secondDateString)
        {
            string format = "yyyy MM dd";
            DateTime firstDate = DateTime.ParseExact(firstDateString, format, CultureInfo.InvariantCulture);
            DateTime secondDate = DateTime.ParseExact(secondDateString, format, CultureInfo.InvariantCulture);
            return Math.Abs((int)(secondDate - firstDate).TotalDays);
        }

        public override string ToString()
        {
            return $"{this.days}";
        }
    }
}
