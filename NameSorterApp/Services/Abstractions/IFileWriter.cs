using NameSorterApp.Models;

namespace NameSorterApp.Services.Abstractions
{
    public interface IFileWriter
    {
        void Write(IEnumerable<Person> text, string filename);
    }
}
