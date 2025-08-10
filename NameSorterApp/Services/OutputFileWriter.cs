using NameSorterApp.Models;
using NameSorterApp.Services.Abstractions;

namespace NameSorterApp.Services
{
    /// <summary>
    /// Writes a collection of <see cref="Person"/> objects to a file named "sorted-names-list.txt".
    /// </summary>
    public class OutputFileWriter : IOutputWriter
    {

        private readonly string FILENAME = "sorted-names-list.txt";

        /// <summary>
        /// Method to write a collection of <see cref="Person"/> objects to a file.
        /// </summary>
        /// <param name="people"></param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="IOException"></exception>
        public void Write(IEnumerable<Person> people)
        {
            if (!people.Any())
            {
                throw new ArgumentException("List cannot be null or empty.");
            }
            // get base directory of the application
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var filePath = Path.Combine(baseDirectory, FILENAME);
            // Ensure the path exists
            if (!File.Exists(filePath))
            {
                File.Create(filePath);
            }

            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine("Sorted Names List:");
                    writer.WriteLine("-------------------");
                    foreach (var person in people)
                    {
                        writer.WriteLine($"{person}");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new IOException($"Failed to write to file '{filePath}'.", ex);
            }
        }
    }
}
