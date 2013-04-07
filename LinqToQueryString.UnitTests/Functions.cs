namespace LinqToQueryString.UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using LinqToQueryString.Tests;

    using LinqToQuerystring;

    using Machine.Specifications;

    public abstract class Functions
    {
        protected static Exception ex;

        protected static IQueryable<ConcreteClass> result;

        protected static List<ConcreteClass> concreteCollection;

        protected static List<ComplexClass> complexCollection;

        private Establish context = () =>
        {
            concreteCollection = new List<ConcreteClass>
                                         {
                                             InstanceBuilders.BuildConcrete("Saturday", 1, new DateTime(2001, 01, 01), true),
                                             InstanceBuilders.BuildConcrete("Satnav", 2, new DateTime(2002, 01, 01), false),
                                             InstanceBuilders.BuildConcrete("Saturnalia", 3, new DateTime(2003, 01, 01), true),
                                             InstanceBuilders.BuildConcrete("Saturn", 4, new DateTime(2004, 01, 01), true),
                                             InstanceBuilders.BuildConcrete("Monday", 5, new DateTime(2005, 01, 01), true),
                                             InstanceBuilders.BuildConcrete("Tuesday", 5, new DateTime(2005, 01, 01), true),
                                             InstanceBuilders.BuildConcrete("Burns", 5, new DateTime(2005, 01, 01), true)
                                         };

            complexCollection = new List<ComplexClass>
                                         {
                                             new ComplexClass { Title = "Charles", Concrete = InstanceBuilders.BuildConcrete("Apple", 5, new DateTime(2005, 01, 01), true) },
                                             new ComplexClass { Title = "Andrew", Concrete = InstanceBuilders.BuildConcrete("Custard", 3, new DateTime(2007, 01, 01), true) },
                                             new ComplexClass { Title = "David", Concrete = InstanceBuilders.BuildConcrete("Banana", 2, new DateTime(2003, 01, 01), false) },
                                             new ComplexClass { Title = "Edward", Concrete = InstanceBuilders.BuildConcrete("Eggs", 1, new DateTime(2000, 01, 01), true) },
                                             new ComplexClass { Title = "Boris", Concrete = InstanceBuilders.BuildConcrete("Dogfood", 4, new DateTime(2009, 01, 01), false) }
                                         };
        };
    }

    public class When_filtering_on_startswith_function : Functions
    {
        private Because of =
            () => result = concreteCollection.AsQueryable().LinqToQuerystring("?$filter=startswith(Name,'Sat')");

        private It should_return_four_records = () => result.Count().ShouldEqual(4);

        private It should_only_return_records_where_name_starts_with_Sat =
            () => result.ShouldEachConformTo(o => o.Name.StartsWith("Sat"));
    }

    public class When_filtering_on_endswith_function : Functions
    {
        private Because of =
            () => result = concreteCollection.AsQueryable().LinqToQuerystring("?$filter=endswith(Name,'day')");

        private It should_return_four_records = () => result.Count().ShouldEqual(3);

        private It should_only_return_records_where_name_ends_with_day =
            () => result.ShouldEachConformTo(o => o.Name.EndsWith("day"));
    }

    public class When_filtering_on_substringof_function : Functions
    {
        private Because of =
            () => result = concreteCollection.AsQueryable().LinqToQuerystring("?$filter=substringof(Name,'urn')");

        private It should_return_four_records = () => result.Count().ShouldEqual(3);

        private It should_only_return_records_where_name_contains_urn =
            () => result.ShouldEachConformTo(o => o.Name.Contains("urn"));
    }
}
