namespace LinqToQuerystring.IntegrationTests.Mongo
{
    using System;

    using LinqToQueryString.Tests;

    using MongoDB.Bson;

    public static class InstanceBuilders
    {
        public static MongoDocument BuildMongoDocument(string name, int age, DateTime date, bool complete)
        {
            return
                new MongoDocument(
                    new BsonDocument { { "Name", name }, { "Date", date }, { "Age", age }, { "Complete", complete } });
        }

        public static MongoDocument BuildComplexMongoDocument(string title, MongoDocument concrete)
        {
            return
                new MongoDocument(
                    new BsonDocument { { "Title", title }, { "Concrete", concrete } });
        }

        public static MongoDocument BuildEdgeCase(string name, int age, DateTime date, bool complete)
        {
            return
                new MongoDocument(
                    new BsonDocument { { "Name", name }, { "Date", date }, { "Age", age }, { "Complete", complete } });
        }

        public static ConcreteMongoClass BuildConcrete(string name, int age, DateTime date, bool complete)
        {
            return new ConcreteMongoClass { Id = ObjectId.GenerateNewId().ToString(), Name = name, Date = date, Age = age, Complete = complete };
        }
    }
}