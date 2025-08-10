using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameSorterApp.Models
{
    public class Person
    {
        /// <summary>
        /// Gets or sets the given names of the individual.
        /// </summary>
        public string? GivenNames { get; set; }

        /// <summary>
        /// Gets or sets the last name of the individual.
        /// </summary>
        public string? LastName { get; set; }

        /// <summary>
        /// Returns a string representation of the full name, consisting of the given names and last name.
        /// </summary>
        public override string ToString()
        {
            return $"{GivenNames} {LastName}";
        }
    }
}
