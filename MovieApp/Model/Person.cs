using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moviemain.Model
{
    public class Person(int? id, string name, DateOnly? birthdate)
    {
        public Person(): this(null, "John Doe", null)
        {
            
        }

        public int? Id { get; set; } = id;
        public string Name { get; set; } = name;
        public DateOnly? BirthDate { get; set; } = birthdate;

        public override string ToString() => $"{Name} ({BirthDate})";
        
    }
}
