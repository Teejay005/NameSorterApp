using NameSorterApp.Models;
using NameSorterApp.Services.Abstractions;
using System.Text.RegularExpressions;

namespace NameSorterApp.Services
{
    // <inheritdoc />
    public class NameParser : INameParser
    {
        /// <summary>
        /// A regular expression pattern used to extract given names and the last name from a full name string.
        /// </summary>
        /// <remarks>The pattern assumes that the full name consists of one or more given names followed
        /// by a single last name, separated by whitespace. The last name is captured in the "lastname" group, and the
        /// given names are captured in the "givennames" group.</remarks>
        private readonly string REGEX_PATTERN = @"(?<givennames>.*)\s+(?<lastname>\S+)$";

        // <inheritdoc />
        public IEnumerable<Person> Parse(IEnumerable<string> names)
        {
            if (names == null || !names.Any())
            {
                throw new ArgumentNullException(nameof(names), "Input names cannot be null or empty.");
            }

            var persons = new List<Person>();
            foreach (var name in names)
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    continue; // Skip empty lines
                }
                var match = Regex.Match(name.Trim(), REGEX_PATTERN);
                if (match.Success)
                {
                    var person = new Person
                    {
                        GivenNames = match.Groups["givennames"].Value.Trim(),
                        LastName = match.Groups["lastname"].Value.Trim()
                    };
                    persons.Add(person);
                }
            }
            return persons;
        }
    }
}
