
using Moviemain.Model;

// a class type is a reference type
Movie movieNull = null;
Movie movieEmpty = new(); // new Movie()
Console.WriteLine(movieEmpty);
Movie movie = new()
{
    Id = 1,
    Title = "Oppenheimer",
};
Console.WriteLine(movie);
Movie movie2 = new("Barbie", 2023);
Movie movie3 = new(3, "Rebel Moon", 2023, 120);

Person person1 = new();
Person person2 = new(2, "Zack Snyder", new DateOnly(1966, 3, 1));
Person person3 = new()
{
    Name = "Sofia Boutella",
    BirthDate = new DateOnly(1982, 4, 3),
};

IEnumerable<Movie> movies = [movieEmpty, movie, movie2, movie3];
IEnumerable<Person> persons = [person1, person2, person3];

foreach (var m in movies)
{
    Console.WriteLine(m.ToString());
}


IEnumerable<Object> basket = [movie2, person3, "Toulouse"];
foreach (var o in basket)
{
    Console.WriteLine(String.Format("tostring={0} ; type={1} ; hash={2}",
        o.ToString(),
        o.GetType(),
        o.GetHashCode())
    );
}

ISet<Movie> movieSet = new HashSet<Movie>() { movie, movie2, movie3 };
Console.WriteLine(movieSet.Contains(movie)); 

var movieSearch = new Movie()
{
    Id = 1,
    Title = "Oppenheimer",
};
Console.WriteLine(movieSet.Contains(movieSearch));

Console.WriteLine(movieSet.Any(movie => movie.Id == 1));
Console.WriteLine(movieSet.Any(movie => (movie.Title == "Barbie") && (movie.Year == 2023)));

ISet<Movie> movieSortedSet = new SortedSet<Movie>(
    Comparer<Movie>.Create((m1, m2) => m1.Title.CompareTo(m2.Title))
) 
{ movie, movie2, movie3 };

foreach (var m in movieSortedSet)
{
    Console.WriteLine($"\t#{m}");
}

ISet<Movie> movieSortedSet2 = new SortedSet<Movie>(){ movie, movie2, movie3 };
foreach (var m in movieSortedSet2)
{
    Console.WriteLine($"\t~{m}");
}

var resSearch1 = movies.Where(m => m.Equals(movieSearch)).ToList();
var resSearch2 = movies.Where(m => m == movieSearch).ToList();
var resSearch3 = movies.Where(m => m == movie).ToList();

Console.WriteLine($"{resSearch1.Count} vs {resSearch2.Count} vs {resSearch3.Count}");

bool ok = movie < movie2;
Console.WriteLine(ok);