
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
UInt64 g = Euclide.Gcd(a, b);
Console.WriteLine($"Gcd({a}, {b}) = {g}");
Console.WriteLine(Weather.Kind(12));
Console.WriteLine(Weather.Kind2(19));
Console.WriteLine(Weather.Kind3(20));
Console.WriteLine(Weather.Kind4(35));