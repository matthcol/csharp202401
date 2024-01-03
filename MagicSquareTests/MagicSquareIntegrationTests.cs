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
                new object[] { SquareFixture.SQUARE_3_OK, 3, 15 },
                new object[] { SquareFixture.SQUARE_4_OK_ALBRECHT_DURER, 4, 34 },
                new object[] { SquareFixture.SQUARE_5_OK, 5, 65 },
                new object[] { SquareFixture.SQUARE_12_OK_WILLEM_BARINK, 12, 870 }
            };
        }

        [Theory]
        [MemberData(nameof(MagicSquaresOk))]
        public void IsMagicTest_OK(UInt32[,] square, UInt32 n, UInt32 magicSum)
        {
            var ok = MagicSquare.IsMagic(square);
            Assert.True(ok);
        }

        public static IEnumerable<Object[]> MagicSquareRowsKo()
        {
            return new List<Object[]>()
            {
                new object[] { SquareFixture.SQUARE_3_KO_ROWS, 3, 15 },
                new object[] { SquareFixture.SQUARE_3_KO_COLUMNS, 3, 15 },
                new object[] { SquareFixture.SQUARE_3_KO_2_DIAGS, 3, 15 },
                new object[] { SquareFixture.SQUARE_3_KO_DIAG1, 3, 15 },
                new object[] { SquareFixture.SQUARE_3_KO_DIAG2, 3, 15 },
                new object[] { SquareFixture.SQUARE_3_KO_OUT_OF_RANGE_UNDER, 3, 15 },
                new object[] { SquareFixture.SQUARE_3_KO_OUT_OF_RANGE_ABOVE, 3, 15 },
                new object[] { SquareFixture.SQUARE_3_KO_REPEATED_VALUE, 3, 15 },
            };
        }

        [Theory]
        [MemberData(nameof(MagicSquareRowsKo))]
        public void IsMagicTest_KO(UInt32[,] square, UInt32 n, UInt32 magicSum)
        {
            var ok = MagicSquare.IsMagic(square);
            Assert.False(ok);
        }
    }
}
