using NameSorterApp.Comparer;
using NameSorterApp.Models;

namespace NameSorterApp.Tests.Comparer
{
    public class PersonComparerTests
    {
        private readonly PersonComparer _comparer = new PersonComparer();

        [Fact]
        public void Compare_BothNull_ReturnsZero()
        {
            // Act
            int result = _comparer.Compare(null, null);

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void Compare_XIsNull_ReturnsMinusOne()
        {
            // Arrange
            var y = new Person { GivenNames = "John", LastName = "Smith" };

            // Act
            int result = _comparer.Compare(null, y);

            // Assert
            Assert.Equal(-1, result);
        }

        [Fact]
        public void Compare_YIsNull_ReturnsOne()
        {
            // Arrange
            var x = new Person { GivenNames = "John", LastName = "Smith" };

            // Act
            int result = _comparer.Compare(x, null);

            // Assert
            Assert.Equal(1, result);
        }

        [Fact]
        public void Compare_DifferentLastNames_ReturnsCorrectOrder()
        {
            // Arrange
            var x = new Person { GivenNames = "John", LastName = "Anderson" };
            var y = new Person { GivenNames = "Jane", LastName = "Brown" };

            // Act
            int result = _comparer.Compare(x, y);

            // Assert
            Assert.True(result < 0); // Anderson < Brown
        }

        [Fact]
        public void Compare_SameLastName_DifferentGivenNames_ReturnsCorrectOrder()
        {
            // Arrange
            var x = new Person { GivenNames = "Alice", LastName = "Smith" };
            var y = new Person { GivenNames = "Bob", LastName = "Smith" };

            // Act
            int result = _comparer.Compare(x, y);

            // Assert
            Assert.True(result < 0); // Alice < Bob
        }

        [Fact]
        public void Compare_SameLastName_SameGivenNames_ReturnsZero()
        {
            // Arrange
            var x = new Person { GivenNames = "Alice", LastName = "Smith" };
            var y = new Person { GivenNames = "Alice", LastName = "Smith" };

            // Act
            int result = _comparer.Compare(x, y);

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void Compare_CaseInsensitiveComparison()
        {
            // Arrange
            var x = new Person { GivenNames = "alice", LastName = "smith" };
            var y = new Person { GivenNames = "ALICE", LastName = "SMITH" };

            // Act
            int result = _comparer.Compare(x, y);

            // Assert
            Assert.Equal(0, result);
        }
    }
}