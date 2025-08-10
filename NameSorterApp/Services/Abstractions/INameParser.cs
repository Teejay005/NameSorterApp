using NameSorterApp.Models;

namespace NameSorterApp.Services.Abstractions
{
    /// <summary>
    /// Defines a contract for parsing a collection of names into a collection of <see cref="Person"/> objects.
    /// </summary>
    /// <remarks>Implementations of this interface are responsible for converting a collection of name strings
    /// into a collection of <see cref="Person"/> objects. The parsing logic may vary depending on the implementation,
    /// such as handling different name formats or applying specific validation rules.</remarks>
    public interface INameParser
    {
        /// <summary>
        /// Parses a collection of names and returns a collection of <see cref="Person"/> objects.
        /// </summary>
        /// <param name="names">A collection of strings representing names to be parsed.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a collection of  <see
        /// cref="Person"/> objects created from the provided names. If no names are provided, the result is an empty
        /// collection.</returns>
        Task<IEnumerable<Person>> Parse(IEnumerable<string> names);
    }
}
