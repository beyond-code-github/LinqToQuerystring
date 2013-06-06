namespace LinqToQuerystring.IntegrationTests.Mongo
{
    using System.Linq;

    using Machine.Specifications;

    #region Simple collections

    public class When_filtering_on_a_simple_collection_property_using_any : MongoCollectionAggregates
    {
        private Because of = () => ex = Catch.Exception(() => collection.LinqToQuerystring("$filter=StringCollection/any(tag: tag eq 'Banana')", true).ToList());

        private It should_throw_an_exception = () => ex.ShouldNotBeNull();
    }

    public class When_filtering_on_a_simple_collection_property_using_any_with_an_or : MongoCollectionAggregates
    {
        private Because of = () => ex = Catch.Exception(() => collection.LinqToQuerystring("$filter=StringCollection/any(tag: tag eq 'Banana' or tag eq 'Eggs')", true).ToList());

        private It should_throw_an_exception = () => ex.ShouldNotBeNull();
    }

    public class When_filtering_on_a_simple_collection_property_using_any_with_functions : MongoCollectionAggregates
    {
        private Because of = () => ex = Catch.Exception(() => collection.LinqToQuerystring("$filter=StringCollection/any(tag: startswith(tag,'Dog'))", true).ToList());

        private It should_throw_an_exception = () => ex.ShouldNotBeNull();
    }

    public class When_filtering_on_a_simple_collection_property_using_all : MongoCollectionAggregates
    {
        private Because of = () => ex = Catch.Exception(() => collection.LinqToQuerystring("$filter=StringCollection/all(tag: tag eq 'Apple')", true).ToList());

        private It should_throw_an_exception = () => ex.ShouldNotBeNull();
    }

    public class When_filtering_on_a_simple_collection_property_using_all_with_an_or : MongoCollectionAggregates
    {
        private Because of = () => ex = Catch.Exception(() => collection.LinqToQuerystring("$filter=StringCollection/all(tag: tag eq 'Apple' or tag eq 'Banana')", true).ToList());

        private It should_throw_an_exception = () => ex.ShouldNotBeNull();
    }

    public class When_filtering_on_a_simple_collection_property_using_all_with_functions : MongoCollectionAggregates
    {
        private Because of = () => ex = Catch.Exception(() => collection.LinqToQuerystring("$filter=StringCollection/all(tag: startswith(tag,'App'))", true).ToList());

        private It should_throw_an_exception = () => ex.ShouldNotBeNull();
    }

    #endregion

    #region Complex collections

    public class When_filtering_on_a_complex_collection_property_using_all : MongoCollectionAggregates
    {
        private Because of = () => ex = Catch.Exception(() => collection.LinqToQuerystring("$filter=ConcreteCollection/all(concrete: concrete/Name eq 'Apple')", true).ToList());

        private It should_throw_an_exception = () => ex.ShouldNotBeNull();
    }

    public class When_filtering_on_a_complex_collection_property_using_all_with_an_or : MongoCollectionAggregates
    {
        private Because of = () => ex = Catch.Exception(() => collection.LinqToQuerystring("$filter=ConcreteCollection/all(concrete: concrete/Name eq 'Apple' or concrete/Name eq 'Banana')", true).ToList());

        private It should_throw_an_exception = () => ex.ShouldNotBeNull();
    }

    public class When_filtering_on_a_complex_collection_property_using_all_with_functions : MongoCollectionAggregates
    {
        private Because of = () => ex = Catch.Exception(() => collection.LinqToQuerystring("$filter=ConcreteCollection/all(concrete: startswith(concrete/Name,'App'))", true).ToList());

        private It should_throw_an_exception = () => ex.ShouldNotBeNull();
    }

    #endregion

    #region Nested Simple collections

    public class When_filtering_on_a_nested_simple_collection_property_using_any : MongoCollectionAggregates
    {
        private Because of = () => ex = Catch.Exception(() => collection.LinqToQuerystring("$filter=Concrete/StringCollection/any(string: string eq 'Banana')", true).ToList());

        private It should_throw_an_exception = () => ex.ShouldNotBeNull();
    }

    public class When_filtering_on_a_nested_simple_collection_property_using_any_with_an_or : MongoCollectionAggregates
    {
        private Because of = () => ex = Catch.Exception(() => collection.LinqToQuerystring("$filter=Concrete/StringCollection/any(string: string eq 'Banana' or string eq 'Eggs')", true).ToList());

        private It should_throw_an_exception = () => ex.ShouldNotBeNull();
    }

    public class When_filtering_on_a_nested_simple_collection_property_using_any_with_functions : MongoCollectionAggregates
    {
        private Because of = () => ex = Catch.Exception(() => collection.LinqToQuerystring("$filter=Concrete/StringCollection/any(string: startswith(string,'Dog'))", true).ToList());

        private It should_throw_an_exception = () => ex.ShouldNotBeNull();
    }

    public class When_filtering_on_a_nested_simple_collection_property_using_all : MongoCollectionAggregates
    {
        private Because of = () => ex = Catch.Exception(() => collection.LinqToQuerystring("$filter=Concrete/StringCollection/all(string: string eq 'Apple')", true).ToList());

        private It should_throw_an_exception = () => ex.ShouldNotBeNull();
    }

    public class When_filtering_on_a_nested_simple_collection_property_using_all_with_an_or : MongoCollectionAggregates
    {
        private Because of = () => ex = Catch.Exception(() => collection.LinqToQuerystring("$filter=Concrete/StringCollection/all(string: string eq 'Apple' or string eq 'Banana')", true).ToList());

        private It should_throw_an_exception = () => ex.ShouldNotBeNull();
    }

    public class When_filtering_on_a_nested_simple_property_using_all_with_functions : MongoCollectionAggregates
    {
        private Because of = () => ex = Catch.Exception(() => collection.LinqToQuerystring("$filter=Concrete/StringCollection/all(string: startswith(string,'App'))", true).ToList());

        private It should_throw_an_exception = () => ex.ShouldNotBeNull();
    }

    #endregion
}
