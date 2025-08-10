using NameSorterApp.Services.Abstractions;

namespace NameSorterApp.Services
{
    /// <summary>
    /// Provides functionality to read the contents of a file line by line.
    /// </summary>
    /// <remarks>This class implements the <see cref="IFileReader"/> interface and reads files using the  <see
    /// cref="File.ReadLines(string)"/> method. It is designed to handle text files and  returns each line as a string
    /// in an enumerable collection.</remarks>
    public class InputFileReader : IFileReader
    {
        // <inheritdoc />
        public IEnumerable<string> ReadFile(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentException("File path cannot be null or empty.", nameof(filePath));
            }
            return File.ReadLines(filePath);
        }
    }
}
