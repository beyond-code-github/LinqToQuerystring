namespace LinqToQuerystring.IntegrationTests.Mongo
{
    using System;

    using MongoDB.Bson;
    using MongoDB.Bson.Serialization;
    using MongoDB.Bson.Serialization.IdGenerators;
    using MongoDB.Bson.Serialization.Serializers;

    public class MongoDocumentClassSerializer : BsonDocumentBackedClassSerializer<MongoDocument>, IBsonIdProvider
    {
        public MongoDocumentClassSerializer()
        {
            this.RegisterMember("Id", "_id", ObjectIdSerializer.Instance, typeof(ObjectId), null);
        }

        protected override MongoDocument CreateInstance(BsonDocument backingDocument)
        {
            return new MongoDocument(backingDocument, this);
        }

        public bool GetDocumentId(object document, out object id, out Type idNominalType, out IIdGenerator idGenerator)
        {
            idNominalType = typeof(ObjectId);
            idGenerator = ObjectIdGenerator.Instance;

            var mongoDocument = document as MongoDocument;
            if (mongoDocument == null)
            {
                id = null;
                return false;
            }

            id = mongoDocument.Id;
            return true;
        }

        public void SetDocumentId(object document, object id)
        {
            var mongoDocument = document as MongoDocument;
            if (mongoDocument != null)
            {
                mongoDocument.Id = (ObjectId)id;
            }
        }
    }
}
