namespace LinqToQueryString.IntegrationTests
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    using LinqToQueryString.Tests;

    using LinqToQuerystring;

    using Machine.Specifications;

    public class SqlPagingAndOrdering
    {
        protected static TestDbContext testDb;

        protected static List<ConcreteClass> result;

        protected static List<ComplexClass> complexResult;

        protected static List<ConcreteClass> concreteCollection;

        protected static List<ComplexClass> complexCollection;

        private Establish context = () =>
            {
                testDb = new TestDbContext();
                Database.SetInitializer(new DropCreateDatabaseAlways<TestDbContext>());
                testDb.Database.Initialize(true);

                testDb.ComplexCollection.Add(new ComplexClass { Title = "Charles", Concrete = InstanceBuilders.BuildConcrete("Apple", 5, new DateTime(2005, 01, 01), true) });
                testDb.ComplexCollection.Add(new ComplexClass { Title = "Andrew", Concrete = InstanceBuilders.BuildConcrete("Custard", 3, new DateTime(2007, 01, 01), true) });
                testDb.ComplexCollection.Add(new ComplexClass { Title = "David", Concrete = InstanceBuilders.BuildConcrete("Banana", 2, new DateTime(2003, 01, 01), false) });
                testDb.ComplexCollection.Add(new ComplexClass { Title = "Edward", Concrete = InstanceBuilders.BuildConcrete("Eggs", 1, new DateTime(2000, 01, 01), true) });
                testDb.ComplexCollection.Add(new ComplexClass { Title = "Boris", Concrete = InstanceBuilders.BuildConcrete("Dogfood", 4, new DateTime(2009, 01, 01), false) });

                testDb.SaveChanges();

                concreteCollection = testDb.ConcreteCollection.ToList();
                complexCollection = testDb.ComplexCollection.ToList();
            };
    }

    #region Top Tests

    public class When_using_top_1 : SqlPagingAndOrdering
    {
        private Because of = () => result = testDb.ConcreteCollection.AsQueryable().LinqToQuerystring("?$top=1").ToList();

        private It should_return_one_record = () => result.Count().ShouldEqual(1);

        private It should_return_the_first_record = () => result.ElementAt(0).Name.ShouldEqual(concreteCollection.ElementAt(0).Name);
    }

    public class When_using_top_3 : SqlPagingAndOrdering
    {
        private Because of = () => result = testDb.ConcreteCollection.AsQueryable().LinqToQuerystring("?$top=3").ToList();

        private It should_return_three_records = () => result.Count().ShouldEqual(3);

        private It should_start_with_the_first_record = () => result.ElementAt(0).Name.ShouldEqual(concreteCollection.ElementAt(0).Name);

        private It should_then_follow_with_the_second_record = () => result.ElementAt(1).Name.ShouldEqual(concreteCollection.ElementAt(1).Name);

        private It should_then_follow_with_the_third_record = () => result.ElementAt(2).Name.ShouldEqual(concreteCollection.ElementAt(2).Name);
    }

    #endregion

    #region Skip Tests

    public class When_using_skip_1_on_ordered_data : SqlPagingAndOrdering
    {
        private Because of = () => result = testDb.ConcreteCollection.AsQueryable().LinqToQuerystring("?$orderby=Id&$skip=1").ToList();

        private It should_return_four_records = () => result.Count().ShouldEqual(4);

        private It should_start_with_the_second_record = () => result.ElementAt(0).Name.ShouldEqual(concreteCollection.ElementAt(1).Name);

        private It should_then_follow_with_the_third_record = () => result.ElementAt(1).Name.ShouldEqual(concreteCollection.ElementAt(2).Name);

        private It should_then_follow_with_the_fourth_record = () => result.ElementAt(2).Name.ShouldEqual(concreteCollection.ElementAt(3).Name);

        private It should_then_follow_with_the_fifth_record = () => result.ElementAt(3).Name.ShouldEqual(concreteCollection.ElementAt(4).Name);
    }

    public class When_using_skip_3_on_ordered_data : SqlPagingAndOrdering
    {
        private Because of = () => result = testDb.ConcreteCollection.AsQueryable().LinqToQuerystring("?$orderby=Id$skip=3").ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(2);

        private It should_start_with_the_fourth_record = () => result.ElementAt(0).Name.ShouldEqual(concreteCollection.ElementAt(3).Name);

        private It should_then_follow_with_the_fifth_record = () => result.ElementAt(1).Name.ShouldEqual(concreteCollection.ElementAt(4).Name);
    }

    #endregion

    #region Skip and Top Tests

    public class When_using_skip_2_and_top_2_on_ordered_data : SqlPagingAndOrdering
    {
        private Because of = () => result = testDb.ConcreteCollection.AsQueryable().LinqToQuerystring("?$orderby=Id$skip=2&$top=2").ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(2);

        private It should_start_with_the_third_record = () => result.ElementAt(0).Name.ShouldEqual(concreteCollection.ElementAt(2).Name);

        private It should_then_follow_with_the_fourth_record = () => result.ElementAt(1).Name.ShouldEqual(concreteCollection.ElementAt(3).Name);
    }

    public class When_using_skip_3_and_top_1_on_ordered_data : SqlPagingAndOrdering
    {
        private Because of = () => result = testDb.ConcreteCollection.AsQueryable().LinqToQuerystring("?$orderby=Id$skip=3&$top=1").ToList();

        private It should_return_one_record = () => result.Count().ShouldEqual(1);

        private It should_start_with_the_fourth_record = () => result.ElementAt(0).Name.ShouldEqual(concreteCollection.ElementAt(3).Name);
    }

    public class When_using_top_2_and_skip_2_on_ordered_data : SqlPagingAndOrdering
    {
        private Because of = () => result = testDb.ConcreteCollection.AsQueryable().LinqToQuerystring("?$orderby=Id$top=2&$skip=2").ToList();

        private It should_return_two_records = () => result.Count().ShouldEqual(2);

        private It should_start_with_the_third_record = () => result.ElementAt(0).Name.ShouldEqual(concreteCollection.ElementAt(2).Name);

        private It should_then_follow_with_the_fourth_record = () => result.ElementAt(1).Name.ShouldEqual(concreteCollection.ElementAt(3).Name);
    }

    #endregion

    #region OrderBy Single Integer Tests

    public class When_using_order_by_on_integer_with_one_criteria : SqlPagingAndOrdering
    {
        private Because of = () => result = testDb.ConcreteCollection.AsQueryable().LinqToQuerystring("?$orderby=Age").ToList();

        private It should_return_five_records = () => result.Count().ShouldEqual(5);

        private It should_return_the_fourth_record = () => result.ElementAt(0).Name.ShouldEqual(concreteCollection.ElementAt(3).Name);

        private It should_be_then_be_followed_by_the_third = () => result.ElementAt(1).Name.ShouldEqual(concreteCollection.ElementAt(2).Name);

        private It should_be_then_be_followed_by_the_second = () => result.ElementAt(2).Name.ShouldEqual(concreteCollection.ElementAt(1).Name);

        private It should_be_then_be_followed_by_the_fifth = () => result.ElementAt(3).Name.ShouldEqual(concreteCollection.ElementAt(4).Name);

        private It should_be_then_be_followed_by_the_first = () => result.ElementAt(4).Name.ShouldEqual(concreteCollection.ElementAt(0).Name);
    }

    public class When_using_order_by_asc_on_integer_with_one_criteria : SqlPagingAndOrdering
    {
        private Because of = () => result = testDb.ConcreteCollection.AsQueryable().LinqToQuerystring("?$orderby=Age asc").ToList();

        private It should_return_five_records = () => result.Count().ShouldEqual(5);

        private It should_return_the_fourth_record = () => result.ElementAt(0).Name.ShouldEqual(concreteCollection.ElementAt(3).Name);

        private It should_be_then_be_followed_by_the_third = () => result.ElementAt(1).Name.ShouldEqual(concreteCollection.ElementAt(2).Name);

        private It should_be_then_be_followed_by_the_second = () => result.ElementAt(2).Name.ShouldEqual(concreteCollection.ElementAt(1).Name);

        private It should_be_then_be_followed_by_the_fifth = () => result.ElementAt(3).Name.ShouldEqual(concreteCollection.ElementAt(4).Name);

        private It should_be_then_be_followed_by_the_first = () => result.ElementAt(4).Name.ShouldEqual(concreteCollection.ElementAt(0).Name);
    }

    public class When_using_order_by_desc_on_integer_with_one_criteria : SqlPagingAndOrdering
    {
        private Because of = () => result = testDb.ConcreteCollection.AsQueryable().LinqToQuerystring("?$orderby=Age desc").ToList();

        private It should_return_five_records = () => result.Count().ShouldEqual(5);

        private It should_return_the_fourth_record = () => result.ElementAt(0).Name.ShouldEqual(concreteCollection.ElementAt(0).Name);

        private It should_be_then_be_followed_by_the_third = () => result.ElementAt(1).Name.ShouldEqual(concreteCollection.ElementAt(4).Name);

        private It should_be_then_be_followed_by_the_second = () => result.ElementAt(2).Name.ShouldEqual(concreteCollection.ElementAt(1).Name);

        private It should_be_then_be_followed_by_the_fifth = () => result.ElementAt(3).Name.ShouldEqual(concreteCollection.ElementAt(2).Name);

        private It should_be_then_be_followed_by_the_first = () => result.ElementAt(4).Name.ShouldEqual(concreteCollection.ElementAt(3).Name);
    }

    #endregion

    #region OrderBy Single String Tests

    public class When_using_order_by_on_string_with_one_criteria : SqlPagingAndOrdering
    {
        private Because of = () => result = testDb.ConcreteCollection.AsQueryable().LinqToQuerystring("?$orderby=Name").ToList();

        private It should_return_five_records = () => result.Count().ShouldEqual(5);

        private It should_return_the_first_record = () => result.ElementAt(0).Name.ShouldEqual(concreteCollection.ElementAt(0).Name);

        private It should_be_then_be_followed_by_the_third = () => result.ElementAt(1).Name.ShouldEqual(concreteCollection.ElementAt(2).Name);

        private It should_be_then_be_followed_by_the_second = () => result.ElementAt(2).Name.ShouldEqual(concreteCollection.ElementAt(1).Name);

        private It should_be_then_be_followed_by_the_fifth = () => result.ElementAt(3).Name.ShouldEqual(concreteCollection.ElementAt(4).Name);

        private It should_be_then_be_followed_by_the_fourth = () => result.ElementAt(4).Name.ShouldEqual(concreteCollection.ElementAt(3).Name);
    }

    public class When_using_order_by_asc_on_string_with_one_criteria : SqlPagingAndOrdering
    {
        private Because of = () => result = testDb.ConcreteCollection.AsQueryable().LinqToQuerystring("?$orderby=Name asc").ToList();

        private It should_return_five_records = () => result.Count().ShouldEqual(5);

        private It should_return_the_first_record = () => result.ElementAt(0).Name.ShouldEqual(concreteCollection.ElementAt(0).Name);

        private It should_be_then_be_followed_by_the_third = () => result.ElementAt(1).Name.ShouldEqual(concreteCollection.ElementAt(2).Name);

        private It should_be_then_be_followed_by_the_second = () => result.ElementAt(2).Name.ShouldEqual(concreteCollection.ElementAt(1).Name);

        private It should_be_then_be_followed_by_the_fifth = () => result.ElementAt(3).Name.ShouldEqual(concreteCollection.ElementAt(4).Name);

        private It should_be_then_be_followed_by_the_fourth = () => result.ElementAt(4).Name.ShouldEqual(concreteCollection.ElementAt(3).Name);
    }

    public class When_using_order_by_desc_on_string_with_one_criteria : SqlPagingAndOrdering
    {
        private Because of = () => result = testDb.ConcreteCollection.AsQueryable().LinqToQuerystring("?$orderby=Name desc").ToList();

        private It should_return_five_records = () => result.Count().ShouldEqual(5);

        private It should_return_the_first_record = () => result.ElementAt(0).Name.ShouldEqual(concreteCollection.ElementAt(3).Name);

        private It should_be_then_be_followed_by_the_third = () => result.ElementAt(1).Name.ShouldEqual(concreteCollection.ElementAt(4).Name);

        private It should_be_then_be_followed_by_the_second = () => result.ElementAt(2).Name.ShouldEqual(concreteCollection.ElementAt(1).Name);

        private It should_be_then_be_followed_by_the_fifth = () => result.ElementAt(3).Name.ShouldEqual(concreteCollection.ElementAt(2).Name);

        private It should_be_then_be_followed_by_the_fourth = () => result.ElementAt(4).Name.ShouldEqual(concreteCollection.ElementAt(0).Name);
    }

    #endregion

    #region OrderBy Single Date Tests

    public class When_using_order_by_on_date_with_one_criteria : SqlPagingAndOrdering
    {
        private Because of = () => result = testDb.ConcreteCollection.AsQueryable().LinqToQuerystring("?$orderby=Date").ToList();

        private It should_return_five_records = () => result.Count().ShouldEqual(5);

        private It should_return_the_fourth_record = () => result.ElementAt(0).Name.ShouldEqual(concreteCollection.ElementAt(3).Name);

        private It should_be_then_be_followed_by_the_third = () => result.ElementAt(1).Name.ShouldEqual(concreteCollection.ElementAt(2).Name);

        private It should_be_then_be_followed_by_the_first = () => result.ElementAt(2).Name.ShouldEqual(concreteCollection.ElementAt(0).Name);

        private It should_be_then_be_followed_by_the_second = () => result.ElementAt(3).Name.ShouldEqual(concreteCollection.ElementAt(1).Name);

        private It should_be_then_be_followed_by_the_fifth = () => result.ElementAt(4).Name.ShouldEqual(concreteCollection.ElementAt(4).Name);
    }

    public class When_using_order_by_asc_on_date_with_one_criteria : SqlPagingAndOrdering
    {
        private Because of = () => result = testDb.ConcreteCollection.AsQueryable().LinqToQuerystring("?$orderby=Date asc").ToList();

        private It should_return_five_records = () => result.Count().ShouldEqual(5);

        private It should_return_the_fourth_record = () => result.ElementAt(0).Name.ShouldEqual(concreteCollection.ElementAt(3).Name);

        private It should_be_then_be_followed_by_the_third = () => result.ElementAt(1).Name.ShouldEqual(concreteCollection.ElementAt(2).Name);

        private It should_be_then_be_followed_by_the_first = () => result.ElementAt(2).Name.ShouldEqual(concreteCollection.ElementAt(0).Name);

        private It should_be_then_be_followed_by_the_second = () => result.ElementAt(3).Name.ShouldEqual(concreteCollection.ElementAt(1).Name);

        private It should_be_then_be_followed_by_the_fifth = () => result.ElementAt(4).Name.ShouldEqual(concreteCollection.ElementAt(4).Name);
    }

    public class When_using_order_by_desc_on_date_with_one_criteria : SqlPagingAndOrdering
    {
        private Because of = () => result = testDb.ConcreteCollection.AsQueryable().LinqToQuerystring("?$orderby=Date desc").ToList();

        private It should_return_five_records = () => result.Count().ShouldEqual(5);

        private It should_return_the_fourth_record = () => result.ElementAt(0).Name.ShouldEqual(concreteCollection.ElementAt(4).Name);

        private It should_be_then_be_followed_by_the_third = () => result.ElementAt(1).Name.ShouldEqual(concreteCollection.ElementAt(1).Name);

        private It should_be_then_be_followed_by_the_first = () => result.ElementAt(2).Name.ShouldEqual(concreteCollection.ElementAt(0).Name);

        private It should_be_then_be_followed_by_the_second = () => result.ElementAt(3).Name.ShouldEqual(concreteCollection.ElementAt(2).Name);

        private It should_be_then_be_followed_by_the_fifth = () => result.ElementAt(4).Name.ShouldEqual(concreteCollection.ElementAt(3).Name);
    }

    #endregion

    #region OrderBy Single Boolean Tests

    public class When_using_order_by_on_bool_with_one_criteria : SqlPagingAndOrdering
    {
        private Because of = () => result = testDb.ConcreteCollection.AsQueryable().LinqToQuerystring("?$orderby=Complete").ToList();

        private It should_return_five_records = () => result.Count().ShouldEqual(5);

        private It should_have_sorted_a_false_value_first = () => result.ElementAt(0).Complete.ShouldBeFalse();

        private It should_have_sorted_a_false_value_second = () => result.ElementAt(1).Complete.ShouldBeFalse();

        private It should_have_sorted_a_true_value_third = () => result.ElementAt(2).Complete.ShouldBeTrue();

        private It should_have_sorted_a_true_value_fourth = () => result.ElementAt(3).Complete.ShouldBeTrue();

        private It should_have_sorted_a_true_value_fifth = () => result.ElementAt(4).Complete.ShouldBeTrue();
    }

    public class When_using_order_by_asc_on_bool_with_one_criteria : SqlPagingAndOrdering
    {
        private Because of = () => result = testDb.ConcreteCollection.AsQueryable().LinqToQuerystring("?$orderby=Complete asc").ToList();

        private It should_return_five_records = () => result.Count().ShouldEqual(5);

        private It should_have_sorted_a_false_value_first = () => result.ElementAt(0).Complete.ShouldBeFalse();

        private It should_have_sorted_a_false_value_second = () => result.ElementAt(1).Complete.ShouldBeFalse();

        private It should_have_sorted_a_true_value_third = () => result.ElementAt(2).Complete.ShouldBeTrue();

        private It should_have_sorted_a_true_value_fourth = () => result.ElementAt(3).Complete.ShouldBeTrue();

        private It should_have_sorted_a_true_value_fifth = () => result.ElementAt(4).Complete.ShouldBeTrue();
    }

    public class When_using_order_by_desc_on_bool_with_one_criteria : SqlPagingAndOrdering
    {
        private Because of = () => result = testDb.ConcreteCollection.AsQueryable().LinqToQuerystring("?$orderby=Complete desc").ToList();

        private It should_return_five_records = () => result.Count().ShouldEqual(5);

        private It should_have_sorted_a_true_value_first = () => result.ElementAt(0).Complete.ShouldBeTrue();

        private It should_have_sorted_a_true_value_second = () => result.ElementAt(1).Complete.ShouldBeTrue();

        private It should_have_sorted_a_true_value_third = () => result.ElementAt(2).Complete.ShouldBeTrue();

        private It should_have_sorted_a_false_value_fourth = () => result.ElementAt(3).Complete.ShouldBeFalse();

        private It should_have_sorted_a_false_value_fifth = () => result.ElementAt(4).Complete.ShouldBeFalse();
    }

    #endregion

    #region OrderBy Multiple Properties

    public class When_using_order_by_on_two_properties : SqlPagingAndOrdering
    {
        private Because of = () => result = testDb.ConcreteCollection.AsQueryable().LinqToQuerystring("?$orderby=Complete,Age").ToList();

        private It should_return_five_records = () => result.Count().ShouldEqual(5);

        private It should_return_the_third_record = () => result.ElementAt(0).Name.ShouldEqual(concreteCollection.ElementAt(2).Name);

        private It should_then_be_followed_by_the_fifth = () => result.ElementAt(1).Name.ShouldEqual(concreteCollection.ElementAt(4).Name);

        private It should_then_be_followed_by_the_fourth = () => result.ElementAt(2).Name.ShouldEqual(concreteCollection.ElementAt(3).Name);

        private It should_then_be_followed_by_the_second = () => result.ElementAt(3).Name.ShouldEqual(concreteCollection.ElementAt(1).Name);

        private It should_then_be_followed_by_the_first = () => result.ElementAt(4).Name.ShouldEqual(concreteCollection.ElementAt(0).Name);
    }

    public class When_using_order_by_on_one_descending_and_one_ascending : SqlPagingAndOrdering
    {
        private Because of = () => result = testDb.ConcreteCollection.AsQueryable().LinqToQuerystring("?$orderby=Complete desc,Age").ToList();

        private It should_return_five_records = () => result.Count().ShouldEqual(5);

        private It should_return_the_fourth_record = () => result.ElementAt(0).Name.ShouldEqual(concreteCollection.ElementAt(3).Name);

        private It should_then_be_followed_by_the_second = () => result.ElementAt(1).Name.ShouldEqual(concreteCollection.ElementAt(1).Name);

        private It should_then_be_followed_by_the_first = () => result.ElementAt(2).Name.ShouldEqual(concreteCollection.ElementAt(0).Name);

        private It should_then_be_followed_by_the_third = () => result.ElementAt(3).Name.ShouldEqual(concreteCollection.ElementAt(2).Name);

        private It should_then_be_followed_by_the_fifth = () => result.ElementAt(4).Name.ShouldEqual(concreteCollection.ElementAt(4).Name);
    }

    public class When_using_order_by_on_one_ascending_and_one_descending : SqlPagingAndOrdering
    {
        private Because of = () => result = testDb.ConcreteCollection.AsQueryable().LinqToQuerystring("?$orderby=Complete,Age desc").ToList();

        private It should_return_five_records = () => result.Count().ShouldEqual(5);

        private It should_return_the_fifth_record = () => result.ElementAt(0).Name.ShouldEqual(concreteCollection.ElementAt(4).Name);

        private It should_then_be_followed_by_the_third = () => result.ElementAt(1).Name.ShouldEqual(concreteCollection.ElementAt(2).Name);

        private It should_then_be_followed_by_the_first = () => result.ElementAt(2).Name.ShouldEqual(concreteCollection.ElementAt(0).Name);

        private It should_then_be_followed_by_the_second = () => result.ElementAt(3).Name.ShouldEqual(concreteCollection.ElementAt(1).Name);

        private It should_then_be_followed_by_the_fourth = () => result.ElementAt(4).Name.ShouldEqual(concreteCollection.ElementAt(3).Name);
    }

    public class When_using_order_by_on_two_properties_both_descending : SqlPagingAndOrdering
    {
        private Because of = () => result = testDb.ConcreteCollection.AsQueryable().LinqToQuerystring("?$orderby=Complete desc,Age desc").ToList();

        private It should_return_five_records = () => result.Count().ShouldEqual(5);

        private It should_return_the_first_record = () => result.ElementAt(0).Name.ShouldEqual(concreteCollection.ElementAt(0).Name);

        private It should_then_be_followed_by_the_second = () => result.ElementAt(1).Name.ShouldEqual(concreteCollection.ElementAt(1).Name);

        private It should_then_be_followed_by_the_fourth = () => result.ElementAt(2).Name.ShouldEqual(concreteCollection.ElementAt(3).Name);

        private It should_then_be_followed_by_the_fifth = () => result.ElementAt(3).Name.ShouldEqual(concreteCollection.ElementAt(4).Name);

        private It should_then_be_followed_by_the_third = () => result.ElementAt(4).Name.ShouldEqual(concreteCollection.ElementAt(2).Name);
    }

    #endregion

    #region OrderBy SubProperties

    public class When_using_order_by_on_a_single_subproperty : SqlPagingAndOrdering
    {
        private Because of = () => complexResult = testDb.ComplexCollection.AsQueryable().LinqToQuerystring(@"?$orderby=Concrete/Age").ToList();

        private It should_return_five_records = () => complexResult.Count().ShouldEqual(5);

        private It should_return_the_fourth_record = () => complexResult.ElementAt(0).Title.ShouldEqual(complexCollection.ElementAt(3).Title);

        private It should_be_then_be_followed_by_the_third = () => complexResult.ElementAt(1).Title.ShouldEqual(complexCollection.ElementAt(2).Title);

        private It should_be_then_be_followed_by_the_second = () => complexResult.ElementAt(2).Title.ShouldEqual(complexCollection.ElementAt(1).Title);

        private It should_be_then_be_followed_by_the_fifth = () => complexResult.ElementAt(3).Title.ShouldEqual(complexCollection.ElementAt(4).Title);

        private It should_be_then_be_followed_by_the_first = () => complexResult.ElementAt(4).Title.ShouldEqual(complexCollection.ElementAt(0).Title);
    }

    public class When_using_order_by_asc_on_a_single_subproperty : SqlPagingAndOrdering
    {
        private Because of = () => complexResult = testDb.ComplexCollection.AsQueryable().LinqToQuerystring(@"?$orderby=Concrete/Age asc").ToList();

        private It should_return_five_records = () => complexResult.Count().ShouldEqual(5);

        private It should_return_the_fourth_record = () => complexResult.ElementAt(0).Title.ShouldEqual(complexCollection.ElementAt(3).Title);

        private It should_be_then_be_followed_by_the_third = () => complexResult.ElementAt(1).Title.ShouldEqual(complexCollection.ElementAt(2).Title);

        private It should_be_then_be_followed_by_the_second = () => complexResult.ElementAt(2).Title.ShouldEqual(complexCollection.ElementAt(1).Title);

        private It should_be_then_be_followed_by_the_fifth = () => complexResult.ElementAt(3).Title.ShouldEqual(complexCollection.ElementAt(4).Title);

        private It should_be_then_be_followed_by_the_first = () => complexResult.ElementAt(4).Title.ShouldEqual(complexCollection.ElementAt(0).Title);
    }

    public class When_using_order_by_desc_on_a_single_subproperty : SqlPagingAndOrdering
    {
        private Because of = () => complexResult = testDb.ComplexCollection.AsQueryable().LinqToQuerystring("?$orderby=Concrete/Age desc").ToList();

        private It should_return_five_records = () => complexResult.Count().ShouldEqual(5);

        private It should_return_the_first_record = () => complexResult.ElementAt(0).Title.ShouldEqual(complexCollection.ElementAt(0).Title);

        private It should_be_then_be_followed_by_the_fifth = () => complexResult.ElementAt(1).Title.ShouldEqual(complexCollection.ElementAt(4).Title);

        private It should_be_then_be_followed_by_the_second = () => complexResult.ElementAt(2).Title.ShouldEqual(complexCollection.ElementAt(1).Title);

        private It should_be_then_be_followed_by_the_third = () => complexResult.ElementAt(3).Title.ShouldEqual(complexCollection.ElementAt(2).Title);

        private It should_be_then_be_followed_by_the_fourth = () => complexResult.ElementAt(4).Title.ShouldEqual(complexCollection.ElementAt(3).Title);
    }

    #endregion

    #region OrderBy Multiple SubProperties

    public class When_using_order_by_on_two_sub_properties : SqlPagingAndOrdering
    {
        private Because of = () => complexResult = testDb.ComplexCollection.AsQueryable().LinqToQuerystring("?$orderby=Concrete/Complete,Concrete/Age").ToList();

        private It should_return_five_records = () => complexResult.Count().ShouldEqual(5);

        private It should_return_the_third_record = () => complexResult.ElementAt(0).Title.ShouldEqual(complexCollection.ElementAt(2).Title);

        private It should_then_be_followed_by_the_fifth = () => complexResult.ElementAt(1).Title.ShouldEqual(complexCollection.ElementAt(4).Title);

        private It should_then_be_followed_by_the_fourth = () => complexResult.ElementAt(2).Title.ShouldEqual(complexCollection.ElementAt(3).Title);

        private It should_then_be_followed_by_the_second = () => complexResult.ElementAt(3).Title.ShouldEqual(complexCollection.ElementAt(1).Title);

        private It should_then_be_followed_by_the_first = () => complexResult.ElementAt(4).Title.ShouldEqual(complexCollection.ElementAt(0).Title);
    }

    public class When_using_order_by_on_two_sub_properties_one_descending_and_one_ascending : SqlPagingAndOrdering
    {
        private Because of = () => complexResult = testDb.ComplexCollection.AsQueryable().LinqToQuerystring("?$orderby=Concrete/Complete desc,Concrete/Age").ToList();

        private It should_return_five_records = () => complexResult.Count().ShouldEqual(5);

        private It should_return_the_fourth_record = () => complexResult.ElementAt(0).Title.ShouldEqual(complexCollection.ElementAt(3).Title);

        private It should_then_be_followed_by_the_second = () => complexResult.ElementAt(1).Title.ShouldEqual(complexCollection.ElementAt(1).Title);

        private It should_then_be_followed_by_the_first = () => complexResult.ElementAt(2).Title.ShouldEqual(complexCollection.ElementAt(0).Title);

        private It should_then_be_followed_by_the_third = () => complexResult.ElementAt(3).Title.ShouldEqual(complexCollection.ElementAt(2).Title);

        private It should_then_be_followed_by_the_fifth = () => complexResult.ElementAt(4).Title.ShouldEqual(complexCollection.ElementAt(4).Title);
    }

    public class When_using_order_by_on_two_sub_properties_one_ascending_and_one_descending : SqlPagingAndOrdering
    {
        private Because of = () => complexResult = testDb.ComplexCollection.AsQueryable().LinqToQuerystring("?$orderby=Concrete/Complete,Concrete/Age desc").ToList();

        private It should_return_five_records = () => complexResult.Count().ShouldEqual(5);

        private It should_return_the_fifth_record = () => complexResult.ElementAt(0).Title.ShouldEqual(complexCollection.ElementAt(4).Title);

        private It should_then_be_followed_by_the_third = () => complexResult.ElementAt(1).Title.ShouldEqual(complexCollection.ElementAt(2).Title);

        private It should_then_be_followed_by_the_first = () => complexResult.ElementAt(2).Title.ShouldEqual(complexCollection.ElementAt(0).Title);

        private It should_then_be_followed_by_the_second = () => complexResult.ElementAt(3).Title.ShouldEqual(complexCollection.ElementAt(1).Title);

        private It should_then_be_followed_by_the_fourth = () => complexResult.ElementAt(4).Title.ShouldEqual(complexCollection.ElementAt(3).Title);
    }

    public class When_using_order_by_on_two_sub_properties_both_descending : SqlPagingAndOrdering
    {
        private Because of = () => complexResult = testDb.ComplexCollection.AsQueryable().LinqToQuerystring("?$orderby=Concrete/Complete desc,Concrete/Age desc").ToList();

        private It should_return_five_records = () => complexResult.Count().ShouldEqual(5);

        private It should_return_the_first_record = () => complexResult.ElementAt(0).Title.ShouldEqual(complexCollection.ElementAt(0).Title);

        private It should_then_be_followed_by_the_second = () => complexResult.ElementAt(1).Title.ShouldEqual(complexCollection.ElementAt(1).Title);

        private It should_then_be_followed_by_the_fourth = () => complexResult.ElementAt(2).Title.ShouldEqual(complexCollection.ElementAt(3).Title);

        private It should_then_be_followed_by_the_fifth = () => complexResult.ElementAt(3).Title.ShouldEqual(complexCollection.ElementAt(4).Title);

        private It should_then_be_followed_by_the_third = () => complexResult.ElementAt(4).Title.ShouldEqual(complexCollection.ElementAt(2).Title);
    }

    #endregion

    #region OrderBy Mixed Properties and SubProperties

    public class When_using_order_by_on_mixed_properties : SqlPagingAndOrdering
    {
        private Because of = () => complexResult = testDb.ComplexCollection.AsQueryable().LinqToQuerystring("?$orderby=Concrete/Complete,Title").ToList();

        private It should_return_five_records = () => complexResult.Count().ShouldEqual(5);

        private It should_return_the_fifth_record = () => complexResult.ElementAt(0).Title.ShouldEqual(complexCollection.ElementAt(4).Title);

        private It should_then_be_followed_by_the_third = () => complexResult.ElementAt(1).Title.ShouldEqual(complexCollection.ElementAt(2).Title);

        private It should_then_be_followed_by_the_second = () => complexResult.ElementAt(2).Title.ShouldEqual(complexCollection.ElementAt(1).Title);

        private It should_then_be_followed_by_the_first = () => complexResult.ElementAt(3).Title.ShouldEqual(complexCollection.ElementAt(0).Title);

        private It should_then_be_followed_by_the_fourth = () => complexResult.ElementAt(4).Title.ShouldEqual(complexCollection.ElementAt(3).Title);
    }

    public class When_using_order_by_on_mixed_properties_one_descending_and_one_ascending : SqlPagingAndOrdering
    {
        private Because of = () => complexResult = testDb.ComplexCollection.AsQueryable().LinqToQuerystring("?$orderby=Concrete/Complete desc,Title").ToList();

        private It should_return_five_records = () => complexResult.Count().ShouldEqual(5);

        private It should_return_the_second_record = () => complexResult.ElementAt(0).Title.ShouldEqual(complexCollection.ElementAt(1).Title);

        private It should_then_be_followed_by_the_first = () => complexResult.ElementAt(1).Title.ShouldEqual(complexCollection.ElementAt(0).Title);

        private It should_then_be_followed_by_the_fourth = () => complexResult.ElementAt(2).Title.ShouldEqual(complexCollection.ElementAt(3).Title);

        private It should_then_be_followed_by_the_fifth = () => complexResult.ElementAt(3).Title.ShouldEqual(complexCollection.ElementAt(4).Title);

        private It should_then_be_followed_by_the_third = () => complexResult.ElementAt(4).Title.ShouldEqual(complexCollection.ElementAt(2).Title);
    }

    public class When_using_order_by_on_mixed_properties_one_ascending_and_one_descending : SqlPagingAndOrdering
    {
        private Because of = () => complexResult = testDb.ComplexCollection.AsQueryable().LinqToQuerystring("?$orderby=Concrete/Complete,Title desc").ToList();

        private It should_return_five_records = () => complexResult.Count().ShouldEqual(5);

        private It should_return_the_third_record = () => complexResult.ElementAt(0).Title.ShouldEqual(complexCollection.ElementAt(2).Title);

        private It should_then_be_followed_by_the_fifth = () => complexResult.ElementAt(1).Title.ShouldEqual(complexCollection.ElementAt(4).Title);

        private It should_then_be_followed_by_the_fourth = () => complexResult.ElementAt(2).Title.ShouldEqual(complexCollection.ElementAt(3).Title);

        private It should_then_be_followed_by_the_first = () => complexResult.ElementAt(3).Title.ShouldEqual(complexCollection.ElementAt(0).Title);

        private It should_then_be_followed_by_the_second = () => complexResult.ElementAt(4).Title.ShouldEqual(complexCollection.ElementAt(1).Title);
    }

    public class When_using_order_by_on_mixed_properties_both_descending : SqlPagingAndOrdering
    {
        private Because of = () => complexResult = testDb.ComplexCollection.AsQueryable().LinqToQuerystring("?$orderby=Concrete/Complete desc,Title desc").ToList();

        private It should_return_five_records = () => complexResult.Count().ShouldEqual(5);

        private It should_return_the_fourth_record = () => complexResult.ElementAt(0).Title.ShouldEqual(complexCollection.ElementAt(3).Title);

        private It should_then_be_followed_by_the_first = () => complexResult.ElementAt(1).Title.ShouldEqual(complexCollection.ElementAt(0).Title);

        private It should_then_be_followed_by_the_second = () => complexResult.ElementAt(2).Title.ShouldEqual(complexCollection.ElementAt(1).Title);

        private It should_then_be_followed_by_the_third = () => complexResult.ElementAt(3).Title.ShouldEqual(complexCollection.ElementAt(2).Title);

        private It should_then_be_followed_by_the_fifth = () => complexResult.ElementAt(4).Title.ShouldEqual(complexCollection.ElementAt(4).Title);
    }

    #endregion
}
