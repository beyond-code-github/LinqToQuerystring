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

        protected static List<ConcreteClass> concreteCollection;

        protected static List<EdgeCaseClass> edgeCaseCollection;

        private Establish context = () =>
        {
            testDb = new TestDbContext();
            Database.SetInitializer(new DropCreateDatabaseAlways<TestDbContext>());
            testDb.Database.Initialize(true);

            testDb.ConcreteCollection.Add(InstanceBuilders.BuildConcrete("Apple", 1, new DateTime(2002, 01, 01), true));
            testDb.ConcreteCollection.Add(InstanceBuilders.BuildConcrete("Apple", 2, new DateTime(2005, 01, 01), false));
            testDb.ConcreteCollection.Add(InstanceBuilders.BuildConcrete("Custard", 1, new DateTime(2003, 01, 01), true));
            testDb.ConcreteCollection.Add(InstanceBuilders.BuildConcrete("Custard", 2, new DateTime(2002, 01, 01), false));
            testDb.ConcreteCollection.Add(InstanceBuilders.BuildConcrete("Custard", 3, new DateTime(2002, 01, 01), true));
            testDb.ConcreteCollection.Add(InstanceBuilders.BuildConcrete("Banana", 3, new DateTime(2003, 01, 01), false));
            testDb.ConcreteCollection.Add(InstanceBuilders.BuildConcrete("Eggs", 1, new DateTime(2005, 01, 01), true));
            testDb.ConcreteCollection.Add(InstanceBuilders.BuildConcrete("Eggs", 3, new DateTime(2001, 01, 01), false));
            testDb.ConcreteCollection.Add(InstanceBuilders.BuildConcrete("Dogfood", 4, new DateTime(2003, 01, 01), true));
            testDb.ConcreteCollection.Add(InstanceBuilders.BuildConcrete("Dogfood", 4, new DateTime(2004, 01, 01), false));
            testDb.ConcreteCollection.Add(InstanceBuilders.BuildConcrete("Dogfood", 5, new DateTime(2001, 01, 01), true));

            testDb.EdgeCaseCollection.Add(InstanceBuilders.BuildEdgeCase("Apple\\Bob", 1, new DateTime(2002, 01, 01), true));
            testDb.EdgeCaseCollection.Add(InstanceBuilders.BuildEdgeCase("Apple\bBob", 1, new DateTime(2002, 01, 01), true));
            testDb.EdgeCaseCollection.Add(InstanceBuilders.BuildEdgeCase("Apple\tBob", 1, new DateTime(2002, 01, 01), true));
            testDb.EdgeCaseCollection.Add(InstanceBuilders.BuildEdgeCase("Apple\nBob", 1, new DateTime(2002, 01, 01), true));
            testDb.EdgeCaseCollection.Add(InstanceBuilders.BuildEdgeCase("Apple\fBob", 1, new DateTime(2002, 01, 01), true));
            testDb.EdgeCaseCollection.Add(InstanceBuilders.BuildEdgeCase("Apple\rBob", 1, new DateTime(2002, 01, 01), true));
            testDb.EdgeCaseCollection.Add(InstanceBuilders.BuildEdgeCase("Apple\"Bob", 1, new DateTime(2002, 01, 01), true));
            testDb.EdgeCaseCollection.Add(InstanceBuilders.BuildEdgeCase("Apple'Bob", 1, new DateTime(2002, 01, 01), true));

            testDb.SaveChanges();

            concreteCollection = testDb.ConcreteCollection.ToList();
            edgeCaseCollection = testDb.EdgeCaseCollection.ToList();
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
