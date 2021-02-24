using System;
using Pesel.Validator;

namespace Pesel.Model
{
    public class PeselModel
    {
        public const int PeselSize = 11;

        private static readonly int[] Weights = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };

        public PeselModel(string pesel)
        {
            if (string.IsNullOrEmpty((pesel)))
                throw new NullReferenceException(nameof(pesel));

            if (pesel.Length != PeselSize)
                throw new ArgumentOutOfRangeException(nameof(pesel));

            if (!int.TryParse(pesel, out int result))
                throw new ArgumentException("The PESEL should be a number", nameof(pesel));

            this.PeselValue = pesel;
        }

        public string PeselValue { get; private set; }

        public int this[int index] => DigitAt(index);

        public int Day => BirthDay();

        public int Month => BirthMonth();

        public int Year => BirthYear();

        public int DigitAt(int index)
        {
            if (!string.IsNullOrEmpty((this.PeselValue)))
            {
                if (index >= 0 && index < this.PeselValue.Length)
                {
                    int result = (int)(this.PeselValue[index] - '0');
                    if (result < 0 || result > 9)
                        throw new ArgumentOutOfRangeException(nameof(this.PeselValue));
                    return result;
                }
            }
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        public int CountCheckSum(string pesel)
        {
            int sum = 0;
            if (pesel.Length == PeselSize)
            {
                PeselModel peselObj = new PeselModel(pesel);

                for (int i = 0; i < Weights.Length; i++)
                {
                    sum += Weights[i] * peselObj[i];
                }
            }

            int checkDigit = sum % 10;
            return checkDigit == 0 ? 0 : 10 - checkDigit;
        }

        public bool IsPeselValid(string pesel)
        {
            // Check if is number and 11 digit long
            if (pesel.Length == PeselModel.PeselSize)
            {
                PeselModel peselObj = new PeselModel(pesel);

                // Check birth date
                if (DateValidator.IsDateValid(peselObj.Year, peselObj.Month, peselObj.Day))
                {
                    // Count weighted sum: 1 3 7 9 1 3 7 9 1 3
                    int lastDigit = CountCheckSum(pesel);
                    // 11th digit is check sum digit
                    return (lastDigit == peselObj[10]);
                }
            }
            return false;
        }

        public int BirthDay()
        {
            return 10 * DigitAt(4) + DigitAt(5);
        }

        public int BirthMonth()
        {
            int month = 10 * DigitAt(2) + DigitAt(3);
            return Utils.Utils.GetPeselBirthMonth(month);
        }

        public int BirthYear()
        {
            int year = 10 * DigitAt(0) + DigitAt(1);
            int month = 10 * DigitAt(2) + DigitAt(3);
            return Utils.Utils.GetPeselBirthYear(year, month);
        }
    }
}
