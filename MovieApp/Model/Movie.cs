using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Moviemain.Model
{
    public class Movie: IComparable<Movie>, IEquatable<Movie>, IComparisonOperators<Movie,Movie,bool>
    {
        public Movie(): this(null,"?", 0, null)
        {
            
        }
        public Movie(string title, int year): this(null, title, year, null)
        {

        }

        public Movie(int? id, string title, int year, int? duration)
        {
            Id = id;
            Title = title;
            Year = year;
            Duration = duration;
        }




        // property with auto: private attribute + getter, setter methods
        public int? Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public int? Duration { get; set; }

        public int CompareTo(Movie? other)
        {
            if (other == null) return 1;
            // Movie other2 = other as Movie;
            return (Year, Title).CompareTo((other.Year, other.Title));
        }

        // implements IEquatable<Movie>.equals
        public bool Equals(Movie? other)
        {
            if (other == null) return false;
            return (Year, Title).Equals((other.Year, other.Title));
        }

        // override Object.equals
        public override bool Equals(Object? other)
        {
            if (!(other is Movie)) return false;
            return Equals((Movie)other);
        }

        // override Object.GetHashCode
        public override int GetHashCode()
        {
            return (Title,Year).GetHashCode();
        }


        // Override Object method
        //public override string ToString() => $"{Title} ({Year})#{Id??0}";         
        public override string ToString() => $"{Title} ({Year})#{(Id==null ? "?" : Id.ToString())}";

        public static bool operator ==(Movie left, Movie right)
        {
            if (ReferenceEquals(left, null))
            {
                return ReferenceEquals(right, null);
            }

            return left.Equals(right);
        }

        public static bool operator !=(Movie left, Movie right)
        {
            return !(left == right);
        }

        public static bool operator <(Movie left, Movie right)
        {
            return ReferenceEquals(left, null) ? !ReferenceEquals(right, null) : left.CompareTo(right) < 0;
        }

        public static bool operator <=(Movie left, Movie right)
        {
            return ReferenceEquals(left, null) || left.CompareTo(right) <= 0;
        }

        public static bool operator >(Movie left, Movie right)
        {
            return !ReferenceEquals(left, null) && left.CompareTo(right) > 0;
        }

        public static bool operator >=(Movie left, Movie right)
        {
            return ReferenceEquals(left, null) ? ReferenceEquals(right, null) : left.CompareTo(right) >= 0;
        }
    }
}
