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

        private It should_only_return_records_where_string_collection_contains_apple = () => result.ShouldEachConformTo(o => o["StringCollection"].AsBsonArray.Any(s => s == "Banana"));
    }

    public class When_filtering_on_a_complex_collection_property_using_any_with_an_or : MongoCollectionAggregates
    {
        private Because of = () => result = collection.LinqToQuerystring("$filter=ConcreteCollection/any(concrete: concrete/Name eq 'Banana' or concrete/Name eq 'Eggs')", true).ToList();

        private It should_return_four_records = () => result.Count().ShouldEqual(4);

        private It should_only_return_records_where_string_collection_contains_apple = () => result.ShouldEachConformTo(o => o["StringCollection"].AsBsonArray.Any(s => s == "Banana" || s == "Eggs"));
    }

    public class When_filtering_on_a_complex_collection_property_using_any_with_functions : MongoCollectionAggregates
    {
        private Because of = () => result = collection.LinqToQuerystring("$filter=ConcreteCollection/any(concrete: startswith(concrete/Name,'Dog'))", true).ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(2);

        private It should_only_return_records_where_string_collection_contains_apple = () => result.ShouldEachConformTo(o => o["StringCollection"].AsBsonArray.Any(s => ((string)s).StartsWith("Dog")));
    }

    #endregion

    #region Nested collections

    public class When_filtering_on_a_nested_complex_collection_property_using_any : MongoCollectionAggregates
    {
        private Because of = () => result = collection.LinqToQuerystring("$filter=Concrete/ComplexCollection/any(complex: complex/Name eq 'Banana')", true).ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(2);

        private It should_only_return_records_where_string_collection_contains_apple = () => result.ShouldEachConformTo(o => o["Concrete"]["ComplexCollection"].AsBsonArray.Any(s => s["Name"] == "Banana"));
    }

    public class When_filtering_on_a_nested_complex_collection_property_using_any_with_an_or : MongoCollectionAggregates
    {
        private Because of = () => result = collection.LinqToQuerystring("$filter=Concrete/ComplexCollection/any(complex: complex/Name eq 'Banana' or complex/Name eq 'Eggs')", true).ToList();

        private It should_return_four_records = () => result.Count().ShouldEqual(4);

        private It should_only_return_records_where_string_collection_contains_apple = () => result.ShouldEachConformTo(o => o["Concrete"]["ComplexCollection"].AsBsonArray.Any(s => s["Name"] == "Banana" || s["Name"] == "Eggs"));
    }

    public class When_filtering_on_a_nested_complex_collection_property_using_any_with_functions : MongoCollectionAggregates
    {
        private Because of = () => result = collection.LinqToQuerystring("$filter=Concrete/ComplexCollection/any(complex: startswith(complex/Name,'Dog'))", true).ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(2);

        private It should_only_return_records_where_string_collection_contains_apple = () => result.ShouldEachConformTo(o => o["Concrete"]["ComplexCollection"].AsBsonArray.Any(s => ((string)s["Name"]).StartsWith("Dog")));
    }

    #endregion
}
