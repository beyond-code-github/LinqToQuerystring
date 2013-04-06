namespace LinqToQueryString.UnitTests
{
    using System;
    using System.Linq;

    using LinqToQuerystring;

    using Machine.Specifications;

    #region Filter on String tests

    public class When_using_gt_filter_on_a_single_string : Filtering
    {
        private Because of = () => ex = Catch.Exception(() => result = concreteCollection.AsQueryable().LinqToQuerystring("?$filter=Name gt 'B'"));

        private It should_throw_an_exception = () => ex.ShouldBeOfType<InvalidOperationException>();
    }

    public class When_using_ge_filter_on_a_single_string : Filtering
    {
        private Because of = () => ex = Catch.Exception(() => result = concreteCollection.AsQueryable().LinqToQuerystring("?$filter=Name ge 'B'"));

        private It should_throw_an_exception = () => ex.ShouldBeOfType<InvalidOperationException>();
    }

    public class When_using_lt_filter_on_a_single_string : Filtering
    {
        private Because of = () => ex = Catch.Exception(() => result = concreteCollection.AsQueryable().LinqToQuerystring("?$filter=Name lt 'B'"));

        private It should_throw_an_exception = () => ex.ShouldBeOfType<InvalidOperationException>();
    }

    public class When_using_le_filter_on_a_single_string : Filtering
    {
        private Because of = () => ex = Catch.Exception(() => result = concreteCollection.AsQueryable().LinqToQuerystring("?$filter=Name lt 'B'"));

        private It should_throw_an_exception = () => ex.ShouldBeOfType<InvalidOperationException>();
    }

    #endregion

    #region Filter on Bool tests

    public class When_using_gt_filter_on_a_single_bool : Filtering
    {
        private Because of = () => ex = Catch.Exception(() => result = concreteCollection.AsQueryable().LinqToQuerystring("?$filter=Complete gt false"));

        private It should_throw_an_exception = () => ex.ShouldBeOfType<InvalidOperationException>();
    }

    public class When_using_ge_filter_on_a_single_bool : Filtering
    {
        private Because of = () => ex = Catch.Exception(() => result = concreteCollection.AsQueryable().LinqToQuerystring("?$filter=Date ge booltime'2003-01-01T00:00'"));

        private It should_throw_an_exception = () => ex.ShouldBeOfType<InvalidOperationException>();
    }

    public class When_using_lt_filter_on_a_single_bool : Filtering
    {
        private Because of = () => ex = Catch.Exception(() => result = concreteCollection.AsQueryable().LinqToQuerystring("?$filter=Date lt booltime'2003-01-01T00:00'"));

        private It should_throw_an_exception = () => ex.ShouldBeOfType<InvalidOperationException>();
    }

    public class When_using_le_filter_on_a_single_bool : Filtering
    {
        private Because of = () => ex = Catch.Exception(() => result = concreteCollection.AsQueryable().LinqToQuerystring("?$filter=Date le booltime'2003-01-01T00:00'"));

        private It should_throw_an_exception = () => ex.ShouldBeOfType<InvalidOperationException>();
    }

    #endregion
}
