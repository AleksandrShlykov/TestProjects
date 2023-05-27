using MBLib.Tests.Common;
using MindBoxLib;
using MindBoxLib.Exceptions;

namespace MBLib.Tests.Figures
{
    public class TreanglesTests
    {
        [Fact]
        public void IntTreangleCorrectTest()
        {
            //Arrange
            var treangleInt1 = FiguresFactory.treangleInt;
            var treangleInt2 = FiguresFactory.treangleInt2;
            var eps = FiguresFactory.eps;
            //Act
            var result1 = FiguresFactory.CalcPerform(treangleInt1);
            var result2 = FiguresFactory.CalcPerform(treangleInt2);

            //Assert
           
            Assert.True(Math.Abs(result1 - 2.9047375) <= eps && Math.Abs(result2 - 6) <= eps);
        }
        [Fact]
        public void FloatTreangleCorrectTest()
        {
            //Arrange
            var treangleFloat = FiguresFactory.treangleFloat;
            var eps = FiguresFactory.eps;
            //Act
            var result = FiguresFactory.CalcPerform(treangleFloat);
            //Assert
            Assert.True(Math.Abs(result - 5.01529592) <= eps);
        }
        [Fact]
        public void IntTreangleIncorrectTest()
        {
            //Arrange
            //Act
            //Assert
            Assert.Throws<NotValidDataException>(() => new Treangle(-2, 3, 4));
            Assert.Throws<NotValidDataException>(() => new Treangle(2, -3, 4));
            Assert.Throws<NotValidDataException>(() => new Treangle(2, 3, -4));
            Assert.Throws<NotValidDataException>(() => new Treangle(-3, -4, -5));
        }

        [Fact]
        public void TreangleIsRightTest()
        {
            //Arrange
            var treangleFloat = FiguresFactory.treangleIsRight;

            //Act
            var result = treangleFloat.IsRight();

            //Assert
            Assert.True(result);
        }
    }
}

      