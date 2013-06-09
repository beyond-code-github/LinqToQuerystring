namespace LinqToQuerystring.IntegrationTests.Mongo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Machine.Specifications;

    using MongoDB.Bson;
    using MongoDB.Driver;
    using MongoDB.Driver.Linq;

    public abstract class MongoFiltering
    {
        private static MongoServer server;

        private static MongoDatabase database;

        protected static List<MongoDocument> result;

        protected static List<MongoDocument> concreteCollection;

        protected static IQueryable<MongoDocument> edgeCaseCollection;

        protected static IQueryable<MongoDocument> collection;

        protected static Guid[] guidArray;

        private Cleanup cleanup = () =>
            {
                var mongoCollection = database.GetCollection<MongoDocument>("Dynamic");
                mongoCollection.RemoveAll();

                var edgeCases = database.GetCollection<MongoDocument>("EdgeCases");
                edgeCases.RemoveAll();
            };

        private Establish context = () =>
            {
                Configuration.TypeConversionMap = (from, to) =>
                    {
                        if (from == typeof(byte) && to == typeof(BsonValue))
                        {
                            return typeof(int);
                        }

                        if (from == typeof(float) && to == typeof(BsonValue))
                        {
                            return typeof(double);
                        }

                        return Configuration.DefaultTypeConversionMap(from, to);
                    };

                guidArray = Enumerable.Range(1, 5).Select(o => Guid.NewGuid()).ToArray();

                server = MongoServer.Create("mongodb://localhost/LinqToQuerystring?safe=true");
                database = server.GetDatabase("LinqToQuerystring");

                var mongoCollection = database.GetCollection<MongoDocument>("Dynamic");

                mongoCollection.Insert(InstanceBuilders.BuildMongoDocument("Apple", 1, new DateTime(2002, 01, 01), true, 10000000000, 111.111, 111.111f, 0x00, guidArray[0]));
                mongoCollection.Insert(InstanceBuilders.BuildMongoDocument("Apple", 2, new DateTime(2005, 01, 01), false, 30000000000, 333.333, 333.333f, 0x22, guidArray[2]));
                mongoCollection.Insert(InstanceBuilders.BuildMongoDocument("Custard", 1, new DateTime(2003, 01, 01), true, 50000000000, 555.555, 555.555f, 0xDD, guidArray[4]));
                mongoCollection.Insert(InstanceBuilders.BuildMongoDocument("Custard", 2, new DateTime(2002, 01, 01), false, 30000000000, 333.333, 333.333f, 0x00, guidArray[2]));
                mongoCollection.Insert(InstanceBuilders.BuildMongoDocument("Custard", 3, new DateTime(2002, 01, 01), true, 40000000000, 444.444, 444.444f, 0x22, guidArray[3]));
                mongoCollection.Insert(InstanceBuilders.BuildMongoDocument("Banana", 3, new DateTime(2003, 01, 01), false, 10000000000, 111.111, 111.111f, 0x00, guidArray[0]));
                mongoCollection.Insert(InstanceBuilders.BuildMongoDocument("Eggs", 1, new DateTime(2005, 01, 01), true, 40000000000, 444.444, 444.444f, 0xCC, guidArray[3]));
                mongoCollection.Insert(InstanceBuilders.BuildMongoDocument("Eggs", 3, new DateTime(2001, 01, 01), false, 20000000000, 222.222, 222.222f, 0xCC, guidArray[1]));
                mongoCollection.Insert(InstanceBuilders.BuildMongoDocument("Dogfood", 4, new DateTime(2003, 01, 01), true, 30000000000, 333.333, 333.333f, 0xEE, guidArray[2]));
                mongoCollection.Insert(InstanceBuilders.BuildMongoDocument("Dogfood", 4, new DateTime(2004, 01, 01), false, 10000000000, 111.111, 111.111f, 0xDD, guidArray[0]));
                mongoCollection.Insert(InstanceBuilders.BuildMongoDocument("Dogfood", 5, new DateTime(2001, 01, 01), true, 20000000000, 222.222, 222.222f, 0xCC, guidArray[1]));

                var mongoEdgeCaseCollection = database.GetCollection<MongoDocument>("EdgeCases");

                mongoEdgeCaseCollection.Insert(InstanceBuilders.BuildEdgeCase("Apple\\Bob", 1, new DateTime(2002, 01, 01), true));
                mongoEdgeCaseCollection.Insert(InstanceBuilders.BuildEdgeCase("Apple\bBob", 1, new DateTime(2002, 01, 01), true));
                mongoEdgeCaseCollection.Insert(InstanceBuilders.BuildEdgeCase("Apple\tBob", 1, new DateTime(2002, 01, 01), true));
                mongoEdgeCaseCollection.Insert(InstanceBuilders.BuildEdgeCase("Apple\nBob", 1, new DateTime(2002, 01, 01), true));
                mongoEdgeCaseCollection.Insert(InstanceBuilders.BuildEdgeCase("Apple\fBob", 1, new DateTime(2002, 01, 01), true));
                mongoEdgeCaseCollection.Insert(InstanceBuilders.BuildEdgeCase("Apple\rBob", 1, new DateTime(2002, 01, 01), true));
                mongoEdgeCaseCollection.Insert(InstanceBuilders.BuildEdgeCase("Apple\"Bob", 1, new DateTime(2002, 01, 01), true));
                mongoEdgeCaseCollection.Insert(InstanceBuilders.BuildEdgeCase("Apple'Bob", 1, new DateTime(2002, 01, 01), true));

                collection = mongoCollection.AsQueryable();

                concreteCollection = collection.ToList();
                edgeCaseCollection = mongoEdgeCaseCollection.AsQueryable();
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

    public class When_using_eq_filter_on_a_single_string_with_reversed_parameters : MongoFiltering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$filter='Apple' eq Name", true).ToList();

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

    #region Filter on string escape character tests

    public class When_using_eq_filter_on_a_single_string_with_escaped_slash : MongoFiltering
    {
        private Because of =
            () => result = edgeCaseCollection.LinqToQuerystring(@"?$filter=Name eq 'Apple\\Bob'", true).ToList();

        private It should_return_one_record = () => result.Count().ShouldEqual(1);

        private It should_only_return_records_where_name_matches = () => result.ShouldEachConformTo(o => o["Name"] == "Apple\\Bob");
    }

    public class When_using_eq_filter_on_a_single_string_with_escaped_backspace : MongoFiltering
    {
        private Because of = () => result = edgeCaseCollection.LinqToQuerystring(@"?$filter=Name eq 'Apple\bBob'", true).ToList();

        private It should_return_one_record = () => result.Count().ShouldEqual(1);

        private It should_only_return_records_where_name_matches = () => result.ShouldEachConformTo(o => o["Name"] == "Apple\bBob");
    }

    public class When_using_eq_filter_on_a_single_string_with_escaped_tab : MongoFiltering
    {
        private Because of = () => result = edgeCaseCollection.LinqToQuerystring(@"?$filter=Name eq 'Apple\tBob'", true).ToList();

        private It should_return_one_record = () => result.Count().ShouldEqual(1);

        private It should_only_return_records_where_name_matches = () => result.ShouldEachConformTo(o => o["Name"] == "Apple\tBob");
    }

    public class When_using_eq_filter_on_a_single_string_with_escaped_newline : MongoFiltering
    {
        private Because of = () => result = edgeCaseCollection.LinqToQuerystring(@"?$filter=Name eq 'Apple\nBob'", true).ToList();

        private It should_return_one_record = () => result.Count().ShouldEqual(1);

        private It should_only_return_records_where_name_matches = () => result.ShouldEachConformTo(o => o["Name"] == "Apple\nBob");
    }

    public class When_using_eq_filter_on_a_single_string_with_escaped_formfeed : MongoFiltering
    {
        private Because of = () => result = edgeCaseCollection.LinqToQuerystring(@"?$filter=Name eq 'Apple\fBob'", true).ToList();

        private It should_return_one_record = () => result.Count().ShouldEqual(1);

        private It should_only_return_records_where_name_matches = () => result.ShouldEachConformTo(o => o["Name"] == "Apple\fBob");
    }

    public class When_using_eq_filter_on_a_single_string_with_escaped_carriage_return : MongoFiltering
    {
        private Because of = () => result = edgeCaseCollection.LinqToQuerystring(@"?$filter=Name eq 'Apple\rBob'", true).ToList();

        private It should_return_one_record = () => result.Count().ShouldEqual(1);

        private It should_only_return_records_where_name_matches = () => result.ShouldEachConformTo(o => o["Name"] == "Apple\rBob");
    }

    public class When_using_eq_filter_on_a_single_string_with_quote : MongoFiltering
    {
        private Because of = () => result = edgeCaseCollection.LinqToQuerystring(@"?$filter=Name eq 'Apple""Bob'", true).ToList();

        private It should_return_one_record = () => result.Count().ShouldEqual(1);

        private It should_only_return_records_where_name_matches = () => result.ShouldEachConformTo(o => o["Name"] == @"Apple""Bob");
    }

    public class When_using_eq_filter_on_a_single_string_with_double_escaped_single_quote : MongoFiltering
    {
        private Because of = () => result = edgeCaseCollection.LinqToQuerystring(@"?$filter=Name eq 'Apple''Bob'", true).ToList();

        private It should_return_one_record = () => result.Count().ShouldEqual(1);

        private It should_only_return_records_where_name_matches = () => result.ShouldEachConformTo(o => o["Name"] == "Apple'Bob");
    }

    public class When_using_eq_filter_on_a_single_string_with_escaped_single_quote : MongoFiltering
    {
        private Because of = () => result = edgeCaseCollection.LinqToQuerystring(@"?$filter=Name eq 'Apple\'Bob'", true).ToList();

        private It should_return_one_record = () => result.Count().ShouldEqual(1);

        private It should_only_return_records_where_name_matches = () => result.ShouldEachConformTo(o => o["Name"] == "Apple'Bob");
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

    #region Filter on long tests

    public class When_using_eq_filter_on_a_single_long : MongoFiltering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$filter=Population eq 40000000000L", true).ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(2);

        private It should_only_return_records_where_population_is_40000000000 = () => result.ShouldEachConformTo(o => o["Population"] == 40000000000);
    }

    public class When_using_not_eq_filter_on_a_single_long : MongoFiltering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$filter=not Population eq 40000000000L", true).ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(9);

        private It should_only_return_records_where_population_is_not_40000000000 = () => result.ShouldEachConformTo(o => o["Population"] != 40000000000);
    }

    public class When_using_ne_filter_on_a_single_long : MongoFiltering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$filter=Population ne 40000000000L", true).ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(9);

        private It should_only_return_records_where_population_is_not_40000000000 = () => result.ShouldEachConformTo(o => o["Population"] != 40000000000);
    }

    public class When_using_not_ne_filter_on_a_single_long : MongoFiltering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$filter=not Population ne 40000000000L", true).ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(2);

        private It should_only_return_records_where_population_is_40000000000 = () => result.ShouldEachConformTo(o => o["Population"] == 40000000000);
    }

    public class When_using_gt_filter_on_a_single_long : MongoFiltering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$filter=Population gt 30000000000L", true).ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(3);

        private It should_only_return_records_where_population_is_greater_than_30000000000 = () => result.ShouldEachConformTo(o => o["Population"] > 30000000000);
    }

    public class When_using_not_gt_filter_on_a_single_long : MongoFiltering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$filter=not Population gt 30000000000L", true).ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(8);

        private It should_only_return_records_where_population_is_not_greater_than_30000000000 = () => result.ShouldEachConformTo(o => !(o["Population"] > 30000000000));
    }

    public class When_using_ge_filter_on_a_single_long : MongoFiltering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$filter=Population ge 30000000000L", true).ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(6);

        private It should_only_return_records_where_population_is_greater_than_or_equal_to_30000000000 = () => result.ShouldEachConformTo(o => o["Population"] >= 30000000000);
    }

    public class When_using_not_ge_filter_on_a_single_long : MongoFiltering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$filter=not Population ge 30000000000L", true).ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(5);

        private It should_only_return_records_where_population_is_not_greater_than_or_equal_to_30000000000 = () => result.ShouldEachConformTo(o => !(o["Population"] >= 30000000000));
    }

    public class When_using_lt_filter_on_a_single_long : MongoFiltering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$filter=Population lt 30000000000L", true).ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(5);

        private It should_only_return_records_where_population_is_less_than_30000000000 = () => result.ShouldEachConformTo(o => o["Population"] < 30000000000);
    }

    public class When_using_not_lt_filter_on_a_single_long : MongoFiltering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$filter=not Population lt 30000000000L", true).ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(6);

        private It should_only_return_records_where_population_is_not_less_than_30000000000 = () => result.ShouldEachConformTo(o => !(o["Population"] < 30000000000));
    }

    public class When_using_le_filter_on_a_single_long : MongoFiltering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$filter=Population le 30000000000L", true).ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(8);

        private It should_only_return_records_where_population_is_less_than_or_equal_to_30000000000 = () => result.ShouldEachConformTo(o => o["Population"] <= 30000000000);
    }

    public class When_using_not_le_filter_on_a_single_long : MongoFiltering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$filter=not Population le 30000000000L", true).ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(3);

        private It should_only_return_records_where_population_is_not_less_than_or_equal_to_30000000000 = () => result.ShouldEachConformTo(o => !(o["Population"] <= 0000000000));
    }

    #endregion

    #region Filter on byte tests

    public class When_using_eq_filter_on_a_single_byte_numerically : MongoFiltering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$filter=Code eq 34", true).ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(2);

        private It should_only_return_records_where_code_is_0x22 = () => result.ShouldEachConformTo(o => o["Code"] == 0x22);
    }

    public class When_using_eq_filter_on_a_single_byte : MongoFiltering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$filter=Code eq 0x22", true).ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(2);

        private It should_only_return_records_where_code_is_0x22 = () => result.ShouldEachConformTo(o => o["Code"] == 0x22);
    }

    public class When_using_not_eq_filter_on_a_single_byte : MongoFiltering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$filter=not Code eq 0x22", true).ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(9);

        private It should_only_return_records_where_code_is_not_0x22 = () => result.ShouldEachConformTo(o => o["Code"] != 0x22);
    }

    public class When_using_ne_filter_on_a_single_byte : MongoFiltering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$filter=Code ne 0x22", true).ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(9);

        private It should_only_return_records_where_code_is_not_0x22 = () => result.ShouldEachConformTo(o => o["Code"] != 0x22);
    }

    public class When_using_not_ne_filter_on_a_single_byte : MongoFiltering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$filter=not Code ne 0x22", true).ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(2);

        private It should_only_return_records_where_code_is_0x22 = () => result.ShouldEachConformTo(o => o["Code"] == 0x22);
    }

    public class When_using_gt_filter_on_a_single_byte : MongoFiltering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$filter=Code gt 0xCC", true).ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(3);

        private It should_only_return_records_where_code_is_greater_than_0xCC = () => result.ShouldEachConformTo(o => o["Code"] > 0xCC);
    }

    public class When_using_not_gt_filter_on_a_single_byte : MongoFiltering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$filter=not Code gt 0xCC", true).ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(8);

        private It should_only_return_records_where_code_is_not_greater_than_0xCC = () => result.ShouldEachConformTo(o => !(o["Code"] > 0xCC));
    }

    public class When_using_ge_filter_on_a_single_byte : MongoFiltering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$filter=Code ge 0xCC", true).ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(6);

        private It should_only_return_records_where_code_is_greater_than_or_equal_to_0xCC = () => result.ShouldEachConformTo(o => o["Code"] >= 0xCC);
    }

    public class When_using_not_ge_filter_on_a_single_byte : MongoFiltering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$filter=not Code ge 0xCC", true).ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(5);

        private It should_only_return_records_where_code_is_not_greater_than_or_equal_to_0xCC = () => result.ShouldEachConformTo(o => !(o["Code"] >= 0xCC));
    }

    public class When_using_lt_filter_on_a_single_byte : MongoFiltering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$filter=Code lt 0xCC", true).ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(5);

        private It should_only_return_records_where_code_is_less_than_0xCC = () => result.ShouldEachConformTo(o => o["Code"] < 0xCC);
    }

    public class When_using_not_lt_filter_on_a_single_byte : MongoFiltering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$filter=not Code lt 0xCC", true).ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(6);

        private It should_only_return_records_where_code_is_not_less_than_0xCC = () => result.ShouldEachConformTo(o => !(o["Code"] < 0xCC));
    }

    public class When_using_le_filter_on_a_single_byte : MongoFiltering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$filter=Code le 0xCC", true).ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(8);

        private It should_only_return_records_where_code_is_less_than_or_equal_to_0xCC = () => result.ShouldEachConformTo(o => o["Code"] <= 0xCC);
    }

    public class When_using_not_le_filter_on_a_single_byte : MongoFiltering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$filter=not Code le 0xCC", true).ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(3);

        private It should_only_return_records_where_code_is_not_less_than_or_equal_to_0xCC = () => result.ShouldEachConformTo(o => !(o["Code"] <= 0000000000));
    }

    #endregion

    #region Filter on guid tests

    public class When_using_eq_filter_on_a_single_guid : MongoFiltering
    {
        private Because of = () => result = collection.LinqToQuerystring(string.Format("?$filter=Guid eq guid'{0}'", guidArray[1]), true).ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(2);

        private It should_only_return_records_where_guid_matches = () => result.ShouldEachConformTo(o => o["Guid"] == guidArray[1]);
    }

    public class When_using_not_eq_filter_on_a_single_guid : MongoFiltering
    {
        private Because of = () => result = collection.LinqToQuerystring(string.Format("?$filter=not Guid eq guid'{0}'", guidArray[1]), true).ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(9);

        private It should_only_return_records_where_guid_matches = () => result.ShouldEachConformTo(o => o["Guid"] != guidArray[1]);
    }

    public class When_using_ne_filter_on_a_single_guid : MongoFiltering
    {
        private Because of = () => result = collection.LinqToQuerystring(string.Format("?$filter=Guid ne guid'{0}'", guidArray[1]), true).ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(9);

        private It should_only_return_records_where_guid_matches = () => result.ShouldEachConformTo(o => o["Guid"] != guidArray[1]);
    }

    public class When_using_not_ne_filter_on_a_single_guid : MongoFiltering
    {
        private Because of = () => result = collection.LinqToQuerystring(string.Format("?$filter=not Guid ne guid'{0}'", guidArray[1]), true).ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(2);

        private It should_only_return_records_where_guid_matches = () => result.ShouldEachConformTo(o => o["Guid"] == guidArray[1]);
    }

    #endregion

    #region Filter on single tests

    public class When_using_eq_filter_on_a_single_single : MongoFiltering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$filter=Cost eq 444.444f", true).ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(2);

        private It should_only_return_records_where_cost_is_444point444 = () => result.ShouldEachConformTo(o => o["Cost"] == 444.444f);
    }

    public class When_using_not_eq_filter_on_a_single_single : MongoFiltering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$filter=not Cost eq 444.444f", true).ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(9);

        private It should_only_return_records_where_cost_is_not_444point444 = () => result.ShouldEachConformTo(o => o["Cost"] != 444.444f);
    }

    public class When_using_ne_filter_on_a_single_single : MongoFiltering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$filter=Cost ne 444.444f", true).ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(9);

        private It should_only_return_records_where_cost_is_not_444point444 = () => result.ShouldEachConformTo(o => o["Cost"] != 444.444f);
    }

    public class When_using_not_ne_filter_on_a_single_single : MongoFiltering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$filter=not Cost ne 444.444f", true).ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(2);

        private It should_only_return_records_where_cost_is_444point444 = () => result.ShouldEachConformTo(o => o["Cost"] == 444.444f);
    }

    public class When_using_gt_filter_on_a_single_single : MongoFiltering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$filter=Cost gt 333.333f", true).ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(3);

        private It should_only_return_records_where_cost_is_greater_than_333point333 = () => result.ShouldEachConformTo(o => o["Cost"] > 333.333f);
    }

    public class When_using_not_gt_filter_on_a_single_single : MongoFiltering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$filter=not Cost gt 333.333f", true).ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(8);

        private It should_only_return_records_where_cost_is_not_greater_than_333point333 = () => result.ShouldEachConformTo(o => !(o["Cost"] > 333.333f));
    }

    public class When_using_ge_filter_on_a_single_single : MongoFiltering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$filter=Cost ge 333.333f", true).ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(6);

        private It should_only_return_records_where_cost_is_greater_than_or_equal_to_333point333 = () => result.ShouldEachConformTo(o => o["Cost"] >= 333.333f);
    }

    public class When_using_not_ge_filter_on_a_single_single : MongoFiltering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$filter=not Cost ge 333.333f", true).ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(5);

        private It should_only_return_records_where_cost_is_not_greater_than_or_equal_to_333point333 = () => result.ShouldEachConformTo(o => !(o["Cost"] >= 333.333f));
    }

    public class When_using_lt_filter_on_a_single_single : MongoFiltering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$filter=Cost lt 333.333f", true).ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(5);

        private It should_only_return_records_where_cost_is_less_than_333point333 = () => result.ShouldEachConformTo(o => o["Cost"] < 333.333f);
    }

    public class When_using_not_lt_filter_on_a_single_single : MongoFiltering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$filter=not Cost lt 333.333f", true).ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(6);

        private It should_only_return_records_where_cost_is_not_less_than_333point333 = () => result.ShouldEachConformTo(o => !(o["Cost"] < 333.333f));
    }

    public class When_using_le_filter_on_a_single_single : MongoFiltering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$filter=Cost le 333.333f", true).ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(8);

        private It should_only_return_records_where_cost_is_less_than_or_equal_to_333point333 = () => result.ShouldEachConformTo(o => o["Cost"] <= 333.333f);
    }

    public class When_using_not_le_filter_on_a_single_single : MongoFiltering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$filter=not Cost le 333.333f", true).ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(3);

        private It should_only_return_records_where_cost_is_not_less_than_or_equal_to_333point333 = () => result.ShouldEachConformTo(o => !(o["Cost"] <= 333.333f));
    }

    #endregion

    #region Filter on double tests

    public class When_using_eq_filter_on_a_single_double : MongoFiltering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$filter=Value eq 444.444", true).ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(2);

        private It should_only_return_records_where_value_is_444point444 = () => result.ShouldEachConformTo(o => o["Value"] == 444.444);
    }

    public class When_using_not_eq_filter_on_a_single_double : MongoFiltering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$filter=not Value eq 444.444", true).ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(9);

        private It should_only_return_records_where_value_is_not_444point444 = () => result.ShouldEachConformTo(o => o["Value"] != 444.444);
    }

    public class When_using_ne_filter_on_a_single_double : MongoFiltering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$filter=Value ne 444.444", true).ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(9);

        private It should_only_return_records_where_value_is_not_444point444 = () => result.ShouldEachConformTo(o => o["Value"] != 444.444);
    }

    public class When_using_not_ne_filter_on_a_single_double : MongoFiltering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$filter=not Value ne 444.444", true).ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(2);

        private It should_only_return_records_where_value_is_444point444 = () => result.ShouldEachConformTo(o => o["Value"] == 444.444);
    }

    public class When_using_gt_filter_on_a_single_double : MongoFiltering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$filter=Value gt 333.333", true).ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(3);

        private It should_only_return_records_where_value_is_greater_than_333point333 = () => result.ShouldEachConformTo(o => o["Value"] > 333.333);
    }

    public class When_using_not_gt_filter_on_a_single_double : MongoFiltering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$filter=not Value gt 333.333", true).ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(8);

        private It should_only_return_records_where_value_is_not_greater_than_333point333 = () => result.ShouldEachConformTo(o => !(o["Value"] > 333.333));
    }

    public class When_using_ge_filter_on_a_single_double : MongoFiltering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$filter=Value ge 333.333", true).ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(6);

        private It should_only_return_records_where_value_is_greater_than_or_equal_to_333point333 = () => result.ShouldEachConformTo(o => o["Value"] >= 333.333);
    }

    public class When_using_not_ge_filter_on_a_single_double : MongoFiltering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$filter=not Value ge 333.333", true).ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(5);

        private It should_only_return_records_where_value_is_not_greater_than_or_equal_to_333point333 = () => result.ShouldEachConformTo(o => !(o["Value"] >= 333.333));
    }

    public class When_using_lt_filter_on_a_single_double : MongoFiltering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$filter=Value lt 333.333", true).ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(5);

        private It should_only_return_records_where_value_is_less_than_333point333 = () => result.ShouldEachConformTo(o => o["Value"] < 333.333);
    }

    public class When_using_not_lt_filter_on_a_single_double : MongoFiltering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$filter=not Value lt 333.333", true).ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(6);

        private It should_only_return_records_where_value_is_not_less_than_333point333 = () => result.ShouldEachConformTo(o => !(o["Value"] < 333.333));
    }

    public class When_using_le_filter_on_a_single_double : MongoFiltering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$filter=Value le 333.333", true).ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(8);

        private It should_only_return_records_where_value_is_less_than_or_equal_to_333point333 = () => result.ShouldEachConformTo(o => o["Value"] <= 333.333);
    }

    public class When_using_not_le_filter_on_a_single_double : MongoFiltering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$filter=not Value le 333.333", true).ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(3);

        private It should_only_return_records_where_value_is_not_less_than_or_equal_to_333point333 = () => result.ShouldEachConformTo(o => !(o["Value"] <= 333.333));
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
