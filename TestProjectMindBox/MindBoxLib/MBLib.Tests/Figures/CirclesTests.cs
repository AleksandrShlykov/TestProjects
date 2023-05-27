using MBLib.Tests.Common;
using MindBoxLib;
using MindBoxLib.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBLib.Tests.Figures
{
    public class CirclesTests
    {
        [Fact]
        public void CircleIntTest()
        {
            //Arrange
            var circleInt = FiguresFactory.circleInt;
            var eps = FiguresFactory.eps;
            //Act
            var result = FiguresFactory.CalcPerform(circleInt);
            //Assert
            Assert.Equal(result, 201.061929, eps);
           
        }
        [Fact]
        public void CircleFloatTest()
        {
            //Arrange
            var circleFloat = FiguresFactory.circleFloat;
            var eps = FiguresFactory.eps;
            //Act
            var result = FiguresFactory.CalcPerform(circleFloat);
            //Assert
            Assert.Equal(476.3045,result, eps);
          
        }
        [Fact]
        public void CircleNegativeTest()
        {
            //Arrange
            //Act
            //Assert
            Assert.Throws<NotValidDataException>(()=> new Circle(-9));
        }
    }
}
