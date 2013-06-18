namespace LinqToQueryString.IntegrationTests.Sql
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    using LinqToQueryString.Tests;

    using LinqToQuerystring;

    using Machine.Specifications;

    public abstract class SqlExpand
    {
        protected static TestDbContext testDb;

        protected static List<ComplexClass> result;

        protected static List<Dictionary<string, object>> dynamicResult;

        private Establish context = () =>
        {
            testDb = new TestDbContext();
            Database.SetInitializer(new DropCreateDatabaseAlways<TestDbContext>());
            testDb.Database.Initialize(true);

            testDb.ComplexCollection.Add(
                new ComplexClass
                {
                    Title = "Charles",
                    ConcreteCollection =
                        new List<ConcreteClass>
                                    {
                                        InstanceBuilders.BuildConcrete(
                                            "Apple", 1, new DateTime(2005, 01, 01), true),
                                    }
                });

            testDb.ComplexCollection.Add(
                new ComplexClass
                {
                    Title = "Andrew",
                    ConcreteCollection =
                        new List<ConcreteClass>
                                    {
                                        InstanceBuilders.BuildConcrete(
                                            "Apple", 1, new DateTime(2005, 01, 01), true),
                                        InstanceBuilders.BuildConcrete(
                                            "Banana",
                                            2,
                                            new DateTime(2003, 01, 01),
                                            false)
                                    }
                });

            testDb.ComplexCollection.Add(
                new ComplexClass
                {
                    Title = "David",
                    ConcreteCollection =
                        new List<ConcreteClass>
                                    {
                                        InstanceBuilders.BuildConcrete(
                                            "Apple", 1, new DateTime(2005, 01, 01), true),
                                        InstanceBuilders.BuildConcrete(
                                            "Banana",
                                            2,
                                            new DateTime(2003, 01, 01),
                                            false),
                                        InstanceBuilders.BuildConcrete(
                                            "Custard",
                                            3,
                                            new DateTime(2007, 01, 01),
                                            true)
                                    }
                });

            testDb.ComplexCollection.Add(
                new ComplexClass
                {
                    Title = "Edward",
                    ConcreteCollection =
                        new List<ConcreteClass>
                                    {
                                        InstanceBuilders.BuildConcrete(
                                            "Apple", 1, new DateTime(2005, 01, 01), true),
                                        InstanceBuilders.BuildConcrete(
                                            "Custard",
                                            3,
                                            new DateTime(2007, 01, 01),
                                            true),
                                        InstanceBuilders.BuildConcrete(
                                            "Dogfood",
                                            4,
                                            new DateTime(2009, 01, 01),
                                            false),
                                        InstanceBuilders.BuildConcrete(
                                            "Eggs", 5, new DateTime(2000, 01, 01), true)
                                    }
                });

            testDb.ComplexCollection.Add(
                new ComplexClass
                {
                    Title = "Boris",
                    ConcreteCollection =
                        new List<ConcreteClass>
                                    {
                                        InstanceBuilders.BuildConcrete(
                                            "Apple", 1, new DateTime(2005, 01, 01), true),
                                        InstanceBuilders.BuildConcrete(
                                            "Dogfood",
                                            4,
                                            new DateTime(2009, 01, 01),
                                            false),
                                        InstanceBuilders.BuildConcrete(
                                            "Eggs", 5, new DateTime(2000, 01, 01), true)
                                    }
                });

            testDb.SaveChanges();
            // Clear local cached entities
            testDb = new TestDbContext();

            Configuration.Reset();
        };
    }

    public abstract class SqlExpandWithSetup : SqlExpand
    {
        private Establish context = () => LinqToQuerystring.EntityFramework.Configuration.Init();
    }

    public class When_expanding_complex_collection_without_setup : SqlExpand
    {
        private static Exception ex;

        private Because of = () => ex = Catch.Exception(() => result = testDb.ComplexCollection.LinqToQuerystring("$expand=ConcreteCollection").ToList());

        private It should_throw_a_not_supported_exception = () => ex.ShouldBeOfType<NotSupportedException>();
    }

    public class When_not_expanding_complex_collection : SqlExpandWithSetup
    {
        private Because of = () => result = testDb.ComplexCollection.LinqToQuerystring(string.Empty).ToList();

        private It should_the_correct_number_of_records = () => result.Count.ShouldEqual(5);

        private It should_return_null_for_the_concrete_collection = () =>
            result.ShouldEachConformTo(o => o.ConcreteCollection == null);
    }

    public class When_expanding_a_complex_collection : SqlExpandWithSetup
    {
        private Because of = () => result = testDb.ComplexCollection.LinqToQuerystring("$expand=ConcreteCollection").ToList();

        private It should_return_all_the_records = () => result.Count.ShouldEqual(5);

        private It should_return_the_concrete_collection = () =>
            result.ShouldEachConformTo(o => o.ConcreteCollection != null);
    }

    public class When_expanding_a_complex_collection_with_preexisting_filter : SqlExpandWithSetup
    {
        private Because of = () => result = testDb.ComplexCollection.Where(o => o.Title != "Charles").LinqToQuerystring("$expand=ConcreteCollection").ToList();

        private It should_return_the_correct_number_of_records = () => result.Count.ShouldEqual(4);

        private It should_return_the_concrete_collection = () =>
            result.ShouldEachConformTo(o => o.ConcreteCollection != null);
    }

    public class When_ordering_and_expanding_a_complex_collection : SqlExpandWithSetup
    {
        private Because of = () => result = testDb.ComplexCollection.LinqToQuerystring("$expand=ConcreteCollection&$orderby=Title").ToList();

        private It should_return_all_the_records = () => result.Count.ShouldEqual(5);

        private It should_return_the_concrete_collection = () =>
            result.ShouldEachConformTo(o => o.ConcreteCollection != null);
    }

    public class When_filtering_and_expanding_a_complex_collection : SqlExpandWithSetup
    {
        private Because of = () => result = testDb.ComplexCollection.LinqToQuerystring("$expand=ConcreteCollection&$filter=Title eq 'Charles'").ToList();

        private It should_return_all_the_records = () => result.Count.ShouldEqual(1);

        private It should_return_null_for_the_concrete_collection = () =>
            result.ShouldEachConformTo(o => o.ConcreteCollection != null);
    }

    public class When_paging_and_expanding_a_complex_collection : SqlExpandWithSetup
    {
        private Because of = () => result = testDb.ComplexCollection.LinqToQuerystring("$expand=ConcreteCollection&$orderby=Title&$top=2&$skip=2").ToList();

        private It should_return_all_the_records = () => result.Count.ShouldEqual(2);

        private It should_return_null_for_the_concrete_collection = () =>
            result.ShouldEachConformTo(o => o.ConcreteCollection != null);
    }

    public class When_projecting_and_expanding_a_complex_collection : SqlExpandWithSetup
    {
        private Because of = () => dynamicResult = testDb.ComplexCollection.LinqToQuerystring<ComplexClass, IQueryable<Dictionary<string, object>>>("$expand=ConcreteCollection&$select=ConcreteCollection").ToList();

        private It should_return_all_the_records = () => dynamicResult.Count.ShouldEqual(5);

        private It should_return_null_for_the_concrete_collection = () =>
            dynamicResult.ShouldEachConformTo(o => o["ConcreteCollection"] != null);
    }
}
