using MindBoxLib.Exceptions;

namespace MindBoxLib
{
    abstract public class Figure
    {
        double Area { get; }

        abstract public double CalcArea();
    }
    public class Circle : Figure
    {
        private readonly double _radius;
        public Circle(double radius)
        {
            if(radius<0)
            {
                throw new NotValidDataException();
            }
            _radius = radius;
        }
        public override double CalcArea()
        {
            return Math.PI * (_radius * _radius);
        }
    }
    public class Treangle : Figure
    {
        private readonly double _sideLong;
        private readonly double _sideShort1;
        private readonly double _sideShort2;
        private readonly bool _isRight;
        private const double eps = 0.00001;
    

        public Treangle(double sideA, double sideB, double sideC)
        {
            _isRight = false;
            if (sideA > 0 && sideB > 0 && sideC > 0)
                (_sideLong, _sideShort1, _sideShort2) = (sideA, sideB, sideC);
            else
                throw new NotValidDataException();
            var sqrA = sideA * sideA;
            var sqrB = sideB * sideB;
            var sqrC = sideC * sideC;
            if (Math.Abs(sqrA - (sqrB + sqrC)) <= eps)
            {
                _isRight = true;
                _sideLong = sideA;
                _sideShort1 = sideB;
                _sideShort2 = sideC;
            }
            if (Math.Abs(sqrB - (sqrA + sqrC)) <= eps)
            {
                _isRight = true;
                _sideLong = sideB;
                _sideShort1 = sideA;
                _sideShort2 = sideC;
            }
            if (Math.Abs(sqrC - (sqrA + sqrB)) <= eps)
            {
                _sideLong = sideC;
                _sideShort1 = sideA;
                _sideShort2 = sideB;
                _isRight = true;
            }


        }
        public bool IsRight()
        {
            return _isRight;
        }

        public override double CalcArea()
        {
            if (_isRight)
            {
                return _sideShort1 * _sideShort2 / 2;
            }
            var halfP = (_sideLong + _sideShort1 + _sideShort2) / 2;
            return Math.Sqrt(halfP * (halfP - _sideLong) * (halfP - _sideShort1) * (halfP - _sideShort2));
        }
    }
    public static class CaclArea
    {
        public static double GetArea(Figure figure)
        {
            return figure.CalcArea();
        }
    }
}