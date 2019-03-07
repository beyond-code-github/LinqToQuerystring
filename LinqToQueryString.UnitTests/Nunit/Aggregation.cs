using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToQuerystring;
using LinqToQueryString.Tests;
using NUnit.Framework;

namespace LinqToQueryString.UnitTests.Nunit
{
    public abstract class Aggregations
    {
        protected static Exception ex;

        protected static IQueryable<Dictionary<string, object>> result;

        protected static IQueryable<Dictionary<string, object>> complexResult;

        protected static IQueryable<Dictionary<string, object>> nullableResult;

        protected static List<ConcreteClass> concreteCollection;

        protected static List<ComplexClass> complexCollection;

        protected static List<NullableClass> nullableCollection;

        protected static Guid[] guidArray;

        protected void CreateContext()
        {
            guidArray = Enumerable.Range(1, 5).Select(o => Guid.NewGuid()).ToArray();

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

            nullableCollection = new List<NullableClass>
                                     {
                                         InstanceBuilders.BuildNull(),
                                         InstanceBuilders.BuildNull(1, new DateTime(2002, 01, 01), true, 10000000000, 111.111, 111.111f, 0x00, guidArray[0])
                                     };
        }
    }
    [TestFixture]
    public class When_aggregating_single_numeric_property_with_sum_as_total : Aggregations
    {
        private IQueryable<Dictionary<string, object>> _result;
        [SetUp]
        public void Setup()
        {
            // establish context
            CreateContext();
            _result = concreteCollection.AsQueryable()
                .LinqToQuerystring<ConcreteClass, IQueryable<Dictionary<string, object>>>("?$apply=aggregate(Age with sum as Total)");
            
        }

        [Test]
        public void Should_have_the_projected_property_in_the_dictionary()
        {
            Assert.IsTrue(_result.All(r => r.ContainsKey("Total")));
        }

        [Test]
        public void Should_have_exactly_one_property()
        {
            Assert.IsTrue(_result.All(r => r.Count == 1));
        }

        [Test]
        public void Should_have_the_correct_sum()
        {
            Assert.IsTrue((int)_result.ElementAt(0)["Total"] == 5);
            Assert.IsTrue((int)_result.ElementAt(1)["Total"] == 10);
            Assert.IsTrue((int)_result.ElementAt(2)["Total"] == 15);
            Assert.IsTrue((int)_result.ElementAt(3)["Total"] == 20);
            Assert.IsTrue((int)_result.ElementAt(4)["Total"] == 25);
        }
    }

    [TestFixture]
    public class When_aggregating_single_numeric_property_with_avg_as_average : Aggregations
    {
        private IQueryable<Dictionary<string, object>> _result;
        [SetUp]
        public void Setup()
        {
            // establish context
            CreateContext();
            _result = concreteCollection.AsQueryable()
                .LinqToQuerystring<ConcreteClass, IQueryable<Dictionary<string, object>>>("?$apply=aggregate(Age with average as AverageAge)");

        }

        [Test]
        public void Should_have_the_projected_property_in_the_dictionary()
        {
            Assert.IsTrue(_result.All(r => r.ContainsKey("AverageAge")));
        }

        [Test]
        public void Should_have_exactly_one_property()
        {
            Assert.IsTrue(_result.All(r => r.Count == 1));
        }

        [Test]
        public void Should_have_the_correct_average()
        {
            Assert.IsTrue((double)_result.ElementAt(0)["AverageAge"] == 1);
            Assert.IsTrue((double)_result.ElementAt(1)["AverageAge"] == 2);
            Assert.IsTrue((double)_result.ElementAt(2)["AverageAge"] == 3);
            Assert.IsTrue((double)_result.ElementAt(3)["AverageAge"] == 4);
            Assert.IsTrue((double)_result.ElementAt(4)["AverageAge"] == 5);
        }
    }

    [TestFixture]
    public class When_aggregating_single_numeric_property_with_max_as_average : Aggregations
    {
        private IQueryable<Dictionary<string, object>> _result;
        [SetUp]
        public void Setup()
        {
            // establish context
            CreateContext();
            _result = concreteCollection.AsQueryable()
                .LinqToQuerystring<ConcreteClass, IQueryable<Dictionary<string, object>>>("?$apply=aggregate(Age with max as MaxAge)");

        }

        [Test]
        public void Should_have_the_projected_property_in_the_dictionary()
        {
            Assert.IsTrue(_result.All(r => r.ContainsKey("MaxAge")));
        }

        [Test]
        public void Should_have_exactly_one_property()
        {
            Assert.IsTrue(_result.All(r => r.Count == 1));
        }

        [Test]
        public void Should_have_the_correct_max()
        {
            Assert.IsTrue((int)_result.ElementAt(0)["MaxAge"] == 1);
            Assert.IsTrue((int)_result.ElementAt(1)["MaxAge"] == 2);
            Assert.IsTrue((int)_result.ElementAt(2)["MaxAge"] == 3);
            Assert.IsTrue((int)_result.ElementAt(3)["MaxAge"] == 4);
            Assert.IsTrue((int)_result.ElementAt(4)["MaxAge"] == 5);
        }
    }


    [TestFixture]
    public class When_aggregating_single_numeric_property_with_min_as_average : Aggregations
    {
        private IQueryable<Dictionary<string, object>> _result;
        [SetUp]
        public void Setup()
        {
            // establish context
            CreateContext();
            _result = concreteCollection.AsQueryable()
                .LinqToQuerystring<ConcreteClass, IQueryable<Dictionary<string, object>>>("?$apply=aggregate(Age with min as MinAge)");

        }

        [Test]
        public void Should_have_the_projected_property_in_the_dictionary()
        {
            Assert.IsTrue(_result.All(r => r.ContainsKey("MinAge")));
        }

        [Test]
        public void Should_have_exactly_one_property()
        {
            Assert.IsTrue(_result.All(r => r.Count == 1));
        }

        [Test]
        public void Should_have_the_correct_max()
        {
            Assert.IsTrue((int)_result.ElementAt(0)["MinAge"] == 1);
            Assert.IsTrue((int)_result.ElementAt(1)["MinAge"] == 2);
            Assert.IsTrue((int)_result.ElementAt(2)["MinAge"] == 3);
            Assert.IsTrue((int)_result.ElementAt(3)["MinAge"] == 4);
            Assert.IsTrue((int)_result.ElementAt(4)["MinAge"] == 5);
        }
    }
}
