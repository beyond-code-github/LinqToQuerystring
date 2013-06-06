namespace LinqToQuerystring.IntegrationTests.Mongo
{
    using System;
    using System.Collections.Generic;

    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class ConcreteMongoClass
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public string Id { get; set; }

        public string Name { get; set; }

        public DateTime Date { get; set; }

        public bool Complete { get; set; }

        public int Age { get; set; }

        public List<string> StringCollection { get; set; }
    }
}
