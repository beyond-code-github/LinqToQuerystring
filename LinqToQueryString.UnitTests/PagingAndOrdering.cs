namespace LinqToQueryString.UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using LinqToQueryString.Tests;

    using LinqToQuerystring;

    using Machine.Specifications;

    public abstract class PagingAndOrdering
    {
        protected static IQueryable<ConcreteClass> result;

        protected static IQueryable<ComplexClass> complexResult;

        protected static IQueryable<NullableClass> nullableResult;

        protected static List<ConcreteClass> concreteCollection;

        protected static List<ComplexClass> complexCollection;

        protected static List<NullableClass> nullableCollection;

        protected static Guid[] guidArray;

        private Establish context = () =>
        {
            guidArray = Enumerable.Range(1, 5).Select(o => Guid.NewGuid()).ToArray();

            concreteCollection = new List<ConcreteClass>
                                         {
                                             InstanceBuilders.BuildConcrete("Apple", 5, new DateTime(2005, 01, 01), true),
                                             InstanceBuilders.BuildConcrete("Custard", 3, new DateTime(2007, 01, 01), true),
                                             InstanceBuilders.BuildConcrete("Banana", 2, new DateTime(2003, 01, 01), false),
                                             InstanceBuilders.BuildConcrete("Eggs", 1, new DateTime(2000, 01, 01), true),
                                             InstanceBuilders.BuildConcrete("Dogfood", 4, new DateTime(2009, 01, 01), false)
                                         };

            complexCollection = new List<ComplexClass>
                                         {
                                             new ComplexClass { Title = "Charles", Concrete = InstanceBuilders.BuildConcrete("Apple", 5, new DateTime(2005, 01, 01), true) },
                                             new ComplexClass { Title = "Andrew", Concrete = InstanceBuilders.BuildConcrete("Custard", 3, new DateTime(2007, 01, 01), true) },
                                             new ComplexClass { Title = "David", Concrete = InstanceBuilders.BuildConcrete("Banana", 2, new DateTime(2003, 01, 01), false) },
                                             new ComplexClass { Title = "Edward", Concrete = InstanceBuilders.BuildConcrete("Eggs", 1, new DateTime(2000, 01, 01), true) },
                                             new ComplexClass { Title = "Boris", Concrete = InstanceBuilders.BuildConcrete("Dogfood", 4, new DateTime(2009, 01, 01), false) }
                                         };


            nullableCollection = new List<NullableClass>
                                     {
                                         InstanceBuilders.BuildNull(3, new DateTime(2003, 01, 01), true, 30000000000, 333.333, 333.333f, 0xEE, guidArray[2]),
                                         InstanceBuilders.BuildNull(1, new DateTime(2001, 01, 01), false, 10000000000, 111.111, 111.111f, 0xDD, guidArray[0]),
                                         InstanceBuilders.BuildNull(),
                                         InstanceBuilders.BuildNull(2, new DateTime(2002, 01, 01), true, 20000000000, 222.222, 222.222f, 0xCC, guidArray[1]),
                                     };
        };
    }

    #region Top Tests

    public class When_using_top_1 : PagingAndOrdering
    {
        private Because of = () => result = concreteCollection.AsQueryable().LinqToQuerystring("?$top=1");

        private It should_return_one_record = () => result.Count().ShouldEqual(1);

        private It should_return_the_first_record = () => result.ElementAt(0).Name.ShouldEqual(concreteCollection.ElementAt(0).Name);
    }

    public class When_using_top_3 : PagingAndOrdering
    {
        private Because of = () => result = concreteCollection.AsQueryable().LinqToQuerystring("?$top=3");

        private It should_return_three_record = () => result.Count().ShouldEqual(3);

        private It should_start_with_the_first_record = () => result.ElementAt(0).Name.ShouldEqual(concreteCollection.ElementAt(0).Name);

        private It should_then_follow_with_the_second_record = () => result.ElementAt(1).Name.ShouldEqual(concreteCollection.ElementAt(1).Name);

        private It should_then_follow_with_the_third_record = () => result.ElementAt(2).Name.ShouldEqual(concreteCollection.ElementAt(2).Name);
    }

    #endregion

    #region Skip Tests

    public class When_using_skip_1 : PagingAndOrdering
    {
        private Because of = () => result = concreteCollection.AsQueryable().LinqToQuerystring("?$skip=1");

        private It should_return_four_records = () => result.Count().ShouldEqual(4);

        private It should_start_with_the_second_record = () => result.ElementAt(0).Name.ShouldEqual(concreteCollection.ElementAt(1).Name);

        private It should_then_follow_with_the_third_record = () => result.ElementAt(1).Name.ShouldEqual(concreteCollection.ElementAt(2).Name);

        private It should_then_follow_with_the_fourth_record = () => result.ElementAt(2).Name.ShouldEqual(concreteCollection.ElementAt(3).Name);

        private It should_then_follow_with_the_fifth_record = () => result.ElementAt(3).Name.ShouldEqual(concreteCollection.ElementAt(4).Name);
    }

    public class When_using_skip_3 : PagingAndOrdering
    {
        private Because of = () => result = concreteCollection.AsQueryable().LinqToQuerystring("?$skip=3");

        private It should_return_two_records = () => result.Count().ShouldEqual(2);

        private It should_start_with_the_fourth_record = () => result.ElementAt(0).Name.ShouldEqual(concreteCollection.ElementAt(3).Name);

        private It should_then_follow_with_the_fifth_record = () => result.ElementAt(1).Name.ShouldEqual(concreteCollection.ElementAt(4).Name);
    }

    #endregion

    #region Skip and Top Tests

    public class When_using_skip_2_and_top_2 : PagingAndOrdering
    {
        private Because of = () => result = concreteCollection.AsQueryable().LinqToQuerystring("?$skip=2&$top=2");

        private It should_return_two_records = () => result.Count().ShouldEqual(2);

        private It should_start_with_the_third_record = () => result.ElementAt(0).Name.ShouldEqual(concreteCollection.ElementAt(2).Name);

        private It should_then_follow_with_the_fourth_record = () => result.ElementAt(1).Name.ShouldEqual(concreteCollection.ElementAt(3).Name);
    }

    public class When_using_skip_3_and_top_1 : PagingAndOrdering
    {
        private Because of = () => result = concreteCollection.AsQueryable().LinqToQuerystring("?$skip=3&$top=1");

        private It should_return_one_record = () => result.Count().ShouldEqual(1);

        private It should_start_with_the_fourth_record = () => result.ElementAt(0).Name.ShouldEqual(concreteCollection.ElementAt(3).Name);
    }

    public class When_using_top_2_and_skip_2 : PagingAndOrdering
    {
        private Because of = () => result = concreteCollection.AsQueryable().LinqToQuerystring("?$top=2&$skip=2");

        private It should_return_two_records = () => result.Count().ShouldEqual(2);

        private It should_start_with_the_third_record = () => result.ElementAt(0).Name.ShouldEqual(concreteCollection.ElementAt(2).Name);

        private It should_then_follow_with_the_fourth_record = () => result.ElementAt(1).Name.ShouldEqual(concreteCollection.ElementAt(3).Name);
    }

    #endregion

    #region OrderBy Single Integer Tests

    public class When_using_order_by_on_integer_with_one_criteria : PagingAndOrdering
    {
        private Because of = () => result = concreteCollection.AsQueryable().LinqToQuerystring("?$orderby=Age");

        private It should_return_five_records = () => result.Count().ShouldEqual(5);

        private It should_return_the_fourth_record = () => result.ElementAt(0).Name.ShouldEqual(concreteCollection.ElementAt(3).Name);

        private It should_be_then_be_followed_by_the_third = () => result.ElementAt(1).Name.ShouldEqual(concreteCollection.ElementAt(2).Name);

        private It should_be_then_be_followed_by_the_second = () => result.ElementAt(2).Name.ShouldEqual(concreteCollection.ElementAt(1).Name);

        private It should_be_then_be_followed_by_the_fifth = () => result.ElementAt(3).Name.ShouldEqual(concreteCollection.ElementAt(4).Name);

        private It should_be_then_be_followed_by_the_first = () => result.ElementAt(4).Name.ShouldEqual(concreteCollection.ElementAt(0).Name);
    }

    public class When_using_order_by_asc_on_integer_with_one_criteria : PagingAndOrdering
    {
        private Because of = () => result = concreteCollection.AsQueryable().LinqToQuerystring("?$orderby=Age asc");

        private It should_return_five_records = () => result.Count().ShouldEqual(5);

        private It should_return_the_fourth_record = () => result.ElementAt(0).Name.ShouldEqual(concreteCollection.ElementAt(3).Name);

        private It should_be_then_be_followed_by_the_third = () => result.ElementAt(1).Name.ShouldEqual(concreteCollection.ElementAt(2).Name);

        private It should_be_then_be_followed_by_the_second = () => result.ElementAt(2).Name.ShouldEqual(concreteCollection.ElementAt(1).Name);

        private It should_be_then_be_followed_by_the_fifth = () => result.ElementAt(3).Name.ShouldEqual(concreteCollection.ElementAt(4).Name);

        private It should_be_then_be_followed_by_the_first = () => result.ElementAt(4).Name.ShouldEqual(concreteCollection.ElementAt(0).Name);
    }

    public class When_using_order_by_desc_on_integer_with_one_criteria : PagingAndOrdering
    {
        private Because of = () => result = concreteCollection.AsQueryable().LinqToQuerystring("?$orderby=Age desc");

        private It should_return_five_records = () => result.Count().ShouldEqual(5);

        private It should_return_the_fourth_record = () => result.ElementAt(0).Name.ShouldEqual(concreteCollection.ElementAt(0).Name);

        private It should_be_then_be_followed_by_the_third = () => result.ElementAt(1).Name.ShouldEqual(concreteCollection.ElementAt(4).Name);

        private It should_be_then_be_followed_by_the_second = () => result.ElementAt(2).Name.ShouldEqual(concreteCollection.ElementAt(1).Name);

        private It should_be_then_be_followed_by_the_fifth = () => result.ElementAt(3).Name.ShouldEqual(concreteCollection.ElementAt(2).Name);

        private It should_be_then_be_followed_by_the_first = () => result.ElementAt(4).Name.ShouldEqual(concreteCollection.ElementAt(3).Name);
    }

    #endregion

    #region OrderBy Nullable Integer Tests

    public class When_using_order_by_on_nullable_integer_with_one_criteria : PagingAndOrdering
    {
        private Because of = () => nullableResult = nullableCollection.AsQueryable().LinqToQuerystring("?$orderby=Age");

        private It should_return_four_records = () => nullableResult.Count().ShouldEqual(4);

        private It should_return_the_third_record = () => nullableResult.ElementAt(0).Age.ShouldEqual(nullableCollection.ElementAt(2).Age);

        private It should_be_then_be_followed_by_the_second = () => nullableResult.ElementAt(1).Age.ShouldEqual(nullableCollection.ElementAt(1).Age);

        private It should_be_then_be_followed_by_the_fourth = () => nullableResult.ElementAt(2).Age.ShouldEqual(nullableCollection.ElementAt(3).Age);

        private It should_be_then_be_followed_by_the_first = () => nullableResult.ElementAt(3).Age.ShouldEqual(nullableCollection.ElementAt(0).Age);
    }

    public class When_using_order_by_asc_on_nullable_integer_with_one_criteria : PagingAndOrdering
    {
        private Because of = () => nullableResult = nullableCollection.AsQueryable().LinqToQuerystring("?$orderby=Age asc");

        private It should_return_four_records = () => nullableResult.Count().ShouldEqual(4);

        private It should_return_the_third_record = () => nullableResult.ElementAt(0).Age.ShouldEqual(nullableCollection.ElementAt(2).Age);

        private It should_be_then_be_followed_by_the_second = () => nullableResult.ElementAt(1).Age.ShouldEqual(nullableCollection.ElementAt(1).Age);

        private It should_be_then_be_followed_by_the_fourth = () => nullableResult.ElementAt(2).Age.ShouldEqual(nullableCollection.ElementAt(3).Age);

        private It should_be_then_be_followed_by_the_first = () => nullableResult.ElementAt(3).Age.ShouldEqual(nullableCollection.ElementAt(0).Age);
    }

    public class When_using_order_by_desc_on_nullable_integer_with_one_criteria : PagingAndOrdering
    {
        private Because of = () => nullableResult = nullableCollection.AsQueryable().LinqToQuerystring("?$orderby=Age desc");

        private It should_return_four_records = () => nullableResult.Count().ShouldEqual(4);

        private It should_return_the_first_record = () => nullableResult.ElementAt(0).Age.ShouldEqual(nullableCollection.ElementAt(0).Age);

        private It should_be_then_be_followed_by_the_fourth = () => nullableResult.ElementAt(1).Age.ShouldEqual(nullableCollection.ElementAt(3).Age);

        private It should_be_then_be_followed_by_the_second = () => nullableResult.ElementAt(2).Age.ShouldEqual(nullableCollection.ElementAt(1).Age);

        private It should_be_then_be_followed_by_the_third = () => nullableResult.ElementAt(3).Age.ShouldEqual(nullableCollection.ElementAt(2).Age);
    }

    #endregion

    #region OrderBy Single String Tests

    public class When_using_order_by_on_string_with_one_criteria : PagingAndOrdering
    {
        private Because of = () => result = concreteCollection.AsQueryable().LinqToQuerystring("?$orderby=Name");

        private It should_return_five_records = () => result.Count().ShouldEqual(5);

        private It should_return_the_first_record = () => result.ElementAt(0).Name.ShouldEqual(concreteCollection.ElementAt(0).Name);

        private It should_be_then_be_followed_by_the_third = () => result.ElementAt(1).Name.ShouldEqual(concreteCollection.ElementAt(2).Name);

        private It should_be_then_be_followed_by_the_second = () => result.ElementAt(2).Name.ShouldEqual(concreteCollection.ElementAt(1).Name);

        private It should_be_then_be_followed_by_the_fifth = () => result.ElementAt(3).Name.ShouldEqual(concreteCollection.ElementAt(4).Name);

        private It should_be_then_be_followed_by_the_fourth = () => result.ElementAt(4).Name.ShouldEqual(concreteCollection.ElementAt(3).Name);
    }

    public class When_using_order_by_asc_on_string_with_one_criteria : PagingAndOrdering
    {
        private Because of = () => result = concreteCollection.AsQueryable().LinqToQuerystring("?$orderby=Name asc");

        private It should_return_five_records = () => result.Count().ShouldEqual(5);

        private It should_return_the_first_record = () => result.ElementAt(0).Name.ShouldEqual(concreteCollection.ElementAt(0).Name);

        private It should_be_then_be_followed_by_the_third = () => result.ElementAt(1).Name.ShouldEqual(concreteCollection.ElementAt(2).Name);

        private It should_be_then_be_followed_by_the_second = () => result.ElementAt(2).Name.ShouldEqual(concreteCollection.ElementAt(1).Name);

        private It should_be_then_be_followed_by_the_fifth = () => result.ElementAt(3).Name.ShouldEqual(concreteCollection.ElementAt(4).Name);

        private It should_be_then_be_followed_by_the_fourth = () => result.ElementAt(4).Name.ShouldEqual(concreteCollection.ElementAt(3).Name);
    }

    public class When_using_order_by_desc_on_string_with_one_criteria : PagingAndOrdering
    {
        private Because of = () => result = concreteCollection.AsQueryable().LinqToQuerystring("?$orderby=Name desc");

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
        private Because of = () => result = concreteCollection.AsQueryable().LinqToQuerystring("?$orderby=Date");

        private It should_return_five_records = () => result.Count().ShouldEqual(5);

        private It should_return_the_fourth_record = () => result.ElementAt(0).Name.ShouldEqual(concreteCollection.ElementAt(3).Name);

        private It should_be_then_be_followed_by_the_third = () => result.ElementAt(1).Name.ShouldEqual(concreteCollection.ElementAt(2).Name);

        private It should_be_then_be_followed_by_the_first = () => result.ElementAt(2).Name.ShouldEqual(concreteCollection.ElementAt(0).Name);

        private It should_be_then_be_followed_by_the_second = () => result.ElementAt(3).Name.ShouldEqual(concreteCollection.ElementAt(1).Name);

        private It should_be_then_be_followed_by_the_fifth = () => result.ElementAt(4).Name.ShouldEqual(concreteCollection.ElementAt(4).Name);
    }

    public class When_using_order_by_asc_on_date_with_one_criteria : PagingAndOrdering
    {
        private Because of = () => result = concreteCollection.AsQueryable().LinqToQuerystring("?$orderby=Date asc");

        private It should_return_five_records = () => result.Count().ShouldEqual(5);

        private It should_return_the_fourth_record = () => result.ElementAt(0).Name.ShouldEqual(concreteCollection.ElementAt(3).Name);

        private It should_be_then_be_followed_by_the_third = () => result.ElementAt(1).Name.ShouldEqual(concreteCollection.ElementAt(2).Name);

        private It should_be_then_be_followed_by_the_first = () => result.ElementAt(2).Name.ShouldEqual(concreteCollection.ElementAt(0).Name);

        private It should_be_then_be_followed_by_the_second = () => result.ElementAt(3).Name.ShouldEqual(concreteCollection.ElementAt(1).Name);

        private It should_be_then_be_followed_by_the_fifth = () => result.ElementAt(4).Name.ShouldEqual(concreteCollection.ElementAt(4).Name);
    }

    public class When_using_order_by_desc_on_date_with_one_criteria : PagingAndOrdering
    {
        private Because of = () => result = concreteCollection.AsQueryable().LinqToQuerystring("?$orderby=Date desc");

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
        private Because of = () => result = concreteCollection.AsQueryable().LinqToQuerystring("?$orderby=Complete");

        private It should_return_five_records = () => result.Count().ShouldEqual(5);

        private It should_have_sorted_a_false_value_first = () => result.ElementAt(0).Complete.ShouldBeFalse();

        private It should_have_sorted_a_false_value_second = () => result.ElementAt(1).Complete.ShouldBeFalse();

        private It should_have_sorted_a_true_value_third = () => result.ElementAt(2).Complete.ShouldBeTrue();

        private It should_have_sorted_a_true_value_fourth = () => result.ElementAt(3).Complete.ShouldBeTrue();

        private It should_have_sorted_a_true_value_fifth = () => result.ElementAt(4).Complete.ShouldBeTrue();
    }

    public class When_using_order_by_asc_on_bool_with_one_criteria : PagingAndOrdering
    {
        private Because of = () => result = concreteCollection.AsQueryable().LinqToQuerystring("?$orderby=Complete asc");

        private It should_return_five_records = () => result.Count().ShouldEqual(5);

        private It should_have_sorted_a_false_value_first = () => result.ElementAt(0).Complete.ShouldBeFalse();

        private It should_have_sorted_a_false_value_second = () => result.ElementAt(1).Complete.ShouldBeFalse();

        private It should_have_sorted_a_true_value_third = () => result.ElementAt(2).Complete.ShouldBeTrue();

        private It should_have_sorted_a_true_value_fourth = () => result.ElementAt(3).Complete.ShouldBeTrue();

        private It should_have_sorted_a_true_value_fifth = () => result.ElementAt(4).Complete.ShouldBeTrue();
    }

    public class When_using_order_by_desc_on_bool_with_one_criteria : PagingAndOrdering
    {
        private Because of = () => result = concreteCollection.AsQueryable().LinqToQuerystring("?$orderby=Complete desc");

        private It should_return_five_records = () => result.Count().ShouldEqual(5);

        private It should_have_sorted_a_true_value_first = () => result.ElementAt(0).Complete.ShouldBeTrue();

        private It should_have_sorted_a_true_value_second = () => result.ElementAt(1).Complete.ShouldBeTrue();

        private It should_have_sorted_a_true_value_third = () => result.ElementAt(2).Complete.ShouldBeTrue();

        private It should_have_sorted_a_false_value_fourth = () => result.ElementAt(3).Complete.ShouldBeFalse();

        private It should_have_sorted_a_false_value_fifth = () => result.ElementAt(4).Complete.ShouldBeFalse();
    }

    #endregion

    #region OrderBy Nullable Boolean Tests

    public class When_using_order_by_on_nullable_boolean_with_one_criteria : PagingAndOrdering
    {
        private Because of = () => nullableResult = nullableCollection.AsQueryable().LinqToQuerystring("?$orderby=Complete");

        private It should_return_four_records = () => nullableResult.Count().ShouldEqual(4);

        private It should_return_the_third_record = () => nullableResult.ElementAt(0).Age.ShouldEqual(nullableCollection.ElementAt(2).Age);

        private It should_be_then_be_followed_by_the_second = () => nullableResult.ElementAt(1).Age.ShouldEqual(nullableCollection.ElementAt(1).Age);

        private It should_be_then_be_followed_by_the_fourth = () => nullableResult.ElementAt(2).Age.ShouldEqual(nullableCollection.ElementAt(0).Age);

        private It should_be_then_be_followed_by_the_first = () => nullableResult.ElementAt(3).Age.ShouldEqual(nullableCollection.ElementAt(3).Age);
    }

    public class When_using_order_by_asc_on_nullable_boolean_with_one_criteria : PagingAndOrdering
    {
        private Because of = () => nullableResult = nullableCollection.AsQueryable().LinqToQuerystring("?$orderby=Complete asc");

        private It should_return_four_records = () => nullableResult.Count().ShouldEqual(4);

        private It should_return_the_third_record = () => nullableResult.ElementAt(0).Age.ShouldEqual(nullableCollection.ElementAt(2).Age);

        private It should_be_then_be_followed_by_the_second = () => nullableResult.ElementAt(1).Age.ShouldEqual(nullableCollection.ElementAt(1).Age);

        private It should_be_then_be_followed_by_the_fourth = () => nullableResult.ElementAt(2).Age.ShouldEqual(nullableCollection.ElementAt(0).Age);

        private It should_be_then_be_followed_by_the_first = () => nullableResult.ElementAt(3).Age.ShouldEqual(nullableCollection.ElementAt(3).Age);
    }

    public class When_using_order_by_desc_on_nullable_boolean_with_one_criteria : PagingAndOrdering
    {
        private Because of = () => nullableResult = nullableCollection.AsQueryable().LinqToQuerystring("?$orderby=Complete desc");

        private It should_return_four_records = () => nullableResult.Count().ShouldEqual(4);

        private It should_return_the_first_record = () => nullableResult.ElementAt(0).Age.ShouldEqual(nullableCollection.ElementAt(0).Age);

        private It should_be_then_be_followed_by_the_fourth = () => nullableResult.ElementAt(1).Age.ShouldEqual(nullableCollection.ElementAt(3).Age);

        private It should_be_then_be_followed_by_the_second = () => nullableResult.ElementAt(2).Age.ShouldEqual(nullableCollection.ElementAt(1).Age);

        private It should_be_then_be_followed_by_the_third = () => nullableResult.ElementAt(3).Age.ShouldEqual(nullableCollection.ElementAt(2).Age);
    }

    #endregion

    #region OrderBy Multiple Properties

    public class When_using_order_by_on_two_properties : PagingAndOrdering
    {
        private Because of = () => result = concreteCollection.AsQueryable().LinqToQuerystring("?$orderby=Complete,Age");

        private It should_return_five_records = () => result.Count().ShouldEqual(5);

        private It should_return_the_third_record = () => result.ElementAt(0).Name.ShouldEqual(concreteCollection.ElementAt(2).Name);

        private It should_then_be_followed_by_the_fifth = () => result.ElementAt(1).Name.ShouldEqual(concreteCollection.ElementAt(4).Name);

        private It should_then_be_followed_by_the_fourth = () => result.ElementAt(2).Name.ShouldEqual(concreteCollection.ElementAt(3).Name);

        private It should_then_be_followed_by_the_second = () => result.ElementAt(3).Name.ShouldEqual(concreteCollection.ElementAt(1).Name);

        private It should_then_be_followed_by_the_first = () => result.ElementAt(4).Name.ShouldEqual(concreteCollection.ElementAt(0).Name);
    }

    public class When_using_order_by_on_one_descending_and_one_ascending : PagingAndOrdering
    {
        private Because of = () => result = concreteCollection.AsQueryable().LinqToQuerystring("?$orderby=Complete desc,Age");

        private It should_return_five_records = () => result.Count().ShouldEqual(5);

        private It should_return_the_fourth_record = () => result.ElementAt(0).Name.ShouldEqual(concreteCollection.ElementAt(3).Name);

        private It should_then_be_followed_by_the_second = () => result.ElementAt(1).Name.ShouldEqual(concreteCollection.ElementAt(1).Name);

        private It should_then_be_followed_by_the_first = () => result.ElementAt(2).Name.ShouldEqual(concreteCollection.ElementAt(0).Name);

        private It should_then_be_followed_by_the_third = () => result.ElementAt(3).Name.ShouldEqual(concreteCollection.ElementAt(2).Name);

        private It should_then_be_followed_by_the_fifth = () => result.ElementAt(4).Name.ShouldEqual(concreteCollection.ElementAt(4).Name);
    }

    public class When_using_order_by_on_one_ascending_and_one_descending : PagingAndOrdering
    {
        private Because of = () => result = concreteCollection.AsQueryable().LinqToQuerystring("?$orderby=Complete,Age desc");

        private It should_return_five_records = () => result.Count().ShouldEqual(5);

        private It should_return_the_fifth_record = () => result.ElementAt(0).Name.ShouldEqual(concreteCollection.ElementAt(4).Name);

        private It should_then_be_followed_by_the_third = () => result.ElementAt(1).Name.ShouldEqual(concreteCollection.ElementAt(2).Name);

        private It should_then_be_followed_by_the_first = () => result.ElementAt(2).Name.ShouldEqual(concreteCollection.ElementAt(0).Name);

        private It should_then_be_followed_by_the_second = () => result.ElementAt(3).Name.ShouldEqual(concreteCollection.ElementAt(1).Name);

        private It should_then_be_followed_by_the_fourth = () => result.ElementAt(4).Name.ShouldEqual(concreteCollection.ElementAt(3).Name);
    }

    public class When_using_order_by_on_two_properties_both_descending : PagingAndOrdering
    {
        private Because of = () => result = concreteCollection.AsQueryable().LinqToQuerystring("?$orderby=Complete desc,Age desc");

        private It should_return_five_records = () => result.Count().ShouldEqual(5);

        private It should_return_the_first_record = () => result.ElementAt(0).Name.ShouldEqual(concreteCollection.ElementAt(0).Name);

        private It should_then_be_followed_by_the_second = () => result.ElementAt(1).Name.ShouldEqual(concreteCollection.ElementAt(1).Name);

        private It should_then_be_followed_by_the_fourth = () => result.ElementAt(2).Name.ShouldEqual(concreteCollection.ElementAt(3).Name);

        private It should_then_be_followed_by_the_fifth = () => result.ElementAt(3).Name.ShouldEqual(concreteCollection.ElementAt(4).Name);

        private It should_then_be_followed_by_the_third = () => result.ElementAt(4).Name.ShouldEqual(concreteCollection.ElementAt(2).Name);
    }

    #endregion

    #region OrderBy Complex Types

    public class When_using_order_by_on_complex_types_using_IComparable : PagingAndOrdering
    {
        private Because of = () => complexResult = complexCollection.AsQueryable().LinqToQuerystring("?$orderby=Concrete");

        private It should_return_five_records = () => complexResult.Count().ShouldEqual(5);

        private It should_return_the_first_record = () => complexResult.ElementAt(0).Title.ShouldEqual(complexCollection.ElementAt(0).Title);

        private It should_be_then_be_followed_by_the_third = () => complexResult.ElementAt(1).Title.ShouldEqual(complexCollection.ElementAt(2).Title);

        private It should_be_then_be_followed_by_the_second = () => complexResult.ElementAt(2).Title.ShouldEqual(complexCollection.ElementAt(1).Title);

        private It should_be_then_be_followed_by_the_fifth = () => complexResult.ElementAt(3).Title.ShouldEqual(complexCollection.ElementAt(4).Title);

        private It should_be_then_be_followed_by_the_fourth = () => complexResult.ElementAt(4).Title.ShouldEqual(complexCollection.ElementAt(3).Title);
    }

    public class When_using_order_by_asc_on_complex_types_using_IComparable : PagingAndOrdering
    {
        private Because of = () => complexResult = complexCollection.AsQueryable().LinqToQuerystring("?$orderby=Concrete asc");

        private It should_return_five_records = () => complexResult.Count().ShouldEqual(5);

        private It should_return_the_first_record = () => complexResult.ElementAt(0).Title.ShouldEqual(complexCollection.ElementAt(0).Title);

        private It should_be_then_be_followed_by_the_third = () => complexResult.ElementAt(1).Title.ShouldEqual(complexCollection.ElementAt(2).Title);

        private It should_be_then_be_followed_by_the_second = () => complexResult.ElementAt(2).Title.ShouldEqual(complexCollection.ElementAt(1).Title);

        private It should_be_then_be_followed_by_the_fifth = () => complexResult.ElementAt(3).Title.ShouldEqual(complexCollection.ElementAt(4).Title);

        private It should_be_then_be_followed_by_the_fourth = () => complexResult.ElementAt(4).Title.ShouldEqual(complexCollection.ElementAt(3).Title);
    }

    public class When_using_order_by_desc_on_complex_types_using_IComparable : PagingAndOrdering
    {
        private Because of = () => complexResult = complexCollection.AsQueryable().LinqToQuerystring("?$orderby=Concrete desc");

        private It should_return_five_records = () => complexResult.Count().ShouldEqual(5);

        private It should_return_the_fourth_record = () => complexResult.ElementAt(0).Title.ShouldEqual(complexCollection.ElementAt(3).Title);

        private It should_be_then_be_followed_by_the_fifth = () => complexResult.ElementAt(1).Title.ShouldEqual(complexCollection.ElementAt(4).Title);

        private It should_be_then_be_followed_by_the_second = () => complexResult.ElementAt(2).Title.ShouldEqual(complexCollection.ElementAt(1).Title);

        private It should_be_then_be_followed_by_the_third = () => complexResult.ElementAt(3).Title.ShouldEqual(complexCollection.ElementAt(2).Title);

        private It should_be_then_be_followed_by_the_first_ = () => complexResult.ElementAt(4).Title.ShouldEqual(complexCollection.ElementAt(0).Title);
    }

    #endregion

    #region OrderBy SubProperties

    public class When_using_order_by_on_a_single_subproperty : PagingAndOrdering
    {
        private Because of = () => complexResult = complexCollection.AsQueryable().LinqToQuerystring(@"?$orderby=Concrete/Age");

        private It should_return_five_records = () => complexResult.Count().ShouldEqual(5);

        private It should_return_the_fourth_record = () => complexResult.ElementAt(0).Title.ShouldEqual(complexCollection.ElementAt(3).Title);

        private It should_be_then_be_followed_by_the_third = () => complexResult.ElementAt(1).Title.ShouldEqual(complexCollection.ElementAt(2).Title);

        private It should_be_then_be_followed_by_the_second = () => complexResult.ElementAt(2).Title.ShouldEqual(complexCollection.ElementAt(1).Title);

        private It should_be_then_be_followed_by_the_fifth = () => complexResult.ElementAt(3).Title.ShouldEqual(complexCollection.ElementAt(4).Title);

        private It should_be_then_be_followed_by_the_first = () => complexResult.ElementAt(4).Title.ShouldEqual(complexCollection.ElementAt(0).Title);
    }

    public class When_using_order_by_asc_on_a_single_subproperty : PagingAndOrdering
    {
        private Because of = () => complexResult = complexCollection.AsQueryable().LinqToQuerystring(@"?$orderby=Concrete/Age asc");

        private It should_return_five_records = () => complexResult.Count().ShouldEqual(5);

        private It should_return_the_fourth_record = () => complexResult.ElementAt(0).Title.ShouldEqual(complexCollection.ElementAt(3).Title);

        private It should_be_then_be_followed_by_the_third = () => complexResult.ElementAt(1).Title.ShouldEqual(complexCollection.ElementAt(2).Title);

        private It should_be_then_be_followed_by_the_second = () => complexResult.ElementAt(2).Title.ShouldEqual(complexCollection.ElementAt(1).Title);

        private It should_be_then_be_followed_by_the_fifth = () => complexResult.ElementAt(3).Title.ShouldEqual(complexCollection.ElementAt(4).Title);

        private It should_be_then_be_followed_by_the_first = () => complexResult.ElementAt(4).Title.ShouldEqual(complexCollection.ElementAt(0).Title);
    }

    public class When_using_order_by_desc_on_a_single_subproperty : PagingAndOrdering
    {
        private Because of = () => complexResult = complexCollection.AsQueryable().LinqToQuerystring("?$orderby=Concrete/Age desc");

        private It should_return_five_records = () => complexResult.Count().ShouldEqual(5);

        private It should_return_the_first_record = () => complexResult.ElementAt(0).Title.ShouldEqual(complexCollection.ElementAt(0).Title);

        private It should_be_then_be_followed_by_the_fifth = () => complexResult.ElementAt(1).Title.ShouldEqual(complexCollection.ElementAt(4).Title);

        private It should_be_then_be_followed_by_the_second = () => complexResult.ElementAt(2).Title.ShouldEqual(complexCollection.ElementAt(1).Title);

        private It should_be_then_be_followed_by_the_third = () => complexResult.ElementAt(3).Title.ShouldEqual(complexCollection.ElementAt(2).Title);

        private It should_be_then_be_followed_by_the_fourth = () => complexResult.ElementAt(4).Title.ShouldEqual(complexCollection.ElementAt(3).Title);
    }

    #endregion

    #region OrderBy Multiple SubProperties

    public class When_using_order_by_on_two_sub_properties : PagingAndOrdering
    {
        private Because of = () => complexResult = complexCollection.AsQueryable().LinqToQuerystring("?$orderby=Concrete/Complete,Concrete/Age");

        private It should_return_five_records = () => complexResult.Count().ShouldEqual(5);

        private It should_return_the_third_record = () => complexResult.ElementAt(0).Title.ShouldEqual(complexCollection.ElementAt(2).Title);

        private It should_then_be_followed_by_the_fifth = () => complexResult.ElementAt(1).Title.ShouldEqual(complexCollection.ElementAt(4).Title);

        private It should_then_be_followed_by_the_fourth = () => complexResult.ElementAt(2).Title.ShouldEqual(complexCollection.ElementAt(3).Title);

        private It should_then_be_followed_by_the_second = () => complexResult.ElementAt(3).Title.ShouldEqual(complexCollection.ElementAt(1).Title);

        private It should_then_be_followed_by_the_first = () => complexResult.ElementAt(4).Title.ShouldEqual(complexCollection.ElementAt(0).Title);
    }

    public class When_using_order_by_on_two_sub_properties_one_descending_and_one_ascending : PagingAndOrdering
    {
        private Because of = () => complexResult = complexCollection.AsQueryable().LinqToQuerystring("?$orderby=Concrete/Complete desc,Concrete/Age");

        private It should_return_five_records = () => complexResult.Count().ShouldEqual(5);

        private It should_return_the_fourth_record = () => complexResult.ElementAt(0).Title.ShouldEqual(complexCollection.ElementAt(3).Title);

        private It should_then_be_followed_by_the_second = () => complexResult.ElementAt(1).Title.ShouldEqual(complexCollection.ElementAt(1).Title);

        private It should_then_be_followed_by_the_first = () => complexResult.ElementAt(2).Title.ShouldEqual(complexCollection.ElementAt(0).Title);

        private It should_then_be_followed_by_the_third = () => complexResult.ElementAt(3).Title.ShouldEqual(complexCollection.ElementAt(2).Title);

        private It should_then_be_followed_by_the_fifth = () => complexResult.ElementAt(4).Title.ShouldEqual(complexCollection.ElementAt(4).Title);
    }

    public class When_using_order_by_on_two_sub_properties_one_ascending_and_one_descending : PagingAndOrdering
    {
        private Because of = () => complexResult = complexCollection.AsQueryable().LinqToQuerystring("?$orderby=Concrete/Complete,Concrete/Age desc");

        private It should_return_five_records = () => complexResult.Count().ShouldEqual(5);

        private It should_return_the_fifth_record = () => complexResult.ElementAt(0).Title.ShouldEqual(complexCollection.ElementAt(4).Title);

        private It should_then_be_followed_by_the_third = () => complexResult.ElementAt(1).Title.ShouldEqual(complexCollection.ElementAt(2).Title);

        private It should_then_be_followed_by_the_first = () => complexResult.ElementAt(2).Title.ShouldEqual(complexCollection.ElementAt(0).Title);

        private It should_then_be_followed_by_the_second = () => complexResult.ElementAt(3).Title.ShouldEqual(complexCollection.ElementAt(1).Title);

        private It should_then_be_followed_by_the_fourth = () => complexResult.ElementAt(4).Title.ShouldEqual(complexCollection.ElementAt(3).Title);
    }

    public class When_using_order_by_on_two_sub_properties_both_descending : PagingAndOrdering
    {
        private Because of = () => complexResult = complexCollection.AsQueryable().LinqToQuerystring("?$orderby=Concrete/Complete desc,Concrete/Age desc");

        private It should_return_five_records = () => complexResult.Count().ShouldEqual(5);

        private It should_return_the_first_record = () => complexResult.ElementAt(0).Title.ShouldEqual(complexCollection.ElementAt(0).Title);

        private It should_then_be_followed_by_the_second = () => complexResult.ElementAt(1).Title.ShouldEqual(complexCollection.ElementAt(1).Title);

        private It should_then_be_followed_by_the_fourth = () => complexResult.ElementAt(2).Title.ShouldEqual(complexCollection.ElementAt(3).Title);

        private It should_then_be_followed_by_the_fifth = () => complexResult.ElementAt(3).Title.ShouldEqual(complexCollection.ElementAt(4).Title);

        private It should_then_be_followed_by_the_third = () => complexResult.ElementAt(4).Title.ShouldEqual(complexCollection.ElementAt(2).Title);
    }

    #endregion

    #region OrderBy Mixed Properties and SubProperties

    public class When_using_order_by_on_mixed_properties : PagingAndOrdering
    {
        private Because of = () => complexResult = complexCollection.AsQueryable().LinqToQuerystring("?$orderby=Concrete/Complete,Title");

        private It should_return_five_records = () => complexResult.Count().ShouldEqual(5);

        private It should_return_the_fifth_record = () => complexResult.ElementAt(0).Title.ShouldEqual(complexCollection.ElementAt(4).Title);

        private It should_then_be_followed_by_the_third = () => complexResult.ElementAt(1).Title.ShouldEqual(complexCollection.ElementAt(2).Title);

        private It should_then_be_followed_by_the_second = () => complexResult.ElementAt(2).Title.ShouldEqual(complexCollection.ElementAt(1).Title);

        private It should_then_be_followed_by_the_first = () => complexResult.ElementAt(3).Title.ShouldEqual(complexCollection.ElementAt(0).Title);

        private It should_then_be_followed_by_the_fourth = () => complexResult.ElementAt(4).Title.ShouldEqual(complexCollection.ElementAt(3).Title);
    }

    public class When_using_order_by_on_mixed_properties_one_descending_and_one_ascending : PagingAndOrdering
    {
        private Because of = () => complexResult = complexCollection.AsQueryable().LinqToQuerystring("?$orderby=Concrete/Complete desc,Title");

        private It should_return_five_records = () => complexResult.Count().ShouldEqual(5);

        private It should_return_the_second_record = () => complexResult.ElementAt(0).Title.ShouldEqual(complexCollection.ElementAt(1).Title);

        private It should_then_be_followed_by_the_first = () => complexResult.ElementAt(1).Title.ShouldEqual(complexCollection.ElementAt(0).Title);

        private It should_then_be_followed_by_the_fourth = () => complexResult.ElementAt(2).Title.ShouldEqual(complexCollection.ElementAt(3).Title);

        private It should_then_be_followed_by_the_fifth = () => complexResult.ElementAt(3).Title.ShouldEqual(complexCollection.ElementAt(4).Title);

        private It should_then_be_followed_by_the_third = () => complexResult.ElementAt(4).Title.ShouldEqual(complexCollection.ElementAt(2).Title);
    }

    public class When_using_order_by_on_mixed_properties_one_ascending_and_one_descending : PagingAndOrdering
    {
        private Because of = () => complexResult = complexCollection.AsQueryable().LinqToQuerystring("?$orderby=Concrete/Complete,Title desc");

        private It should_return_five_records = () => complexResult.Count().ShouldEqual(5);

        private It should_return_the_third_record = () => complexResult.ElementAt(0).Title.ShouldEqual(complexCollection.ElementAt(2).Title);

        private It should_then_be_followed_by_the_fifth = () => complexResult.ElementAt(1).Title.ShouldEqual(complexCollection.ElementAt(4).Title);

        private It should_then_be_followed_by_the_fourth = () => complexResult.ElementAt(2).Title.ShouldEqual(complexCollection.ElementAt(3).Title);

        private It should_then_be_followed_by_the_first = () => complexResult.ElementAt(3).Title.ShouldEqual(complexCollection.ElementAt(0).Title);

        private It should_then_be_followed_by_the_second = () => complexResult.ElementAt(4).Title.ShouldEqual(complexCollection.ElementAt(1).Title);
    }

    public class When_using_order_by_on_mixed_properties_both_descending : PagingAndOrdering
    {
        private Because of = () => complexResult = complexCollection.AsQueryable().LinqToQuerystring("?$orderby=Concrete/Complete desc,Title desc");

        private It should_return_five_records = () => complexResult.Count().ShouldEqual(5);

        private It should_return_the_fourth_record = () => complexResult.ElementAt(0).Title.ShouldEqual(complexCollection.ElementAt(3).Title);

        private It should_then_be_followed_by_the_first = () => complexResult.ElementAt(1).Title.ShouldEqual(complexCollection.ElementAt(0).Title);

        private It should_then_be_followed_by_the_second = () => complexResult.ElementAt(2).Title.ShouldEqual(complexCollection.ElementAt(1).Title);

        private It should_then_be_followed_by_the_third = () => complexResult.ElementAt(3).Title.ShouldEqual(complexCollection.ElementAt(2).Title);

        private It should_then_be_followed_by_the_fifth = () => complexResult.ElementAt(4).Title.ShouldEqual(complexCollection.ElementAt(4).Title);
    }

    #endregion
}

