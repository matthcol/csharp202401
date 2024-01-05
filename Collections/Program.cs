global using CityPop = (string City, uint Population);

using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;


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

    // Linq
    // https://learn.microsoft.com/en-us/dotnet/csharp/linq/

    var first100 = bigData.Take(100)
        .ToList();
    DisplayCollection(first100);

    var data20 = bigData.Take(100)
        .Select(x => 20*x)
        .ToList();
    DisplayCollection(data20);

    // check all values of data20 are in range [0-20[
    bool okRange = data20.All(x => (x >= 0.0) && (x < 20.0));
    Console.WriteLine($"All values are in range [0-20[ : {okRange}");

    // is there any value >= 19 ?
    bool okAnyGreater19 = data20.Any(x => x >= 19.0);
    Console.WriteLine($"Any values >= 19.0: {okAnyGreater19}");

    // how many values >= 19 ?
    int nbGreater19 = data20.Count(x => x >= 19.0);
    Console.WriteLine($"Values >= 19.0: count={nbGreater19}");

    int nbGreater19b = (from x in data20
                       where x >= 19
                       select x
                       ).Count();

    var topValues = bigData.Where(x => x >= 0.95)
        .OrderBy(x => x)
        .ToList();
    DisplayCollection(topValues);

    IEnumerable<char> letters = ['A', 'B', 'C', 'D', 'E', 'F', 'G', 'H'];
    var taggedData = bigData
        .Zip(letters)
        .Select( valueLetter => (valueLetter.First * 20.0, valueLetter.Second))
        .ToList();
    DisplayCollection(taggedData);

    var range = ..100; // not Linq'able'
    var sample = Enumerable.Range(0, 100)
        .Select(i => bigData[i * 1000])
        .ToList();
    DisplayCollection(sample);

    var indexedData = data20.Select((x, i) => (i, x))
        .ToHashSet();
    DisplayCollection(indexedData);
}

void PlayWithList3()
{
    IList<string> cities = new List<string>() {"Pau", "Paris", "Toulouse"};
    IList<string> cities2 = [ "Pau", "Paris", "Toulouse" ]; // C#12
    Console.WriteLine(cities.GetType());
    Console.WriteLine(cities2.GetType());
}

void PlayWithSortedSet()
{
    IList<string> cityList = ["Pau", "Paris", "Toulouse", "Marseille", "Lyon", "Orléans", "Clermont-Ferrand"];
    ISet<string> citySet = new SortedSet<string>(cityList);
    DisplayCollection(cityList);
    DisplayCollection(citySet);
    citySet.Add("Pau");
    citySet.Add("Bayonne");
    DisplayCollection(citySet);

    IComparer<string> comparer = new StringLengthComparer();
    ISet<string> citySet2 = new SortedSet<string>(citySet, comparer);
    DisplayCollection(citySet2);

    IComparer<string> comparerLengthDesc = Comparer<string>.Create(
        (s1, s2) => s2.Length - s1.Length
    );
    ISet<string> citySet3 = new SortedSet<string>(citySet, comparerLengthDesc);
    DisplayCollection(citySet3);

    IComparer<string> comparerLengthDesc2 = Comparer<string>.Create(
      (s1, s2) =>
      {
          var diff = s2.Length - s1.Length;
          if (diff == 0) diff = s1.CompareTo(s2);
          return diff;
      }
    );
    ISet<string> citySet4 = new SortedSet<string>(citySet, comparerLengthDesc2);
    DisplayCollection(citySet4);
}

void PlayWitDictionary()
{
    IDictionary<string, UInt32> cityPopulations = new Dictionary<string, UInt32>()
    {
        { "Pau", 77_000 },
        { "Toulouse", 470_000 },
        { "Paris", 2_161_000 }
    };
    cityPopulations.Add("Orléans", 114_000);
    // cityPopulations.Add("Orléans", 114_611); // System.ArgumentException 
    DisplayCollection(cityPopulations);
    cityPopulations["Orléans"] = 114_611;
    DisplayCollection(cityPopulations);
    cityPopulations["Marseille"] = 860_000;
    DisplayCollection(cityPopulations);
    Console.WriteLine(cityPopulations["Marseille"]);
    // Console.WriteLine(cityPopulations["Bordeaux"]); // KeyNotFoundException

    IList<string> cities = ["Marseille", "Bordeaux"];
    // try methods: TryGetValue, ContainsKey
    foreach (string city in cities)
    {
        UInt32 pop = 0;
        // method 1
        if (cityPopulations.TryGetValue(city, out pop))
        { 
            Console.WriteLine($"Population of city {city} is {pop}");
        } 
        else
        {
            Console.WriteLine($"Population of city {city} is unknown");
        }
        // method 2: non optimized
        if (cityPopulations.ContainsKey(city))
        {
            pop = cityPopulations[city];
            Console.WriteLine($"Population of city {city} is {pop}");
        }
        else
        {
            Console.WriteLine($"Population of city {city} is unknown");
        }
    }
    // iterate over Dictionaries
    Console.WriteLine();
    foreach (KeyValuePair<string, UInt32> cityPop in cityPopulations)
    {
        Console.WriteLine($"{cityPop} : {cityPop.Key} => {cityPop.Value}");
    }

    Console.WriteLine();
    // iterate using deconstructor of type KeyValuePair
    foreach ((var city, var pop) in cityPopulations)
    {
        Console.WriteLine($"{city} => {pop}");
    }

    Console.WriteLine();
    foreach (string city in cityPopulations.Keys)
    {
        Console.WriteLine(city);
    }

    Console.WriteLine();
    foreach (UInt32 pop in cityPopulations.Values)
    {
        Console.WriteLine(pop);
    }
}


(string,int) GenerateCity()
{
    return ("Toulouse", 477_000);
}

(string City, int Population) GenerateCityN()
{
    // return ("Toulouse", 477_000); // still OK
    return (City: "Toulouse", Population: 477_000);
}

void PlayWithTuples()
{
    // https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/value-tuples

    // tuple (struct):  (string,int) or ValueTuple<string,int>
    var cityPop = ("Pau", 77_000);
    Console.WriteLine(cityPop);
    Console.WriteLine(cityPop.Item1);
    Console.WriteLine(cityPop.Item2);

    // Tuple (class): Tuple<string,int>
    var cityPop2 = cityPop.ToTuple();
    Console.WriteLine(cityPop2);
    Console.WriteLine(cityPop2.Item1);
    Console.WriteLine(cityPop2.Item2);

    var cityPop3 = GenerateCity();
    Console.WriteLine(cityPop3);

    // deconstruct tuple
    var (city, pop) = GenerateCity();
    Console.WriteLine($"{city} has population {pop}");

    var cityPop4 = GenerateCityN();
    Console.WriteLine($"{cityPop4}: {cityPop4.City} {cityPop4.Population}");

    Console.WriteLine(cityPop4 == ("Toulouse",477_000));
    Console.WriteLine(cityPop4 == (City:"Toulouse", Population: 477_000));
}

//PlayWithLists();
Console.WriteLine();
PlayWithList2();
Console.WriteLine();
//PlayWithList3();


//PlayWithSortedSet();
//PlayWitDictionary();
//PlayWithTuples();