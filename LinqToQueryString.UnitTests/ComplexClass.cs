namespace LinqToQueryString.UnitTests
{
    using System.Collections.Generic;

    public class ComplexClass
    {
        public List<ConcreteClass> Concretes { get; set; }

        public string Title { get; set; }
    }
}
