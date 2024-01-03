using MagicSquareTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic
{
    public class MagicSquareIntegrationTests
    {

        [Theory]
        [InlineData(1U)]
        [InlineData(3U)]
        [InlineData(5U)]
        public void GenerateTest(UInt32 n)
        {
            var square = MagicSquare.Generate(n);
            Assert.True(MagicSquare.IsMagic(square));
        }

        public static IEnumerable<Object[]> MagicSquaresOk()
        {
            return new List<Object[]>()
            {
                new object[] {SquareFixture.SQUARE_3_OK},
                new object[] {SquareFixture.SQUARE_4_OK_ALBRECHT_DURER},
                new object[] {SquareFixture.SQUARE_5_OK},
                new object[] {SquareFixture.SQUARE_12_OK_WILLEM_BARINK}
            };
        }

        [Theory]
        [MemberData(nameof(MagicSquaresOk))]
        public void IsMagicTest_OK(UInt32[,] square)
        {
            var ok = MagicSquare.IsMagic(square);
            Assert.True(ok);
        }

        public static IEnumerable<Object[]> MagicSquaresKo()
        {
            return new List<Object[]>()
            {
                new object[] { SquareFixture.SQUARE_3_KO_ROWS },
                new object[] { SquareFixture.SQUARE_3_KO_COLUMNS },
                new object[] { SquareFixture.SQUARE_3_KO_2_DIAGS },
                new object[] { SquareFixture.SQUARE_3_KO_DIAG1 },
                new object[] { SquareFixture.SQUARE_3_KO_DIAG2 },
                new object[] { SquareFixture.SQUARE_3_KO_OUT_OF_RANGE_UNDER },
                new object[] { SquareFixture.SQUARE_3_KO_OUT_OF_RANGE_ABOVE },
                new object[] { SquareFixture.SQUARE_3_KO_REPEATED_VALUE },
            };
        }

        [Theory]
        [MemberData(nameof(MagicSquaresKo))]
        public void IsMagicTest_KO(UInt32[,] square)
        {
            var ok = MagicSquare.IsMagic(square);
            Assert.False(ok);
        }
    }
}
