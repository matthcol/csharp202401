public class EuclideTests
{

    [Test]
    public void GcdTest_WhenSame()
    {
        UInt64 n = 12;
        UInt64 g = Euclide.Gcd(n, n);
        Assert.That(g, Is.EqualTo(n));
    }

    [TestCase(1UL, 1UL)]
    [TestCase(1UL, 17UL)]
    [TestCase(17UL, 1UL)]
    [TestCase(3UL, 5UL)]
    public void GcdTest_WhenGcdIs1(UInt64 a, UInt64 b)
    {
        UInt64 g = Euclide.Gcd(a, b);
        Assert.That(g, Is.EqualTo(1));
    }

    [Test]
    public void GcdTest_WhenFirstGreater()
    {
        UInt64 a = 60;
        UInt64 b = 36;
        UInt64 g = Euclide.Gcd(a, b);
        Assert.That(g, Is.EqualTo(12));
    }

    [Test]
    public void GcdTest_WhenSecondGreater()
    {
        UInt64 a = 36;
        UInt64 b = 60;
        UInt64 g = Euclide.Gcd(a, b);
        Assert.That(g, Is.EqualTo(12));
    }

    [Test]
    public void GcdTest_WhenArgIs0()
    {
        UInt64 a = 12;
        UInt64 b = 0;
        Assert.Throws<ArgumentException>(() => Euclide.Gcd(a, b));  
    }

}
