using System;

namespace GeneralUtilities
{
    /// <summary>The Range class.</summary>
    /// <typeparam name="T">Generic parameter.</typeparam>
    public class Range<T> where T : IComparable<T>
    {
        public Range(T value)
        {
            Minimum = value;
            Maximum = value;
        }

        public Range(T minimum, T maximum)
        {
            Minimum = minimum;
            Maximum = maximum;
        }

        /// <summary>Minimum value of the range.</summary>
        public T Minimum { get; }

        /// <summary>Maximum value of the range.</summary>
        public T Maximum { get; }

        /// <summary>Presents the Range in readable format.</summary>
        /// <returns>String representation of the Range</returns>
        public override string ToString()
        {
            return $"[{Minimum} - {Maximum}]";
        }

        /// <summary>Determines if the range is valid.</summary>
        /// <returns>True if range is valid, else false</returns>
        public bool IsValid()
        {
            return Minimum.CompareTo(Maximum) <= 0;
        }

        /// <summary>Determines if the provided value is inside the range.</summary>
        /// <param name="value">The value to test</param>
        /// <returns>True if the value is inside Range, else false</returns>
        public bool ContainsValue(T value)
        {
            return (Minimum.CompareTo(value) <= 0) && (value.CompareTo(Maximum) <= 0);
        }

        /// <summary>Determines if this Range is inside the bounds of another range.</summary>
        /// <param name="range">The parent range to test on</param>
        /// <returns>True if range is inclusive, else false</returns>
        public bool IsInsideRange(Range<T> range)
        {
            return IsValid() && range.IsValid() && range.ContainsValue(Minimum) && range.ContainsValue(Maximum);
        }

        /// <summary>Determines if another range is inside the bounds of this range.</summary>
        /// <param name="range">The child range to test</param>
        /// <returns>True if range is inside, else false</returns>
        public bool ContainsRange(Range<T> range)
        {
            return IsValid() && range.IsValid() && ContainsValue(range.Minimum) && ContainsValue(range.Maximum);
        }

        public bool IntersectsRange(Range<T> range)
        {
            return IsValid() && range.IsValid() && range.Minimum.CompareTo(Maximum) <= 0 && Minimum.CompareTo(range.Maximum) <= 0;
        }

        public Range<T> Hull(Range<T> range)
        {
            Range<T> hull = new Range<T>(Minimum.CompareTo(range.Minimum) < 0 ? Minimum : range.Minimum,
                                         Maximum.CompareTo(range.Maximum) > 0 ? Maximum : range.Maximum);

            return hull;
        }

        public Range<T> SortAscending()
        {
            if (Minimum.CompareTo(Maximum) > 0) // min > max
            {
                return new Range<T>(Maximum, Minimum);
            }

            return this;
        }

        public Range<T> SortDescending()
        {
            if (Maximum.CompareTo(Minimum) > 0) // max > min
            {
                return new Range<T>(Maximum, Minimum);
            }

            return this;
        }

        public static bool operator == (Range<T> a, Range<T> b)
        {
            if (ReferenceEquals(a, b))
            {
                return true;
            }

            if (ReferenceEquals(a, null))
            {
                return false;
            }
            if (ReferenceEquals(b, null))
            {
                return false;
            }

            return a.Minimum.Equals(b.Minimum) && a.Maximum.Equals(b.Maximum);
        }

        public static bool operator != (Range<T> a, Range<T> b)
        {
            return !(a == b);
        }

        public bool Equals(Range<T> other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Minimum.Equals(other.Minimum) && Maximum.Equals(other.Maximum);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            return obj.GetType() == GetType() && Equals((Range<T>)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = Minimum.GetHashCode();
                hashCode = (hashCode * 397) ^ Maximum.GetHashCode();
                return hashCode;
            }
        }
    }
}