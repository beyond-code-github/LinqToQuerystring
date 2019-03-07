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

    [TestFixture]
    public class When_selecting_a_complex_int_property : Projection
    {
        private IQueryable<Dictionary<string, object>> _result;
        [SetUp]
        public void Setup()
        {
            // establish context
            context();
            _result = complexCollection.AsQueryable()
                .LinqToQuerystring<ComplexClass, IQueryable<Dictionary<string, object>>>("?$select=Concrete/Id");
        }

        [Test]
        public void Should_have_the_projected_property_in_the_dictionary()
        {
            Assert.IsTrue(_result.All(r => r.ContainsKey("Concrete_Id")));
        }

        [Test]
        public void Should_have_exactly_one_property()
        {
            Assert.IsTrue(_result.All(r => r.Count == 1));
        }
    }

    [TestFixture]
    public class When_selecting_two_complex_properties : Projection
    {
        private IQueryable<Dictionary<string, object>> _result;
        [SetUp]
        public void Setup()
        {
            // establish context
            context();
            _result = complexCollection.AsQueryable()
                .LinqToQuerystring<ComplexClass, IQueryable<Dictionary<string, object>>>("?$select=Concrete/Id,Concrete/Name");
        }

        [Test]
        public void Should_have_the_projected_property_in_the_dictionary()
        {
            Assert.IsTrue(_result.All(r => r.ContainsKey("Concrete_Id") && r.ContainsKey("Concrete_Name")));
        }

        [Test]
        public void Should_have_exactly_two_property()
        {
            Assert.IsTrue(_result.All(r => r.Count == 2));
        }
    }

    [TestFixture]
    public class When_selecting_int_property_with_rename : Projection
    {
        private IQueryable<Dictionary<string, object>> _result;
        [SetUp]
        public void Setup()
        {
            // establish context
            context();
            _result = concreteCollection.AsQueryable()
                .LinqToQuerystring<ConcreteClass, IQueryable<Dictionary<string, object>>>("?$select=Id as PID");
        }

        [Test]
        public void Should_have_the_projected_property_in_the_dictionary()
        {
            Assert.IsTrue(_result.All(r => r.ContainsKey("PID")));
        }

        [Test]
        public void Should_have_exactly_one_property()
        {
            Assert.IsTrue(_result.All(r => r.Count == 1));
        }
    }

    [TestFixture]
    public class When_selecting_multiple_properties_with_rename : Projection
    {
        private IQueryable<Dictionary<string, object>> _result;
        [SetUp]
        public void Setup()
        {
            // establish context
            context();
            _result = concreteCollection.AsQueryable()
                .LinqToQuerystring<ConcreteClass, IQueryable<Dictionary<string, object>>>("?$select=Id as PID,Name as DisplayName");
        }

        [Test]
        public void Should_have_the_projected_property_in_the_dictionary()
        {
            Assert.IsTrue(_result.All(r => r.ContainsKey("PID") && r.ContainsKey("DisplayName")));
        }

        [Test]
        public void Should_have_exactly_two_property()
        {
            Assert.IsTrue(_result.All(r => r.Count == 2));
        }
    }
}
