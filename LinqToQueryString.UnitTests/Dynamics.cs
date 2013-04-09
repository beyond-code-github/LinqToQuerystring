namespace LinqToQueryString.UnitTests
{
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Linq;

    using LinqToQuerystring;

    using Machine.Specifications;

    public abstract class Dynamics
    {
        protected static List<Dictionary<string, object>> collection;

        protected static IQueryable<Dictionary<string, object>> result;

        private Establish context = () =>
            {
                var item1 = new Dictionary<string, object>();
                item1["Age"] = 23;
                item1["Name"] = "Karl";

                var item2 = new Dictionary<string, object>();
                item2["Age"] = 25;
                item2["Name"] = "Kathryn";

                var item3 = new Dictionary<string, object>();
                item3["Age"] = 28;
                item3["Name"] = "Pete";

                var item4 = new Dictionary<string, object>();
                item4["Age"] = 17;
                item4["Name"] = "Dominic";

                collection = new List<Dictionary<string, object>> { item1, item2, item3, item4 };
            };
    }

    public class When_using_not_filter_on_a_dynamic_type : Dynamics
    {
        private Because of = () => result = collection.AsQueryable().LinqToQuerystring("$filter=not [Age] eq 25");

        private It should_return_three_results = () => result.Count().ShouldEqual(3);
    }

    public class When_using_ge_filter_on_a_dynamic_type : Dynamics
    {
        private Because of = () => result = collection.AsQueryable().LinqToQuerystring("$filter=[Age] ge 25");

        private It should_return_two_results = () => result.Count().ShouldEqual(2);
    }

    public class When_using_gt_filter_on_a_dynamic_type : Dynamics
    {
        private Because of = () => result = collection.AsQueryable().LinqToQuerystring("$filter=[Age] gt 25");

        private It should_return_two_results = () => result.Count().ShouldEqual(1);
    }

    public class When_using_le_filter_on_a_dynamic_type : Dynamics
    {
        private Because of = () => result = collection.AsQueryable().LinqToQuerystring("$filter=[Age] le 25");

        private It should_return_two_results = () => result.Count().ShouldEqual(3);
    }

    public class When_using_lt_filter_on_a_dynamic_type : Dynamics
    {
        private Because of = () => result = collection.AsQueryable().LinqToQuerystring("$filter=[Age] lt 25");

        private It should_return_two_results = () => result.Count().ShouldEqual(2);
    }

    public class When_using_eq_filter_on_a_dynamic_type : Dynamics
    {
        private Because of = () => result = collection.AsQueryable().LinqToQuerystring("$filter=[Age] eq 25");

        private It should_return_two_results = () => result.Count().ShouldEqual(1);
    }

    public class When_using_order_by_on_a_dynamic_type : Dynamics
    {
        private Because of = () => result = collection.AsQueryable().LinqToQuerystring("$orderby=[Age]");

        private It should_return_two_results = () => result.Count().ShouldEqual(4);
    }
}
