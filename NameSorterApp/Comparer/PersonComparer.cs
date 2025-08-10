using NameSorterApp.Models;

namespace NameSorterApp.Comparer
{
    /// <summary>
    /// Provides a comparison mechanism for <see cref="Person"/> objects, sorting them by last name and then by given
    /// names.
    /// </summary>
    /// <remarks>This comparer performs a case-insensitive comparison of the <see cref="Person.LastName"/>
    /// property first.  If the last names are equal, it then compares the <see cref="Person.GivenNames"/> property,
    /// also in a case-insensitive manner. Null values are handled such that a null <see cref="Person"/> is considered
    /// less than a non-null <see cref="Person"/>.</remarks>
    public class PersonComparer : IComparer<Person>
    {
        /// <summary>
        /// Compares two <see cref="Person"/> objects and determines their relative order.
        /// </summary>
        /// <remarks>The comparison is performed first by the <see cref="Person.LastName"/> property, and
        /// if the last names are equal, by the <see cref="Person.GivenNames"/> property. The comparison is
        /// case-insensitive. <para> If both <paramref name="x"/> and <paramref name="y"/> are <see langword="null"/>,
        /// they are considered equal. If only one of the objects is <see langword="null"/>, the non-<see
        /// langword="null"/> object is considered greater. </para></remarks>
        /// <param name="x">The first <see cref="Person"/> object to compare. Can be <see langword="null"/>.</param>
        /// <param name="y">The second <see cref="Person"/> object to compare. Can be <see langword="null"/>.</param>
        /// <returns>A signed integer that indicates the relative order of the objects being compared: <list type="bullet">
        /// <item><description>Less than zero if <paramref name="x"/> is less than <paramref
        /// name="y"/>.</description></item> <item><description>Zero if <paramref name="x"/> is equal to <paramref
        /// name="y"/>.</description></item> <item><description>Greater than zero if <paramref name="x"/> is greater
        /// than <paramref name="y"/>.</description></item> </list></returns>
        public int Compare(Person? x, Person? y)
        {
            // Sort by last name first, then by given names
            if (x == null && y == null) return 0;   
            if (x == null) return -1;
            if (y == null) return 1;
            int lastNameComparison = string.Compare(x.LastName, y.LastName, StringComparison.OrdinalIgnoreCase);
            if (lastNameComparison != 0)
            {
                return lastNameComparison;
            }
            return string.Compare(x.GivenNames, y.GivenNames, StringComparison.OrdinalIgnoreCase);
        }
    }
}
