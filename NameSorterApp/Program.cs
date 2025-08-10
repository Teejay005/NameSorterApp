
using NameSorterApp.Comparer;
using NameSorterApp.Models;
using NameSorterApp.Services;
using NameSorterApp.Services.Abstractions;

public class Program
{
    public static async Task Main(string[] args)
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
            IFileWriter fileWriter = new FileWriter();
            IEnumerable<string> names = fileReader.ReadFile(filePath.Trim());
            INameParser nameParser = new NameParser();
            IEnumerable<Person> persons = await nameParser.Parse(names);

            if (!persons.Any())
            {
                Console.WriteLine("No valid names found in the file.");
                return;
            }

            var sortedPersons = persons.OrderBy(p => p, new PersonComparer()).ToList();

            Console.WriteLine("Sorted Names:");
            foreach (var person in sortedPersons)
            {
                Console.WriteLine($"{person.ToString()}");
            }

            fileWriter.Write(sortedPersons, "sorted-names-list.txt");

        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}