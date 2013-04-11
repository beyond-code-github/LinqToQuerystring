namespace LinqToQuerystring.IntegrationTests.Mongo
{
    using System;

    using MongoDB.Bson;
    using MongoDB.Bson.Serialization;
    using MongoDB.Bson.Serialization.Attributes;

    [Serializable]
    [BsonSerializer(typeof(MongoDocumentClassSerializer))]
    public class MongoDocument : BsonDocumentBackedClass
    {
        public MongoDocument()
            : base(new MongoDocumentClassSerializer())
        {
        }

        public MongoDocument(BsonDocument backingDocument)
            : base(backingDocument, new MongoDocumentClassSerializer())
        {
        }

        public MongoDocument(BsonDocument backingDocument, IBsonDocumentSerializer serializer)
            : base(backingDocument, serializer)
        {

        }

        [BsonId]
        public ObjectId Id { get; set; }

        public BsonValue this[string fieldname]
        {
            get
            {
                return this.BackingDocument[fieldname];
            }

            set
            {
                this.BackingDocument[fieldname] = value;
            }
        }

        public static implicit operator BsonDocument(MongoDocument document)
        {
            return document.BackingDocument;
        }
    }
}
