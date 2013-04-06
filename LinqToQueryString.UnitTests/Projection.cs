namespace LinqToQueryString.UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using LinqToQueryString.Tests;

    using LinqToQuerystring;

    using Machine.Specifications;

    public abstract class Projection
    {
        protected static Exception ex;

        protected static IQueryable<Dictionary<string, object>> result;

        protected static IQueryable<Dictionary<string, object>> complexResult;

        protected static List<ConcreteClass> concreteCollection;

        protected static List<ComplexClass> complexCollection;

        private Establish context = () =>
        {
            concreteCollection = new List<ConcreteClass>
                                         {
                                             InstanceBuilders.BuildConcrete("Apple", 1, new DateTime(2001, 01, 01), true),
                                             InstanceBuilders.BuildConcrete("Banana", 2, new DateTime(2002, 01, 01), false),
                                             InstanceBuilders.BuildConcrete("Custard", 3, new DateTime(2003, 01, 01), true),
                                             InstanceBuilders.BuildConcrete("Dogfood", 4, new DateTime(2004, 01, 01), true),
                                             InstanceBuilders.BuildConcrete("Eggs", 5, new DateTime(2005, 01, 01), true)
                                         };

            complexCollection = new List<ComplexClass>
                                         {
                                             new ComplexClass { Title = "Charles", Concrete = InstanceBuilders.BuildConcrete("Apple", 5, new DateTime(2005, 01, 01), true) },
                                             new ComplexClass { Title = "Andrew", Concrete = InstanceBuilders.BuildConcrete("Custard", 3, new DateTime(2007, 01, 01), true) },
                                             new ComplexClass { Title = "David", Concrete = InstanceBuilders.BuildConcrete("Banana", 2, new DateTime(2003, 01, 01), false) },
                                             new ComplexClass { Title = "Edward", Concrete = InstanceBuilders.BuildConcrete("Eggs", 1, new DateTime(2000, 01, 01), true) },
                                             new ComplexClass { Title = "Boris", Concrete = InstanceBuilders.BuildConcrete("Dogfood", 4, new DateTime(2009, 01, 01), false) }
                                         };
        };
    }

    #region Single Property Tests

    public class When_selecting_a_single_string_property : Projection
    {
        private Because of =
            () =>
            result = concreteCollection.AsQueryable().ExtendFromOData<ConcreteClass, IQueryable<Dictionary<string, object>>>("?$select=Name");

        private It should_project_the_name_properties_into_the_dictionary =
            () => result.ShouldEachConformTo(r => r.ContainsKey("Name"));

        private It should_only_have_projected_the_one_property =
            () => result.ShouldEachConformTo(r => r.Count == 1);

        private It should_contain_5_results = () => result.Count().ShouldEqual(5);

        private It should_start_with_the_first_record = () => result.ElementAt(0)["Name"].ShouldEqual(concreteCollection.ElementAt(0).Name);

        private It should_be_followed_by_the_second_record = () => result.ElementAt(1)["Name"].ShouldEqual(concreteCollection.ElementAt(1).Name);

        private It should_be_followed_by_the_third_record = () => result.ElementAt(2)["Name"].ShouldEqual(concreteCollection.ElementAt(2).Name);

        private It should_be_followed_by_the_fourth_record = () => result.ElementAt(3)["Name"].ShouldEqual(concreteCollection.ElementAt(3).Name);

        private It should_be_followed_by_the_fifth_record = () => result.ElementAt(4)["Name"].ShouldEqual(concreteCollection.ElementAt(4).Name);
    }

    public class When_selecting_a_single_int_property : Projection
    {
        private Because of =
            () =>
            result = concreteCollection.AsQueryable().ExtendFromOData<ConcreteClass, IQueryable<Dictionary<string, object>>>("?$select=Age");

        private It should_project_the_name_properties_into_the_dictionary =
            () => result.ShouldEachConformTo(
                r => r.ContainsKey("Age"));

        private It should_only_have_projected_the_one_property =
            () => result.ShouldEachConformTo(r => r.Count == 1);

        private It should_contain_5_results = () => result.Count().ShouldEqual(5);

        private It should_start_with_the_first_record = () => result.ElementAt(0)["Age"].ShouldEqual(concreteCollection.ElementAt(0).Age);

        private It should_be_followed_by_the_second_record = () => result.ElementAt(1)["Age"].ShouldEqual(concreteCollection.ElementAt(1).Age);

        private It should_be_followed_by_the_third_record = () => result.ElementAt(2)["Age"].ShouldEqual(concreteCollection.ElementAt(2).Age);

        private It should_be_followed_by_the_fourth_record = () => result.ElementAt(3)["Age"].ShouldEqual(concreteCollection.ElementAt(3).Age);

        private It should_be_followed_by_the_fifth_record = () => result.ElementAt(4)["Age"].ShouldEqual(concreteCollection.ElementAt(4).Age);
    }

    public class When_selecting_a_single_datetime_property : Projection
    {
        private Because of =
            () =>
            result = concreteCollection.AsQueryable().ExtendFromOData<ConcreteClass, IQueryable<Dictionary<string, object>>>("?$select=Date");

        private It should_project_the_name_properties_into_the_dictionary =
            () => result.ShouldEachConformTo(
                r => r.ContainsKey("Date"));

        private It should_only_have_projected_the_one_property =
            () => result.ShouldEachConformTo(r => r.Count == 1);

        private It should_contain_5_results = () => result.Count().ShouldEqual(5);

        private It should_start_with_the_first_record = () => result.ElementAt(0)["Date"].ShouldEqual(concreteCollection.ElementAt(0).Date);

        private It should_be_followed_by_the_second_record = () => result.ElementAt(1)["Date"].ShouldEqual(concreteCollection.ElementAt(1).Date);

        private It should_be_followed_by_the_third_record = () => result.ElementAt(2)["Date"].ShouldEqual(concreteCollection.ElementAt(2).Date);

        private It should_be_followed_by_the_fourth_record = () => result.ElementAt(3)["Date"].ShouldEqual(concreteCollection.ElementAt(3).Date);

        private It should_be_followed_by_the_fifth_record = () => result.ElementAt(4)["Date"].ShouldEqual(concreteCollection.ElementAt(4).Date);
    }

    public class When_selecting_a_single_boolean_property : Projection
    {
        private Because of =
            () =>
            result = concreteCollection.AsQueryable().ExtendFromOData<ConcreteClass, IQueryable<Dictionary<string, object>>>("?$select=Complete");

        private It should_project_the_name_properties_into_the_dictionary =
            () => result.ShouldEachConformTo(
                r => r.ContainsKey("Complete"));

        private It should_only_have_projected_the_one_property =
            () => result.ShouldEachConformTo(r => r.Count == 1);

        private It should_contain_5_results = () => result.Count().ShouldEqual(5);

        private It should_start_with_the_first_record = () => result.ElementAt(0)["Complete"].ShouldEqual(concreteCollection.ElementAt(0).Complete);

        private It should_be_followed_by_the_second_record = () => result.ElementAt(1)["Complete"].ShouldEqual(concreteCollection.ElementAt(1).Complete);

        private It should_be_followed_by_the_third_record = () => result.ElementAt(2)["Complete"].ShouldEqual(concreteCollection.ElementAt(2).Complete);

        private It should_be_followed_by_the_fourth_record = () => result.ElementAt(3)["Complete"].ShouldEqual(concreteCollection.ElementAt(3).Complete);

        private It should_be_followed_by_the_fifth_record = () => result.ElementAt(4)["Complete"].ShouldEqual(concreteCollection.ElementAt(4).Complete);
    }

    public class When_selecting_multiple_properties : Projection
    {
        private Because of =
            () =>
            result = concreteCollection.AsQueryable().ExtendFromOData<ConcreteClass, IQueryable<Dictionary<string, object>>>("?$select=Name,Age");

        private It should_project_the_name_and_age_properties_into_the_dictionary =
            () => result.ShouldEachConformTo(
                r => r.ContainsKey("Name") && r.ContainsKey("Age"));

        private It should_only_have_projected_two_properties =
            () => result.ShouldEachConformTo(r => r.Count == 2);

        private It should_contain_5_results = () => result.Count().ShouldEqual(5);

        private It should_project_the_right_name_for_the_first_record = () => result.ElementAt(0)["Age"].ShouldEqual(concreteCollection.ElementAt(0).Age);

        private It should_project_the_right_name_for_the_second_record = () => result.ElementAt(1)["Age"].ShouldEqual(concreteCollection.ElementAt(1).Age);

        private It should_project_the_right_name_for_the_third_record = () => result.ElementAt(2)["Age"].ShouldEqual(concreteCollection.ElementAt(2).Age);

        private It should_project_the_right_name_for_the_fourth_record = () => result.ElementAt(3)["Age"].ShouldEqual(concreteCollection.ElementAt(3).Age);

        private It sshould_project_the_right_name_for_the_fifth_record = () => result.ElementAt(4)["Age"].ShouldEqual(concreteCollection.ElementAt(4).Age);

        private It should_project_the_right_age_for_the_first_record = () => result.ElementAt(0)["Name"].ShouldEqual(concreteCollection.ElementAt(0).Name);

        private It should_project_the_right_age_for_the_second_record = () => result.ElementAt(1)["Name"].ShouldEqual(concreteCollection.ElementAt(1).Name);

        private It should_project_the_right_age_for_the_third_record = () => result.ElementAt(2)["Name"].ShouldEqual(concreteCollection.ElementAt(2).Name);

        private It should_project_the_right_age_for_the_fourth_record = () => result.ElementAt(3)["Name"].ShouldEqual(concreteCollection.ElementAt(3).Name);

        private It should_project_the_right_age_for_the_fifth_record = () => result.ElementAt(4)["Name"].ShouldEqual(concreteCollection.ElementAt(4).Name);
    }

    #endregion

    #region Complex Property Tests



    #endregion
}
