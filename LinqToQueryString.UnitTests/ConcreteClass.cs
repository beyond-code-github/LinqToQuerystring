namespace LinqToQueryString.UnitTests
{
    using System;

    public class ConcreteClass : IComparable<ConcreteClass>
    {
        public string Name { get; set; }

        public DateTime Date { get; set; }

        public bool Complete { get; set; }

        public int Age { get; set; }

        public int CompareTo(ConcreteClass other)
        {
            return String.CompareOrdinal(this.Name, other.Name);
        }
    }
}
