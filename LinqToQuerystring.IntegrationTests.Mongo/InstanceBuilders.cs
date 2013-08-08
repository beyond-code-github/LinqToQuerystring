namespace LinqToQuerystring.IntegrationTests.Mongo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

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

        public static MongoDocument BuildComplex(string title, List<string> strings, List<string> concreteStrings, ConcreteMongoClass concrete)
        {
            throw new NotImplementedException();
        }

        public static MongoDocument BuildComplex(string title, List<string> strings, List<string> concreteStrings, List<MongoDocument> concreteList)
        {
            return
                new MongoDocument(
                    new BsonDocument
                        {
                            { "Title", title },
                            { "StringCollection", new BsonArray(strings) },
                            { "Concrete", new BsonDocument
                                    {
                                        { "StringCollection", new BsonArray(concreteStrings) },
                                        { "ComplexCollection", new BsonArray(concreteList.Select(o => (BsonDocument)o)) }
                                    }
                            },
                            {
                                "ConcreteCollection", new BsonArray(concreteList.Select(o => (BsonDocument)o))
                            }
                        });
        }

        public static MongoDocument BuildMongoDocument(string name, int age, DateTime date, bool complete, long population, double value, float cost, byte code, Guid guid)
        {
            return
                new MongoDocument(
                    new BsonDocument { { "Name", name }, { "Date", date }, { "Age", age }, { "Complete", complete }, { "Population", population }, { "Value", value }, { "Cost", cost }, { "Code", code }, { "Guid", guid } });
        }

        public static MongoDocument BuildNullableMongoDocument(int? age, DateTime? date, bool? complete, long? population, double? value, float? cost, byte? code, Guid? guid)
        {
            return
                new MongoDocument(
                    new BsonDocument { { "Date", date }, { "Age", age }, { "Complete", complete }, { "Population", population }, { "Value", value }, { "Cost", cost }, { "Code", code }, { "Guid", guid } });
        }

        public static MongoDocument BuildNullableMongoDocument()
        {
            return
                new MongoDocument(
                    new BsonDocument { { "Date", BsonNull.Value }, { "Age", BsonNull.Value }, { "Complete", BsonNull.Value }, { "Population", BsonNull.Value }, { "Value", BsonNull.Value }, { "Cost", BsonNull.Value }, { "Code", BsonNull.Value }, { "Guid", BsonNull.Value } });
        }
    }
}