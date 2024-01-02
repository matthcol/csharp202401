// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/built-in-types

// integers
Int32 nombre = 2_000_000_000;
Console.WriteLine(nombre);
Console.WriteLine(2 * nombre); // overflow

UInt32 cpt = 1;
Console.WriteLine(cpt);
cpt--;
Console.WriteLine(cpt);
cpt--;
Console.WriteLine(cpt); // underflow

// flottants (IEEE754): double/Double (0.1), float/Single (0.1f, 0.1F)  
Single price = 0.1f;
Console.WriteLine(String.Format("{0:F8}", price));
Console.WriteLine(String.Format("{0:F8}", 2 * price));
Console.WriteLine(String.Format("{0:F8}", 3 * price));

// virgule fixe: decimal
Decimal price2 = 0.1M;
Console.WriteLine(String.Format("{0:F8}", price2));
Console.WriteLine(String.Format("{0:F8}", 2 * price2));
Console.WriteLine(String.Format("{0:F8}", 3 * price2));

// texte: char 'A'  string "Ah ah"
// string/String is a class
String city = "Toulouse";
Console.WriteLine(city);
Console.WriteLine(city.ToLower());
Console.WriteLine(city[0]);
Console.WriteLine(city.Length);
// Console.WriteLine(city[8]); //  exception IndexOutOfRangeException 
// city[0] = 'J'; // non mutable

// String is IEnumerable<Char>
// foreach loop
foreach (Char c in city)
{
    Console.WriteLine(c);
}

// oldschool for i loop
for (int i = 0; i < city.Length; i++)
{
    Console.WriteLine(city[i]);
}

// operators
//https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/

// numeric: + - * / %
Int32 resI = 13 / 4; // division entiere
Double resD = 13.0 / 4;
Console.WriteLine(String.Format("{0} vs {1}", resI, resD));
Int32 resI2 = -resI;
++resI2;  // --
resI2++;
resI2 += 2; // -=, *=, ...

// comparaisons: == != < <= > >=
Console.WriteLine(resI2 > 0);
Console.WriteLine(city == "Toulouse");
Console.WriteLine(city.ToLower() == "toulouse");
Console.WriteLine(city.Equals("toulouse")); // IEquatable<String>
Console.WriteLine("Toulouse".CompareTo("Paris")); // IComparable<String>

// operator []: read or write
Double[] temperatures = { 12.4, 13.2, 14.7, 21.3, 25.7, 34.0 };
temperatures[0] = 22.4;
Console.WriteLine(temperatures[0]);
Console.WriteLine(temperatures[^1]); // i.e. [Length -1]

Console.WriteLine();
foreach (Double t in temperatures)
{
    Console.WriteLine(t);
}

// operator [] with Range
Console.WriteLine("First 3:");
foreach (Double t in temperatures[..3])
{
    Console.WriteLine(t);
}

Console.WriteLine("From #2 to #5:");
foreach (Double t in temperatures[2..5])
{
    Console.WriteLine(t);
}

Console.WriteLine("From #3:");
foreach (Double t in temperatures[3..])
{
    Console.WriteLine(t);
}

Console.WriteLine("Last 2:");
foreach (Double t in temperatures[^2..])
{
    Console.WriteLine(t);
}

// logical: AND (& &&) OR (| ||) XOR (^)
Double x = -12.4;
Boolean ok = (x > 0.0) && (Math.Sqrt(x) > 12.0);
Console.WriteLine(ok);


