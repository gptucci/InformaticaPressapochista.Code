using BizMathLib;
using System;
using Xunit;

namespace TestBizMathLab
{
    public class UnitTestBizMath
    {
        [Fact]
        public void ScorporaIva_DeveTornareIva()
        {
            // Arrange
            BizMath objBizMath = new BizMath();

            // Act
            decimal Importo = objBizMath.ScorporaIva(100, 21);

            //Assert
            Assert.Equal(17.36m, Importo);
            


        }

        [Fact]
        public void ApplicaIva_IvaApplicataA100()
        {
            // Arrange
            BizMath objBizMath = new BizMath();

            // Act
            decimal Importo = objBizMath.ApplicaIva(100, 21);

            //Assert
            Assert.Equal(121m, Importo);

            // Act
            Importo = objBizMath.ApplicaIva(100.10m, 21);

            //Assert
            Assert.Equal(121.121m, Importo);


        }

    }
}
