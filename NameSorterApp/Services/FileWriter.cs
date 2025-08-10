using NameSorterApp.Models;
using NameSorterApp.Services.Abstractions;

namespace NameSorterApp.Services
{
    public class FileWriter : IFileWriter
    {
        public void Write(IEnumerable<Person> people, string filename)
        {
            if (!people.Any())
            {
                throw new ArgumentException("List cannot be null or empty.");
            }
            if (string.IsNullOrWhiteSpace(filename))
            {
                throw new ArgumentException("Filename cannot be null or empty.", nameof(filename));
            }

            // Ensure the path exists
            if (!File.Exists(filename))
            {
                File.Create(filename);
            }

            try
            {
                foreach (var person in people)
                {
                    var file = new FileInfo(filename);
                    file.AppendText().WriteLine(person.ToString());
                }
            }
            catch (Exception ex)
            {
                throw new IOException($"Failed to write to file '{filename}'.", ex);
            }
        }
    }
}
