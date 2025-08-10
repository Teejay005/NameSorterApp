using NameSorterApp.Services;

namespace NameSorterApp.Tests.Services
{
    public class NameParserTests
    {
        private readonly NameParser _parser = new NameParser();

        [Fact]
        public async Task Parse_ThrowsArgumentNullException_WhenInputIsNull()
        {
            // Act & Assert
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => _parser.Parse(null));
            Assert.Equal("Input names cannot be null or empty. (Parameter 'names')", ex.Message);
        }

        [Fact]
        public async Task Parse_ThrowsArgumentNullException_WhenInputIsEmpty()
        {
            // Act & Assert
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => _parser.Parse(Array.Empty<string>()));
            Assert.Equal("Input names cannot be null or empty. (Parameter 'names')", ex.Message);
        }

        [Fact]
        public async Task Parse_SkipsEmptyOrWhitespaceLines()
        {
            // Arrange
            var input = new[] { "John Smith", "   ", "", "Jane Doe" };

            // Act
            var result = (await _parser.Parse(input)).ToList();

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Contains(result, p => p.GivenNames == "John" && p.LastName == "Smith");
            Assert.Contains(result, p => p.GivenNames == "Jane" && p.LastName == "Doe");
        }

        [Fact]
        public async Task Parse_ParsesGivenNamesAndLastName_Correctly()
        {
            // Arrange
            var input = new[] { "Mary Jane Watson" };

            // Act
            var result = (await _parser.Parse(input)).ToList();

            // Assert
            Assert.Single(result);
            Assert.Equal("Mary Jane", result[0].GivenNames);
            Assert.Equal("Watson", result[0].LastName);
        }

        [Fact]
        public async Task Parse_IgnoresLinesThatDoNotMatchPattern()
        {
            // Arrange
            var input = new[] { "SingleName", "John Smith" };

            // Act
            var result = (await _parser.Parse(input)).ToList();

            // Assert
            Assert.Single(result);
            Assert.Equal("John", result[0].GivenNames);
            Assert.Equal("Smith", result[0].LastName);
        }

        [Fact]
        public async Task Parse_TrimsWhitespaceFromNames()
        {
            // Arrange
            var input = new[] { "   Anna Maria   Lopez   " };

            // Act
            var result = (await _parser.Parse(input)).ToList();

            // Assert
            Assert.Single(result);
            Assert.Equal("Anna Maria", result[0].GivenNames);
            Assert.Equal("Lopez", result[0].LastName);
        }
    }
}