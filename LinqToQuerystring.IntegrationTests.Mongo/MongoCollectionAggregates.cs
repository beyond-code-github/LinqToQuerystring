namespace LinqToQuerystring.IntegrationTests.Mongo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Machine.Specifications;

    using MongoDB.Bson;
    using MongoDB.Driver;
    using MongoDB.Driver.Linq;

    public abstract class MongoCollectionAggregates
    {
        protected static Exception ex;

        private static MongoServer server;

        private static MongoDatabase database;

        protected static List<MongoDocument> result;

        protected static IQueryable<MongoDocument> collection;

        private Cleanup cleanup = () =>
        {
            var mongoCollection = database.GetCollection<MongoDocument>("Dynamic");
            mongoCollection.RemoveAll();
        };

        private Establish context = () =>
            {
                Configuration.MapTypeForEnumerable = (type) =>
                    {
                        if (type == typeof(BsonValue))
                        {
                            return typeof(MongoDocument);
                        }

                        return Configuration.DefaultMapTypeForEnumerable(type);
                    };

                server = MongoServer.Create("mongodb://localhost/LinqToQuerystring?safe=true");
                database = server.GetDatabase("LinqToQuerystring");

                var mongoCollection = database.GetCollection<MongoDocument>("Dynamic");
                var doc = InstanceBuilders.BuildComplex(
                    "Charles",
                    new List<string> { "Apple" },
                    new List<string> { "Apple", "Banana" },
                    new List<MongoDocument>
                    {
                        InstanceBuilders.BuildMongoDocument(
                            "Apple", 5, new DateTime(2005, 01, 01), true)
                    });
                mongoCollection.Insert(doc);

                mongoCollection.Insert(
                    InstanceBuilders.BuildComplex(
                        "Andrew",
                        new List<string> { "Apple", "Banana" },
                        new List<string> { "Apple", "Banana", "Custard" },
                        new List<MongoDocument>
                        {
                            InstanceBuilders.BuildMongoDocument("Apple", 5, new DateTime(2005, 01, 01), true),
                            InstanceBuilders.BuildMongoDocument("Banana", 2, new DateTime(2003, 01, 01), false)
                        }));

                mongoCollection.Insert(
                    InstanceBuilders.BuildComplex(
                        "David",
                        new List<string> { "Apple", "Banana", "Custard" },
                        new List<string> { "Apple", "Custard", "Dogfood", "Eggs" },
                        new List<MongoDocument>
                        {
                            InstanceBuilders.BuildMongoDocument("Apple", 5, new DateTime(2005, 01, 01), true),
                            InstanceBuilders.BuildMongoDocument("Banana", 2, new DateTime(2003, 01, 01), false),
                            InstanceBuilders.BuildMongoDocument("Custard", 3, new DateTime(2007, 01, 01), true)
                        }));

                mongoCollection.Insert(
                    InstanceBuilders.BuildComplex(
                        "Edward",
                        new List<string> { "Apple", "Custard", "Dogfood", "Eggs" },
                        new List<string> { "Apple", "Dogfood", "Eggs" },
                        new List<MongoDocument>
                        {
                            InstanceBuilders.BuildMongoDocument("Apple", 5, new DateTime(2005, 01, 01), true),
                            InstanceBuilders.BuildMongoDocument("Custard", 3, new DateTime(2007, 01, 01), true),
                            InstanceBuilders.BuildMongoDocument("Dogfood", 4, new DateTime(2009, 01, 01), false),
                            InstanceBuilders.BuildMongoDocument("Eggs", 1, new DateTime(2000, 01, 01), true)
                        }));

                mongoCollection.Insert(
                   InstanceBuilders.BuildComplex(
                       "Boris",
                       new List<string> { "Apple", "Dogfood", "Eggs" },
                       new List<string> { "Apple" },
                       new List<MongoDocument>
                        {
                            InstanceBuilders.BuildMongoDocument("Apple", 5, new DateTime(2005, 01, 01), true),
                            InstanceBuilders.BuildMongoDocument("Dogfood", 4, new DateTime(2009, 01, 01), false),
                            InstanceBuilders.BuildMongoDocument("Eggs", 1, new DateTime(2000, 01, 01), true)
                        }));

                collection = mongoCollection.AsQueryable();
                var results = collection.ToList();
            };
    }

    #region Complex collections

    public class When_filtering_on_a_complex_collection_property_using_any : MongoCollectionAggregates
    {
        private Because of = () => result = collection.LinqToQuerystring("$filter=ConcreteCollection/any(concrete: concrete/Name eq 'Banana')", true).ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(2);

        private It should_only_return_records_where_concrete_collection_contains_element_with_name_banana = () => result.ShouldEachConformTo(o => o["ConcreteCollection"].AsBsonArray.Any(s => ((string)s["Name"]) == "Banana"));
    }

    public class When_filtering_on_a_complex_collection_property_using_any_with_an_or : MongoCollectionAggregates
    {
        private Because of = () => result = collection.LinqToQuerystring("$filter=ConcreteCollection/any(concrete: concrete/Name eq 'Banana' or concrete/Name eq 'Eggs')", true).ToList();

        private It should_return_four_records = () => result.Count().ShouldEqual(4);

        private It should_only_return_records_where_concrete_collection_contains_element_with_name_banana_or_eggs = () => result.ShouldEachConformTo(o => o["ConcreteCollection"].AsBsonArray.Any(s => ((string)s["Name"]) == "Banana" || ((string)s["Name"]) == "Eggs"));
    }

    public class When_filtering_on_a_complex_collection_property_using_any_with_functions : MongoCollectionAggregates
    {
        private Because of = () => result = collection.LinqToQuerystring("$filter=ConcreteCollection/any(concrete: startswith(concrete/Name,'Dog'))", true).ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(2);

        private It should_only_return_records_where_concrete_collection_contains_element_with_name_starts_with_dog = () => result.ShouldEachConformTo(o => o["ConcreteCollection"].AsBsonArray.Any(s => ((string)s["Name"]).StartsWith("Dog")));
    }

    public class When_filtering_on_a_complex_collection_property_using_count_greater_than : MongoCollectionAggregates
    {
        private Because of = () => result = collection.LinqToQuerystring("$filter=ConcreteCollection/count() gt 3", true).ToList();

        private It should_return_one_record = () => result.Count().ShouldEqual(1);

        private It should_only_return_records_where_concrete_collection_count_greater_than_three = () => result.ShouldEachConformTo(o => o["ConcreteCollection"].AsBsonArray.Count() > 3);
    }

    public class When_filtering_on_a_complex_collection_property_using_count_greater_than_or_equals : MongoCollectionAggregates
    {
        private Because of = () => result = collection.LinqToQuerystring("$filter=ConcreteCollection/count() ge 3", true).ToList();

        private It should_return_three_records = () => result.Count().ShouldEqual(3);

        private It should_only_return_records_where_concrete_collection_count_greater_than_or_equal_to_three = () => result.ShouldEachConformTo(o => o["ConcreteCollection"].AsBsonArray.Count() >= 3);
    }

    public class When_filtering_on_a_complex_collection_property_using_count_less_than : MongoCollectionAggregates
    {
        private Because of = () => result = collection.LinqToQuerystring("$filter=ConcreteCollection/count() lt 3", true).ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(2);

        private It should_only_return_records_where_concrete_collection_count_less_than_three = () => result.ShouldEachConformTo(o => o["ConcreteCollection"].AsBsonArray.Count() < 3);
    }

    public class When_filtering_on_a_complex_collection_property_using_count_less_than_or_equals : MongoCollectionAggregates
    {
        private Because of = () => result = collection.LinqToQuerystring("$filter=ConcreteCollection/count() le 3", true).ToList();

        private It should_return_four_records = () => result.Count().ShouldEqual(4);

        private It should_only_return_records_where_concrete_collection_count_less_than_or_equal_to_three = () => result.ShouldEachConformTo(o => o["ConcreteCollection"].AsBsonArray.Count() <= 3);
    }

    #endregion

    #region Nested collections

    public class When_filtering_on_a_nested_complex_collection_property_using_any : MongoCollectionAggregates
    {
        private Because of = () => result = collection.LinqToQuerystring("$filter=Concrete/ComplexCollection/any(complex: complex/Name eq 'Banana')", true).ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(2);

        private It should_only_return_records_where_concrete_complex_collection_contains_element_with_name_banana = () => result.ShouldEachConformTo(o => o["Concrete"]["ComplexCollection"].AsBsonArray.Any(s => s["Name"] == "Banana"));
    }

    #endregion
}
