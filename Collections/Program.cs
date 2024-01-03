
using System.Collections.Generic;

void DisplayList(IList<string> list)
{
    Console.Write(list.Count);
    Console.Write("#[ ");
    foreach (var item in list)
    {
        Console.Write(item + " ");
    }
    Console.WriteLine(']');
}

void DisplayCollection<T>(ICollection<T> collection, Int32 maxDisplay = 10)
{
    Console.Write(collection.Count);
    Console.Write("#[ ");
    if (collection.Count <= maxDisplay) 
    {
        foreach (var item in collection)
        {
            Console.Write(item + " ");
        }
    }
    else
    {
        var it = collection.GetEnumerator();
        Int32 spanSize = maxDisplay / 2;
        Int32 skipSize = collection.Count - 2 * spanSize;
        for (Int32 i = 0; i < spanSize; i++)
        {
            it.MoveNext();
            Console.Write($"{it.Current} ");
        }
        Console.Write("... ");
        for (Int32 i = 0; i < skipSize; i++) it.MoveNext();
        for (Int32 i = 0; i < spanSize; i++)
        {
            it.MoveNext();
            Console.Write($"{it.Current} ");
        }
    }
    Console.WriteLine(']');
}


void PlayWithLists()
{
    // NB: string C# type vs String .NET type
    IList<string> cities = new List<string>();
    Console.WriteLine(cities.Count);
    cities.Add("Toulouse");
    cities.Add("Paris");
    cities.Add("Pau");
    Console.WriteLine(cities.Count);

    // a list is IEnumerable
    foreach (string city in cities)
    {
        Console.WriteLine(city);
    }
    DisplayList(cities);
    DisplayCollection(cities);

    // Random Acces
    Console.WriteLine(cities[1]);

    // Contains (ICollection)
    Console.WriteLine(cities.Contains("Toulouse"));
    Console.WriteLine(cities.Contains("Lyon"));

    Int32 index = cities.IndexOf("Toulouse");
    Console.WriteLine(index);
    index = cities.IndexOf("Lyon");
    Console.WriteLine(index);

}

void PlayWithList2()
{
    Double[] temperatureArray = {12.2, 23.4, -5.1, 23.8, 32.1};

    // constructor from IEnumerable
    IList<Double> temperatureList = new List<Double>(temperatureArray);
    DisplayCollection(temperatureList);

    Int32 capacity = 125_000_000;
    IList<Double> bigData = new List<Double>(capacity);
    Console.WriteLine($"Size big data: {bigData.Count}");
    // fill bigData with random numbers
    var rand = new Random();
    for (Int32 i=0; i<capacity; i++)
    {
        bigData.Add(rand.NextDouble());
    }
    Console.WriteLine($"Size big data: {bigData.Count}");
    DisplayCollection(bigData);
    DisplayCollection(bigData, 6);
    Console.WriteLine(bigData[0]);
    Console.WriteLine(bigData[^1]);
}


PlayWithLists();
Console.WriteLine();
PlayWithList2();
