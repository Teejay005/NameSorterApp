using NameSorterApp.Models;
using NameSorterApp.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameSorterApp.Services
{
    /// <summary>
    /// Writes a collection of <see cref="Person"/> objects to the console output.
    /// </summary>
    public class OutputScreenWriter : IOutputWriter
    {
        /// <summary>
        /// Method to write a collection of <see cref="Person"/> objects to the console.
        /// </summary>
        /// <param name="people"></param>
        public void Write(IEnumerable<Person> people)
        {
            foreach (var person in people)
            {
                Console.WriteLine($"{person}");
            }
        }
    }
}
