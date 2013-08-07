namespace LinqToQueryString.Tests
{
    using System.Collections.Generic;

    public class ComplexClass
    {
        public int Id { get; set; }

        public ConcreteClass Concrete { get; set; }

        public List<string> StringCollection { get; set; }

        public List<ConcreteClass> ConcreteCollection { get; set; }

        public string Title { get; set; }

        public List<int> IntCollection { get; set; }
    }

    public class ComplexClassDto
    {
        public int Id { get; set; }

        public ConcreteClass Concrete { get; set; }

        public IEnumerable<string> StringCollection { get; set; }

        public List<ConcreteClass> ConcreteCollection { get; set; }

        public string Title { get; set; }

        public IEnumerable<int> IntCollection { get; set; }
    }

    public class NullableClassDto
    {
        public IEnumerable<int?> NullableCollection { get; set; }
    }
}
