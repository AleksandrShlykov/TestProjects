using MindBoxLib;
using System;


namespace MBLib.Tests.Common
{
    public class FiguresFactory
    {
        public static double eps = 0.00001;
        public static Treangle treangleInt = new Treangle(2, 3, 4);
        public static Treangle treangleInt2 = new Treangle(3, 4, 5);
        public static Treangle treangleFloat = new Treangle(3.5, 3.5, 6.21);
        public static Treangle treangleIsRight = new Treangle(3.5, 3.5, 4.949747468);
        public static Circle circleInt = new Circle(8);
        public static Circle circleFloat = new Circle(12.3131);
        public static List<Figure> figures = new List<Figure>()
        {
            treangleInt, treangleInt2, treangleFloat,
            circleInt, circleFloat
        };
 
        public static double CalcPerform(Figure figure)
        {
            return CaclArea.GetArea(figure);
        }

    }
}
