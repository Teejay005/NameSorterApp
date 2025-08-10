
using NameSorterApp.Comparer;
using NameSorterApp.Models;
using NameSorterApp.Services;
using NameSorterApp.Services.Abstractions;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Name Sorter Application");
        if (args.Length == 0)
        {
            Console.WriteLine("Please provide the file path as a command line argument.");
            return;
        }
        var filePath = args[0];

        if (string.IsNullOrEmpty(filePath))
        {
            Console.WriteLine("File path cannot be null or empty.");
            return;
        }

        try
        {
            IFileReader fileReader = new InputFileReader();
            IOutputWriter fileWriter = new OutputFileWriter();
            IOutputWriter consoleWriter = new OutputScreenWriter();
            IEnumerable<string> names = fileReader.ReadFile(filePath.Trim());
            INameParser nameParser = new NameParser();
            IEnumerable<Person> persons = nameParser.Parse(names);

            if (!persons.Any())
            {
                Console.WriteLine("No valid names found in the file.");
                return;
            }

            var sortedPersons = persons.OrderBy(p => p, new PersonComparer()).ToList();

            Console.WriteLine("Sorted Names:");
            fileWriter.Write(sortedPersons);
            consoleWriter.Write(sortedPersons);

            Console.WriteLine("Names have been sorted and written to 'sorted-names-list.txt'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}