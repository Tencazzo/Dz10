using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timakov12.Classes
{
    public class ComplexNumber
    {
        public double Real { get; private set; }
        public double Imaginary { get; private set; }

        public ComplexNumber(double real, double imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }

        public static ComplexNumber operator +(ComplexNumber a, ComplexNumber b) =>
            new ComplexNumber(a.Real + b.Real, a.Imaginary + b.Imaginary);

        public static ComplexNumber operator -(ComplexNumber a, ComplexNumber b) =>
            new ComplexNumber(a.Real - b.Real, a.Imaginary - b.Imaginary);

        public static ComplexNumber operator *(ComplexNumber a, ComplexNumber b)
        {
            double realPart = a.Real * b.Real - a.Imaginary * b.Imaginary;
            double imaginaryPart = a.Real * b.Imaginary + a.Imaginary * b.Real;
            return new ComplexNumber(realPart, imaginaryPart);
        }

        public static bool operator ==(ComplexNumber a, ComplexNumber b) =>
            a.Real == b.Real && a.Imaginary == b.Imaginary;

        public static bool operator !=(ComplexNumber a, ComplexNumber b) => !(a == b);

        public override string ToString() =>
            Imaginary >= 0 ? $"{Real} + {Imaginary}i" : $"{Real} - {Math.Abs(Imaginary)}i";

        public override bool Equals(object obj) =>
            obj is ComplexNumber other && this == other;

        public override int GetHashCode() =>
            HashCode.Combine(Real, Imaginary);
    }
}
