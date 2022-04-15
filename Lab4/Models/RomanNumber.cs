using System;

namespace Lab4
{
    internal class RomanNumber : ICloneable, IComparable
    {
        protected ushort number = 0;

        public RomanNumber(ushort n)
        {
            if (n <= 0 || n >= 4000)
                throw new ArgumentOutOfRangeException("Error: неверное входное значение");
            number = n;
        }

        public static RomanNumber operator +(RomanNumber? n1, RomanNumber? n2)
        {
            if (n1 != null && n2 != null)
                return new RomanNumber((ushort)(n1.number + n2.number));
            else
                throw new RomanNumberException("Error: сложение невозможно");
        }

        public static RomanNumber operator -(RomanNumber? n1, RomanNumber? n2)
        {
            if (n1 != null && n2 != null && n1.number > n2.number)
                return new RomanNumber((ushort)(n1.number - n2.number));
            else
                throw new RomanNumberException("Error: вычитание невозможно");
        }

        public static RomanNumber operator *(RomanNumber? n1, RomanNumber? n2)
        {
            if (n1 != null && n2 != null && n1.number * n2.number <= 3999)
                return new RomanNumber((ushort)(n1.number * n2.number));
            else
                throw new RomanNumberException("Error: умножение невозможно");
        }



        public static RomanNumber operator /(RomanNumber? n1, RomanNumber? n2)
        {
            if (n1 != null && n2 != null && n2.number != 0 && n1.number % n2.number == 0)
                return new RomanNumber((ushort)(n1.number / n2.number));
            else
                throw new RomanNumberException("Error: деление невозможно");
        }



        public override string ToString()
        {
            string str = "";
            ushort num = number;
            ushort[] a = new ushort[] { 1, 4, 5, 9, 10, 40, 50, 90, 100, 400, 500, 900, 1000 };
            string[] b = new string[] { "I", "IV", "V", "IX", "X", "XL", "L", "XC", "C", "CD", "D", "CM", "M" };

            for (int i = 12; i >= 0; --i)
            {
                if (num / a[i] != 0)
                {
                    for (int j = 0; j < num / a[i]; ++j)
                        str += b[i];
                    num %= a[i];
                }
            }
            return str;
        }


        public object Clone()
        {
            return new RomanNumber(number);
        }

        public int CompareTo(object? obj)
        {
            if (obj is RomanNumber rNumber)
                return number.CompareTo(rNumber.number);
            else
                throw new RomanNumberException("Error: сравнение невозможно");
        }


    }
}