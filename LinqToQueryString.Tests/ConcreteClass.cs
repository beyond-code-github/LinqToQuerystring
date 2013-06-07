namespace LinqToQueryString.Tests
{
    using System;
    using System.Collections.Generic;

    public class ConcreteClass : IComparable<ConcreteClass>
    {
        public ConcreteClass()
        {
            Date = DateTime.UtcNow;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Date { get; set; }

        public bool Complete { get; set; }

        public int Age { get; set; }

        public List<EdgeCaseClass> Children { get; set; }

        public IEnumerable<string> StringCollection { get; set; }

        public int CompareTo(ConcreteClass other)
        {
            return String.CompareOrdinal(this.Name, other.Name);
        }
    }

    public class EdgeCaseClass : IComparable<EdgeCaseClass>
    {
        public EdgeCaseClass()
        {
            Date = DateTime.UtcNow;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Date { get; set; }

        public bool Complete { get; set; }

        public int Age { get; set; }

        public int CompareTo(EdgeCaseClass other)
        {
            return String.CompareOrdinal(this.Name, other.Name);
        }
    }
}
