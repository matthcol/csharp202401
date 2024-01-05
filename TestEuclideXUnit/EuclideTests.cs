
public class EuclideTests
{
    [Fact]
    public void GcdTest_WhenSame()
    {
        UInt64 n = 12;
        UInt64 g = Euclide.Gcd(n, n);
        Assert.Equal(n, g); 
    }

    [Theory]
    [InlineData(1UL, 1UL)]
    [InlineData(1UL, 17UL)]
    [InlineData(17UL, 1UL)]
    [InlineData(3UL, 5UL)]
    public void GcdTest_WhenGcdIs1(UInt64 a, UInt64 b)
    {
        UInt64 g = Euclide.Gcd(a, b);
        Assert.Equal(1UL, g);
    }

    [Fact]
    public void GcdTest_WhenArgIs0()
    {
        UInt64 a = 12;
        UInt64 b = 0;
        Assert.Throws<ArgumentException>(() => Euclide.Gcd(a, b));
    }
}
