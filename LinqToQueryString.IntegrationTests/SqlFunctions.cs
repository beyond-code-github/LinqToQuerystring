namespace LinqToQueryString.IntegrationTests.Sql
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    using LinqToQueryString.Tests;

    using LinqToQuerystring;

    using Machine.Specifications;

    public abstract class SqlFunctions
    {
        protected static TestDbContext testDb;

        protected static List<ConcreteClass> result;

        protected static List<ConcreteClass> concreteCollection;

        private Establish context = () =>
        {
            testDb = new TestDbContext();
            Database.SetInitializer(new DropCreateDatabaseAlways<TestDbContext>());
            testDb.Database.Initialize(true);

            testDb.ConcreteCollection.Add(
                InstanceBuilders.BuildConcrete("Saturday", 1, new DateTime(2001, 01, 01), true));
            testDb.ConcreteCollection.Add(InstanceBuilders.BuildConcrete("Satnav", 2, new DateTime(2002, 01, 01), false));
            testDb.ConcreteCollection.Add(InstanceBuilders.BuildConcrete("Saturnalia", 3, new DateTime(2003, 01, 01), true));
            testDb.ConcreteCollection.Add(InstanceBuilders.BuildConcrete("Saturn", 4, new DateTime(2004, 01, 01), true));
            testDb.ConcreteCollection.Add(InstanceBuilders.BuildConcrete("Monday", 5, new DateTime(2005, 01, 01), true));
            testDb.ConcreteCollection.Add(InstanceBuilders.BuildConcrete("Tuesday", 5, new DateTime(2005, 01, 01), true));
            testDb.ConcreteCollection.Add(InstanceBuilders.BuildConcrete("Burns", 5, new DateTime(2005, 01, 01), true));

            testDb.SaveChanges();

            concreteCollection = testDb.ConcreteCollection.ToList();
        };
    }

    public class When_filtering_on_startswith_function : SqlFunctions
    {
        private Because of =
            () => result = testDb.ConcreteCollection.LinqToQuerystring("?$filter=startswith(Name,'Sat')").ToList();

        private It should_return_four_records = () => result.Count().ShouldEqual(4);

        private It should_only_return_records_where_name_starts_with_Sat =
            () => result.ShouldEachConformTo(o => o.Name.StartsWith("Sat"));
    }

    public class When_filtering_on_substringof_function : SqlFunctions
    {
        private Because of =
            () => result = testDb.ConcreteCollection.LinqToQuerystring("?$filter=substringof('urn',Name)").ToList();

        private It should_return_three_records = () => result.Count().ShouldEqual(3);

        private It should_only_return_records_where_name_contains_urn =
            () => result.ShouldEachConformTo(o => o.Name.Contains("urn"));
    }

    public class When_filtering_on_substringof_function_with_escape_character : SqlFiltering
    {
        private Because of =
            () => edgeCaseResult = testDb.EdgeCaseCollection.LinqToQuerystring(@"?$filter=substringof('\\',Name)").ToList();

        private It should_return_one_record = () => edgeCaseResult.Count().ShouldEqual(1);

        private It should_only_return_records_where_name_contains_escaped_slash =
            () => edgeCaseResult.ShouldEachConformTo(o => o.Name.Contains("\\"));
    }
}
