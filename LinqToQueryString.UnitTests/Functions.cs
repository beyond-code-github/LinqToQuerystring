namespace LinqToQueryString.UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using LinqToQueryString.Tests;

    using LinqToQuerystring;

    using Machine.Specifications;

    public abstract class Functions
    {
        protected static Exception ex;

        protected static IQueryable<ConcreteClass> result;

        protected static List<ConcreteClass> concreteCollection;

        protected static List<ComplexClass> complexCollection;

        private Establish context = () =>
        {
            concreteCollection = new List<ConcreteClass>
                                         {
                                             InstanceBuilders.BuildConcrete("Saturday", 1, new DateTime(2001, 01, 01, 01, 05, 00), true),
                                             InstanceBuilders.BuildConcrete("Satnav", 2, new DateTime(2002, 01, 02, 06, 10, 10), false),
                                             InstanceBuilders.BuildConcrete("Saturnalia", 3, new DateTime(2003, 02, 02, 10, 10, 20), true),
                                             InstanceBuilders.BuildConcrete("Saturn", 4, new DateTime(2004, 04, 06, 10, 20, 30), true),
                                             InstanceBuilders.BuildConcrete("Monday", 5, new DateTime(2005, 06, 21, 13, 20, 40), true),
                                             InstanceBuilders.BuildConcrete("Tuesday", 5, new DateTime(2005, 06, 30, 20, 20, 50), true),
                                             InstanceBuilders.BuildConcrete("Burns", 5, new DateTime(2005, 10, 31, 23, 35, 50), true)
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

    public class When_filtering_on_startswith_function : Functions
    {
        private Because of =
            () => result = concreteCollection.AsQueryable().LinqToQuerystring("?$filter=startswith(Name,'Sat')");

        private It should_return_four_records = () => result.Count().ShouldEqual(4);

        private It should_only_return_records_where_name_starts_with_Sat =
            () => result.ShouldEachConformTo(o => o.Name.StartsWith("Sat"));
    }

    public class When_filtering_on_endswith_function : Functions
    {
        private Because of =
            () => result = concreteCollection.AsQueryable().LinqToQuerystring("?$filter=endswith(Name,'day')");

        private It should_return_four_records = () => result.Count().ShouldEqual(3);

        private It should_only_return_records_where_name_ends_with_day =
            () => result.ShouldEachConformTo(o => o.Name.EndsWith("day"));
    }

    public class When_filtering_on_substringof_function : Functions
    {
        private Because of =
            () => result = concreteCollection.AsQueryable().LinqToQuerystring("?$filter=substringof('urn',Name)");

        private It should_return_three_records = () => result.Count().ShouldEqual(3);

        private It should_only_return_records_where_name_contains_urn =
            () => result.ShouldEachConformTo(o => o.Name.Contains("urn"));
    }

    public class When_filtering_on_multiple_substringof_functions : Functions
    {
        private Because of =
            () => result = concreteCollection.AsQueryable().LinqToQuerystring("?$filter=(substringof('Mond',Name)) or (substringof('Tues',Name))");

        private It should_return_three_records = () => result.Count().ShouldEqual(2);

        private It should_only_return_records_where_name_contains_urn =
            () => result.ShouldEachConformTo(o => o.Name.Contains("Mond") || o.Name.Contains("Tues"));
    }

    public class When_filtering_on_substringof_function_with_escape_character : Filtering
    {
        private Because of =
            () => result = edgeCaseCollection.AsQueryable().LinqToQuerystring(@"?$filter=substringof('\\',Name)");

        private It should_return_one_record = () => result.Count().ShouldEqual(1);

        private It should_only_return_records_where_name_contains_escaped_slash =
            () => result.ShouldEachConformTo(o => o.Name.Contains("\\"));
    }

    public class When_filtering_on_substringof_function_with_tolower : Functions
    {
        private Because of =
            () => result = concreteCollection.AsQueryable().LinqToQuerystring(@"?$filter=substringof('sat',tolower(Name))");

        private It should_return_four_records = () => result.Count().ShouldEqual(4);

        private It should_only_return_records_where_name_contains_sat =
            () => result.ShouldEachConformTo(o => o.Name.Contains("Sat"));
    }

    public class When_filtering_on_substringof_function_with_toupper : Functions
    {
        private Because of =
            () => result = concreteCollection.AsQueryable().LinqToQuerystring(@"?$filter=substringof('SAT',toupper(Name))");

        private It should_return_four_records = () => result.Count().ShouldEqual(4);

        private It should_only_return_records_where_name_contains_sat =
            () => result.ShouldEachConformTo(o => o.Name.Contains("Sat"));
    }

    public class When_filtering_on_year_function : Functions
    {
        private Because of =
            () => result = concreteCollection.AsQueryable().LinqToQuerystring(@"?$filter=year(Date) eq 2005");

        private It should_return_three_records = () => result.Count().ShouldEqual(3);

        private It should_only_return_records_where_year_is_2005 =
            () => result.ShouldEachConformTo(o => o.Date.Year == 2005);
    }

    public class When_filtering_on_years_function : Functions
    {
        private Because of =
            () => result = concreteCollection.AsQueryable().LinqToQuerystring(@"?$filter=years(Date) eq 2005");

        private It should_return_three_records = () => result.Count().ShouldEqual(3);

        private It should_only_return_records_where_year_is_2005 =
            () => result.ShouldEachConformTo(o => o.Date.Year == 2005);
    }

    public class When_filtering_on_month_function : Functions
    {
        private Because of =
            () => result = concreteCollection.AsQueryable().LinqToQuerystring(@"?$filter=month(Date) eq 6");

        private It should_return_two_records = () => result.Count().ShouldEqual(2);

        private It should_only_return_records_where_month_is_6 =
            () => result.ShouldEachConformTo(o => o.Date.Month == 6);
    }

    public class When_filtering_on_day_function : Functions
    {
        private Because of =
            () => result = concreteCollection.AsQueryable().LinqToQuerystring(@"?$filter=day(Date) eq 2");

        private It should_return_two_records = () => result.Count().ShouldEqual(2);

        private It should_only_return_records_where_day_is_2 =
            () => result.ShouldEachConformTo(o => o.Date.Day == 2);
    }

    public class When_filtering_on_days_function : Functions
    {
        private Because of =
            () => result = concreteCollection.AsQueryable().LinqToQuerystring(@"?$filter=days(Date) eq 2");

        private It should_return_two_records = () => result.Count().ShouldEqual(2);

        private It should_only_return_records_where_day_is_2 =
            () => result.ShouldEachConformTo(o => o.Date.Day == 2);
    }

    public class When_filtering_on_hour_function : Functions
    {
        private Because of =
            () => result = concreteCollection.AsQueryable().LinqToQuerystring(@"?$filter=hour(Date) eq 10");

        private It should_return_two_records = () => result.Count().ShouldEqual(2);

        private It should_only_return_records_where_hour_is_10 =
            () => result.ShouldEachConformTo(o => o.Date.Hour == 10);
    }

    public class When_filtering_on_hours_function : Functions
    {
        private Because of =
            () => result = concreteCollection.AsQueryable().LinqToQuerystring(@"?$filter=hours(Date) eq 10");

        private It should_return_two_records = () => result.Count().ShouldEqual(2);

        private It should_only_return_records_where_hour_is_10 =
            () => result.ShouldEachConformTo(o => o.Date.Hour == 10);
    }

    public class When_filtering_on_minute_function : Functions
    {
        private Because of =
            () => result = concreteCollection.AsQueryable().LinqToQuerystring(@"?$filter=minute(Date) eq 20");

        private It should_return_three_records = () => result.Count().ShouldEqual(3);

        private It should_only_return_records_where_minute_is_20 =
            () => result.ShouldEachConformTo(o => o.Date.Minute == 20);
    }

    public class When_filtering_on_minutes_function : Functions
    {
        private Because of =
            () => result = concreteCollection.AsQueryable().LinqToQuerystring(@"?$filter=minutes(Date) eq 20");

        private It should_return_three_records = () => result.Count().ShouldEqual(3);

        private It should_only_return_records_where_minute_is_20 =
            () => result.ShouldEachConformTo(o => o.Date.Minute == 20);
    }

    public class When_filtering_on_second_function : Functions
    {
        private Because of =
            () => result = concreteCollection.AsQueryable().LinqToQuerystring(@"?$filter=second(Date) eq 50");

        private It should_return_two_records = () => result.Count().ShouldEqual(2);

        private It should_only_return_records_where_second_is_50 =
            () => result.ShouldEachConformTo(o => o.Date.Second == 50);
    }

    public class When_filtering_on_seconds_function : Functions
    {
        private Because of =
            () => result = concreteCollection.AsQueryable().LinqToQuerystring(@"?$filter=seconds(Date) eq 50");

        private It should_return_two_records = () => result.Count().ShouldEqual(2);

        private It should_only_return_records_where_second_is_50 =
            () => result.ShouldEachConformTo(o => o.Date.Second == 50);
    }
}
