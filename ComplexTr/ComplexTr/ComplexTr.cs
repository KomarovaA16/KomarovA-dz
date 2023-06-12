using System;

namespace ComplexTrr
{
    public struct ComplexTr
    {
        double abs;
        public double Abs
        {
            get => abs;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Значение должно быть неотрицательным");
                abs = value;
            }
        }
        public double Arg { get; set; }
        public double Re
        {
            get => Math.Round(Abs * Math.Cos(Arg),13);
        }
        public double Im
        {
            get => Math.Round(Abs * Math.Sin(Arg),13);
        }
        public ComplexTr(double abs, double arg) : this()
        {
            Abs = abs;
            Arg = arg;
        }
        public override string ToString()
        {
            if (Abs == 0)
                return "0";
            if (Abs == 1)
                return $"z = cos ({Arg}) + i * sin ({Arg})";
            else return $"z = {Abs} * (cos ({Arg}) + i * sin ({Arg}))";
        }
        public override bool Equals(object obj)
        {
            if (obj is ComplexTr)
                return ((Abs == ((ComplexTr)obj).Abs)&&((Re+Im) - (((ComplexTr)obj).Re + ((ComplexTr)obj).Im))/(2*Math.PI) == 0);
            throw new ArgumentException("Объект для сравнения не является комплексным число в тригоиметрической форме");
        }
        public override int GetHashCode() => (Abs * (Re + Im)).GetHashCode();
        public static bool operator ==(ComplexTr x, ComplexTr y) => x.Equals(y);
        public static bool operator !=(ComplexTr x, ComplexTr y) => !x.Equals(y);
        public static ComplexTr operator *(ComplexTr x, ComplexTr y) => new ComplexTr(x.Abs * y.Abs, x.Arg + y.Arg);
        public static ComplexTr operator /(ComplexTr x, ComplexTr y)
        {
            if (y.Abs == 0)
                throw new ArgumentException("Делить на ноль нельзя!");
            return new ComplexTr(x.Abs/y.Abs, x.Arg - y.Arg);
        }

    }
}