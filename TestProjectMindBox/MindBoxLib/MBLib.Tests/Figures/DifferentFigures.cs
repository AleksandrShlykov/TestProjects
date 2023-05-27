using MBLib.Tests.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBLib.Tests.Figures
{

    public class DifferentFigures
    {
        [Fact]
        public void DifferentFiguresInListTest()
        {
            //Arrange
            var figures = FiguresFactory.figures;
            var eps = FiguresFactory.eps;
            var result = new List<double>();
            var verifiedResult = new List<double>()
            {
               2.9047375, 6, 5.01529592, 201.061929, 476.3045
            };
            //Act
            foreach (var fig in figures)
            {
                result.Add(FiguresFactory.CalcPerform(fig));
            }

            //Assert
            for(int i =0; i<verifiedResult.Count; i++)
            {
                Assert.Equal(verifiedResult[i], result[i], eps);
            }
        }
    }
}
