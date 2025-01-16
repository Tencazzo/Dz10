using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timakov12.Classes
{
    using System;

    public class Rational
    {
        public int Numerator { get; private set; }
        public int Denominator { get; private set; }

        public Rational(int numerator, int denominator)
        {
            if (denominator == 0)
                throw new ArgumentException("Знаменатель не может быть нулем.", nameof(denominator));

            Numerator = numerator;
            Denominator = denominator;
            Simplify();
        }

        private void Simplify()
        {
            int gcd = GCD(Math.Abs(Numerator), Math.Abs(Denominator));
            Numerator /= gcd;
            Denominator /= gcd;

            if (Denominator < 0)
            {
                Numerator = -Numerator;
                Denominator = -Denominator;
            }
        }

        private static int GCD(int a, int b)
        {
            while (b != 0)
            {
                (a, b) = (b, a % b);
            }
            return a;
        }

        public override string ToString() => $"{Numerator}/{Denominator}";

        public static Rational FromString(string str)
        {
            var parts = str.Split('/');
            if (parts.Length != 2 ||
                !int.TryParse(parts[0], out int num) ||
                !int.TryParse(parts[1], out int denom))
            {
                throw new FormatException("Неверный формат дроби.");
            }

            return new Rational(num, denom);
        }

        public Rational GetReciprocal()
        {
            if (Numerator == 0)
                throw new DivideByZeroException("Нельзя получить обратную дробь для нуля.");

            return new Rational(Denominator, Numerator);
        }

        public double ToDecimal() => (double)Numerator / Denominator;

        public static Rational operator +(Rational a, Rational b) =>
            new Rational(a.Numerator * b.Denominator + b.Numerator * a.Denominator, a.Denominator * b.Denominator);

        public static Rational operator -(Rational a, Rational b) =>
            new Rational(a.Numerator * b.Denominator - b.Numerator * a.Denominator, a.Denominator * b.Denominator);

        public static Rational operator *(Rational a, Rational b) =>
            new Rational(a.Numerator * b.Numerator, a.Denominator * b.Denominator);

        public static Rational operator /(Rational a, Rational b)
        {
            if (b.Numerator == 0)
                throw new DivideByZeroException("Деление на ноль.");

            return new Rational(a.Numerator * b.Denominator, a.Denominator * b.Numerator);
        }

        public static Rational operator %(Rational a, Rational b)
        {
            double result = a.ToDecimal() % b.ToDecimal();
            return new Rational((int)(result * b.Denominator), b.Denominator);
        }

        public static implicit operator Rational(int i) => new Rational(i, 1);
        public static implicit operator Rational(float f) => new Rational((int)(f * 10000), 10000);

        public static explicit operator float(Rational r) => (float)r.Numerator / r.Denominator;
        public static explicit operator int(Rational r) => r.Numerator / r.Denominator;

        public static bool operator ==(Rational a, Rational b) => a.Equals(b);
        public static bool operator !=(Rational a, Rational b) => !a.Equals(b);

        public static bool operator <(Rational a, Rational b) => a.ToDecimal() < b.ToDecimal();
        public static bool operator >(Rational a, Rational b) => a.ToDecimal() > b.ToDecimal();
        public static bool operator <=(Rational a, Rational b) => a.ToDecimal() <= b.ToDecimal();
        public static bool operator >=(Rational a, Rational b) => a.ToDecimal() >= b.ToDecimal();

        public static Rational operator ++(Rational r) => r + new Rational(1, 1);
        public static Rational operator --(Rational r) => r - new Rational(1, 1);

        public override bool Equals(object obj) =>
            obj is Rational other && Numerator == other.Numerator && Denominator == other.Denominator;

        public override int GetHashCode() => HashCode.Combine(Numerator, Denominator);
    }
}
