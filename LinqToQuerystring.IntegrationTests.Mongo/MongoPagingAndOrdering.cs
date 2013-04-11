namespace LinqToQuerystring.IntegrationTests.Mongo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Machine.Specifications;

    using MongoDB.Driver;
    using MongoDB.Driver.Linq;

    public class MongoPagingAndOrdering
    {
        private static MongoServer server;

        private static MongoDatabase database;

        protected static List<MongoDocument> result;

        protected static List<MongoDocument> complexResult;

        protected static List<MongoDocument> concreteList;

        protected static List<MongoDocument> complexList;

        protected static IQueryable<MongoDocument> collection;

        protected static IQueryable<MongoDocument> complexCollection;

        private Cleanup cleanup = () =>
        {
            var mongoCollection = database.GetCollection<MongoDocument>("Dynamic");
            mongoCollection.RemoveAll();

            var complexMongoCollection = database.GetCollection<MongoDocument>("ComplexDynamic");
            complexMongoCollection.RemoveAll();
        };

        private Establish context = () =>
        {
            server = MongoServer.Create("mongodb://localhost/LinqToQuerystring?safe=true");
            database = server.GetDatabase("LinqToQuerystring");

            var mongoCollection = database.GetCollection<MongoDocument>("Dynamic");
            var complexMongoCollection = database.GetCollection<MongoDocument>("ComplexDynamic");

            mongoCollection.Insert(InstanceBuilders.BuildMongoDocument("Apple", 5, new DateTime(2005, 01, 01), true));
            mongoCollection.Insert(InstanceBuilders.BuildMongoDocument("Custard", 3, new DateTime(2007, 01, 01), true));
            mongoCollection.Insert(InstanceBuilders.BuildMongoDocument("Banana", 2, new DateTime(2003, 01, 01), false));
            mongoCollection.Insert(InstanceBuilders.BuildMongoDocument("Eggs", 1, new DateTime(2000, 01, 01), true));
            mongoCollection.Insert(InstanceBuilders.BuildMongoDocument("Dogfood", 4, new DateTime(2009, 01, 01), false));

            collection = mongoCollection.AsQueryable();
            concreteList = collection.ToList();

            complexMongoCollection.Insert(InstanceBuilders.BuildComplexMongoDocument("Charles", InstanceBuilders.BuildMongoDocument("Apple", 5, new DateTime(2005, 01, 01), true)));
            complexMongoCollection.Insert(InstanceBuilders.BuildComplexMongoDocument("Andrew", InstanceBuilders.BuildMongoDocument("Custard", 3, new DateTime(2007, 01, 01), true)));
            complexMongoCollection.Insert(InstanceBuilders.BuildComplexMongoDocument("David", InstanceBuilders.BuildMongoDocument("Banana", 2, new DateTime(2003, 01, 01), false)));
            complexMongoCollection.Insert(InstanceBuilders.BuildComplexMongoDocument("Edward", InstanceBuilders.BuildMongoDocument("Eggs", 1, new DateTime(2000, 01, 01), true)));
            complexMongoCollection.Insert(InstanceBuilders.BuildComplexMongoDocument("Boris", InstanceBuilders.BuildMongoDocument("Dogfood", 4, new DateTime(2009, 01, 01), false)));

            complexCollection = complexMongoCollection.AsQueryable();
            complexList = complexCollection.ToList();
        };
    }

    #region Top Tests

    public class When_using_top_1 : MongoPagingAndOrdering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$top=1", true).ToList();

        private It should_return_one_record = () => result.Count().ShouldEqual(1);

        private It should_return_the_first_record = () => result.ElementAt(0)["Name"].ShouldEqual(concreteList.ElementAt(0)["Name"]);
    }

    public class When_using_top_3 : MongoPagingAndOrdering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$top=3", true).ToList();

        private It should_return_three_records = () => result.Count().ShouldEqual(3);

        private It should_start_with_the_first_record = () => result.ElementAt(0)["Name"].ShouldEqual(concreteList.ElementAt(0)["Name"]);

        private It should_then_follow_with_the_second_record = () => result.ElementAt(1)["Name"].ShouldEqual(concreteList.ElementAt(1)["Name"]);

        private It should_then_follow_with_the_third_record = () => result.ElementAt(2)["Name"].ShouldEqual(concreteList.ElementAt(2)["Name"]);
    }

    #endregion

    #region Skip Tests

    public class When_using_skip_1_on_ordered_data : MongoPagingAndOrdering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$orderby=Id&$skip=1", true).ToList();

        private It should_return_four_records = () => result.Count().ShouldEqual(4);

        private It should_start_with_the_second_record = () => result.ElementAt(0)["Name"].ShouldEqual(concreteList.ElementAt(1)["Name"]);

        private It should_then_follow_with_the_third_record = () => result.ElementAt(1)["Name"].ShouldEqual(concreteList.ElementAt(2)["Name"]);

        private It should_then_follow_with_the_fourth_record = () => result.ElementAt(2)["Name"].ShouldEqual(concreteList.ElementAt(3)["Name"]);

        private It should_then_follow_with_the_fifth_record = () => result.ElementAt(3)["Name"].ShouldEqual(concreteList.ElementAt(4)["Name"]);
    }

    public class When_using_skip_3_on_ordered_data : MongoPagingAndOrdering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$orderby=Id$skip=3", true).ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(2);

        private It should_start_with_the_fourth_record = () => result.ElementAt(0)["Name"].ShouldEqual(concreteList.ElementAt(3)["Name"]);

        private It should_then_follow_with_the_fifth_record = () => result.ElementAt(1)["Name"].ShouldEqual(concreteList.ElementAt(4)["Name"]);
    }

    #endregion

    #region Skip and Top Tests

    public class When_using_skip_2_and_top_2_on_ordered_data : MongoPagingAndOrdering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$orderby=Id$skip=2&$top=2", true).ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(2);

        private It should_start_with_the_third_record = () => result.ElementAt(0)["Name"].ShouldEqual(concreteList.ElementAt(2)["Name"]);

        private It should_then_follow_with_the_fourth_record = () => result.ElementAt(1)["Name"].ShouldEqual(concreteList.ElementAt(3)["Name"]);
    }

    public class When_using_skip_3_and_top_1_on_ordered_data : MongoPagingAndOrdering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$orderby=Id$skip=3&$top=1", true).ToList();

        private It should_return_one_record = () => result.Count().ShouldEqual(1);

        private It should_start_with_the_fourth_record = () => result.ElementAt(0)["Name"].ShouldEqual(concreteList.ElementAt(3)["Name"]);
    }

    public class When_using_top_2_and_skip_2_on_ordered_data : MongoPagingAndOrdering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$orderby=Id$top=2&$skip=2", true).ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(2);

        private It should_start_with_the_third_record = () => result.ElementAt(0)["Name"].ShouldEqual(concreteList.ElementAt(2)["Name"]);

        private It should_then_follow_with_the_fourth_record = () => result.ElementAt(1)["Name"].ShouldEqual(concreteList.ElementAt(3)["Name"]);
    }

    #endregion

    #region OrderBy Single Integer Tests

    public class When_using_order_by_on_integer_with_one_criteria : MongoPagingAndOrdering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$orderby=Age", true).ToList();

        private It should_return_five_records = () => result.Count().ShouldEqual(5);

        private It should_return_the_fourth_record = () => result.ElementAt(0)["Name"].ShouldEqual(concreteList.ElementAt(3)["Name"]);

        private It should_be_then_be_followed_by_the_third = () => result.ElementAt(1)["Name"].ShouldEqual(concreteList.ElementAt(2)["Name"]);

        private It should_be_then_be_followed_by_the_second = () => result.ElementAt(2)["Name"].ShouldEqual(concreteList.ElementAt(1)["Name"]);

        private It should_be_then_be_followed_by_the_fifth = () => result.ElementAt(3)["Name"].ShouldEqual(concreteList.ElementAt(4)["Name"]);

        private It should_be_then_be_followed_by_the_first = () => result.ElementAt(4)["Name"].ShouldEqual(concreteList.ElementAt(0)["Name"]);
    }

    public class When_using_order_by_asc_on_integer_with_one_criteria : MongoPagingAndOrdering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$orderby=Age asc", true).ToList();

        private It should_return_five_records = () => result.Count().ShouldEqual(5);

        private It should_return_the_fourth_record = () => result.ElementAt(0)["Name"].ShouldEqual(concreteList.ElementAt(3)["Name"]);

        private It should_be_then_be_followed_by_the_third = () => result.ElementAt(1)["Name"].ShouldEqual(concreteList.ElementAt(2)["Name"]);

        private It should_be_then_be_followed_by_the_second = () => result.ElementAt(2)["Name"].ShouldEqual(concreteList.ElementAt(1)["Name"]);

        private It should_be_then_be_followed_by_the_fifth = () => result.ElementAt(3)["Name"].ShouldEqual(concreteList.ElementAt(4)["Name"]);

        private It should_be_then_be_followed_by_the_first = () => result.ElementAt(4)["Name"].ShouldEqual(concreteList.ElementAt(0)["Name"]);
    }

    public class When_using_order_by_desc_on_integer_with_one_criteria : MongoPagingAndOrdering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$orderby=Age desc", true).ToList();

        private It should_return_five_records = () => result.Count().ShouldEqual(5);

        private It should_return_the_fourth_record = () => result.ElementAt(0)["Name"].ShouldEqual(concreteList.ElementAt(0)["Name"]);

        private It should_be_then_be_followed_by_the_third = () => result.ElementAt(1)["Name"].ShouldEqual(concreteList.ElementAt(4)["Name"]);

        private It should_be_then_be_followed_by_the_second = () => result.ElementAt(2)["Name"].ShouldEqual(concreteList.ElementAt(1)["Name"]);

        private It should_be_then_be_followed_by_the_fifth = () => result.ElementAt(3)["Name"].ShouldEqual(concreteList.ElementAt(2)["Name"]);

        private It should_be_then_be_followed_by_the_first = () => result.ElementAt(4)["Name"].ShouldEqual(concreteList.ElementAt(3)["Name"]);
    }

    #endregion

    #region OrderBy Single String Tests

    public class When_using_order_by_on_string_with_one_criteria : MongoPagingAndOrdering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$orderby=Name", true).ToList();

        private It should_return_five_records = () => result.Count().ShouldEqual(5);

        private It should_return_the_first_record = () => result.ElementAt(0)["Name"].ShouldEqual(concreteList.ElementAt(0)["Name"]);

        private It should_be_then_be_followed_by_the_third = () => result.ElementAt(1)["Name"].ShouldEqual(concreteList.ElementAt(2)["Name"]);

        private It should_be_then_be_followed_by_the_second = () => result.ElementAt(2)["Name"].ShouldEqual(concreteList.ElementAt(1)["Name"]);

        private It should_be_then_be_followed_by_the_fifth = () => result.ElementAt(3)["Name"].ShouldEqual(concreteList.ElementAt(4)["Name"]);

        private It should_be_then_be_followed_by_the_fourth = () => result.ElementAt(4)["Name"].ShouldEqual(concreteList.ElementAt(3)["Name"]);
    }

    public class When_using_order_by_asc_on_string_with_one_criteria : MongoPagingAndOrdering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$orderby=Name asc", true).ToList();

        private It should_return_five_records = () => result.Count().ShouldEqual(5);

        private It should_return_the_first_record = () => result.ElementAt(0)["Name"].ShouldEqual(concreteList.ElementAt(0)["Name"]);

        private It should_be_then_be_followed_by_the_third = () => result.ElementAt(1)["Name"].ShouldEqual(concreteList.ElementAt(2)["Name"]);

        private It should_be_then_be_followed_by_the_second = () => result.ElementAt(2)["Name"].ShouldEqual(concreteList.ElementAt(1)["Name"]);

        private It should_be_then_be_followed_by_the_fifth = () => result.ElementAt(3)["Name"].ShouldEqual(concreteList.ElementAt(4)["Name"]);

        private It should_be_then_be_followed_by_the_fourth = () => result.ElementAt(4)["Name"].ShouldEqual(concreteList.ElementAt(3)["Name"]);
    }

    public class When_using_order_by_desc_on_string_with_one_criteria : MongoPagingAndOrdering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$orderby=Name desc", true).ToList();

        private It should_return_five_records = () => result.Count().ShouldEqual(5);

        private It should_return_the_first_record = () => result.ElementAt(0)["Name"].ShouldEqual(concreteList.ElementAt(3)["Name"]);

        private It should_be_then_be_followed_by_the_third = () => result.ElementAt(1)["Name"].ShouldEqual(concreteList.ElementAt(4)["Name"]);

        private It should_be_then_be_followed_by_the_second = () => result.ElementAt(2)["Name"].ShouldEqual(concreteList.ElementAt(1)["Name"]);

        private It should_be_then_be_followed_by_the_fifth = () => result.ElementAt(3)["Name"].ShouldEqual(concreteList.ElementAt(2)["Name"]);

        private It should_be_then_be_followed_by_the_fourth = () => result.ElementAt(4)["Name"].ShouldEqual(concreteList.ElementAt(0)["Name"]);
    }

    #endregion

    #region OrderBy Single Date Tests

    public class When_using_order_by_on_date_with_one_criteria : MongoPagingAndOrdering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$orderby=Date", true).ToList();

        private It should_return_five_records = () => result.Count().ShouldEqual(5);

        private It should_return_the_fourth_record = () => result.ElementAt(0)["Name"].ShouldEqual(concreteList.ElementAt(3)["Name"]);

        private It should_be_then_be_followed_by_the_third = () => result.ElementAt(1)["Name"].ShouldEqual(concreteList.ElementAt(2)["Name"]);

        private It should_be_then_be_followed_by_the_first = () => result.ElementAt(2)["Name"].ShouldEqual(concreteList.ElementAt(0)["Name"]);

        private It should_be_then_be_followed_by_the_second = () => result.ElementAt(3)["Name"].ShouldEqual(concreteList.ElementAt(1)["Name"]);

        private It should_be_then_be_followed_by_the_fifth = () => result.ElementAt(4)["Name"].ShouldEqual(concreteList.ElementAt(4)["Name"]);
    }

    public class When_using_order_by_asc_on_date_with_one_criteria : MongoPagingAndOrdering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$orderby=Date asc", true).ToList();

        private It should_return_five_records = () => result.Count().ShouldEqual(5);

        private It should_return_the_fourth_record = () => result.ElementAt(0)["Name"].ShouldEqual(concreteList.ElementAt(3)["Name"]);

        private It should_be_then_be_followed_by_the_third = () => result.ElementAt(1)["Name"].ShouldEqual(concreteList.ElementAt(2)["Name"]);

        private It should_be_then_be_followed_by_the_first = () => result.ElementAt(2)["Name"].ShouldEqual(concreteList.ElementAt(0)["Name"]);

        private It should_be_then_be_followed_by_the_second = () => result.ElementAt(3)["Name"].ShouldEqual(concreteList.ElementAt(1)["Name"]);

        private It should_be_then_be_followed_by_the_fifth = () => result.ElementAt(4)["Name"].ShouldEqual(concreteList.ElementAt(4)["Name"]);
    }

    public class When_using_order_by_desc_on_date_with_one_criteria : MongoPagingAndOrdering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$orderby=Date desc", true).ToList();

        private It should_return_five_records = () => result.Count().ShouldEqual(5);

        private It should_return_the_fourth_record = () => result.ElementAt(0)["Name"].ShouldEqual(concreteList.ElementAt(4)["Name"]);

        private It should_be_then_be_followed_by_the_third = () => result.ElementAt(1)["Name"].ShouldEqual(concreteList.ElementAt(1)["Name"]);

        private It should_be_then_be_followed_by_the_first = () => result.ElementAt(2)["Name"].ShouldEqual(concreteList.ElementAt(0)["Name"]);

        private It should_be_then_be_followed_by_the_second = () => result.ElementAt(3)["Name"].ShouldEqual(concreteList.ElementAt(2)["Name"]);

        private It should_be_then_be_followed_by_the_fifth = () => result.ElementAt(4)["Name"].ShouldEqual(concreteList.ElementAt(3)["Name"]);
    }

    #endregion

    #region OrderBy Single Boolean Tests

    public class When_using_order_by_on_bool_with_one_criteria : MongoPagingAndOrdering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$orderby=Complete", true).ToList();

        private It should_return_five_records = () => result.Count().ShouldEqual(5);

        private It should_have_sorted_a_false_value_first = () => result.ElementAt(0)["Complete"].AsBoolean.ShouldBeFalse();

        private It should_have_sorted_a_false_value_second = () => result.ElementAt(1)["Complete"].AsBoolean.ShouldBeFalse();

        private It should_have_sorted_a_true_value_third = () => result.ElementAt(2)["Complete"].AsBoolean.ShouldBeTrue();

        private It should_have_sorted_a_true_value_fourth = () => result.ElementAt(3)["Complete"].AsBoolean.ShouldBeTrue();

        private It should_have_sorted_a_true_value_fifth = () => result.ElementAt(4)["Complete"].AsBoolean.ShouldBeTrue();
    }

    public class When_using_order_by_asc_on_bool_with_one_criteria : MongoPagingAndOrdering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$orderby=Complete asc", true).ToList();

        private It should_return_five_records = () => result.Count().ShouldEqual(5);

        private It should_have_sorted_a_false_value_first = () => result.ElementAt(0)["Complete"].AsBoolean.ShouldBeFalse();

        private It should_have_sorted_a_false_value_second = () => result.ElementAt(1)["Complete"].AsBoolean.ShouldBeFalse();

        private It should_have_sorted_a_true_value_third = () => result.ElementAt(2)["Complete"].AsBoolean.ShouldBeTrue();

        private It should_have_sorted_a_true_value_fourth = () => result.ElementAt(3)["Complete"].AsBoolean.ShouldBeTrue();

        private It should_have_sorted_a_true_value_fifth = () => result.ElementAt(4)["Complete"].AsBoolean.ShouldBeTrue();
    }

    public class When_using_order_by_desc_on_bool_with_one_criteria : MongoPagingAndOrdering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$orderby=Complete desc", true).ToList();

        private It should_return_five_records = () => result.Count().ShouldEqual(5);

        private It should_have_sorted_a_true_value_first = () => result.ElementAt(0)["Complete"].AsBoolean.ShouldBeTrue();

        private It should_have_sorted_a_true_value_second = () => result.ElementAt(1)["Complete"].AsBoolean.ShouldBeTrue();

        private It should_have_sorted_a_true_value_third = () => result.ElementAt(2)["Complete"].AsBoolean.ShouldBeTrue();

        private It should_have_sorted_a_false_value_fourth = () => result.ElementAt(3)["Complete"].AsBoolean.ShouldBeFalse();

        private It should_have_sorted_a_false_value_fifth = () => result.ElementAt(4)["Complete"].AsBoolean.ShouldBeFalse();
    }

    #endregion

    #region OrderBy Multiple Properties

    public class When_using_order_by_on_two_properties : MongoPagingAndOrdering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$orderby=Complete,Age", true).ToList();

        private It should_return_five_records = () => result.Count().ShouldEqual(5);

        private It should_return_the_third_record = () => result.ElementAt(0)["Name"].ShouldEqual(concreteList.ElementAt(2)["Name"]);

        private It should_then_be_followed_by_the_fifth = () => result.ElementAt(1)["Name"].ShouldEqual(concreteList.ElementAt(4)["Name"]);

        private It should_then_be_followed_by_the_fourth = () => result.ElementAt(2)["Name"].ShouldEqual(concreteList.ElementAt(3)["Name"]);

        private It should_then_be_followed_by_the_second = () => result.ElementAt(3)["Name"].ShouldEqual(concreteList.ElementAt(1)["Name"]);

        private It should_then_be_followed_by_the_first = () => result.ElementAt(4)["Name"].ShouldEqual(concreteList.ElementAt(0)["Name"]);
    }

    public class When_using_order_by_on_one_descending_and_one_ascending : MongoPagingAndOrdering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$orderby=Complete desc,Age", true).ToList();

        private It should_return_five_records = () => result.Count().ShouldEqual(5);

        private It should_return_the_fourth_record = () => result.ElementAt(0)["Name"].ShouldEqual(concreteList.ElementAt(3)["Name"]);

        private It should_then_be_followed_by_the_second = () => result.ElementAt(1)["Name"].ShouldEqual(concreteList.ElementAt(1)["Name"]);

        private It should_then_be_followed_by_the_first = () => result.ElementAt(2)["Name"].ShouldEqual(concreteList.ElementAt(0)["Name"]);

        private It should_then_be_followed_by_the_third = () => result.ElementAt(3)["Name"].ShouldEqual(concreteList.ElementAt(2)["Name"]);

        private It should_then_be_followed_by_the_fifth = () => result.ElementAt(4)["Name"].ShouldEqual(concreteList.ElementAt(4)["Name"]);
    }

    public class When_using_order_by_on_one_ascending_and_one_descending : MongoPagingAndOrdering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$orderby=Complete,Age desc", true).ToList();

        private It should_return_five_records = () => result.Count().ShouldEqual(5);

        private It should_return_the_fifth_record = () => result.ElementAt(0)["Name"].ShouldEqual(concreteList.ElementAt(4)["Name"]);

        private It should_then_be_followed_by_the_third = () => result.ElementAt(1)["Name"].ShouldEqual(concreteList.ElementAt(2)["Name"]);

        private It should_then_be_followed_by_the_first = () => result.ElementAt(2)["Name"].ShouldEqual(concreteList.ElementAt(0)["Name"]);

        private It should_then_be_followed_by_the_second = () => result.ElementAt(3)["Name"].ShouldEqual(concreteList.ElementAt(1)["Name"]);

        private It should_then_be_followed_by_the_fourth = () => result.ElementAt(4)["Name"].ShouldEqual(concreteList.ElementAt(3)["Name"]);
    }

    public class When_using_order_by_on_two_properties_both_descending : MongoPagingAndOrdering
    {
        private Because of = () => result = collection.LinqToQuerystring("?$orderby=Complete desc,Age desc", true).ToList();

        private It should_return_five_records = () => result.Count().ShouldEqual(5);

        private It should_return_the_first_record = () => result.ElementAt(0)["Name"].ShouldEqual(concreteList.ElementAt(0)["Name"]);

        private It should_then_be_followed_by_the_second = () => result.ElementAt(1)["Name"].ShouldEqual(concreteList.ElementAt(1)["Name"]);

        private It should_then_be_followed_by_the_fourth = () => result.ElementAt(2)["Name"].ShouldEqual(concreteList.ElementAt(3)["Name"]);

        private It should_then_be_followed_by_the_fifth = () => result.ElementAt(3)["Name"].ShouldEqual(concreteList.ElementAt(4)["Name"]);

        private It should_then_be_followed_by_the_third = () => result.ElementAt(4)["Name"].ShouldEqual(concreteList.ElementAt(2)["Name"]);
    }

    #endregion

    #region OrderBy SubProperties

    public class When_using_order_by_on_a_single_subproperty : MongoPagingAndOrdering
    {
        private Because of = () => complexResult = complexCollection.LinqToQuerystring(@"?$orderby=Concrete/Age", true).ToList();

        private It should_return_five_records = () => complexResult.Count().ShouldEqual(5);

        private It should_return_the_fourth_record = () => complexResult.ElementAt(0)["Title"].ShouldEqual(complexList.ElementAt(3)["Title"]);

        private It should_be_then_be_followed_by_the_third = () => complexResult.ElementAt(1)["Title"].ShouldEqual(complexList.ElementAt(2)["Title"]);

        private It should_be_then_be_followed_by_the_second = () => complexResult.ElementAt(2)["Title"].ShouldEqual(complexList.ElementAt(1)["Title"]);

        private It should_be_then_be_followed_by_the_fifth = () => complexResult.ElementAt(3)["Title"].ShouldEqual(complexList.ElementAt(4)["Title"]);

        private It should_be_then_be_followed_by_the_first = () => complexResult.ElementAt(4)["Title"].ShouldEqual(complexList.ElementAt(0)["Title"]);
    }

    public class When_using_order_by_asc_on_a_single_subproperty : MongoPagingAndOrdering
    {
        private Because of = () => complexResult = complexCollection.LinqToQuerystring(@"?$orderby=Concrete/Age asc", true).ToList();

        private It should_return_five_records = () => complexResult.Count().ShouldEqual(5);

        private It should_return_the_fourth_record = () => complexResult.ElementAt(0)["Title"].ShouldEqual(complexList.ElementAt(3)["Title"]);

        private It should_be_then_be_followed_by_the_third = () => complexResult.ElementAt(1)["Title"].ShouldEqual(complexList.ElementAt(2)["Title"]);

        private It should_be_then_be_followed_by_the_second = () => complexResult.ElementAt(2)["Title"].ShouldEqual(complexList.ElementAt(1)["Title"]);

        private It should_be_then_be_followed_by_the_fifth = () => complexResult.ElementAt(3)["Title"].ShouldEqual(complexList.ElementAt(4)["Title"]);

        private It should_be_then_be_followed_by_the_first = () => complexResult.ElementAt(4)["Title"].ShouldEqual(complexList.ElementAt(0)["Title"]);
    }

    public class When_using_order_by_desc_on_a_single_subproperty : MongoPagingAndOrdering
    {
        private Because of = () => complexResult = complexCollection.LinqToQuerystring("?$orderby=Concrete/Age desc", true).ToList();

        private It should_return_five_records = () => complexResult.Count().ShouldEqual(5);

        private It should_return_the_first_record = () => complexResult.ElementAt(0)["Title"].ShouldEqual(complexList.ElementAt(0)["Title"]);

        private It should_be_then_be_followed_by_the_fifth = () => complexResult.ElementAt(1)["Title"].ShouldEqual(complexList.ElementAt(4)["Title"]);

        private It should_be_then_be_followed_by_the_second = () => complexResult.ElementAt(2)["Title"].ShouldEqual(complexList.ElementAt(1)["Title"]);

        private It should_be_then_be_followed_by_the_third = () => complexResult.ElementAt(3)["Title"].ShouldEqual(complexList.ElementAt(2)["Title"]);

        private It should_be_then_be_followed_by_the_fourth = () => complexResult.ElementAt(4)["Title"].ShouldEqual(complexList.ElementAt(3)["Title"]);
    }

    #endregion

    #region OrderBy Multiple SubProperties

    public class When_using_order_by_on_two_sub_properties : MongoPagingAndOrdering
    {
        private Because of = () => complexResult = complexCollection.LinqToQuerystring("?$orderby=Concrete/Complete,Concrete/Age", true).ToList();

        private It should_return_five_records = () => complexResult.Count().ShouldEqual(5);

        private It should_return_the_third_record = () => complexResult.ElementAt(0)["Title"].ShouldEqual(complexList.ElementAt(2)["Title"]);

        private It should_then_be_followed_by_the_fifth = () => complexResult.ElementAt(1)["Title"].ShouldEqual(complexList.ElementAt(4)["Title"]);

        private It should_then_be_followed_by_the_fourth = () => complexResult.ElementAt(2)["Title"].ShouldEqual(complexList.ElementAt(3)["Title"]);

        private It should_then_be_followed_by_the_second = () => complexResult.ElementAt(3)["Title"].ShouldEqual(complexList.ElementAt(1)["Title"]);

        private It should_then_be_followed_by_the_first = () => complexResult.ElementAt(4)["Title"].ShouldEqual(complexList.ElementAt(0)["Title"]);
    }

    public class When_using_order_by_on_two_sub_properties_one_descending_and_one_ascending : MongoPagingAndOrdering
    {
        private Because of = () => complexResult = complexCollection.LinqToQuerystring("?$orderby=Concrete/Complete desc,Concrete/Age", true).ToList();

        private It should_return_five_records = () => complexResult.Count().ShouldEqual(5);

        private It should_return_the_fourth_record = () => complexResult.ElementAt(0)["Title"].ShouldEqual(complexList.ElementAt(3)["Title"]);

        private It should_then_be_followed_by_the_second = () => complexResult.ElementAt(1)["Title"].ShouldEqual(complexList.ElementAt(1)["Title"]);

        private It should_then_be_followed_by_the_first = () => complexResult.ElementAt(2)["Title"].ShouldEqual(complexList.ElementAt(0)["Title"]);

        private It should_then_be_followed_by_the_third = () => complexResult.ElementAt(3)["Title"].ShouldEqual(complexList.ElementAt(2)["Title"]);

        private It should_then_be_followed_by_the_fifth = () => complexResult.ElementAt(4)["Title"].ShouldEqual(complexList.ElementAt(4)["Title"]);
    }

    public class When_using_order_by_on_two_sub_properties_one_ascending_and_one_descending : MongoPagingAndOrdering
    {
        private Because of = () => complexResult = complexCollection.LinqToQuerystring("?$orderby=Concrete/Complete,Concrete/Age desc", true).ToList();

        private It should_return_five_records = () => complexResult.Count().ShouldEqual(5);

        private It should_return_the_fifth_record = () => complexResult.ElementAt(0)["Title"].ShouldEqual(complexList.ElementAt(4)["Title"]);

        private It should_then_be_followed_by_the_third = () => complexResult.ElementAt(1)["Title"].ShouldEqual(complexList.ElementAt(2)["Title"]);

        private It should_then_be_followed_by_the_first = () => complexResult.ElementAt(2)["Title"].ShouldEqual(complexList.ElementAt(0)["Title"]);

        private It should_then_be_followed_by_the_second = () => complexResult.ElementAt(3)["Title"].ShouldEqual(complexList.ElementAt(1)["Title"]);

        private It should_then_be_followed_by_the_fourth = () => complexResult.ElementAt(4)["Title"].ShouldEqual(complexList.ElementAt(3)["Title"]);
    }

    public class When_using_order_by_on_two_sub_properties_both_descending : MongoPagingAndOrdering
    {
        private Because of = () => complexResult = complexCollection.LinqToQuerystring("?$orderby=Concrete/Complete desc,Concrete/Age desc", true).ToList();

        private It should_return_five_records = () => complexResult.Count().ShouldEqual(5);

        private It should_return_the_first_record = () => complexResult.ElementAt(0)["Title"].ShouldEqual(complexList.ElementAt(0)["Title"]);

        private It should_then_be_followed_by_the_second = () => complexResult.ElementAt(1)["Title"].ShouldEqual(complexList.ElementAt(1)["Title"]);

        private It should_then_be_followed_by_the_fourth = () => complexResult.ElementAt(2)["Title"].ShouldEqual(complexList.ElementAt(3)["Title"]);

        private It should_then_be_followed_by_the_fifth = () => complexResult.ElementAt(3)["Title"].ShouldEqual(complexList.ElementAt(4)["Title"]);

        private It should_then_be_followed_by_the_third = () => complexResult.ElementAt(4)["Title"].ShouldEqual(complexList.ElementAt(2)["Title"]);
    }

    #endregion

    #region OrderBy Mixed Properties and SubProperties

    public class When_using_order_by_on_mixed_properties : MongoPagingAndOrdering
    {
        private Because of = () => complexResult = complexCollection.LinqToQuerystring("?$orderby=Concrete/Complete,Title", true).ToList();

        private It should_return_five_records = () => complexResult.Count().ShouldEqual(5);

        private It should_return_the_fifth_record = () => complexResult.ElementAt(0)["Title"].ShouldEqual(complexList.ElementAt(4)["Title"]);

        private It should_then_be_followed_by_the_third = () => complexResult.ElementAt(1)["Title"].ShouldEqual(complexList.ElementAt(2)["Title"]);

        private It should_then_be_followed_by_the_second = () => complexResult.ElementAt(2)["Title"].ShouldEqual(complexList.ElementAt(1)["Title"]);

        private It should_then_be_followed_by_the_first = () => complexResult.ElementAt(3)["Title"].ShouldEqual(complexList.ElementAt(0)["Title"]);

        private It should_then_be_followed_by_the_fourth = () => complexResult.ElementAt(4)["Title"].ShouldEqual(complexList.ElementAt(3)["Title"]);
    }

    public class When_using_order_by_on_mixed_properties_one_descending_and_one_ascending : MongoPagingAndOrdering
    {
        private Because of = () => complexResult = complexCollection.LinqToQuerystring("?$orderby=Concrete/Complete desc,Title", true).ToList();

        private It should_return_five_records = () => complexResult.Count().ShouldEqual(5);

        private It should_return_the_second_record = () => complexResult.ElementAt(0)["Title"].ShouldEqual(complexList.ElementAt(1)["Title"]);

        private It should_then_be_followed_by_the_first = () => complexResult.ElementAt(1)["Title"].ShouldEqual(complexList.ElementAt(0)["Title"]);

        private It should_then_be_followed_by_the_fourth = () => complexResult.ElementAt(2)["Title"].ShouldEqual(complexList.ElementAt(3)["Title"]);

        private It should_then_be_followed_by_the_fifth = () => complexResult.ElementAt(3)["Title"].ShouldEqual(complexList.ElementAt(4)["Title"]);

        private It should_then_be_followed_by_the_third = () => complexResult.ElementAt(4)["Title"].ShouldEqual(complexList.ElementAt(2)["Title"]);
    }

    public class When_using_order_by_on_mixed_properties_one_ascending_and_one_descending : MongoPagingAndOrdering
    {
        private Because of = () => complexResult = complexCollection.LinqToQuerystring("?$orderby=Concrete/Complete,Title desc", true).ToList();

        private It should_return_five_records = () => complexResult.Count().ShouldEqual(5);

        private It should_return_the_third_record = () => complexResult.ElementAt(0)["Title"].ShouldEqual(complexList.ElementAt(2)["Title"]);

        private It should_then_be_followed_by_the_fifth = () => complexResult.ElementAt(1)["Title"].ShouldEqual(complexList.ElementAt(4)["Title"]);

        private It should_then_be_followed_by_the_fourth = () => complexResult.ElementAt(2)["Title"].ShouldEqual(complexList.ElementAt(3)["Title"]);

        private It should_then_be_followed_by_the_first = () => complexResult.ElementAt(3)["Title"].ShouldEqual(complexList.ElementAt(0)["Title"]);

        private It should_then_be_followed_by_the_second = () => complexResult.ElementAt(4)["Title"].ShouldEqual(complexList.ElementAt(1)["Title"]);
    }

    public class When_using_order_by_on_mixed_properties_both_descending : MongoPagingAndOrdering
    {
        private Because of = () => complexResult = complexCollection.LinqToQuerystring("?$orderby=Concrete/Complete desc,Title desc", true).ToList();

        private It should_return_five_records = () => complexResult.Count().ShouldEqual(5);

        private It should_return_the_fourth_record = () => complexResult.ElementAt(0)["Title"].ShouldEqual(complexList.ElementAt(3)["Title"]);

        private It should_then_be_followed_by_the_first = () => complexResult.ElementAt(1)["Title"].ShouldEqual(complexList.ElementAt(0)["Title"]);

        private It should_then_be_followed_by_the_second = () => complexResult.ElementAt(2)["Title"].ShouldEqual(complexList.ElementAt(1)["Title"]);

        private It should_then_be_followed_by_the_third = () => complexResult.ElementAt(3)["Title"].ShouldEqual(complexList.ElementAt(2)["Title"]);

        private It should_then_be_followed_by_the_fifth = () => complexResult.ElementAt(4)["Title"].ShouldEqual(complexList.ElementAt(4)["Title"]);
    }

    #endregion
}
