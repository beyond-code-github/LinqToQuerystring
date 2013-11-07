namespace LinqToQuerystring.IntegrationTests.Mongo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using LinqToQueryString.Tests;

    using Machine.Specifications;

    using MongoDB.Driver;
    using MongoDB.Driver.Linq;

    public abstract class MongoFunctions
    {
        private static MongoServer server;

        private static MongoDatabase database;

        protected static List<MongoDocument> result;

        protected static List<ConcreteMongoClass> strongResult;

        protected static IQueryable<MongoDocument> collection;

        protected static IQueryable<ConcreteMongoClass> strongCollection;

        private Cleanup cleanup = () =>
        {
            var mongoCollection = database.GetCollection<MongoDocument>("Dynamic");
            mongoCollection.RemoveAll();
            var strongMongoCollection = database.GetCollection<ConcreteMongoClass>("ConcreteMongo");
            strongMongoCollection.RemoveAll();
        };

        private Establish context = () =>
        {
            server = MongoServer.Create("mongodb://localhost/LinqToQuerystring?safe=true");
            database = server.GetDatabase("LinqToQuerystring");

            var strongMongoCollection = database.GetCollection<ConcreteMongoClass>("ConcreteMongo");
            var mongoCollection = database.GetCollection<MongoDocument>("Dynamic");

            mongoCollection.Insert(InstanceBuilders.BuildMongoDocument("Saturday", 1, new DateTime(2001, 01, 01), true));
            mongoCollection.Insert(InstanceBuilders.BuildMongoDocument("Satnav", 2, new DateTime(2002, 01, 01), false));
            mongoCollection.Insert(InstanceBuilders.BuildMongoDocument("Saturnalia", 3, new DateTime(2003, 01, 01), true));
            mongoCollection.Insert(InstanceBuilders.BuildMongoDocument("Saturn", 4, new DateTime(2004, 01, 01), true));
            mongoCollection.Insert(InstanceBuilders.BuildMongoDocument("Monday", 5, new DateTime(2005, 01, 01), true));
            mongoCollection.Insert(InstanceBuilders.BuildMongoDocument("Tuesday", 5, new DateTime(2005, 01, 01), true));
            mongoCollection.Insert(InstanceBuilders.BuildMongoDocument("Burns", 5, new DateTime(2005, 01, 01), true));

            strongMongoCollection.Insert(InstanceBuilders.BuildConcrete("Saturday", 1, new DateTime(2001, 01, 01), true));
            strongMongoCollection.Insert(InstanceBuilders.BuildConcrete("Satnav", 2, new DateTime(2002, 01, 01), false));
            strongMongoCollection.Insert(InstanceBuilders.BuildConcrete("Saturnalia", 3, new DateTime(2003, 01, 01), true));
            strongMongoCollection.Insert(InstanceBuilders.BuildConcrete("Saturn", 4, new DateTime(2004, 01, 01), true));
            strongMongoCollection.Insert(InstanceBuilders.BuildConcrete("Monday", 5, new DateTime(2005, 01, 01), true));
            strongMongoCollection.Insert(InstanceBuilders.BuildConcrete("Tuesday", 5, new DateTime(2005, 01, 01), true));
            strongMongoCollection.Insert(InstanceBuilders.BuildConcrete("Burns", 5, new DateTime(2005, 01, 01), true));

            collection = mongoCollection.AsQueryable();
            strongCollection = strongMongoCollection.AsQueryable();
        };
    }

    #region Strongly typed data functions

    public class When_filtering_strongly_typed_data_with_startswith_function : MongoFunctions
    {
        private Because of =
            () => strongResult = strongCollection.LinqToQuerystring("?$filter=startswith(Name,'Sat')").ToList();

        private It should_return_four_records = () => strongResult.Count().ShouldEqual(4);

        private It should_only_return_records_where_name_starts_with_Sat =
            () => strongResult.ShouldEachConformTo(o => o.Name.StartsWith("Sat"));
    }

    public class When_filtering_strongly_typed_data_with_substringof_function : MongoFunctions
    {
        private Because of =
            () => strongResult = strongCollection.LinqToQuerystring("?$filter=substringof('urn',Name)").ToList();

        private It should_return_three_records = () => strongResult.Count().ShouldEqual(3);

        private It should_only_return_records_where_name_contains_urn =
            () => strongResult.ShouldEachConformTo(o => o.Name.Contains("urn"));
    }

    public class When_filtering_strongly_typed_data_with_multiple_substringof_functions : MongoFunctions
    {
        private Because of =
            () =>
            strongResult = strongCollection.LinqToQuerystring(
                "?$filter=(substringof('Mond',Name)) or (substringof('Tues',Name))").ToList();

        private It should_return_three_records = () => strongResult.Count().ShouldEqual(2);

        private It should_only_return_records_where_name_contains_urn =
            () => strongResult.ShouldEachConformTo(o => o.Name.Contains("Mond") || o.Name.Contains("Tues"));
    }

    public class When_filtering_loosely_strongly_data_with_substringof_function_with_tolower : MongoFunctions
    {
        private Because of =
            () => strongResult = strongCollection.LinqToQuerystring(@"?$filter=substringof('sat',tolower(Name))").ToList();

        private It should_return_four_records = () => strongResult.Count().ShouldEqual(4);

        private It should_only_return_records_where_name_contains_sat =
            () => strongResult.ShouldEachConformTo(o => o.Name.Contains("Sat"));
    }

    #endregion

    #region Loosely typed data functions

    public class When_filtering_loosely_typed_data_with_startswith_function : MongoFunctions
    {
        private Because of =
            () => result = collection.LinqToQuerystring("?$filter=startswith([Name],'Sat')").ToList();

        private It should_return_four_records = () => result.Count().ShouldEqual(4);

        private It should_only_return_records_where_name_starts_with_Sat =
            () => result.ShouldEachConformTo(o => o["Name"].AsString.StartsWith("Sat"));
    }

    public class When_filtering_loosely_typed_data_with_substringof_function : MongoFunctions
    {
        private Because of =
            () => result = collection.LinqToQuerystring("?$filter=substringof('urn',[Name])").ToList();

        private It should_return_three_records = () => result.Count().ShouldEqual(3);

        private It should_only_return_records_where_name_contains_urn =
            () => result.ShouldEachConformTo(o => o["Name"].AsString.Contains("urn"));
    }

    public class When_filtering_loosely_typed_data_with_multiple_substringof_functions : MongoFunctions
    {
        private Because of =
            () =>
            result = collection.LinqToQuerystring(
                "?$filter=(substringof('Mond',[Name])) or (substringof('Tues',[Name]))").ToList();

        private It should_return_three_records = () => result.Count().ShouldEqual(2);

        private It should_only_return_records_where_name_contains_urn =
            () => result.ShouldEachConformTo(o => o["Name"].AsString.Contains("Mond") || o["Name"].AsString.Contains("Tues"));
    }

    public class When_filtering_loosely_typed_data_with_substringof_function_with_tolower : MongoFunctions
    {
        private Because of =
            () => result = collection.LinqToQuerystring(@"?$filter=substringof('sat',tolower([Name]))").ToList();

        private It should_return_four_records = () => result.Count().ShouldEqual(4);

        private It should_only_return_records_where_name_contains_sat =
            () => result.ShouldEachConformTo(o => o["Name"].AsString.Contains("Sat"));
    }

    #endregion
}
