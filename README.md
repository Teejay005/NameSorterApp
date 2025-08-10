# NameSorterApp

NameSorterApp is a .NET 8 console application that reads a list of names from a file, sorts them by last name (and then by given names), and writes the sorted list to an output file. The application demonstrates clean separation of concerns using services for parsing, reading, writing, and comparing names.

## Features

- Reads names from a text file (one name per line)
- Parses names into given names and last name
- Sorts names by last name, then by given names (case-insensitive)
- Writes the sorted names to an output file
- Robust error handling for file and input issues

## Project Structure

- `Models/Person.cs` - Represents a person with given names and last name
- `Comparer/PersonComparer.cs` - Sorts `Person` objects
- `Services/InputFileReader.cs` - Reads names from a file
- `Services/NameParser.cs` - Parses raw name strings into `Person` objects
- `Services/FileWriter.cs` - Writes sorted names to a file

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) installed

## How to Build

1. Open a terminal in the project root directory.
2. Build the project using the following command:
   ```bash
   dotnet build
   ```
3. Ensure there are no build errors.
4. Then navigate to the `NameSorterApp` directory:
   ```bash
   cd NameSorterApp
   ```
5. Then the release build can be created with:
   ```bash
   dotnet publish -c Release -o ./publish
   ```
6. The output will be in the `publish` directory.
7. Execute the application with:
   ```bash
   nam-sorter <input_file>
   ```