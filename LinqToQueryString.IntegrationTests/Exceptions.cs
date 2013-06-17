namespace LinqToQueryString.IntegrationTests.Sql
{
    using System;
    using System.Data;
    using System.Linq;

    using LinqToQuerystring;

    using Machine.Specifications;

    public class When_using_skip_on_unordered_data : SqlPagingAndOrdering
    {
        private static Exception ex;

        private Because of = () => ex = Catch.Exception(() => result = testDb.ConcreteCollection.LinqToQuerystring("?$skip=1").ToList());

        private It should_throw_an_exception = () => ex.ShouldBeOfType<NotSupportedException>();
    }

    public class When_trying_to_order_by_complex_types : SqlPagingAndOrdering
    {
        private static Exception ex;

        private Because of = () => ex = Catch.Exception(() => complexResult = testDb.ComplexCollection.LinqToQuerystring("?$orderby=concrete").ToList());

        private It should_throw_an_exception = () => ex.ShouldBeOfType<ArgumentException>();
    }

    public class When_filtering_on_endswith_function : SqlFunctions
    {
        private static Exception ex;

        private Because of = () => ex = Catch.Exception(() => testDb.ConcreteCollection.LinqToQuerystring("?$filter=endswith(Name,'day')").ToList());

        private It should_throw_an_exception = () => ex.ShouldBeOfType<EntityCommandCompilationException>();

        private It should_fail_due_to_SQL_CE_not_supporting_endswith =
            () =>
            ex.InnerException.Message.ShouldEqual("The function 'Reverse' is not supported by SQL Server Compact.");
    }
}
