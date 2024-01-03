using MagicSquareTests;

namespace Magic
{
    public class MagicSquareTests
    {
        [Theory]
        [InlineData(1,1)]
        [InlineData(3, 15)]
        [InlineData(4, 34)]
        [InlineData(5, 65)]
        public void MagicSumTest(UInt32 n, UInt32 expectedMagicSum)
        {
            var actualMagicSum = MagicSquare.MagicSum(n);
            Assert.Equal(expectedMagicSum, actualMagicSum);
        }


        public static IEnumerable<Object[]> MagicSquareRows()
        {
            return new List<Object[]>()
            {
                new object[] { SquareFixture.SQUARE_3_OK },
                new object[] { SquareFixture.SQUARE_3_KO_COLUMNS },
                new object[] { SquareFixture.SQUARE_3_KO_2_DIAGS },
                new object[] { SquareFixture.SQUARE_4_OK_ALBRECHT_DURER },
                new object[] { SquareFixture.SQUARE_5_OK },
                new object[] { SquareFixture.SQUARE_12_OK_WILLEM_BARINK }
            };
        }

        [Theory]
        [MemberData(nameof(MagicSquareRows))]
        public void AreMagicRowsTest_OK(UInt32[,] square)
        {
            var ok = MagicSquare.AreMagicRows(square);
            Assert.True(ok);
        }

        //[Theory]
        //public void AreMagicRowsTest_KO(UInt32[,] square)
        //{
        //    var ok = MagicSquare.AreMagicRows(square);
        //    Assert.False(ok);
        //}
    }
}