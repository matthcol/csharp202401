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
    }
}