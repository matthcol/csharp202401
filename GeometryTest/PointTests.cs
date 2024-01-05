namespace Geometry.Model
{
    public class PointTests
    {
        [Theory]
        [InlineData(1)]
        [InlineData(-300)]
        [InlineData(300)]
        public void DistanceTest(int exp)
        {
            double expectedDistance = 5.0 * Math.Pow(1, exp);
            Point p1 = new()
            {
                X = 1.5 * Math.Pow(1, exp),
                Y = 7.25 * Math.Pow(1, exp),
            };
            Point p2 = new()
            {
                X = 4.5 * Math.Pow(1, exp),
                Y = 3.25 * Math.Pow(1, exp),
            };
            double actualDistance = p1.Distance(p2);
            Assert.Equal(expectedDistance, actualDistance);
        }
    }
}