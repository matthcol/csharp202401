using MagicSquareTests;

namespace Magic
{
    public class MagicSquareUnitTests
    {
        [Theory]
        [InlineData(1,1)]
        [InlineData(3, 15)]
        [InlineData(4, 34)]
        [InlineData(5, 65)]
        [InlineData(12, 870)]
        public void MagicSumTest(UInt32 n, UInt32 expectedMagicSum)
        {
            var actualMagicSum = MagicSquare.MagicSum(n);
            Assert.Equal(expectedMagicSum, actualMagicSum);
        }

        // rows

        public static IEnumerable<Object[]> MagicSquareRowsOk()
        {
            return new List<Object[]>()
            {
                new object[] { SquareFixture.SQUARE_3_OK, 3, 15 },
                new object[] { SquareFixture.SQUARE_3_KO_COLUMNS, 3, 15 },
                new object[] { SquareFixture.SQUARE_3_KO_2_DIAGS, 3, 15 },
                new object[] { SquareFixture.SQUARE_4_OK_ALBRECHT_DURER, 4, 34 },
                new object[] { SquareFixture.SQUARE_5_OK, 5, 65 },
                new object[] { SquareFixture.SQUARE_12_OK_WILLEM_BARINK, 12, 870 }
            };
        }

        [Theory]
        [MemberData(nameof(MagicSquareRowsOk))]
        public void AreMagicRowsTest_OK(UInt32[,] square, UInt32 n, UInt32 magicSum)
        {
            var ok = MagicSquare.AreMagicRows(square, n, magicSum);
            Assert.True(ok);
        }

        public static IEnumerable<Object[]> MagicSquareRowsKo()
        {
            return new List<Object[]>()
            {
                new object[] { SquareFixture.SQUARE_3_KO_ROWS, 3, 15 }

            };
        }

        [Theory]
        [MemberData(nameof(MagicSquareRowsKo))]
        public void AreMagicRowsTest_KO(UInt32[,] square, UInt32 n, UInt32 magicSum)
        {
            var ok = MagicSquare.AreMagicRows(square, n, magicSum);
            Assert.False(ok);
        }

        // columns

        public static IEnumerable<Object[]> MagicSquareColumnsOk()
        {
            return new List<Object[]>()
            {
                new object[] { SquareFixture.SQUARE_3_OK, 3, 15 },
                new object[] { SquareFixture.SQUARE_3_KO_ROWS, 3, 15 },
                new object[] { SquareFixture.SQUARE_3_KO_2_DIAGS, 3, 15 },
                new object[] { SquareFixture.SQUARE_4_OK_ALBRECHT_DURER, 4, 34 },
                new object[] { SquareFixture.SQUARE_5_OK, 5, 65 },
                new object[] { SquareFixture.SQUARE_12_OK_WILLEM_BARINK, 12, 870 }
            };
        }

        [Theory]
        [MemberData(nameof(MagicSquareColumnsOk))]
        public void AreMagicColumnsTest_OK(UInt32[,] square, UInt32 n, UInt32 magicSum)
        {
            var ok = MagicSquare.AreMagicColumns(square, n, magicSum);
            Assert.True(ok);
        }

        public static IEnumerable<Object[]> MagicSquareColumnsKo()
        {
            return new List<Object[]>()
            {
                new object[] { SquareFixture.SQUARE_3_KO_COLUMNS, 3, 15 }
            };
        }

        [Theory]
        [MemberData(nameof(MagicSquareColumnsKo))]
        public void AreMagicColumnsTest_KO(UInt32[,] square, UInt32 n, UInt32 magicSum)
        {
            var ok = MagicSquare.AreMagicColumns(square, n, magicSum);
            Assert.False(ok);
        }

        // diagonals

        public static IEnumerable<Object[]> MagicSquareDiagonalsOk()
        {
            return new List<Object[]>()
            {
                new object[] { SquareFixture.SQUARE_3_OK, 3, 15 },
                new object[] { SquareFixture.SQUARE_3_KO_ROWS, 3, 15 },
                new object[] { SquareFixture.SQUARE_3_KO_COLUMNS, 3, 15 },
                new object[] { SquareFixture.SQUARE_4_OK_ALBRECHT_DURER, 4, 34 },
                new object[] { SquareFixture.SQUARE_5_OK, 5, 65 },
                new object[] { SquareFixture.SQUARE_12_OK_WILLEM_BARINK, 12, 870 }
            };
        }

        [Theory]
        [MemberData(nameof(MagicSquareDiagonalsOk))]
        public void AreMagicDiagonalsTest_OK(UInt32[,] square, UInt32 n, UInt32 magicSum)
        {
            var ok = MagicSquare.AreMagicDiagonals(square, n, magicSum);
            Assert.True(ok);
        }

        public static IEnumerable<Object[]> MagicSquareDiagonalsKo()
        {
            return new List<Object[]>()
            {
                new object[] { SquareFixture.SQUARE_3_KO_2_DIAGS, 3, 15 },
                new object[] { SquareFixture.SQUARE_3_KO_DIAG1, 3, 15 },
                new object[] { SquareFixture.SQUARE_3_KO_DIAG2, 3, 15 },
            };
        }

        [Theory]
        [MemberData(nameof(MagicSquareDiagonalsKo))]
        public void AreMagicDiagonalsTest_KO(UInt32[,] square, UInt32 n, UInt32 magicSum)
        {
            var ok = MagicSquare.AreMagicDiagonals(square, n, magicSum);
            Assert.False(ok);
        }
    }
}