using NameSorterApp.Models;

namespace NameSorterApp.Services.Abstractions
{

    /// <summary>
    /// Interface for writing output to a destination.
    /// </summary>
    public interface IOutputWriter
    {
        /// <summary>
        /// Writes a collection of <see cref="Person"/> objects to an output destination.
        /// </summary>
        /// <param name="people"></param>
        void Write(IEnumerable<Person> people);
    }
}
