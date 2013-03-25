namespace LinqToQueryString.UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using LinqToQuerystring;

    using Machine.Specifications;

    public abstract class PagingAndOrdering
    {
        protected static IQueryable<ConcreteClass> result;

        protected static List<ConcreteClass> concreteCollection, complexOrderingCollection;

        protected static ConcreteClass BuildConcreteClassInstance(string name, int age, DateTime date, bool complete)
        {
            return new ConcreteClass
                       {
                           Name = name,
                           Date = date,
                           Age = age,
                           Complete = complete
                       };
        }

        private Establish context = () =>
        {
            concreteCollection = new List<ConcreteClass>
                                         {
                                             BuildConcreteClassInstance("Apple", 5, new DateTime(2005, 01, 01), true),
                                             BuildConcreteClassInstance("Custard", 3, new DateTime(2007, 01, 01), true),
                                             BuildConcreteClassInstance("Banana", 2, new DateTime(2003, 01, 01), false),
                                             BuildConcreteClassInstance("Eggs", 1, new DateTime(2000, 01, 01), true),
                                             BuildConcreteClassInstance("Dogfood", 4, new DateTime(2009, 01, 01), false),
                                         };

            complexOrderingCollection = new List<ConcreteClass>
                                         {
                                             BuildConcreteClassInstance("Apple", 1, new DateTime(2005, 01, 01), true),
                                             BuildConcreteClassInstance("Apple", 1, new DateTime(2007, 01, 01), true),
                                             BuildConcreteClassInstance("Banana", 1, new DateTime(2000, 01, 01), false),
                                             BuildConcreteClassInstance("Banana", 2, new DateTime(2000, 01, 01), true),
                                             BuildConcreteClassInstance("Banana", 3, new DateTime(2000, 01, 01), false),
                                         };
        };
    }

    #region Top Tests

    public class When_using_top_1 : PagingAndOrdering
    {
        private Because of = () => result = concreteCollection.AsQueryable().ExtendFromOData("?$top=1");

        private It should_return_one_record = () => result.Count().ShouldEqual(1);

        private It should_return_the_first_record = () => result.ElementAt(0).Name.ShouldEqual(concreteCollection.ElementAt(0).Name);
    }

    public class When_using_top_3 : PagingAndOrdering
    {
        private Because of = () => result = concreteCollection.AsQueryable().ExtendFromOData("?$top=3");

        private It should_return_three_record = () => result.Count().ShouldEqual(3);

        private It should_start_with_the_first_record = () => result.ElementAt(0).Name.ShouldEqual(concreteCollection.ElementAt(0).Name);

        private It should_then_follow_with_the_second_record = () => result.ElementAt(1).Name.ShouldEqual(concreteCollection.ElementAt(1).Name);

        private It should_then_follow_with_the_third_record = () => result.ElementAt(2).Name.ShouldEqual(concreteCollection.ElementAt(2).Name);
    }

    #endregion

    #region Skip Tests

    public class When_using_skip_1 : PagingAndOrdering
    {
        private Because of = () => result = concreteCollection.AsQueryable().ExtendFromOData("?$skip=1");

        private It should_return_four_records = () => result.Count().ShouldEqual(4);

        private It should_start_with_the_second_record = () => result.ElementAt(0).Name.ShouldEqual(concreteCollection.ElementAt(1).Name);

        private It should_then_follow_with_the_third_record = () => result.ElementAt(1).Name.ShouldEqual(concreteCollection.ElementAt(2).Name);

        private It should_then_follow_with_the_fourth_record = () => result.ElementAt(2).Name.ShouldEqual(concreteCollection.ElementAt(3).Name);

        private It should_then_follow_with_the_fifth_record = () => result.ElementAt(3).Name.ShouldEqual(concreteCollection.ElementAt(4).Name);
    }

    public class When_using_skip_3 : PagingAndOrdering
    {
        private Because of = () => result = concreteCollection.AsQueryable().ExtendFromOData("?$skip=3");

        private It should_return_two_records = () => result.Count().ShouldEqual(2);

        private It should_start_with_the_fourth_record = () => result.ElementAt(0).Name.ShouldEqual(concreteCollection.ElementAt(3).Name);

        private It should_then_follow_with_the_fifth_record = () => result.ElementAt(1).Name.ShouldEqual(concreteCollection.ElementAt(4).Name);
    }

    #endregion

    #region Skip and Top Tests

    public class When_using_skip_2_and_top_2 : PagingAndOrdering
    {
        private Because of = () => result = concreteCollection.AsQueryable().ExtendFromOData("?$skip=2&$top=2");

        private It should_return_two_records = () => result.Count().ShouldEqual(2);

        private It should_start_with_the_third_record = () => result.ElementAt(0).Name.ShouldEqual(concreteCollection.ElementAt(2).Name);

        private It should_then_follow_with_the_fourth_record = () => result.ElementAt(1).Name.ShouldEqual(concreteCollection.ElementAt(3).Name);
    }

    public class When_using_skip_3_and_top_1 : PagingAndOrdering
    {
        private Because of = () => result = concreteCollection.AsQueryable().ExtendFromOData("?$skip=3&$top=1");

        private It should_return_one_record = () => result.Count().ShouldEqual(1);

        private It should_start_with_the_fourth_record = () => result.ElementAt(0).Name.ShouldEqual(concreteCollection.ElementAt(3).Name);
    }

    public class When_using_top_2_and_skip_2 : PagingAndOrdering
    {
        private Because of = () => result = concreteCollection.AsQueryable().ExtendFromOData("?$top=2&$skip=2");

        private It should_return_two_records = () => result.Count().ShouldEqual(2);

        private It should_start_with_the_third_record = () => result.ElementAt(0).Name.ShouldEqual(concreteCollection.ElementAt(2).Name);

        private It should_then_follow_with_the_fourth_record = () => result.ElementAt(1).Name.ShouldEqual(concreteCollection.ElementAt(3).Name);
    }

    #endregion

    #region OrderBy Single Integer Tests

    public class When_using_order_by_on_integer_with_one_criteria : PagingAndOrdering
    {
        private Because of = () => result = concreteCollection.AsQueryable().ExtendFromOData("?$orderby=Age");

        private It should_return_five_records = () => result.Count().ShouldEqual(5);

        private It should_return_the_fourth_record = () => result.ElementAt(0).Name.ShouldEqual(concreteCollection.ElementAt(3).Name);

        private It should_be_then_be_followed_by_the_third = () => result.ElementAt(1).Name.ShouldEqual(concreteCollection.ElementAt(2).Name);

        private It should_be_then_be_followed_by_the_second = () => result.ElementAt(2).Name.ShouldEqual(concreteCollection.ElementAt(1).Name);

        private It should_be_then_be_followed_by_the_fifth = () => result.ElementAt(3).Name.ShouldEqual(concreteCollection.ElementAt(4).Name);

        private It should_be_then_be_followed_by_the_first = () => result.ElementAt(4).Name.ShouldEqual(concreteCollection.ElementAt(0).Name);
    }

    public class When_using_order_by_asc_on_integer_with_one_criteria : PagingAndOrdering
    {
        private Because of = () => result = concreteCollection.AsQueryable().ExtendFromOData("?$orderby=Age asc");

        private It should_return_five_records = () => result.Count().ShouldEqual(5);

        private It should_return_the_fourth_record = () => result.ElementAt(0).Name.ShouldEqual(concreteCollection.ElementAt(3).Name);

        private It should_be_then_be_followed_by_the_third = () => result.ElementAt(1).Name.ShouldEqual(concreteCollection.ElementAt(2).Name);

        private It should_be_then_be_followed_by_the_second = () => result.ElementAt(2).Name.ShouldEqual(concreteCollection.ElementAt(1).Name);

        private It should_be_then_be_followed_by_the_fifth = () => result.ElementAt(3).Name.ShouldEqual(concreteCollection.ElementAt(4).Name);

        private It should_be_then_be_followed_by_the_first = () => result.ElementAt(4).Name.ShouldEqual(concreteCollection.ElementAt(0).Name);
    }

    public class When_using_order_by_desc_on_integer_with_one_criteria : PagingAndOrdering
    {
        private Because of = () => result = concreteCollection.AsQueryable().ExtendFromOData("?$orderby=Age desc");

        private It should_return_five_records = () => result.Count().ShouldEqual(5);

        private It should_return_the_fourth_record = () => result.ElementAt(0).Name.ShouldEqual(concreteCollection.ElementAt(0).Name);

        private It should_be_then_be_followed_by_the_third = () => result.ElementAt(1).Name.ShouldEqual(concreteCollection.ElementAt(4).Name);

        private It should_be_then_be_followed_by_the_second = () => result.ElementAt(2).Name.ShouldEqual(concreteCollection.ElementAt(1).Name);

        private It should_be_then_be_followed_by_the_fifth = () => result.ElementAt(3).Name.ShouldEqual(concreteCollection.ElementAt(2).Name);

        private It should_be_then_be_followed_by_the_first = () => result.ElementAt(4).Name.ShouldEqual(concreteCollection.ElementAt(3).Name);
    }

    #endregion

    #region OrderBy Single String Tests

    public class When_using_order_by_on_string_with_one_criteria : PagingAndOrdering
    {
        private Because of = () => result = concreteCollection.AsQueryable().ExtendFromOData("?$orderby=Name");

        private It should_return_five_records = () => result.Count().ShouldEqual(5);

        private It should_return_the_first_record = () => result.ElementAt(0).Name.ShouldEqual(concreteCollection.ElementAt(0).Name);

        private It should_be_then_be_followed_by_the_third = () => result.ElementAt(1).Name.ShouldEqual(concreteCollection.ElementAt(2).Name);

        private It should_be_then_be_followed_by_the_second = () => result.ElementAt(2).Name.ShouldEqual(concreteCollection.ElementAt(1).Name);

        private It should_be_then_be_followed_by_the_fifth = () => result.ElementAt(3).Name.ShouldEqual(concreteCollection.ElementAt(4).Name);

        private It should_be_then_be_followed_by_the_fourth = () => result.ElementAt(4).Name.ShouldEqual(concreteCollection.ElementAt(3).Name);
    }

    public class When_using_order_by_asc_on_string_with_one_criteria : PagingAndOrdering
    {
        private Because of = () => result = concreteCollection.AsQueryable().ExtendFromOData("?$orderby=Name asc");

        private It should_return_five_records = () => result.Count().ShouldEqual(5);

        private It should_return_the_first_record = () => result.ElementAt(0).Name.ShouldEqual(concreteCollection.ElementAt(0).Name);

        private It should_be_then_be_followed_by_the_third = () => result.ElementAt(1).Name.ShouldEqual(concreteCollection.ElementAt(2).Name);

        private It should_be_then_be_followed_by_the_second = () => result.ElementAt(2).Name.ShouldEqual(concreteCollection.ElementAt(1).Name);

        private It should_be_then_be_followed_by_the_fifth = () => result.ElementAt(3).Name.ShouldEqual(concreteCollection.ElementAt(4).Name);

        private It should_be_then_be_followed_by_the_fourth = () => result.ElementAt(4).Name.ShouldEqual(concreteCollection.ElementAt(3).Name);
    }

    public class When_using_order_by_desc_on_string_with_one_criteria : PagingAndOrdering
    {
        private Because of = () => result = concreteCollection.AsQueryable().ExtendFromOData("?$orderby=Name desc");

        private It should_return_five_records = () => result.Count().ShouldEqual(5);

        private It should_return_the_first_record = () => result.ElementAt(0).Name.ShouldEqual(concreteCollection.ElementAt(3).Name);

        private It should_be_then_be_followed_by_the_third = () => result.ElementAt(1).Name.ShouldEqual(concreteCollection.ElementAt(4).Name);

        private It should_be_then_be_followed_by_the_second = () => result.ElementAt(2).Name.ShouldEqual(concreteCollection.ElementAt(1).Name);

        private It should_be_then_be_followed_by_the_fifth = () => result.ElementAt(3).Name.ShouldEqual(concreteCollection.ElementAt(2).Name);

        private It should_be_then_be_followed_by_the_fourth = () => result.ElementAt(4).Name.ShouldEqual(concreteCollection.ElementAt(0).Name);
    }

    #endregion

    #region OrderBy Single Date Tests

    public class When_using_order_by_on_date_with_one_criteria : PagingAndOrdering
    {
        private Because of = () => result = concreteCollection.AsQueryable().ExtendFromOData("?$orderby=Date");

        private It should_return_five_records = () => result.Count().ShouldEqual(5);

        private It should_return_the_fourth_record = () => result.ElementAt(0).Name.ShouldEqual(concreteCollection.ElementAt(3).Name);

        private It should_be_then_be_followed_by_the_third = () => result.ElementAt(1).Name.ShouldEqual(concreteCollection.ElementAt(2).Name);

        private It should_be_then_be_followed_by_the_first = () => result.ElementAt(2).Name.ShouldEqual(concreteCollection.ElementAt(0).Name);

        private It should_be_then_be_followed_by_the_second = () => result.ElementAt(3).Name.ShouldEqual(concreteCollection.ElementAt(1).Name);

        private It should_be_then_be_followed_by_the_fifth = () => result.ElementAt(4).Name.ShouldEqual(concreteCollection.ElementAt(4).Name);
    }

    public class When_using_order_by_asc_on_date_with_one_criteria : PagingAndOrdering
    {
        private Because of = () => result = concreteCollection.AsQueryable().ExtendFromOData("?$orderby=Date asc");

        private It should_return_five_records = () => result.Count().ShouldEqual(5);

        private It should_return_the_fourth_record = () => result.ElementAt(0).Name.ShouldEqual(concreteCollection.ElementAt(3).Name);

        private It should_be_then_be_followed_by_the_third = () => result.ElementAt(1).Name.ShouldEqual(concreteCollection.ElementAt(2).Name);

        private It should_be_then_be_followed_by_the_first = () => result.ElementAt(2).Name.ShouldEqual(concreteCollection.ElementAt(0).Name);

        private It should_be_then_be_followed_by_the_second = () => result.ElementAt(3).Name.ShouldEqual(concreteCollection.ElementAt(1).Name);

        private It should_be_then_be_followed_by_the_fifth = () => result.ElementAt(4).Name.ShouldEqual(concreteCollection.ElementAt(4).Name);
    }

    public class When_using_order_by_desc_on_date_with_one_criteria : PagingAndOrdering
    {
        private Because of = () => result = concreteCollection.AsQueryable().ExtendFromOData("?$orderby=Date desc");

        private It should_return_five_records = () => result.Count().ShouldEqual(5);

        private It should_return_the_fourth_record = () => result.ElementAt(0).Name.ShouldEqual(concreteCollection.ElementAt(4).Name);

        private It should_be_then_be_followed_by_the_third = () => result.ElementAt(1).Name.ShouldEqual(concreteCollection.ElementAt(1).Name);

        private It should_be_then_be_followed_by_the_first = () => result.ElementAt(2).Name.ShouldEqual(concreteCollection.ElementAt(0).Name);

        private It should_be_then_be_followed_by_the_second = () => result.ElementAt(3).Name.ShouldEqual(concreteCollection.ElementAt(2).Name);

        private It should_be_then_be_followed_by_the_fifth = () => result.ElementAt(4).Name.ShouldEqual(concreteCollection.ElementAt(3).Name);
    }

    #endregion

    #region OrderBy Single Boolean Tests

    public class When_using_order_by_on_bool_with_one_criteria : PagingAndOrdering
    {
        private Because of = () => result = concreteCollection.AsQueryable().ExtendFromOData("?$orderby=Complete");

        private It should_return_five_records = () => result.Count().ShouldEqual(5);

        private It should_have_sorted_a_false_value_first = () => result.ElementAt(0).Complete.ShouldBeFalse();

        private It should_have_sorted_a_false_value_second = () => result.ElementAt(1).Complete.ShouldBeFalse();

        private It should_have_sorted_a_true_value_third = () => result.ElementAt(2).Complete.ShouldBeTrue();

        private It should_have_sorted_a_true_value_fourth = () => result.ElementAt(3).Complete.ShouldBeTrue();

        private It should_have_sorted_a_true_value_fifth = () => result.ElementAt(4).Complete.ShouldBeTrue();
    }

    public class When_using_order_by_asc_on_bool_with_one_criteria : PagingAndOrdering
    {
        private Because of = () => result = concreteCollection.AsQueryable().ExtendFromOData("?$orderby=Complete asc");

        private It should_return_five_records = () => result.Count().ShouldEqual(5);

        private It should_have_sorted_a_false_value_first = () => result.ElementAt(0).Complete.ShouldBeFalse();

        private It should_have_sorted_a_false_value_second = () => result.ElementAt(1).Complete.ShouldBeFalse();

        private It should_have_sorted_a_true_value_third = () => result.ElementAt(2).Complete.ShouldBeTrue();

        private It should_have_sorted_a_true_value_fourth = () => result.ElementAt(3).Complete.ShouldBeTrue();

        private It should_have_sorted_a_true_value_fifth = () => result.ElementAt(4).Complete.ShouldBeTrue();
    }

    public class When_using_order_by_desc_on_bool_with_one_criteria : PagingAndOrdering
    {
        private Because of = () => result = concreteCollection.AsQueryable().ExtendFromOData("?$orderby=Complete desc");

        private It should_return_five_records = () => result.Count().ShouldEqual(5);

        private It should_have_sorted_a_true_value_first = () => result.ElementAt(0).Complete.ShouldBeTrue();

        private It should_have_sorted_a_true_value_second = () => result.ElementAt(1).Complete.ShouldBeTrue();

        private It should_have_sorted_a_true_value_third = () => result.ElementAt(2).Complete.ShouldBeTrue();

        private It should_have_sorted_a_false_value_fourth = () => result.ElementAt(3).Complete.ShouldBeFalse();

        private It should_have_sorted_a_false_value_fifth = () => result.ElementAt(4).Complete.ShouldBeFalse();
    }

    #endregion

    #region OrderBy Multiple Properties

    public class When_using_order_by_on_two_properties : PagingAndOrdering
    {
        private Because of = () => result = concreteCollection.AsQueryable().ExtendFromOData("?$orderby=Complete,Age");

        private It should_return_five_records = () => result.Count().ShouldEqual(5);

        private It should_return_the_third_record = () => result.ElementAt(0).Name.ShouldEqual(concreteCollection.ElementAt(2).Name);

        private It should_then_be_followed_by_the_fifth = () => result.ElementAt(1).Name.ShouldEqual(concreteCollection.ElementAt(4).Name);

        private It should_then_be_followed_by_the_fourth = () => result.ElementAt(2).Name.ShouldEqual(concreteCollection.ElementAt(3).Name);

        private It should_then_be_followed_by_the_second = () => result.ElementAt(3).Name.ShouldEqual(concreteCollection.ElementAt(1).Name);

        private It should_then_be_followed_by_the_first = () => result.ElementAt(4).Name.ShouldEqual(concreteCollection.ElementAt(0).Name);
    }

    public class When_using_order_by_on_one_descending_and_one_ascending : PagingAndOrdering
    {
        private Because of = () => result = concreteCollection.AsQueryable().ExtendFromOData("?$orderby=Complete desc,Age");

        private It should_return_five_records = () => result.Count().ShouldEqual(5);

        private It should_return_the_fourth_record = () => result.ElementAt(0).Name.ShouldEqual(concreteCollection.ElementAt(3).Name);

        private It should_then_be_followed_by_the_second = () => result.ElementAt(1).Name.ShouldEqual(concreteCollection.ElementAt(1).Name);

        private It should_then_be_followed_by_the_first = () => result.ElementAt(2).Name.ShouldEqual(concreteCollection.ElementAt(0).Name);

        private It should_then_be_followed_by_the_third = () => result.ElementAt(3).Name.ShouldEqual(concreteCollection.ElementAt(2).Name);

        private It should_then_be_followed_by_the_fifth = () => result.ElementAt(4).Name.ShouldEqual(concreteCollection.ElementAt(4).Name);
    }

    public class When_using_order_by_on_one_ascending_and_one_descending : PagingAndOrdering
    {
        private Because of = () => result = concreteCollection.AsQueryable().ExtendFromOData("?$orderby=Complete,Age desc");

        private It should_return_five_records = () => result.Count().ShouldEqual(5);

        private It should_return_the_fifth_record = () => result.ElementAt(0).Name.ShouldEqual(concreteCollection.ElementAt(4).Name);

        private It should_then_be_followed_by_the_third = () => result.ElementAt(1).Name.ShouldEqual(concreteCollection.ElementAt(2).Name);

        private It should_then_be_followed_by_the_first = () => result.ElementAt(2).Name.ShouldEqual(concreteCollection.ElementAt(0).Name);

        private It should_then_be_followed_by_the_second = () => result.ElementAt(3).Name.ShouldEqual(concreteCollection.ElementAt(1).Name);

        private It should_then_be_followed_by_the_fourth = () => result.ElementAt(4).Name.ShouldEqual(concreteCollection.ElementAt(3).Name);
    }

    public class When_using_order_by_on_two_properties_both_descending : PagingAndOrdering
    {
        private Because of = () => result = concreteCollection.AsQueryable().ExtendFromOData("?$orderby=Complete desc,Age desc");

        private It should_return_five_records = () => result.Count().ShouldEqual(5);

        private It should_return_the_first_record = () => result.ElementAt(0).Name.ShouldEqual(concreteCollection.ElementAt(0).Name);

        private It should_then_be_followed_by_the_second = () => result.ElementAt(1).Name.ShouldEqual(concreteCollection.ElementAt(1).Name);

        private It should_then_be_followed_by_the_fourth = () => result.ElementAt(2).Name.ShouldEqual(concreteCollection.ElementAt(3).Name);

        private It should_then_be_followed_by_the_fifth = () => result.ElementAt(3).Name.ShouldEqual(concreteCollection.ElementAt(4).Name);

        private It should_then_be_followed_by_the_third = () => result.ElementAt(4).Name.ShouldEqual(concreteCollection.ElementAt(2).Name);
    }

    #endregion
}

