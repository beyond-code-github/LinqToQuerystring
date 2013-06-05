namespace LinqToQueryString.UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using LinqToQueryString.Tests;

    using LinqToQuerystring;

    using Machine.Specifications;

    public abstract class CollectionAggregates
    {
        protected static Exception ex;

        protected static IQueryable<ComplexClass> result;

        protected static List<ComplexClass> complexCollection;

        private Establish context = () =>
        {
            //complexCollection = new List<ComplexClass>
            //                             {
            //                                 new ComplexClass { Title = "Charles", Concrete = InstanceBuilders.BuildConcrete("Apple", 5, new DateTime(2005, 01, 01), true) },
            //                                 new ComplexClass { Title = "Andrew", Concrete = InstanceBuilders.BuildConcrete("Custard", 3, new DateTime(2007, 01, 01), true) },
            //                                 new ComplexClass { Title = "David", Concrete = InstanceBuilders.BuildConcrete("Banana", 2, new DateTime(2003, 01, 01), false) },
            //                                 new ComplexClass { Title = "Edward", Concrete = InstanceBuilders.BuildConcrete("Eggs", 1, new DateTime(2000, 01, 01), true) },
            //                                 new ComplexClass { Title = "Boris", Concrete = InstanceBuilders.BuildConcrete("Dogfood", 4, new DateTime(2009, 01, 01), false) }
            //                             };

            complexCollection = new List<ComplexClass>
                                         {
                                             new ComplexClass
                                                 {
                                                     Title = "Charles", StringCollection = new List<string> { "Apple" }
                                                 },
                                             new ComplexClass
                                                 {
                                                     Title = "Andrew", StringCollection = new List<string> { "Apple", "Banana" }
                                                 },
                                             new ComplexClass
                                                 {
                                                     Title = "David", StringCollection = new List<string> { "Apple", "Banana", "Custard" }
                                                 },
                                             new ComplexClass
                                                 {
                                                     Title = "Edward", StringCollection = new List<string> { "Custard", "Dogfood", "Eggs" }
                                                 },
                                             new ComplexClass
                                                 {
                                                     Title = "Boris", StringCollection = new List<string> { "Dogfood", "Eggs" }
                                                 }
                                         };

            var query = complexCollection.Where(o => o.StringCollection.Any(tag => tag == "apple"));
        };
    }

    public class When_filtering_on_a_simple_collection_property_using_any : CollectionAggregates
    {
        private Because of = () => result = complexCollection.AsQueryable().LinqToQuerystring("$filter=StringCollection/any(tag: tag eq 'Apple')");

        private It should_return_three_records = () => result.Count().ShouldEqual(3);

        private It should_only_return_records_where_string_collection_contains_apple = () => result.ShouldEachConformTo(o => o.StringCollection.Any(s => s == "Apple"));
    }

    public class When_filtering_on_a_simple_collection_property_using_any_with_an_or : CollectionAggregates
    {
        private Because of = () => result = complexCollection.AsQueryable().LinqToQuerystring("$filter=StringCollection/any(tag: tag eq 'Apple' or tag eq 'Eggs')");

        private It should_return_five_records = () => result.Count().ShouldEqual(5);

        private It should_only_return_records_where_string_collection_contains_apple = () => result.ShouldEachConformTo(o => o.StringCollection.Any(s => s == "Apple" || s == "Eggs"));
    }

    public class When_filtering_on_a_simple_collection_property_using_any_with_functions : CollectionAggregates
    {
        private Because of = () => result = complexCollection.AsQueryable().LinqToQuerystring("$filter=StringCollection/any(tag: startswith(tag,'Dog'))");

        private It should_return_two_records = () => result.Count().ShouldEqual(2);

        private It should_only_return_records_where_string_collection_contains_apple = () => result.ShouldEachConformTo(o => o.StringCollection.Any(s => s.StartsWith("Dog")));
    }
}
