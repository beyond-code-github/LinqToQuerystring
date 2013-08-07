namespace LinqToQueryString.IntegrationTests.Sql
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    using LinqToQueryString.Tests;

    using LinqToQuerystring;

    using Machine.Specifications;

    public abstract class SqlFiltering
    {
        protected static TestDbContext testDb;

        protected static List<ConcreteClass> result;

        protected static List<EdgeCaseClass> edgeCaseResult;

        protected static List<NullableClass> nullableResult;

        protected static List<ConcreteClass> concreteCollection;

        protected static List<EdgeCaseClass> edgeCaseCollection;

        protected static List<NullableClass> nullableCollection;

        protected static Guid[] guidArray;

        private Establish context = () =>
        {
            guidArray = Enumerable.Range(1, 5).Select(o => Guid.NewGuid()).ToArray();

            testDb = new TestDbContext();
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<TestDbContext>());

            testDb.Database.ExecuteSqlCommand("UPDATE ComplexClasses SET Concrete_Id = NULL");
            testDb.Database.ExecuteSqlCommand("DELETE FROM EdgeCaseClasses");
            testDb.Database.ExecuteSqlCommand("DELETE FROM ConcreteClasses");
            testDb.Database.ExecuteSqlCommand("DELETE FROM ComplexClasses");
            testDb.Database.ExecuteSqlCommand("DELETE FROM NullableClasses");

            testDb.ConcreteCollection.Add(InstanceBuilders.BuildConcrete("Apple", 1, new DateTime(2002, 01, 01), true, 10000000000, 111.111, 111.111f, 0x00, guidArray[0]));
            testDb.ConcreteCollection.Add(InstanceBuilders.BuildConcrete("Apple", 2, new DateTime(2005, 01, 01), false, 30000000000, 333.333, 333.333f, 0x22, guidArray[2]));
            testDb.ConcreteCollection.Add(InstanceBuilders.BuildConcrete("Custard", 1, new DateTime(2003, 01, 01), true, 50000000000, 555.555, 555.555f, 0xDD, guidArray[4]));
            testDb.ConcreteCollection.Add(InstanceBuilders.BuildConcrete("Custard", 2, new DateTime(2002, 01, 01), false, 30000000000, 333.333, 333.333f, 0x00, guidArray[2]));
            testDb.ConcreteCollection.Add(InstanceBuilders.BuildConcrete("Custard", 3, new DateTime(2002, 01, 01), true, 40000000000, 444.444, 444.444f, 0x22, guidArray[3]));
            testDb.ConcreteCollection.Add(InstanceBuilders.BuildConcrete("Banana", 3, new DateTime(2003, 01, 01), false, 10000000000, 111.111, 111.111f, 0x00, guidArray[0]));
            testDb.ConcreteCollection.Add(InstanceBuilders.BuildConcrete("Eggs", 1, new DateTime(2005, 01, 01), true, 40000000000, 444.444, 444.444f, 0xCC, guidArray[3]));
            testDb.ConcreteCollection.Add(InstanceBuilders.BuildConcrete("Eggs", 3, new DateTime(2001, 01, 01), false, 20000000000, 222.222, 222.222f, 0xCC, guidArray[1]));
            testDb.ConcreteCollection.Add(InstanceBuilders.BuildConcrete("Dogfood", 4, new DateTime(2003, 01, 01), true, 30000000000, 333.333, 333.333f, 0xEE, guidArray[2]));
            testDb.ConcreteCollection.Add(InstanceBuilders.BuildConcrete("Dogfood", 4, new DateTime(2004, 01, 01), false, 10000000000, 111.111, 111.111f, 0xDD, guidArray[0]));
            testDb.ConcreteCollection.Add(InstanceBuilders.BuildConcrete("Dogfood", 5, new DateTime(2001, 01, 01), true, 20000000000, 222.222, 222.222f, 0xCC, guidArray[1]));

            testDb.EdgeCaseCollection.Add(InstanceBuilders.BuildEdgeCase("Apple\\Bob", 1, new DateTime(2002, 01, 01), true));
            testDb.EdgeCaseCollection.Add(InstanceBuilders.BuildEdgeCase("Apple\bBob", 1, new DateTime(2002, 01, 01), true));
            testDb.EdgeCaseCollection.Add(InstanceBuilders.BuildEdgeCase("Apple\tBob", 1, new DateTime(2002, 01, 01), true));
            testDb.EdgeCaseCollection.Add(InstanceBuilders.BuildEdgeCase("Apple\nBob", 1, new DateTime(2002, 01, 01), true));
            testDb.EdgeCaseCollection.Add(InstanceBuilders.BuildEdgeCase("Apple\fBob", 1, new DateTime(2002, 01, 01), true));
            testDb.EdgeCaseCollection.Add(InstanceBuilders.BuildEdgeCase("Apple\rBob", 1, new DateTime(2002, 01, 01), true));
            testDb.EdgeCaseCollection.Add(InstanceBuilders.BuildEdgeCase("Apple\"Bob", 1, new DateTime(2002, 01, 01), true));
            testDb.EdgeCaseCollection.Add(InstanceBuilders.BuildEdgeCase("Apple'Bob", 1, new DateTime(2002, 01, 01), true));

            testDb.NullableCollection.Add(InstanceBuilders.BuildNull());
            testDb.NullableCollection.Add(InstanceBuilders.BuildNull(1, new DateTime(2002, 01, 01), true, 10000000000, 111.111, 111.111f, 0x00, guidArray[0]));

            testDb.SaveChanges();

            concreteCollection = testDb.ConcreteCollection.ToList();
            edgeCaseCollection = testDb.EdgeCaseCollection.ToList();
            nullableCollection = testDb.NullableCollection.ToList();

            testDb = new TestDbContext();
        };
    }

    #region Filter on implicit boolean identifiers

    public class When_specifying_a_single_boolean_identifier_as_a_filter : SqlFiltering
    {
        private Because of = () => result = testDb.ConcreteCollection.LinqToQuerystring("?$filter=Complete").ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(6);

        private It should_only_return_records_where_name_is_apple = () => result.ShouldEachConformTo(o => o.Complete);
    }

    public class When_specifying_a_negated_single_boolean_identifier_as_a_filter : SqlFiltering
    {
        private Because of = () => result = testDb.ConcreteCollection.LinqToQuerystring("?$filter=not Complete").ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(5);

        private It should_only_return_records_where_name_is_apple = () => result.ShouldEachConformTo(o => !o.Complete);
    }

    #endregion

    #region Filter on string tests

    public class When_using_eq_filter_on_a_single_string : SqlFiltering
    {
        private Because of = () => result = testDb.ConcreteCollection.LinqToQuerystring("?$filter=Name eq 'Apple'").ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(2);

        private It should_only_return_records_where_name_is_apple = () => result.ShouldEachConformTo(o => o.Name == "Apple");
    }

    public class When_using_eq_filter_on_a_single_string_with_reversed_parameters : SqlFiltering
    {
        private Because of = () => result = testDb.ConcreteCollection.LinqToQuerystring("?$filter='Apple' eq Name").ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(2);

        private It should_only_return_records_where_name_is_apple = () => result.ShouldEachConformTo(o => o.Name == "Apple");
    }

    public class When_using_not_eq_filter_on_a_single_string : SqlFiltering
    {
        private Because of = () => result = testDb.ConcreteCollection.LinqToQuerystring("?$filter=not Name eq 'Apple'").ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(9);

        private It should_only_return_records_where_name_is_not_apple = () => result.ShouldEachConformTo(o => o.Name != "Apple");
    }

    public class When_using_ne_filter_on_a_single_string : SqlFiltering
    {
        private Because of = () => result = testDb.ConcreteCollection.LinqToQuerystring("?$filter=Name ne 'Apple'").ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(9);

        private It should_only_return_records_where_name_is_not_apple = () => result.ShouldEachConformTo(o => o.Name != "Apple");
    }

    public class When_using_not_ne_filter_on_a_single_string : SqlFiltering
    {
        private Because of = () => result = testDb.ConcreteCollection.LinqToQuerystring("?$filter=not Name ne 'Apple'").ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(2);

        private It should_only_return_records_where_name_is_apple = () => result.ShouldEachConformTo(o => o.Name == "Apple");
    }

    #endregion

    #region Filter on string escape character tests

    public class When_using_eq_filter_on_a_single_string_with_escaped_slash : SqlFiltering
    {
        private Because of =
            () => edgeCaseResult = testDb.EdgeCaseCollection.LinqToQuerystring(@"?$filter=Name eq 'Apple\\Bob'").ToList();

        private It should_return_one_record = () => edgeCaseResult.Count().ShouldEqual(1);

        private It should_only_return_records_where_name_matches = () => edgeCaseResult.ShouldEachConformTo(o => o.Name == "Apple\\Bob");
    }

    public class When_using_eq_filter_on_a_single_string_with_escaped_backspace : SqlFiltering
    {
        private Because of = () => edgeCaseResult = testDb.EdgeCaseCollection.LinqToQuerystring(@"?$filter=Name eq 'Apple\bBob'").ToList();

        private It should_return_one_record = () => edgeCaseResult.Count().ShouldEqual(1);

        private It should_only_return_records_where_name_matches = () => edgeCaseResult.ShouldEachConformTo(o => o.Name == "Apple\bBob");
    }

    public class When_using_eq_filter_on_a_single_string_with_escaped_tab : SqlFiltering
    {
        private Because of = () => edgeCaseResult = testDb.EdgeCaseCollection.LinqToQuerystring(@"?$filter=Name eq 'Apple\tBob'").ToList();

        private It should_return_one_record = () => edgeCaseResult.Count().ShouldEqual(1);

        private It should_only_return_records_where_name_matches = () => edgeCaseResult.ShouldEachConformTo(o => o.Name == "Apple\tBob");
    }

    public class When_using_eq_filter_on_a_single_string_with_escaped_newline : SqlFiltering
    {
        private Because of = () => edgeCaseResult = testDb.EdgeCaseCollection.LinqToQuerystring(@"?$filter=Name eq 'Apple\nBob'").ToList();

        private It should_return_one_record = () => edgeCaseResult.Count().ShouldEqual(1);

        private It should_only_return_records_where_name_matches = () => edgeCaseResult.ShouldEachConformTo(o => o.Name == "Apple\nBob");
    }

    public class When_using_eq_filter_on_a_single_string_with_escaped_formfeed : SqlFiltering
    {
        private Because of = () => edgeCaseResult = testDb.EdgeCaseCollection.LinqToQuerystring(@"?$filter=Name eq 'Apple\fBob'").ToList();

        private It should_return_one_record = () => edgeCaseResult.Count().ShouldEqual(1);

        private It should_only_return_records_where_name_matches = () => edgeCaseResult.ShouldEachConformTo(o => o.Name == "Apple\fBob");
    }

    public class When_using_eq_filter_on_a_single_string_with_escaped_carriage_return : SqlFiltering
    {
        private Because of = () => edgeCaseResult = testDb.EdgeCaseCollection.LinqToQuerystring(@"?$filter=Name eq 'Apple\rBob'").ToList();

        private It should_return_one_record = () => edgeCaseResult.Count().ShouldEqual(1);

        private It should_only_return_records_where_name_matches = () => edgeCaseResult.ShouldEachConformTo(o => o.Name == "Apple\rBob");
    }

    public class When_using_eq_filter_on_a_single_string_with_quote : SqlFiltering
    {
        private Because of = () => edgeCaseResult = testDb.EdgeCaseCollection.LinqToQuerystring(@"?$filter=Name eq 'Apple""Bob'").ToList();

        private It should_return_one_record = () => edgeCaseResult.Count().ShouldEqual(1);

        private It should_only_return_records_where_name_matches = () => edgeCaseResult.ShouldEachConformTo(o => o.Name == @"Apple""Bob");
    }

    public class When_using_eq_filter_on_a_single_string_with_double_escaped_single_quote : SqlFiltering
    {
        private Because of = () => edgeCaseResult = testDb.EdgeCaseCollection.LinqToQuerystring(@"?$filter=Name eq 'Apple''Bob'").ToList();

        private It should_return_one_record = () => edgeCaseResult.Count().ShouldEqual(1);

        private It should_only_return_records_where_name_matches = () => edgeCaseResult.ShouldEachConformTo(o => o.Name == "Apple'Bob");
    }

    public class When_using_eq_filter_on_a_single_string_with_escaped_single_quote : SqlFiltering
    {
        private Because of = () => edgeCaseResult = testDb.EdgeCaseCollection.LinqToQuerystring(@"?$filter=Name eq 'Apple\'Bob'").ToList();

        private It should_return_one_record = () => edgeCaseResult.Count().ShouldEqual(1);

        private It should_only_return_records_where_name_matches = () => edgeCaseResult.ShouldEachConformTo(o => o.Name == "Apple'Bob");
    }

    #endregion

    #region Filter on int tests

    public class When_using_eq_filter_on_a_single_int : SqlFiltering
    {
        private Because of = () => result = testDb.ConcreteCollection.LinqToQuerystring("?$filter=Age eq 4").ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(2);

        private It should_only_return_records_where_age_is_4 = () => result.ShouldEachConformTo(o => o.Age == 4);
    }

    public class When_using_eq_filter_on_a_negative_int : SqlFiltering
    {
        private Because of = () => result = testDb.ConcreteCollection.LinqToQuerystring("?$filter=Age gt -4").ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(11);

        private It should_only_return_records_where_age_is_4 = () => result.ShouldEachConformTo(o => o.Age > -4);
    }


    public class When_using_not_eq_filter_on_a_single_int : SqlFiltering
    {
        private Because of = () => result = testDb.ConcreteCollection.LinqToQuerystring("?$filter=not Age eq 4").ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(9);

        private It should_only_return_records_where_age_is_not_4 = () => result.ShouldEachConformTo(o => o.Age != 4);
    }

    public class When_using_ne_filter_on_a_single_int : SqlFiltering
    {
        private Because of = () => result = testDb.ConcreteCollection.LinqToQuerystring("?$filter=Age ne 4").ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(9);

        private It should_only_return_records_where_age_is_not_4 = () => result.ShouldEachConformTo(o => o.Age != 4);
    }

    public class When_using_not_ne_filter_on_a_single_int : SqlFiltering
    {
        private Because of = () => result = testDb.ConcreteCollection.LinqToQuerystring("?$filter=not Age ne 4").ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(2);

        private It should_only_return_records_where_age_is_4 = () => result.ShouldEachConformTo(o => o.Age == 4);
    }

    public class When_using_gt_filter_on_a_single_int : SqlFiltering
    {
        private Because of = () => result = testDb.ConcreteCollection.LinqToQuerystring("?$filter=Age gt 3").ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(3);

        private It should_only_return_records_where_age_is_greater_than_3 = () => result.ShouldEachConformTo(o => o.Age > 3);
    }

    public class When_using_not_gt_filter_on_a_single_int : SqlFiltering
    {
        private Because of = () => result = testDb.ConcreteCollection.LinqToQuerystring("?$filter=not Age gt 3").ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(8);

        private It should_only_return_records_where_age_is_not_greater_than_3 = () => result.ShouldEachConformTo(o => !(o.Age > 3));
    }

    public class When_using_ge_filter_on_a_single_int : SqlFiltering
    {
        private Because of = () => result = testDb.ConcreteCollection.LinqToQuerystring("?$filter=Age ge 3").ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(6);

        private It should_only_return_records_where_age_is_greater_than_or_equal_to_3 = () => result.ShouldEachConformTo(o => o.Age >= 3);
    }

    public class When_using_not_ge_filter_on_a_single_int : SqlFiltering
    {
        private Because of = () => result = testDb.ConcreteCollection.LinqToQuerystring("?$filter=not Age ge 3").ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(5);

        private It should_only_return_records_where_age_is_not_greater_than_or_equal_to_3 = () => result.ShouldEachConformTo(o => !(o.Age >= 3));
    }

    public class When_using_lt_filter_on_a_single_int : SqlFiltering
    {
        private Because of = () => result = testDb.ConcreteCollection.LinqToQuerystring("?$filter=Age lt 3").ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(5);

        private It should_only_return_records_where_age_is_less_than_3 = () => result.ShouldEachConformTo(o => o.Age < 3);
    }

    public class When_using_not_lt_filter_on_a_single_int : SqlFiltering
    {
        private Because of = () => result = testDb.ConcreteCollection.LinqToQuerystring("?$filter=not Age lt 3").ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(6);

        private It should_only_return_records_where_age_is_not_less_than_3 = () => result.ShouldEachConformTo(o => !(o.Age < 3));
    }

    public class When_using_le_filter_on_a_single_int : SqlFiltering
    {
        private Because of = () => result = testDb.ConcreteCollection.LinqToQuerystring("?$filter=Age le 3").ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(8);

        private It should_only_return_records_where_age_is_less_than_or_equal_to_3 = () => result.ShouldEachConformTo(o => o.Age <= 3);
    }

    public class When_using_not_le_filter_on_a_single_int : SqlFiltering
    {
        private Because of = () => result = testDb.ConcreteCollection.LinqToQuerystring("?$filter=not Age le 3").ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(3);

        private It should_only_return_records_where_age_is_not_less_than_or_equal_to_3 = () => result.ShouldEachConformTo(o => !(o.Age <= 3));
    }

    #endregion

    #region Filter on long tests

    public class When_using_eq_filter_on_a_single_long : SqlFiltering
    {
        private Because of = () => result = testDb.ConcreteCollection.LinqToQuerystring("?$filter=Population eq 40000000000L").ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(2);

        private It should_only_return_records_where_population_is_40000000000 = () => result.ShouldEachConformTo(o => o.Population == 40000000000);
    }

    public class When_using_eq_filter_on_a_negative_long : SqlFiltering
    {
        private Because of = () => result = testDb.ConcreteCollection.AsQueryable().LinqToQuerystring("?$filter=Population gt -40000000000L").ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(11);

        private It should_only_return_records_where_age_is_4 = () => result.ShouldEachConformTo(o => o.Age > -40000000000);
    }

    public class When_using_not_eq_filter_on_a_single_long : SqlFiltering
    {
        private Because of = () => result = testDb.ConcreteCollection.LinqToQuerystring("?$filter=not Population eq 40000000000L").ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(9);

        private It should_only_return_records_where_population_is_not_40000000000 = () => result.ShouldEachConformTo(o => o.Population != 40000000000);
    }

    public class When_using_ne_filter_on_a_single_long : SqlFiltering
    {
        private Because of = () => result = testDb.ConcreteCollection.LinqToQuerystring("?$filter=Population ne 40000000000L").ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(9);

        private It should_only_return_records_where_population_is_not_40000000000 = () => result.ShouldEachConformTo(o => o.Population != 40000000000);
    }

    public class When_using_not_ne_filter_on_a_single_long : SqlFiltering
    {
        private Because of = () => result = testDb.ConcreteCollection.LinqToQuerystring("?$filter=not Population ne 40000000000L").ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(2);

        private It should_only_return_records_where_population_is_40000000000 = () => result.ShouldEachConformTo(o => o.Population == 40000000000);
    }

    public class When_using_gt_filter_on_a_single_long : SqlFiltering
    {
        private Because of = () => result = testDb.ConcreteCollection.LinqToQuerystring("?$filter=Population gt 30000000000L").ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(3);

        private It should_only_return_records_where_population_is_greater_than_30000000000 = () => result.ShouldEachConformTo(o => o.Population > 30000000000);
    }

    public class When_using_not_gt_filter_on_a_single_long : SqlFiltering
    {
        private Because of = () => result = testDb.ConcreteCollection.LinqToQuerystring("?$filter=not Population gt 30000000000L").ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(8);

        private It should_only_return_records_where_population_is_not_greater_than_30000000000 = () => result.ShouldEachConformTo(o => !(o.Population > 30000000000));
    }

    public class When_using_ge_filter_on_a_single_long : SqlFiltering
    {
        private Because of = () => result = testDb.ConcreteCollection.LinqToQuerystring("?$filter=Population ge 30000000000L").ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(6);

        private It should_only_return_records_where_population_is_greater_than_or_equal_to_30000000000 = () => result.ShouldEachConformTo(o => o.Population >= 30000000000);
    }

    public class When_using_not_ge_filter_on_a_single_long : SqlFiltering
    {
        private Because of = () => result = testDb.ConcreteCollection.LinqToQuerystring("?$filter=not Population ge 30000000000L").ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(5);

        private It should_only_return_records_where_population_is_not_greater_than_or_equal_to_30000000000 = () => result.ShouldEachConformTo(o => !(o.Population >= 30000000000));
    }

    public class When_using_lt_filter_on_a_single_long : SqlFiltering
    {
        private Because of = () => result = testDb.ConcreteCollection.LinqToQuerystring("?$filter=Population lt 30000000000L").ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(5);

        private It should_only_return_records_where_population_is_less_than_30000000000 = () => result.ShouldEachConformTo(o => o.Population < 30000000000);
    }

    public class When_using_not_lt_filter_on_a_single_long : SqlFiltering
    {
        private Because of = () => result = testDb.ConcreteCollection.LinqToQuerystring("?$filter=not Population lt 30000000000L").ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(6);

        private It should_only_return_records_where_population_is_not_less_than_30000000000 = () => result.ShouldEachConformTo(o => !(o.Population < 30000000000));
    }

    public class When_using_le_filter_on_a_single_long : SqlFiltering
    {
        private Because of = () => result = testDb.ConcreteCollection.LinqToQuerystring("?$filter=Population le 30000000000L").ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(8);

        private It should_only_return_records_where_population_is_less_than_or_equal_to_30000000000 = () => result.ShouldEachConformTo(o => o.Population <= 30000000000);
    }

    public class When_using_not_le_filter_on_a_single_long : SqlFiltering
    {
        private Because of = () => result = testDb.ConcreteCollection.LinqToQuerystring("?$filter=not Population le 30000000000L").ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(3);

        private It should_only_return_records_where_population_is_not_less_than_or_equal_to_30000000000 = () => result.ShouldEachConformTo(o => !(o.Population <= 0000000000));
    }

    #endregion

    #region Filter on byte tests

    public class When_using_eq_filter_on_a_single_byte_numerically : SqlFiltering
    {
        private Because of = () => result = testDb.ConcreteCollection.LinqToQuerystring("?$filter=Code eq 34").ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(2);

        private It should_only_return_records_where_code_is_0x22 = () => result.ShouldEachConformTo(o => o.Code == 0x22);
    }

    public class When_using_eq_filter_on_a_single_byte : SqlFiltering
    {
        private Because of = () => result = testDb.ConcreteCollection.LinqToQuerystring("?$filter=Code eq 0x22").ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(2);

        private It should_only_return_records_where_code_is_0x22 = () => result.ShouldEachConformTo(o => o.Code == 0x22);
    }

    public class When_using_not_eq_filter_on_a_single_byte : SqlFiltering
    {
        private Because of = () => result = testDb.ConcreteCollection.LinqToQuerystring("?$filter=not Code eq 0x22").ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(9);

        private It should_only_return_records_where_code_is_not_0x22 = () => result.ShouldEachConformTo(o => o.Code != 0x22);
    }

    public class When_using_ne_filter_on_a_single_byte : SqlFiltering
    {
        private Because of = () => result = testDb.ConcreteCollection.LinqToQuerystring("?$filter=Code ne 0x22").ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(9);

        private It should_only_return_records_where_code_is_not_0x22 = () => result.ShouldEachConformTo(o => o.Code != 0x22);
    }

    public class When_using_not_ne_filter_on_a_single_byte : SqlFiltering
    {
        private Because of = () => result = testDb.ConcreteCollection.LinqToQuerystring("?$filter=not Code ne 0x22").ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(2);

        private It should_only_return_records_where_code_is_0x22 = () => result.ShouldEachConformTo(o => o.Code == 0x22);
    }

    public class When_using_gt_filter_on_a_single_byte : SqlFiltering
    {
        private Because of = () => result = testDb.ConcreteCollection.LinqToQuerystring("?$filter=Code gt 0xCC").ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(3);

        private It should_only_return_records_where_code_is_greater_than_0xCC = () => result.ShouldEachConformTo(o => o.Code > 0xCC);
    }

    public class When_using_not_gt_filter_on_a_single_byte : SqlFiltering
    {
        private Because of = () => result = testDb.ConcreteCollection.LinqToQuerystring("?$filter=not Code gt 0xCC").ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(8);

        private It should_only_return_records_where_code_is_not_greater_than_0xCC = () => result.ShouldEachConformTo(o => !(o.Code > 0xCC));
    }

    public class When_using_ge_filter_on_a_single_byte : SqlFiltering
    {
        private Because of = () => result = testDb.ConcreteCollection.LinqToQuerystring("?$filter=Code ge 0xCC").ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(6);

        private It should_only_return_records_where_code_is_greater_than_or_equal_to_0xCC = () => result.ShouldEachConformTo(o => o.Code >= 0xCC);
    }

    public class When_using_not_ge_filter_on_a_single_byte : SqlFiltering
    {
        private Because of = () => result = testDb.ConcreteCollection.LinqToQuerystring("?$filter=not Code ge 0xCC").ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(5);

        private It should_only_return_records_where_code_is_not_greater_than_or_equal_to_0xCC = () => result.ShouldEachConformTo(o => !(o.Code >= 0xCC));
    }

    public class When_using_lt_filter_on_a_single_byte : SqlFiltering
    {
        private Because of = () => result = testDb.ConcreteCollection.LinqToQuerystring("?$filter=Code lt 0xCC").ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(5);

        private It should_only_return_records_where_code_is_less_than_0xCC = () => result.ShouldEachConformTo(o => o.Code < 0xCC);
    }

    public class When_using_not_lt_filter_on_a_single_byte : SqlFiltering
    {
        private Because of = () => result = testDb.ConcreteCollection.LinqToQuerystring("?$filter=not Code lt 0xCC").ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(6);

        private It should_only_return_records_where_code_is_not_less_than_0xCC = () => result.ShouldEachConformTo(o => !(o.Code < 0xCC));
    }

    public class When_using_le_filter_on_a_single_byte : SqlFiltering
    {
        private Because of = () => result = testDb.ConcreteCollection.LinqToQuerystring("?$filter=Code le 0xCC").ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(8);

        private It should_only_return_records_where_code_is_less_than_or_equal_to_0xCC = () => result.ShouldEachConformTo(o => o.Code <= 0xCC);
    }

    public class When_using_not_le_filter_on_a_single_byte : SqlFiltering
    {
        private Because of = () => result = testDb.ConcreteCollection.LinqToQuerystring("?$filter=not Code le 0xCC").ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(3);

        private It should_only_return_records_where_code_is_not_less_than_or_equal_to_0xCC = () => result.ShouldEachConformTo(o => !(o.Code <= 0000000000));
    }

    #endregion

    #region Filter on guid tests

    public class When_using_eq_filter_on_a_single_guid : SqlFiltering
    {
        private Because of = () => result = testDb.ConcreteCollection.LinqToQuerystring(string.Format("?$filter=Guid eq guid'{0}'", guidArray[1])).ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(2);

        private It should_only_return_records_where_guid_matches = () => result.ShouldEachConformTo(o => o.Guid == guidArray[1]);
    }

    public class When_using_not_eq_filter_on_a_single_guid : SqlFiltering
    {
        private Because of = () => result = testDb.ConcreteCollection.LinqToQuerystring(string.Format("?$filter=not Guid eq guid'{0}'", guidArray[1])).ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(9);

        private It should_only_return_records_where_guid_matches = () => result.ShouldEachConformTo(o => o.Guid != guidArray[1]);
    }

    public class When_using_ne_filter_on_a_single_guid : SqlFiltering
    {
        private Because of = () => result = testDb.ConcreteCollection.LinqToQuerystring(string.Format("?$filter=Guid ne guid'{0}'", guidArray[1])).ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(9);

        private It should_only_return_records_where_guid_matches = () => result.ShouldEachConformTo(o => o.Guid != guidArray[1]);
    }

    public class When_using_not_ne_filter_on_a_single_guid : SqlFiltering
    {
        private Because of = () => result = testDb.ConcreteCollection.LinqToQuerystring(string.Format("?$filter=not Guid ne guid'{0}'", guidArray[1])).ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(2);

        private It should_only_return_records_where_guid_matches = () => result.ShouldEachConformTo(o => o.Guid == guidArray[1]);
    }

    #endregion

    #region Filter on single tests

    public class When_using_eq_filter_on_a_single_single : SqlFiltering
    {
        private Because of = () => result = testDb.ConcreteCollection.LinqToQuerystring("?$filter=Cost eq 444.444f").ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(2);

        private It should_only_return_records_where_cost_is_444point444 = () => result.ShouldEachConformTo(o => o.Cost == 444.444f);
    }

    public class When_using_eq_filter_on_a_negative_single : SqlFiltering
    {
        private Because of = () => result = testDb.ConcreteCollection.AsQueryable().LinqToQuerystring("?$filter=Cost gt -444.444f").ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(11);

        private It should_only_return_records_where_age_is_4 = () => result.ShouldEachConformTo(o => o.Cost > -444.444f);
    }

    public class When_using_not_eq_filter_on_a_single_single : SqlFiltering
    {
        private Because of = () => result = testDb.ConcreteCollection.LinqToQuerystring("?$filter=not Cost eq 444.444f").ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(9);

        private It should_only_return_records_where_cost_is_not_444point444 = () => result.ShouldEachConformTo(o => o.Cost != 444.444f);
    }

    public class When_using_ne_filter_on_a_single_single : SqlFiltering
    {
        private Because of = () => result = testDb.ConcreteCollection.LinqToQuerystring("?$filter=Cost ne 444.444f").ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(9);

        private It should_only_return_records_where_cost_is_not_444point444 = () => result.ShouldEachConformTo(o => o.Cost != 444.444f);
    }

    public class When_using_not_ne_filter_on_a_single_single : SqlFiltering
    {
        private Because of = () => result = testDb.ConcreteCollection.LinqToQuerystring("?$filter=not Cost ne 444.444f").ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(2);

        private It should_only_return_records_where_cost_is_444point444 = () => result.ShouldEachConformTo(o => o.Cost == 444.444f);
    }

    public class When_using_gt_filter_on_a_single_single : SqlFiltering
    {
        private Because of = () => result = testDb.ConcreteCollection.LinqToQuerystring("?$filter=Cost gt 333.333f").ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(3);

        private It should_only_return_records_where_cost_is_greater_than_333point333 = () => result.ShouldEachConformTo(o => o.Cost > 333.333f);
    }

    public class When_using_not_gt_filter_on_a_single_single : SqlFiltering
    {
        private Because of = () => result = testDb.ConcreteCollection.LinqToQuerystring("?$filter=not Cost gt 333.333f").ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(8);

        private It should_only_return_records_where_cost_is_not_greater_than_333point333 = () => result.ShouldEachConformTo(o => !(o.Cost > 333.333f));
    }

    public class When_using_ge_filter_on_a_single_single : SqlFiltering
    {
        private Because of = () => result = testDb.ConcreteCollection.LinqToQuerystring("?$filter=Cost ge 333.333f").ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(6);

        private It should_only_return_records_where_cost_is_greater_than_or_equal_to_333point333 = () => result.ShouldEachConformTo(o => o.Cost >= 333.333f);
    }

    public class When_using_not_ge_filter_on_a_single_single : SqlFiltering
    {
        private Because of = () => result = testDb.ConcreteCollection.LinqToQuerystring("?$filter=not Cost ge 333.333f").ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(5);

        private It should_only_return_records_where_cost_is_not_greater_than_or_equal_to_333point333 = () => result.ShouldEachConformTo(o => !(o.Cost >= 333.333f));
    }

    public class When_using_lt_filter_on_a_single_single : SqlFiltering
    {
        private Because of = () => result = testDb.ConcreteCollection.LinqToQuerystring("?$filter=Cost lt 333.333f").ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(5);

        private It should_only_return_records_where_cost_is_less_than_333point333 = () => result.ShouldEachConformTo(o => o.Cost < 333.333f);
    }

    public class When_using_not_lt_filter_on_a_single_single : SqlFiltering
    {
        private Because of = () => result = testDb.ConcreteCollection.LinqToQuerystring("?$filter=not Cost lt 333.333f").ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(6);

        private It should_only_return_records_where_cost_is_not_less_than_333point333 = () => result.ShouldEachConformTo(o => !(o.Cost < 333.333f));
    }

    public class When_using_le_filter_on_a_single_single : SqlFiltering
    {
        private Because of = () => result = testDb.ConcreteCollection.LinqToQuerystring("?$filter=Cost le 333.333f").ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(8);

        private It should_only_return_records_where_cost_is_less_than_or_equal_to_333point333 = () => result.ShouldEachConformTo(o => o.Cost <= 333.333f);
    }

    public class When_using_not_le_filter_on_a_single_single : SqlFiltering
    {
        private Because of = () => result = testDb.ConcreteCollection.LinqToQuerystring("?$filter=not Cost le 333.333f").ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(3);

        private It should_only_return_records_where_cost_is_not_less_than_or_equal_to_333point333 = () => result.ShouldEachConformTo(o => !(o.Cost <= 333.333f));
    }

    #endregion

    #region Filter on double tests

    public class When_using_eq_filter_on_a_single_double : SqlFiltering
    {
        private Because of = () => result = testDb.ConcreteCollection.LinqToQuerystring("?$filter=Value eq 444.444").ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(2);

        private It should_only_return_records_where_value_is_444point444 = () => result.ShouldEachConformTo(o => o.Value == 444.444);
    }

    public class When_using_eq_filter_on_a_negative_double : SqlFiltering
    {
        private Because of = () => result = testDb.ConcreteCollection.AsQueryable().LinqToQuerystring("?$filter=Cost gt -444.444").ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(11);

        private It should_only_return_records_where_age_is_4 = () => result.ShouldEachConformTo(o => o.Cost > -444.444);
    }

    public class When_using_not_eq_filter_on_a_single_double : SqlFiltering
    {
        private Because of = () => result = testDb.ConcreteCollection.LinqToQuerystring("?$filter=not Value eq 444.444").ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(9);

        private It should_only_return_records_where_value_is_not_444point444 = () => result.ShouldEachConformTo(o => o.Value != 444.444);
    }

    public class When_using_ne_filter_on_a_single_double : SqlFiltering
    {
        private Because of = () => result = testDb.ConcreteCollection.LinqToQuerystring("?$filter=Value ne 444.444").ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(9);

        private It should_only_return_records_where_value_is_not_444point444 = () => result.ShouldEachConformTo(o => o.Value != 444.444);
    }

    public class When_using_not_ne_filter_on_a_single_double : SqlFiltering
    {
        private Because of = () => result = testDb.ConcreteCollection.LinqToQuerystring("?$filter=not Value ne 444.444").ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(2);

        private It should_only_return_records_where_value_is_444point444 = () => result.ShouldEachConformTo(o => o.Value == 444.444);
    }

    public class When_using_gt_filter_on_a_single_double : SqlFiltering
    {
        private Because of = () => result = testDb.ConcreteCollection.LinqToQuerystring("?$filter=Value gt 333.333").ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(3);

        private It should_only_return_records_where_value_is_greater_than_333point333 = () => result.ShouldEachConformTo(o => o.Value > 333.333);
    }

    public class When_using_not_gt_filter_on_a_single_double : SqlFiltering
    {
        private Because of = () => result = testDb.ConcreteCollection.LinqToQuerystring("?$filter=not Value gt 333.333").ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(8);

        private It should_only_return_records_where_value_is_not_greater_than_333point333 = () => result.ShouldEachConformTo(o => !(o.Value > 333.333));
    }

    public class When_using_ge_filter_on_a_single_double : SqlFiltering
    {
        private Because of = () => result = testDb.ConcreteCollection.LinqToQuerystring("?$filter=Value ge 333.333").ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(6);

        private It should_only_return_records_where_value_is_greater_than_or_equal_to_333point333 = () => result.ShouldEachConformTo(o => o.Value >= 333.333);
    }

    public class When_using_not_ge_filter_on_a_single_double : SqlFiltering
    {
        private Because of = () => result = testDb.ConcreteCollection.LinqToQuerystring("?$filter=not Value ge 333.333").ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(5);

        private It should_only_return_records_where_value_is_not_greater_than_or_equal_to_333point333 = () => result.ShouldEachConformTo(o => !(o.Value >= 333.333));
    }

    public class When_using_lt_filter_on_a_single_double : SqlFiltering
    {
        private Because of = () => result = testDb.ConcreteCollection.LinqToQuerystring("?$filter=Value lt 333.333").ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(5);

        private It should_only_return_records_where_value_is_less_than_333point333 = () => result.ShouldEachConformTo(o => o.Value < 333.333);
    }

    public class When_using_not_lt_filter_on_a_single_double : SqlFiltering
    {
        private Because of = () => result = testDb.ConcreteCollection.LinqToQuerystring("?$filter=not Value lt 333.333").ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(6);

        private It should_only_return_records_where_value_is_not_less_than_333point333 = () => result.ShouldEachConformTo(o => !(o.Value < 333.333));
    }

    public class When_using_le_filter_on_a_single_double : SqlFiltering
    {
        private Because of = () => result = testDb.ConcreteCollection.LinqToQuerystring("?$filter=Value le 333.333").ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(8);

        private It should_only_return_records_where_value_is_less_than_or_equal_to_333point333 = () => result.ShouldEachConformTo(o => o.Value <= 333.333);
    }

    public class When_using_not_le_filter_on_a_single_double : SqlFiltering
    {
        private Because of = () => result = testDb.ConcreteCollection.LinqToQuerystring("?$filter=not Value le 333.333").ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(3);

        private It should_only_return_records_where_value_is_not_less_than_or_equal_to_333point333 = () => result.ShouldEachConformTo(o => !(o.Value <= 333.333));
    }

    #endregion

    #region Filter on date tests

    public class When_using_eq_filter_on_a_single_date : SqlFiltering
    {
        private Because of = () => result = testDb.ConcreteCollection.LinqToQuerystring("?$filter=Date eq datetime'2002-01-01T00:00'").ToList();

        private It should_return_three_records = () => result.Count().ShouldEqual(3);

        private It should_only_return_records_where_date_is_2002_01_01 = () => result.ShouldEachConformTo(o => o.Date == new DateTime(2002, 01, 01));
    }

    public class When_using_not_eq_filter_on_a_single_date : SqlFiltering
    {
        private Because of = () => result = testDb.ConcreteCollection.LinqToQuerystring("?$filter=not Date eq datetime'2002-01-01T00:00'").ToList();

        private It should_return_eight_records = () => result.Count().ShouldEqual(8);

        private It should_only_return_records_where_age_is_not_2002_01_01 = () => result.ShouldEachConformTo(o => o.Date != new DateTime(2002, 01, 01));
    }

    public class When_using_ne_filter_on_a_single_date : SqlFiltering
    {
        private Because of = () => result = testDb.ConcreteCollection.LinqToQuerystring("?$filter=Date ne datetime'2002-01-01T00:00'").ToList();

        private It should_return_eight_records = () => result.Count().ShouldEqual(8);

        private It should_only_return_records_where_age_is_not_2002_01_01 = () => result.ShouldEachConformTo(o => o.Date != new DateTime(2002, 01, 01));
    }

    public class When_using_not_ne_filter_on_a_single_date : SqlFiltering
    {
        private Because of = () => result = testDb.ConcreteCollection.LinqToQuerystring("?$filter=not Date ne datetime'2002-01-01T00:00'").ToList();

        private It should_return_three_records = () => result.Count().ShouldEqual(3);

        private It should_only_return_records_where_age_is_2002_01_01 = () => result.ShouldEachConformTo(o => o.Date == new DateTime(2002, 01, 01));
    }

    public class When_using_gt_filter_on_a_single_date : SqlFiltering
    {
        private Because of = () => result = testDb.ConcreteCollection.LinqToQuerystring("?$filter=Date gt datetime'2003-01-01T00:00'").ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(3);

        private It should_only_return_records_where_age_is_greater_than_3 = () => result.ShouldEachConformTo(o => o.Date > new DateTime(2003, 01, 01));
    }

    public class When_using_not_gt_filter_on_a_single_date : SqlFiltering
    {
        private Because of = () => result = testDb.ConcreteCollection.LinqToQuerystring("?$filter=not Date gt datetime'2003-01-01T00:00'").ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(8);

        private It should_only_return_records_where_age_is_not_greater_than_3 = () => result.ShouldEachConformTo(o => !(o.Date > new DateTime(2003, 01, 01)));
    }

    public class When_using_ge_filter_on_a_single_date : SqlFiltering
    {
        private Because of = () => result = testDb.ConcreteCollection.LinqToQuerystring("?$filter=Date ge datetime'2003-01-01T00:00'").ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(6);

        private It should_only_return_records_where_age_is_greater_than_or_equal_to_3 = () => result.ShouldEachConformTo(o => o.Date >= new DateTime(2003, 01, 01));
    }

    public class When_using_not_ge_filter_on_a_single_date : SqlFiltering
    {
        private Because of = () => result = testDb.ConcreteCollection.LinqToQuerystring("?$filter=not Date ge datetime'2003-01-01T00:00'").ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(5);

        private It should_only_return_records_where_age_is_not_greater_than_or_equal_to_3 = () => result.ShouldEachConformTo(o => !(o.Date >= new DateTime(2003, 01, 01)));
    }

    public class When_using_lt_filter_on_a_single_date : SqlFiltering
    {
        private Because of = () => result = testDb.ConcreteCollection.LinqToQuerystring("?$filter=Date lt datetime'2003-01-01T00:00'").ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(5);

        private It should_only_return_records_where_age_is_less_than_3 = () => result.ShouldEachConformTo(o => o.Date < new DateTime(2003, 01, 01));
    }

    public class When_using_not_lt_filter_on_a_single_date : SqlFiltering
    {
        private Because of = () => result = testDb.ConcreteCollection.LinqToQuerystring("?$filter=not Date lt datetime'2003-01-01T00:00'").ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(6);

        private It should_only_return_records_where_age_is_not_less_than_3 = () => result.ShouldEachConformTo(o => !(o.Date < new DateTime(2003, 01, 01)));
    }

    public class When_using_le_filter_on_a_single_date : SqlFiltering
    {
        private Because of = () => result = testDb.ConcreteCollection.LinqToQuerystring("?$filter=Date le datetime'2003-01-01T00:00'").ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(8);

        private It should_only_return_records_where_age_is_less_than_or_equal_to_3 = () => result.ShouldEachConformTo(o => o.Date <= new DateTime(2003, 01, 01));
    }

    public class When_using_not_le_filter_on_a_single_date : SqlFiltering
    {
        private Because of = () => result = testDb.ConcreteCollection.LinqToQuerystring("?$filter=not Date le datetime'2003-01-01T00:00'").ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(3);

        private It should_only_return_records_where_age_is_not_less_than_or_equal_to_3 = () => result.ShouldEachConformTo(o => !(o.Date <= new DateTime(2003, 01, 01)));
    }

    #endregion

    #region Filter on bool tests

    public class When_using_eq_filter_on_a_single_bool : SqlFiltering
    {
        private Because of = () => result = testDb.ConcreteCollection.LinqToQuerystring("?$filter=Complete eq true").ToList();

        private It should_return_three_records = () => result.Count().ShouldEqual(6);

        private It should_only_return_records_where_bool_is_2002_01_01 = () => result.ShouldEachConformTo(o => o.Complete);
    }

    public class When_using_not_eq_filter_on_a_single_bool : SqlFiltering
    {
        private Because of = () => result = testDb.ConcreteCollection.LinqToQuerystring("?$filter=not Complete eq true").ToList();

        private It should_return_eight_records = () => result.Count().ShouldEqual(5);

        private It should_only_return_records_where_age_is_not_2002_01_01 = () => result.ShouldEachConformTo(o => !o.Complete);
    }

    public class When_using_ne_filter_on_a_single_bool : SqlFiltering
    {
        private Because of = () => result = testDb.ConcreteCollection.LinqToQuerystring("?$filter=Complete ne true").ToList();

        private It should_return_eight_records = () => result.Count().ShouldEqual(5);

        private It should_only_return_records_where_age_is_not_2002_01_01 = () => result.ShouldEachConformTo(o => !o.Complete);
    }

    public class When_using_not_ne_filter_on_a_single_bool : SqlFiltering
    {
        private Because of = () => result = testDb.ConcreteCollection.LinqToQuerystring("?$filter=not Complete ne true").ToList();

        private It should_return_three_records = () => result.Count().ShouldEqual(6);

        private It should_only_return_records_where_age_is_2002_01_01 = () => result.ShouldEachConformTo(o => o.Complete);
    }

    #endregion

    #region Filter on nullable ints

    //eq
    public class When_using_eq_filter_on_a_single_nullable_int : SqlFiltering
    {
        private Because of = () => nullableResult = testDb.NullableCollection.LinqToQuerystring("?$filter=Age eq 1").ToList();

        private It should_return_the_correct_number_of_records = () => nullableResult.Count().ShouldEqual(1);

        private It should_only_return_matching_records = () => nullableResult.ShouldEachConformTo(o => o.Age == 1);
    }

    public class When_using_eq_filter_on_a_single_nullable_int_with_operands_reversed : SqlFiltering
    {
        private Because of = () => nullableResult = testDb.NullableCollection.LinqToQuerystring("?$filter=1 eq Age").ToList();

        private It should_return_the_correct_number_of_records = () => nullableResult.Count().ShouldEqual(1);

        private It should_only_return_matching_records = () => nullableResult.ShouldEachConformTo(o => o.Age == 1);
    }

    //ne
    public class When_using_ne_filter_on_a_single_nullable_int : SqlFiltering
    {
        private Because of = () => nullableResult = testDb.NullableCollection.LinqToQuerystring("?$filter=Age ne 1").ToList();

        private It should_return_the_correct_number_of_records = () => nullableResult.Count().ShouldEqual(1);

        private It should_only_return_matching_records = () => nullableResult.ShouldEachConformTo(o => o.Age != 1);
    }

    public class When_using_ne_filter_on_a_single_nullable_int_with_operands_reversed : SqlFiltering
    {
        private Because of = () => nullableResult = testDb.NullableCollection.LinqToQuerystring("?$filter=1 ne Age").ToList();

        private It should_return_the_correct_number_of_records = () => nullableResult.Count().ShouldEqual(1);

        private It should_only_return_matching_records = () => nullableResult.ShouldEachConformTo(o => o.Age != 1);
    }

    //gt
    public class When_using_gt_filter_on_a_single_nullable_int : SqlFiltering
    {
        private Because of = () => nullableResult = testDb.NullableCollection.LinqToQuerystring("?$filter=Age gt 0").ToList();

        private It should_return_the_correct_number_of_records = () => nullableResult.Count().ShouldEqual(1);

        private It should_only_return_matching_records = () => nullableResult.ShouldEachConformTo(o => o.Age > 0);
    }

    public class When_using_gt_filter_on_a_single_nullable_int_with_operands_reversed : SqlFiltering
    {
        private Because of = () => nullableResult = testDb.NullableCollection.LinqToQuerystring("?$filter=2 gt Age").ToList();

        private It should_return_the_correct_number_of_records = () => nullableResult.Count().ShouldEqual(1);

        private It should_only_return_matching_records = () => nullableResult.ShouldEachConformTo(o => 2 > o.Age);
    }

    //ge
    public class When_using_ge_filter_on_a_single_nullable_int : SqlFiltering
    {
        private Because of = () => nullableResult = testDb.NullableCollection.LinqToQuerystring("?$filter=Age ge 1").ToList();

        private It should_return_the_correct_number_of_records = () => nullableResult.Count().ShouldEqual(1);

        private It should_only_return_matching_records = () => nullableResult.ShouldEachConformTo(o => o.Age >= 1);
    }

    public class When_using_ge_filter_on_a_single_nullable_int_with_operands_reversed : SqlFiltering
    {
        private Because of = () => nullableResult = testDb.NullableCollection.LinqToQuerystring("?$filter=1 ge Age").ToList();

        private It should_return_the_correct_number_of_records = () => nullableResult.Count().ShouldEqual(1);

        private It should_only_return_matching_records = () => nullableResult.ShouldEachConformTo(o => 1 >= o.Age);
    }

    //lt
    public class When_using_lt_filter_on_a_single_nullable_int : SqlFiltering
    {
        private Because of = () => nullableResult = testDb.NullableCollection.LinqToQuerystring("?$filter=Age lt 2").ToList();

        private It should_return_the_correct_number_of_records = () => nullableResult.Count().ShouldEqual(1);

        private It should_only_return_matching_records = () => nullableResult.ShouldEachConformTo(o => o.Age < 2);
    }

    public class When_using_lt_filter_on_a_single_nullable_int_with_operands_reversed : SqlFiltering
    {
        private Because of = () => nullableResult = testDb.NullableCollection.LinqToQuerystring("?$filter=0 lt Age").ToList();

        private It should_return_the_correct_number_of_records = () => nullableResult.Count().ShouldEqual(1);

        private It should_only_return_matching_records = () => nullableResult.ShouldEachConformTo(o => 0 < o.Age);
    }

    //le
    public class When_using_le_filter_on_a_single_nullable_int : SqlFiltering
    {
        private Because of = () => nullableResult = testDb.NullableCollection.LinqToQuerystring("?$filter=Age le 1").ToList();

        private It should_return_the_correct_number_of_records = () => nullableResult.Count().ShouldEqual(1);

        private It should_only_return_matching_records = () => nullableResult.ShouldEachConformTo(o => o.Age == 1);
    }

    public class When_using_le_filter_on_a_single_nullable_int_with_operands_reversed : SqlFiltering
    {
        private Because of = () => nullableResult = testDb.NullableCollection.LinqToQuerystring("?$filter=1 le Age").ToList();

        private It should_return_the_correct_number_of_records = () => nullableResult.Count().ShouldEqual(1);

        private It should_only_return_matching_records = () => nullableResult.ShouldEachConformTo(o => 1 <= o.Age);
    }

    //not

    #endregion

    #region Filter with comparison to nulls

    //eq
    public class When_using_eq_filter_null_comparison : SqlFiltering
    {
        private Because of = () => nullableResult = testDb.NullableCollection.LinqToQuerystring("?$filter=Age eq null").ToList();

        private It should_return_the_correct_number_of_records = () => nullableResult.Count().ShouldEqual(1);

        private It should_only_return_matching_records = () => nullableResult.ShouldEachConformTo(o => o.Age == null);
    }

    public class When_using_eq_filter_null_comparison_with_operands_reversed : SqlFiltering
    {
        private Because of = () => nullableResult = testDb.NullableCollection.LinqToQuerystring("?$filter=null eq Age").ToList();

        private It should_return_the_correct_number_of_records = () => nullableResult.Count().ShouldEqual(1);

        private It should_only_return_matching_records = () => nullableResult.ShouldEachConformTo(o => o.Age == null);
    }

    //ne
    public class When_using_ne_filter_null_comparison : SqlFiltering
    {
        private Because of = () => nullableResult = testDb.NullableCollection.LinqToQuerystring("?$filter=Age ne null").ToList();

        private It should_return_the_correct_number_of_records = () => nullableResult.Count().ShouldEqual(1);

        private It should_only_return_matching_records = () => nullableResult.ShouldEachConformTo(o => o.Age != null);
    }

    public class When_using_ne_filter_null_comparison_with_operands_reversed : SqlFiltering
    {
        private Because of = () => nullableResult = testDb.NullableCollection.LinqToQuerystring("?$filter=null ne Age").ToList();

        private It should_return_the_correct_number_of_records = () => nullableResult.Count().ShouldEqual(1);

        private It should_only_return_matching_records = () => nullableResult.ShouldEachConformTo(o => o.Age != null);
    }

    //gt
    public class When_using_gt_filter_null_comparison : SqlFiltering
    {
        private Because of = () => nullableResult = testDb.NullableCollection.LinqToQuerystring("?$filter=Age gt null").ToList();

        private It should_return_0_records_because_null_is_not_valid_for_comparisons = () => nullableResult.Count().ShouldEqual(0);
    }

    public class When_using_gt_filter_null_comparison_with_operands_reversed : SqlFiltering
    {
        private Because of = () => nullableResult = testDb.NullableCollection.LinqToQuerystring("?$filter=null gt Age").ToList();

        private It should_return_0_records_because_null_is_not_valid_for_comparisons = () => nullableResult.Count().ShouldEqual(0);
    }

    //ge
    public class When_using_ge_filter_null_comparison : SqlFiltering
    {
        private Because of = () => nullableResult = testDb.NullableCollection.LinqToQuerystring("?$filter=Age ge null").ToList();

        private It should_return_0_records_because_null_is_not_valid_for_comparisons = () => nullableResult.Count().ShouldEqual(0);
    }

    public class When_using_ge_filter_null_comparison_with_operands_reversed : SqlFiltering
    {
        private Because of = () => nullableResult = testDb.NullableCollection.LinqToQuerystring("?$filter=null ge Age").ToList();

        private It should_return_0_records_because_null_is_not_valid_for_comparisons = () => nullableResult.Count().ShouldEqual(0);
    }

    //lt
    public class When_using_lt_filter_null_comparison : SqlFiltering
    {
        private Because of = () => nullableResult = testDb.NullableCollection.LinqToQuerystring("?$filter=Age lt null").ToList();

        private It should_return_0_records_because_null_is_not_valid_for_comparisons = () => nullableResult.Count().ShouldEqual(0);
    }

    public class When_using_lt_filter_null_comparison_with_operands_reversed : SqlFiltering
    {
        private Because of = () => nullableResult = testDb.NullableCollection.LinqToQuerystring("?$filter=null lt Age").ToList();

        private It should_return_0_records_because_null_is_not_valid_for_comparisons = () => nullableResult.Count().ShouldEqual(0);
    }

    //le
    public class When_using_le_filter_null_comparison : SqlFiltering
    {
        private Because of = () => nullableResult = testDb.NullableCollection.LinqToQuerystring("?$filter=Age le null").ToList();

        private It should_return_0_records_because_null_is_not_valid_for_comparisons = () => nullableResult.Count().ShouldEqual(0);
    }

    public class When_using_le_filter_null_comparison_with_operands_reversed : SqlFiltering
    {
        private Because of = () => nullableResult = testDb.NullableCollection.LinqToQuerystring("?$filter=null le Age").ToList();

        private It should_return_0_records_because_null_is_not_valid_for_comparisons = () => nullableResult.Count().ShouldEqual(0);
    }

    //not

    #endregion

    #region Filter on other nullable types

    public class When_using_eq_filter_on_a_single_nullable_date : SqlFiltering
    {
        private Because of = () => nullableResult = testDb.NullableCollection.LinqToQuerystring("?$filter=Date eq datetime'2002-01-01T00:00'").ToList();

        private It should_return_the_correct_number_of_records = () => nullableResult.Count().ShouldEqual(1);

        private It should_only_return_matching_records = () => nullableResult.ShouldEachConformTo(o => o.Date == new DateTime(2002, 01, 01));
    }

    public class When_using_eq_filter_on_a_single_nullable_bool_equal_true : SqlFiltering
    {
        private Because of = () => nullableResult = testDb.NullableCollection.LinqToQuerystring("?$filter=Complete eq true").ToList();

        private It should_return_the_correct_number_of_records = () => nullableResult.Count().ShouldEqual(1);

        private It should_only_return_matching_records = () => nullableResult.ShouldEachConformTo(o => o.Complete == true);
    }

    public class When_using_eq_filter_on_a_single_nullable_bool_implicit : SqlFiltering
    {
        private Because of = () => nullableResult = testDb.NullableCollection.LinqToQuerystring("?$filter=Complete").ToList();

        private It should_return_the_correct_number_of_records = () => nullableResult.Count().ShouldEqual(1);

        private It should_only_return_matching_records = () => nullableResult.ShouldEachConformTo(o => o.Complete == true);
    }

    public class When_using_eq_filter_on_a_single_nullable_bool_equal_false : SqlFiltering
    {
        private Because of = () => nullableResult = testDb.NullableCollection.LinqToQuerystring("?$filter=Complete eq false").ToList();

        private It should_return_the_correct_number_of_records = () => nullableResult.Count().ShouldEqual(0);

        private It should_only_return_matching_records = () => nullableResult.ShouldEachConformTo(o => o.Complete == false);
    }

    public class When_using_eq_filter_on_a_single_nullable_bool_not_true : SqlFiltering
    {
        private Because of = () => nullableResult = testDb.NullableCollection.LinqToQuerystring("?$filter=not Complete eq true").ToList();

        private It should_return_the_correct_number_of_records = () => nullableResult.Count().ShouldEqual(1);

        private It should_only_return_matching_records = () => nullableResult.ShouldEachConformTo(o => o.Complete != true);
    }

    public class When_using_eq_filter_on_a_single_nullable_bool_implicit_not : SqlFiltering
    {
        private Because of = () => nullableResult = testDb.NullableCollection.LinqToQuerystring("?$filter=not Complete").ToList();

        private It should_return_the_correct_number_of_records = () => nullableResult.Count().ShouldEqual(1);

        private It should_only_return_matching_records = () => nullableResult.ShouldEachConformTo(o => o.Complete != true);
    }

    public class When_using_eq_filter_on_a_single_nullable_bool_not_false : SqlFiltering
    {
        private Because of = () => nullableResult = testDb.NullableCollection.LinqToQuerystring("?$filter=not Complete eq false").ToList();

        private It should_return_the_correct_number_of_records = () => nullableResult.Count().ShouldEqual(2);

        private It should_only_return_matching_records = () => nullableResult.ShouldEachConformTo(o => o.Complete != false);
    }

    public class When_using_eq_filter_on_a_single_nullable_long : SqlFiltering
    {
        private Because of = () => nullableResult = testDb.NullableCollection.LinqToQuerystring("?$filter=Population eq 10000000000L").ToList();

        private It should_return_the_correct_number_of_records = () => nullableResult.Count().ShouldEqual(1);

        private It should_only_return_matching_records = () => nullableResult.ShouldEachConformTo(o => o.Population == 10000000000L);
    }

    public class When_using_eq_filter_on_a_single_nullable_double : SqlFiltering
    {
        private Because of = () => nullableResult = testDb.NullableCollection.LinqToQuerystring("?$filter=Value eq 111.111").ToList();

        private It should_return_the_correct_number_of_records = () => nullableResult.Count().ShouldEqual(1);

        private It should_only_return_matching_records = () => nullableResult.ShouldEachConformTo(o => o.Value == 111.111);
    }

    public class When_using_eq_filter_on_a_single_nullable_float : SqlFiltering
    {
        private Because of = () => nullableResult = testDb.NullableCollection.LinqToQuerystring("?$filter=Cost eq 111.111f").ToList();

        private It should_return_the_correct_number_of_records = () => nullableResult.Count().ShouldEqual(1);

        private It should_only_return_matching_records = () => nullableResult.ShouldEachConformTo(o => o.Cost == 111.111f);
    }

    public class When_using_eq_filter_on_a_single_nullable_byte : SqlFiltering
    {
        private Because of = () => nullableResult = testDb.NullableCollection.LinqToQuerystring("?$filter=Code eq 0x00").ToList();

        private It should_return_the_correct_number_of_records = () => nullableResult.Count().ShouldEqual(1);

        private It should_only_return_matching_records = () => nullableResult.ShouldEachConformTo(o => o.Code == 0x00);
    }

    public class When_using_eq_filter_on_a_single_nullable_guid : SqlFiltering
    {
        private Because of = () => nullableResult = testDb.NullableCollection.LinqToQuerystring(string.Format("?$filter=Guid eq guid'{0}'", guidArray[0])).ToList();

        private It should_return_the_correct_number_of_records = () => nullableResult.Count().ShouldEqual(1);

        private It should_only_return_matching_records = () => nullableResult.ShouldEachConformTo(o => o.Guid == guidArray[0]);
    }

    #endregion

    #region Simple Logic Tests

    public class When_anding_two_filters_together : SqlFiltering
    {
        private Because of =
            () => result = testDb.ConcreteCollection.LinqToQuerystring("?$filter=Name eq 'Custard' and Age ge 2").ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(2);

        private It should_only_return_records_with_name_equal_to_custard =
            () => result.ShouldEachConformTo(o => o.Name == "Custard");

        private It should_only_return_records_with_age_greater_than_or_equal_to_2 =
            () => result.ShouldEachConformTo(o => o.Age >= 2);
    }

    public class When_anding_a_filter_and_a_not_filter : SqlFiltering
    {
        private Because of =
            () => result = testDb.ConcreteCollection.LinqToQuerystring("?$filter=Name eq 'Custard' and not Age lt 2").ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(2);

        private It should_only_return_records_with_name_equal_to_custard =
            () => result.ShouldEachConformTo(o => o.Name == "Custard");

        private It should_only_return_records_with_age_greater_than_or_equal_to_2 =
            () => result.ShouldEachConformTo(o => o.Age >= 2);
    }

    public class When_oring_two_filters_together : SqlFiltering
    {
        private Because of =
            () => result = testDb.ConcreteCollection.LinqToQuerystring("?$filter=Name eq 'Banana' or Date gt datetime'2003-01-01T00:00'").ToList();

        private It should_return_four_records = () => result.Count().ShouldEqual(4);

        private It should_only_return_records_with_name_equal_to_banana_or_date_greater_than_2003_01_01 =
            () => result.ShouldEachConformTo(o => o.Name == "Banana" || o.Date > new DateTime(2003, 01, 01));
    }

    public class When_oring_a_filter_and_a_not_filter : SqlFiltering
    {
        private Because of =
            () => result = testDb.ConcreteCollection.LinqToQuerystring("?$filter=Name eq 'Banana' or not Date le datetime'2003-01-01T00:00'").ToList();

        private It should_return_four_records = () => result.Count().ShouldEqual(4);

        private It should_only_return_records_with_name_equal_to_banana_or_date_greater_than_2003_01_01 =
            () => result.ShouldEachConformTo(o => o.Name == "Banana" || o.Date > new DateTime(2003, 01, 01));
    }

    #endregion

    #region Operator Precedence and Parenthesis tests

    public class When_combining_and_or_filters_together : SqlFiltering
    {
        private Because of =
            () => result = testDb.ConcreteCollection.LinqToQuerystring("?$filter=Name eq 'Apple' and Complete eq true or Date gt datetime'2003-01-01T00:00'").ToList();

        private It should_return_four_records = () => result.Count().ShouldEqual(4);

        private It should_only_return_records_with_name_equal_to_apples_complete_equal_to_true_or_date_greater_than_2003_01_01 =
            () => result.ShouldEachConformTo(o => o.Name == "Apple" && o.Complete || o.Date > new DateTime(2003, 01, 01));
    }

    public class When_combining_and_or_not_filters_together : SqlFiltering
    {
        private Because of =
            () => result = testDb.ConcreteCollection.LinqToQuerystring("?$filter=Name eq 'Apple' and Complete eq true or not Date le datetime'2003-01-01T00:00'").ToList();

        private It should_return_four_records = () => result.Count().ShouldEqual(4);

        private It
            should_only_return_records_with_name_equal_to_apples_complete_equal_to_true_or_date_not_less_than_2003_01_01
                = () => result.ShouldEachConformTo(o => o.Name == "Apple" && o.Complete || !(o.Date <= new DateTime(2003, 01, 01)));
    }

    public class When_using_parenthesis : SqlFiltering
    {
        private Because of =
            () => result = testDb.ConcreteCollection.LinqToQuerystring("?$filter=Name eq 'Apple' and (Complete eq true or Date gt datetime'2003-01-01T00:00')").ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(2);

        private It should_only_return_records_with_name_equal_to_custard_and_result_of_complete_equals_true_or_date_greater_than_2003_01_01 =
            () => result.ShouldEachConformTo(o => o.Name == "Apple" && (o.Complete || o.Date > new DateTime(2003, 01, 01)));
    }

    public class When_notting_an_entire_parenthesised_expression : SqlFiltering
    {
        private Because of =
            () => result = testDb.ConcreteCollection.LinqToQuerystring("?$filter=not (Name eq 'Apple' and (Complete eq true or Date gt datetime'2003-01-01T00:00'))").ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(9);

        private It should_only_return_records_with_name_equal_to_custard_and_result_of_complete_equals_true_or_date_greater_than_2003_01_01 =
            () => result.ShouldEachConformTo(o => !(o.Name == "Apple" && (o.Complete || o.Date > new DateTime(2003, 01, 01))));
    }

    #endregion
}
