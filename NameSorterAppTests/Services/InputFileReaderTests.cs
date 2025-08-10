using NameSorterApp.Services;

namespace NameSorterApp.Tests.Services
{
        public class InputFileReaderTests
        {
            private readonly InputFileReader _reader = new InputFileReader();

            [Fact]
            public void ReadFile_ThrowsArgumentException_WhenFilePathIsNull()
            {
                // Arrange
                string filePath = null;

                // Act & Assert
                var ex = Assert.Throws<ArgumentException>(() => _reader.ReadFile(filePath));
                Assert.Equal("File path cannot be null or empty. (Parameter 'filePath')", ex.Message);
            }

            [Theory]
            [InlineData("")]
            [InlineData("   ")]
            public void ReadFile_ThrowsArgumentException_WhenFilePathIsEmptyOrWhitespace(string filePath)
            {
                // Act & Assert
                var ex = Assert.Throws<ArgumentException>(() => _reader.ReadFile(filePath));
                Assert.Equal("File path cannot be null or empty. (Parameter 'filePath')", ex.Message);
            }

            [Fact]
            public void ReadFile_ReturnsLines_WhenFileExists()
            {
                // Arrange
                var tempFile = Path.GetTempFileName();
                var lines = new[] { "First line", "Second line", "Third line" };
                File.WriteAllLines(tempFile, lines);

                try
                {
                    // Act
                    var result = _reader.ReadFile(tempFile);

                    // Assert
                    Assert.Equal(lines, result.ToArray());
                }
                finally
                {
                    File.Delete(tempFile);
                }
            }

            [Fact]
            public void ReadFile_ThrowsFileNotFoundException_WhenFileDoesNotExist()
            {
                // Arrange
                var nonExistentFile = Path.Combine(Path.GetTempPath(), Guid.NewGuid() + ".txt");

                // Act & Assert
                Assert.Throws<FileNotFoundException>(() => _reader.ReadFile(nonExistentFile).ToList());
            }
        }
}

