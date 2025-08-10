namespace NameSorterApp.Services.Abstractions
{
    /// <summary>
    /// Defines a contract for reading files and retrieving their contents as lines of text.
    /// </summary>
    /// <remarks>Implementations of this interface are responsible for reading the contents of a file and
    /// returning them as an enumerable collection of strings, where each string represents a single line in the file.
    /// The behavior of the implementation may vary depending on the file format or encoding, so callers should ensure
    /// the file is in a compatible format.</remarks>
    public interface IFileReader
    {
        /// <summary>
        /// Reads all lines from the specified file.
        /// </summary>
        /// <param name="filePath">The path to the file to read. Must not be null, empty, or consist only of whitespace.</param>
        /// <returns>An enumerable collection of strings, where each string represents a line in the file.</returns>
        /// <exception cref="ArgumentException">Thrown if <paramref name="filePath"/> is null, empty, or consists only of whitespace.</exception>

        IEnumerable<string> ReadFile(string filePath);
    }
}
