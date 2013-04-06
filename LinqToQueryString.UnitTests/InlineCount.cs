namespace LinqToQueryString.UnitTests
{
    using System.Collections.Generic;
    using System.Linq;

    using LinqToQueryString.Tests;

    using LinqToQuerystring;

    using Machine.Specifications;

    public class InlineCount : Projection
    {
        protected static Dictionary<string, object> inlineCountResult;

        protected static IQueryable<ConcreteClass> concreteResult;

        protected static IQueryable<ConcreteClass> GetWrappedResults()
        {
            return (inlineCountResult["Results"] as IQueryable<ConcreteClass>);
        }

        protected static IQueryable<Dictionary<string, object>> GetWrappedProjectedResults()
        {
            return (inlineCountResult["Results"] as IQueryable<Dictionary<string, object>>);
        }
    }

    public class When_requesting_inline_count_none : InlineCount
    {
        Because of = () => concreteResult = concreteCollection.AsQueryable().ExtendFromOData("?$inlinecount=none");

        private It should_return_all_the_records_normally = () => concreteResult.Count().ShouldEqual(5);

        private It should_return_the_first_record = () => concreteResult.ElementAt(0).Name.ShouldEqual(concreteCollection.ElementAt(0).Name);

        private It should_then_be_followed_by_the_second = () => concreteResult.ElementAt(1).Name.ShouldEqual(concreteCollection.ElementAt(1).Name);

        private It should_then_be_followed_by_the_third = () => concreteResult.ElementAt(2).Name.ShouldEqual(concreteCollection.ElementAt(2).Name);

        private It should_then_be_followed_by_the_fourth = () => concreteResult.ElementAt(3).Name.ShouldEqual(concreteCollection.ElementAt(3).Name);

        private It should_then_be_followed_by_the_fifth = () => concreteResult.ElementAt(4).Name.ShouldEqual(concreteCollection.ElementAt(4).Name);
    }

    public class When_requesting_inline_count_on_an_unfiltered_query : InlineCount
    {
        Because of = () => inlineCountResult = concreteCollection.AsQueryable().ExtendFromOData<ConcreteClass, Dictionary<string, object>>("?$inlinecount=allpages");

        private It should_return_the_correct_count = () => inlineCountResult["Count"].ShouldEqual(5);

        private It should_return_the_response_within_a_wrapper = () => GetWrappedResults().Count().ShouldEqual(5);

        private It should_return_the_first_record = () => GetWrappedResults().ElementAt(0).Name.ShouldEqual(concreteCollection.ElementAt(0).Name);

        private It should_then_be_followed_by_the_second = () => GetWrappedResults().ElementAt(1).Name.ShouldEqual(concreteCollection.ElementAt(1).Name);

        private It should_then_be_followed_by_the_third = () => GetWrappedResults().ElementAt(2).Name.ShouldEqual(concreteCollection.ElementAt(2).Name);

        private It should_then_be_followed_by_the_fourth = () => GetWrappedResults().ElementAt(3).Name.ShouldEqual(concreteCollection.ElementAt(3).Name);

        private It should_then_be_followed_by_the_fifth = () => GetWrappedResults().ElementAt(4).Name.ShouldEqual(concreteCollection.ElementAt(4).Name);
    }

    public class When_requesting_inline_count_on_a_projected_query : InlineCount
    {
        Because of = () => inlineCountResult = concreteCollection.AsQueryable().ExtendFromOData<ConcreteClass, Dictionary<string, object>>("?$select=Name,Age&$inlinecount=allpages");

        private It should_return_the_correct_count = () => inlineCountResult["Count"].ShouldEqual(5);

        private It should_return_the_response_within_a_wrapper = () => GetWrappedProjectedResults().Count().ShouldEqual(5);

        private It should_project_the_name_and_age_properties_into_the_dictionary =
            () => GetWrappedProjectedResults().ShouldEachConformTo(
                r => r.ContainsKey("Name") && r.ContainsKey("Age"));

        private It should_only_have_projected_two_properties =
            () => GetWrappedProjectedResults().ShouldEachConformTo(r => r.Count == 2);

        private It should_project_the_right_name_for_the_first_record = () => GetWrappedProjectedResults().ElementAt(0)["Age"].ShouldEqual(concreteCollection.ElementAt(0).Age);

        private It should_project_the_right_name_for_the_second_record = () => GetWrappedProjectedResults().ElementAt(1)["Age"].ShouldEqual(concreteCollection.ElementAt(1).Age);

        private It should_project_the_right_name_for_the_third_record = () => GetWrappedProjectedResults().ElementAt(2)["Age"].ShouldEqual(concreteCollection.ElementAt(2).Age);

        private It should_project_the_right_name_for_the_fourth_record = () => GetWrappedProjectedResults().ElementAt(3)["Age"].ShouldEqual(concreteCollection.ElementAt(3).Age);

        private It sshould_project_the_right_name_for_the_fifth_record = () => GetWrappedProjectedResults().ElementAt(4)["Age"].ShouldEqual(concreteCollection.ElementAt(4).Age);

        private It should_project_the_right_age_for_the_first_record = () => GetWrappedProjectedResults().ElementAt(0)["Name"].ShouldEqual(concreteCollection.ElementAt(0).Name);

        private It should_project_the_right_age_for_the_second_record = () => GetWrappedProjectedResults().ElementAt(1)["Name"].ShouldEqual(concreteCollection.ElementAt(1).Name);

        private It should_project_the_right_age_for_the_third_record = () => GetWrappedProjectedResults().ElementAt(2)["Name"].ShouldEqual(concreteCollection.ElementAt(2).Name);

        private It should_project_the_right_age_for_the_fourth_record = () => GetWrappedProjectedResults().ElementAt(3)["Name"].ShouldEqual(concreteCollection.ElementAt(3).Name);

        private It should_project_the_right_age_for_the_fifth_record = () => GetWrappedProjectedResults().ElementAt(4)["Name"].ShouldEqual(concreteCollection.ElementAt(4).Name);
    }

    public class When_requesting_inline_count_on_a_filtered_query : InlineCount
    {
        Because of = () => inlineCountResult = concreteCollection.AsQueryable().ExtendFromOData<ConcreteClass, Dictionary<string, object>>("?$filter=Age ge 3&$inlinecount=allpages");

        private It should_return_the_correct_count = () => inlineCountResult["Count"].ShouldEqual(3);

        private It should_return_the_response_within_a_wrapper = () => GetWrappedResults().Count().ShouldEqual(3);

        private It should_return_third_record = () => GetWrappedResults().ElementAt(0).Name.ShouldEqual(concreteCollection.ElementAt(2).Name);

        private It should_then_be_followed_by_the_fourth = () => GetWrappedResults().ElementAt(1).Name.ShouldEqual(concreteCollection.ElementAt(3).Name);

        private It should_then_be_followed_by_the_fifth = () => GetWrappedResults().ElementAt(2).Name.ShouldEqual(concreteCollection.ElementAt(4).Name);
    }

    public class When_requesting_inline_count_on_an_ordered_query : InlineCount
    {
        Because of = () => inlineCountResult = concreteCollection.AsQueryable().ExtendFromOData<ConcreteClass, Dictionary<string, object>>("?$orderby=Age desc&$inlinecount=allpages");

        private It should_return_the_correct_count = () => inlineCountResult["Count"].ShouldEqual(5);

        private It should_return_the_response_within_a_wrapper = () => GetWrappedResults().Count().ShouldEqual(5);

        private It should_return_the_fifth_record = () => GetWrappedResults().ElementAt(0).Name.ShouldEqual(concreteCollection.ElementAt(4).Name);

        private It should_then_be_followed_by_the_fourth = () => GetWrappedResults().ElementAt(1).Name.ShouldEqual(concreteCollection.ElementAt(3).Name);

        private It should_then_be_followed_by_the_third = () => GetWrappedResults().ElementAt(2).Name.ShouldEqual(concreteCollection.ElementAt(2).Name);

        private It should_then_be_followed_by_the_second = () => GetWrappedResults().ElementAt(3).Name.ShouldEqual(concreteCollection.ElementAt(1).Name);

        private It should_then_be_followed_by_the_first = () => GetWrappedResults().ElementAt(4).Name.ShouldEqual(concreteCollection.ElementAt(0).Name);
    }

    public class When_requesting_inline_count_on_a_top_limited_query : InlineCount
    {
        Because of = () => inlineCountResult = concreteCollection.AsQueryable().ExtendFromOData<ConcreteClass, Dictionary<string, object>>("?$top=3&$inlinecount=allpages");

        private It should_return_the_correct_count = () => inlineCountResult["Count"].ShouldEqual(5);

        private It should_return_the_response_within_a_wrapper = () => GetWrappedResults().Count().ShouldEqual(3);

        private It should_return_the_first_record = () => GetWrappedResults().ElementAt(0).Name.ShouldEqual(concreteCollection.ElementAt(0).Name);

        private It should_then_be_followed_by_the_second = () => GetWrappedResults().ElementAt(1).Name.ShouldEqual(concreteCollection.ElementAt(1).Name);

        private It should_then_be_followed_by_the_third = () => GetWrappedResults().ElementAt(2).Name.ShouldEqual(concreteCollection.ElementAt(2).Name);
    }

    public class When_requesting_inline_count_on_a_top_limited_projected_query : InlineCount
    {
        Because of = () => inlineCountResult = concreteCollection.AsQueryable().ExtendFromOData<ConcreteClass, Dictionary<string, object>>("?$top=3&$select=Name,Age&$inlinecount=allpages");

        private It should_return_the_correct_count = () => inlineCountResult["Count"].ShouldEqual(5);

        private It should_return_the_response_within_a_wrapper = () => GetWrappedProjectedResults().Count().ShouldEqual(3);

        private It should_return_the_first_record = () => GetWrappedProjectedResults().ElementAt(0)["Name"].ShouldEqual(concreteCollection.ElementAt(0).Name);

        private It should_then_be_followed_by_the_second = () => GetWrappedProjectedResults().ElementAt(1)["Name"].ShouldEqual(concreteCollection.ElementAt(1).Name);

        private It should_then_be_followed_by_the_third = () => GetWrappedProjectedResults().ElementAt(2)["Name"].ShouldEqual(concreteCollection.ElementAt(2).Name);
    }

    public class When_requesting_inline_count_on_a_paged_query : InlineCount
    {
        Because of = () => inlineCountResult = concreteCollection.AsQueryable().ExtendFromOData<ConcreteClass, Dictionary<string, object>>("?$skip=2&$top=2&$inlinecount=allpages");

        private It should_return_the_correct_count = () => inlineCountResult["Count"].ShouldEqual(5);

        private It should_return_the_response_within_a_wrapper = () => GetWrappedResults().Count().ShouldEqual(2);

        private It should_return_the_third_record = () => GetWrappedResults().ElementAt(0).Name.ShouldEqual(concreteCollection.ElementAt(2).Name);

        private It should_then_be_followed_by_the_fourth = () => GetWrappedResults().ElementAt(1).Name.ShouldEqual(concreteCollection.ElementAt(3).Name);
    }

    public class When_requesting_inline_count_on_a_paged_projected_query : InlineCount
    {
        Because of = () => inlineCountResult = concreteCollection.AsQueryable().ExtendFromOData<ConcreteClass, Dictionary<string, object>>("?$skip=2&$top=2&$select=Name,Age&$inlinecount=allpages");

        private It should_return_the_correct_count = () => inlineCountResult["Count"].ShouldEqual(5);

        private It should_return_the_response_within_a_wrapper = () => GetWrappedProjectedResults().Count().ShouldEqual(2);

        private It should_return_the_third_record = () => GetWrappedProjectedResults().ElementAt(0)["Name"].ShouldEqual(concreteCollection.ElementAt(2).Name);

        private It should_then_be_followed_by_the_fourth = () => GetWrappedProjectedResults().ElementAt(1)["Name"].ShouldEqual(concreteCollection.ElementAt(3).Name);
    }

    public class When_requesting_inline_count_on_a_filtered_paged_query : InlineCount
    {
        Because of = () => inlineCountResult = concreteCollection.AsQueryable().ExtendFromOData<ConcreteClass, Dictionary<string, object>>("?$filter=Age ge 3&$skip=2&$top=2&$inlinecount=allpages");

        private It should_return_the_correct_count = () => inlineCountResult["Count"].ShouldEqual(3);

        private It should_return_the_response_within_a_wrapper = () => GetWrappedResults().Count().ShouldEqual(1);

        private It should_return_the_fifth_record = () => GetWrappedResults().ElementAt(0).Name.ShouldEqual(concreteCollection.ElementAt(4).Name);
    }

    public class When_requesting_inline_count_on_a_filtered_paged_projected_query : InlineCount
    {
        Because of = () => inlineCountResult = concreteCollection.AsQueryable().ExtendFromOData<ConcreteClass, Dictionary<string, object>>("?$filter=Age ge 3&$skip=2&$top=2&$select=Name,Age&$inlinecount=allpages");

        private It should_return_the_correct_count = () => inlineCountResult["Count"].ShouldEqual(3);

        private It should_return_the_response_within_a_wrapper = () => GetWrappedProjectedResults().Count().ShouldEqual(1);

        private It should_return_the_fifth_record = () => GetWrappedProjectedResults().ElementAt(0)["Name"].ShouldEqual(concreteCollection.ElementAt(4).Name);
    }
}
