namespace LinqToQuerystring.IntegrationTests.Mongo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Machine.Specifications;

    using MongoDB.Driver;
    using MongoDB.Driver.Linq;

    public abstract class MongoFiltering
    {
        private static MongoServer server;

        private static MongoDatabase database;

        protected static List<MongoDocument> result;

        protected static List<MongoDocument> concreteCollection;

        protected static IQueryable<MongoDocument> collection;

        private Cleanup cleanup = () =>
            {
                var mongoCollection = database.GetCollection<MongoDocument>("Dynamic");
                mongoCollection.RemoveAll();
            };

        private Establish context = () =>
            {
                server = MongoServer.Create("mongodb://localhost/LinqToQuerystring?safe=true");
                database = server.GetDatabase("LinqToQuerystring");

                var mongoCollection = database.GetCollection<MongoDocument>("Dynamic");

                mongoCollection.Insert(InstanceBuilders.BuildMongoDocument("Apple", 1, new DateTime(2002, 01, 01), true));
                mongoCollection.Insert(InstanceBuilders.BuildMongoDocument("Apple", 2, new DateTime(2005, 01, 01), false));
                mongoCollection.Insert(InstanceBuilders.BuildMongoDocument("Custard", 1, new DateTime(2003, 01, 01), true));
                mongoCollection.Insert(InstanceBuilders.BuildMongoDocument("Custard", 2, new DateTime(2002, 01, 01), false));
                mongoCollection.Insert(InstanceBuilders.BuildMongoDocument("Custard", 3, new DateTime(2002, 01, 01), true));
                mongoCollection.Insert(InstanceBuilders.BuildMongoDocument("Banana", 3, new DateTime(2003, 01, 01), false));
                mongoCollection.Insert(InstanceBuilders.BuildMongoDocument("Eggs", 1, new DateTime(2005, 01, 01), true));
                mongoCollection.Insert(InstanceBuilders.BuildMongoDocument("Eggs", 3, new DateTime(2001, 01, 01), false));
                mongoCollection.Insert(InstanceBuilders.BuildMongoDocument("Dogfood", 4, new DateTime(2003, 01, 01), true));
                mongoCollection.Insert(InstanceBuilders.BuildMongoDocument("Dogfood", 4, new DateTime(2004, 01, 01), false));
                mongoCollection.Insert(InstanceBuilders.BuildMongoDocument("Dogfood", 5, new DateTime(2001, 01, 01), true));

                collection = mongoCollection.AsQueryable();
                concreteCollection = collection.ToList();
            };
    }

    #region Filter on implicit boolean identifiers

    public class When_specifying_no_filter : MongoFiltering
    {
        private Because of = () => result = collection.LinqToQuerystring("?foo=bar", true).ToList();

        private It should_return_all_records = () => result.Count().ShouldEqual(11);
    }

    public class When_specifying_a_single_boolean_identifier_as_a_filter : MongoFiltering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$filter=Complete", true).ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(6);

        private It should_only_return_records_where_name_is_apple = () => result.ShouldEachConformTo(o => o["Complete"].AsBoolean);
    }

    public class When_specifying_a_negated_single_boolean_identifier_as_a_filter : MongoFiltering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$filter=not Complete", true).ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(5);

        private It should_only_return_records_where_name_is_apple = () => result.ShouldEachConformTo(o => !o["Complete"].AsBoolean);
    }

    #endregion

    #region Filter on string tests

    public class When_using_eq_filter_on_a_single_string : MongoFiltering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$filter=Name eq 'Apple'", true).ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(2);

        private It should_only_return_records_where_name_is_apple = () => result.ShouldEachConformTo(o => o["Name"].AsString == "Apple");
    }

    public class When_using_not_eq_filter_on_a_single_string : MongoFiltering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$filter=not Name eq 'Apple'", true).ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(9);

        private It should_only_return_records_where_name_is_not_apple = () => result.ShouldEachConformTo(o => o["Name"].AsString != "Apple");
    }

    public class When_using_ne_filter_on_a_single_string : MongoFiltering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$filter=Name ne 'Apple'", true).ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(9);

        private It should_only_return_records_where_name_is_not_apple = () => result.ShouldEachConformTo(o => o["Name"].AsString != "Apple");
    }

    public class When_using_not_ne_filter_on_a_single_string : MongoFiltering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$filter=not Name ne 'Apple'", true).ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(2);

        private It should_only_return_records_where_name_is_apple = () => result.ShouldEachConformTo(o => o["Name"].AsString == "Apple");
    }

    #endregion

    #region Filter on int tests

    public class When_using_eq_filter_on_a_single_int : MongoFiltering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$filter=Age eq 4", true).ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(2);

        private It should_only_return_records_where_age_is_4 = () => result.ShouldEachConformTo(o => o["Age"].AsInt32 == 4);
    }

    public class When_using_not_eq_filter_on_a_single_int : MongoFiltering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$filter=not Age eq 4", true).ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(9);

        private It should_only_return_records_where_age_is_not_4 = () => result.ShouldEachConformTo(o => o["Age"].AsInt32 != 4);
    }

    public class When_using_ne_filter_on_a_single_int : MongoFiltering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$filter=Age ne 4", true).ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(9);

        private It should_only_return_records_where_age_is_not_4 = () => result.ShouldEachConformTo(o => o["Age"].AsInt32 != 4);
    }

    public class When_using_not_ne_filter_on_a_single_int : MongoFiltering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$filter=not Age ne 4", true).ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(2);

        private It should_only_return_records_where_age_is_4 = () => result.ShouldEachConformTo(o => o["Age"].AsInt32 == 4);
    }

    public class When_using_gt_filter_on_a_single_int : MongoFiltering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$filter=Age gt 3", true).ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(3);

        private It should_only_return_records_where_age_is_greater_than_3 = () => result.ShouldEachConformTo(o => o["Age"].AsInt32 > 3);
    }

    public class When_using_not_gt_filter_on_a_single_int : MongoFiltering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$filter=not Age gt 3", true).ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(8);

        private It should_only_return_records_where_age_is_not_greater_than_3 = () => result.ShouldEachConformTo(o => !(o["Age"].AsInt32 > 3));
    }

    public class When_using_ge_filter_on_a_single_int : MongoFiltering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$filter=Age ge 3", true).ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(6);

        private It should_only_return_records_where_age_is_greater_than_or_equal_to_3 = () => result.ShouldEachConformTo(o => o["Age"].AsInt32 >= 3);
    }

    public class When_using_not_ge_filter_on_a_single_int : MongoFiltering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$filter=not Age ge 3", true).ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(5);

        private It should_only_return_records_where_age_is_not_greater_than_or_equal_to_3 = () => result.ShouldEachConformTo(o => !(o["Age"].AsInt32 >= 3));
    }

    public class When_using_lt_filter_on_a_single_int : MongoFiltering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$filter=Age lt 3", true).ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(5);

        private It should_only_return_records_where_age_is_less_than_3 = () => result.ShouldEachConformTo(o => o["Age"].AsInt32 < 3);
    }

    public class When_using_not_lt_filter_on_a_single_int : MongoFiltering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$filter=not Age lt 3", true).ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(6);

        private It should_only_return_records_where_age_is_not_less_than_3 = () => result.ShouldEachConformTo(o => !(o["Age"].AsInt32 < 3));
    }

    public class When_using_le_filter_on_a_single_int : MongoFiltering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$filter=Age le 3", true).ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(8);

        private It should_only_return_records_where_age_is_less_than_or_equal_to_3 = () => result.ShouldEachConformTo(o => o["Age"].AsInt32 <= 3);
    }

    public class When_using_not_le_filter_on_a_single_int : MongoFiltering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$filter=not Age le 3", true).ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(3);

        private It should_only_return_records_where_age_is_not_less_than_or_equal_to_3 = () => result.ShouldEachConformTo(o => !(o["Age"].AsInt32 <= 3));
    }

    #endregion

    #region Filter on date tests

    public class When_using_eq_filter_on_a_single_date : MongoFiltering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$filter=Date eq datetime'2002-01-01T00:00'", true).ToList();

        private It should_return_three_records = () => result.Count().ShouldEqual(3);

        private It should_only_return_records_where_date_is_2002_01_01 = () => result.ShouldEachConformTo(o => o["Date"].AsDateTime == new DateTime(2002, 01, 01));
    }

    public class When_using_not_eq_filter_on_a_single_date : MongoFiltering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$filter=not Date eq datetime'2002-01-01T00:00'", true).ToList();

        private It should_return_eight_records = () => result.Count().ShouldEqual(8);

        private It should_only_return_records_where_age_is_not_2002_01_01 = () => result.ShouldEachConformTo(o => o["Date"].AsDateTime != new DateTime(2002, 01, 01));
    }

    public class When_using_ne_filter_on_a_single_date : MongoFiltering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$filter=Date ne datetime'2002-01-01T00:00'", true).ToList();

        private It should_return_eight_records = () => result.Count().ShouldEqual(8);

        private It should_only_return_records_where_age_is_not_2002_01_01 = () => result.ShouldEachConformTo(o => o["Date"].AsDateTime != new DateTime(2002, 01, 01));
    }

    public class When_using_not_ne_filter_on_a_single_date : MongoFiltering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$filter=not Date ne datetime'2002-01-01T00:00'", true).ToList();

        private It should_return_three_records = () => result.Count().ShouldEqual(3);

        private It should_only_return_records_where_age_is_2002_01_01 = () => result.ShouldEachConformTo(o => o["Date"].AsDateTime == new DateTime(2002, 01, 01));
    }

    public class When_using_gt_filter_on_a_single_date : MongoFiltering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$filter=Date gt datetime'2003-01-01T00:00'", true).ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(3);

        private It should_only_return_records_where_age_is_greater_than_3 = () => result.ShouldEachConformTo(o => o["Date"].AsDateTime > new DateTime(2003, 01, 01));
    }

    public class When_using_not_gt_filter_on_a_single_date : MongoFiltering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$filter=not Date gt datetime'2003-01-01T00:00'", true).ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(8);

        private It should_only_return_records_where_age_is_not_greater_than_3 = () => result.ShouldEachConformTo(o => !(o["Date"].AsDateTime > new DateTime(2003, 01, 01)));
    }

    public class When_using_ge_filter_on_a_single_date : MongoFiltering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$filter=Date ge datetime'2003-01-01T00:00'", true).ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(6);

        private It should_only_return_records_where_age_is_greater_than_or_equal_to_3 = () => result.ShouldEachConformTo(o => o["Date"].AsDateTime >= new DateTime(2003, 01, 01));
    }

    public class When_using_not_ge_filter_on_a_single_date : MongoFiltering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$filter=not Date ge datetime'2003-01-01T00:00'", true).ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(5);

        private It should_only_return_records_where_age_is_not_greater_than_or_equal_to_3 = () => result.ShouldEachConformTo(o => !(o["Date"].AsDateTime >= new DateTime(2003, 01, 01)));
    }

    public class When_using_lt_filter_on_a_single_date : MongoFiltering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$filter=Date lt datetime'2003-01-01T00:00'", true).ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(5);

        private It should_only_return_records_where_age_is_less_than_3 = () => result.ShouldEachConformTo(o => o["Date"].AsDateTime < new DateTime(2003, 01, 01));
    }

    public class When_using_not_lt_filter_on_a_single_date : MongoFiltering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$filter=not Date lt datetime'2003-01-01T00:00'", true).ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(6);

        private It should_only_return_records_where_age_is_not_less_than_3 = () => result.ShouldEachConformTo(o => !(o["Date"].AsDateTime < new DateTime(2003, 01, 01)));
    }

    public class When_using_le_filter_on_a_single_date : MongoFiltering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$filter=Date le datetime'2003-01-01T00:00'", true).ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(8);

        private It should_only_return_records_where_age_is_less_than_or_equal_to_3 = () => result.ShouldEachConformTo(o => o["Date"].AsDateTime <= new DateTime(2003, 01, 01));
    }

    public class When_using_not_le_filter_on_a_single_date : MongoFiltering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$filter=not Date le datetime'2003-01-01T00:00'", true).ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(3);

        private It should_only_return_records_where_age_is_not_less_than_or_equal_to_3 = () => result.ShouldEachConformTo(o => !(o["Date"].AsDateTime <= new DateTime(2003, 01, 01)));
    }

    #endregion

    #region Filter on bool tests

    public class When_using_eq_filter_on_a_single_bool : MongoFiltering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$filter=Complete eq true", true).ToList();

        private It should_return_three_records = () => result.Count().ShouldEqual(6);

        private It should_only_return_records_where_bool_is_2002_01_01 = () => result.ShouldEachConformTo(o => o["Complete"].AsBoolean);
    }

    public class When_using_not_eq_filter_on_a_single_bool : MongoFiltering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$filter=not Complete eq true", true).ToList();

        private It should_return_eight_records = () => result.Count().ShouldEqual(5);

        private It should_only_return_records_where_age_is_not_2002_01_01 = () => result.ShouldEachConformTo(o => !o["Complete"].AsBoolean);
    }

    public class When_using_ne_filter_on_a_single_bool : MongoFiltering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$filter=Complete ne true", true).ToList();

        private It should_return_eight_records = () => result.Count().ShouldEqual(5);

        private It should_only_return_records_where_age_is_not_2002_01_01 = () => result.ShouldEachConformTo(o => !o["Complete"].AsBoolean);
    }

    public class When_using_not_ne_filter_on_a_single_bool : MongoFiltering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$filter=not Complete ne true", true).ToList();

        private It should_return_three_records = () => result.Count().ShouldEqual(6);

        private It should_only_return_records_where_age_is_2002_01_01 = () => result.ShouldEachConformTo(o => o["Complete"].AsBoolean);
    }

    #endregion

    #region Simple Logic Tests

    public class When_anding_two_filters_together : MongoFiltering
    {
        private Because of =
            () => result = collection.LinqToQuerystring("?$filter=Name eq 'Custard' and Age ge 2", true).ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(2);

        private It should_only_return_records_with_name_equal_to_custard =
            () => result.ShouldEachConformTo(o => o["Name"].AsString == "Custard");

        private It should_only_return_records_with_age_greater_than_or_equal_to_2 =
            () => result.ShouldEachConformTo(o => o["Age"].AsInt32 >= 2);
    }

    public class When_anding_a_filter_and_a_not_filter : MongoFiltering
    {
        private Because of =
            () => result = collection.LinqToQuerystring("?$filter=Name eq 'Custard' and not Age lt 2", true).ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(2);

        private It should_only_return_records_with_name_equal_to_custard =
            () => result.ShouldEachConformTo(o => o["Name"].AsString == "Custard");

        private It should_only_return_records_with_age_greater_than_or_equal_to_2 =
            () => result.ShouldEachConformTo(o => o["Age"].AsInt32 >= 2);
    }

    public class When_oring_two_filters_together : MongoFiltering
    {
        private Because of =
            () => result = collection.LinqToQuerystring("?$filter=Name eq 'Banana' or Date gt datetime'2003-01-01T00:00'", true).ToList();

        private It should_return_four_records = () => result.Count().ShouldEqual(4);

        private It should_only_return_records_with_name_equal_to_banana_or_date_greater_than_2003_01_01 =
            () => result.ShouldEachConformTo(o => o["Name"].AsString == "Banana" || o["Date"].AsDateTime > new DateTime(2003, 01, 01));
    }

    public class When_oring_a_filter_and_a_not_filter : MongoFiltering
    {
        private Because of =
            () => result = collection.LinqToQuerystring("?$filter=Name eq 'Banana' or not Date le datetime'2003-01-01T00:00'", true).ToList();

        private It should_return_four_records = () => result.Count().ShouldEqual(4);

        private It should_only_return_records_with_name_equal_to_banana_or_date_greater_than_2003_01_01 =
            () => result.ShouldEachConformTo(o => o["Name"].AsString == "Banana" || o["Date"].AsDateTime > new DateTime(2003, 01, 01));
    }

    #endregion

    #region Operator Precedence and Parenthesis tests

    public class When_combining_and_or_filters_together : MongoFiltering
    {
        private Because of =
            () => result = collection.LinqToQuerystring("?$filter=Name eq 'Apple' and Complete eq true or Date gt datetime'2003-01-01T00:00'", true).ToList();

        private It should_return_four_records = () => result.Count().ShouldEqual(4);

        private It should_only_return_records_with_name_equal_to_apples_complete_equal_to_true_or_date_greater_than_2003_01_01 =
            () => result.ShouldEachConformTo(o => o["Name"].AsString == "Apple" && o["Complete"].AsBoolean || o["Date"].AsDateTime > new DateTime(2003, 01, 01));
    }

    public class When_combining_and_or_not_filters_together : MongoFiltering
    {
        private Because of =
            () => result = collection.LinqToQuerystring("?$filter=Name eq 'Apple' and Complete eq true or not Date le datetime'2003-01-01T00:00'", true).ToList();

        private It should_return_four_records = () => result.Count().ShouldEqual(4);

        private It
            should_only_return_records_with_name_equal_to_apples_complete_equal_to_true_or_date_not_less_than_2003_01_01
                = () => result.ShouldEachConformTo(o => o["Name"].AsString == "Apple" && o["Complete"].AsBoolean || !(o["Date"].AsDateTime <= new DateTime(2003, 01, 01)));
    }

    public class When_using_parenthesis : MongoFiltering
    {
        private Because of =
            () => result = collection.LinqToQuerystring("?$filter=Name eq 'Apple' and (Complete eq true or Date gt datetime'2003-01-01T00:00')", true).ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(2);

        private It should_only_return_records_with_name_equal_to_custard_and_result_of_complete_equals_true_or_date_greater_than_2003_01_01 =
            () => result.ShouldEachConformTo(o => o["Name"].AsString == "Apple" && (o["Complete"].AsBoolean || o["Date"].AsDateTime > new DateTime(2003, 01, 01)));
    }

    public class When_notting_an_entire_parenthesised_expression : MongoFiltering
    {
        private Because of =
            () => result = collection.LinqToQuerystring("?$filter=not (Name eq 'Apple' and (Complete eq true or Date gt datetime'2003-01-01T00:00'))", true).ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(9);

        private It should_only_return_records_with_name_equal_to_custard_and_result_of_complete_equals_true_or_date_greater_than_2003_01_01 =
            () => result.ShouldEachConformTo(o => !(o["Name"].AsString == "Apple" && (o["Complete"].AsBoolean || o["Date"].AsDateTime > new DateTime(2003, 01, 01))));
    }

    #endregion
}
