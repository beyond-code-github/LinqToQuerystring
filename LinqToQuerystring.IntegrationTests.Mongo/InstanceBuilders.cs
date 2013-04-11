namespace LinqToQuerystring.IntegrationTests.Mongo
{
    using System;

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
    }
}