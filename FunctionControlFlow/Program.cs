UInt64 Gcd(UInt64 a, UInt64 b)
{
    while (a != b)
    {
        if (a > b)
        {
            a -= b;
        }
        else
        {
            b -= a;
        }        
    }
    return a;
}


void NewYearCounter(UInt32 cpt)
{
    while (cpt > 0)
    {
        Console.WriteLine(cpt);
        --cpt; 
    }
    Console.WriteLine("Happy new year !");
}


NewYearCounter(10);
UInt64 a = 12;
UInt64 b = 27;
UInt64 g = Gcd(a, b);
Console.WriteLine($"Gcd({a}, {b}) = {g}");