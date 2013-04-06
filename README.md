v0.4.1 Overview
==============

Linq to Querystring is an expression parser for .NET that aims to provide a lightweight subset of the OData URI Specification.

Check out the demo site here: http://linqtoquerystring.azurewebsites.net/

Installation
===========

Nuget package: https://nuget.org/packages/LinqToQuerystring/

PM> Install-Package LinqToQuerystring


Currently supported
===================

* Seamless integration with Asp.Net Web API using LinqToQueryable Attribute 
* string, int32, bool, datetime data types
* $top
* $skip (must be used in conjunction with orderby in Linq to Entities)
* $orderby:
    * simple types, 
    * subproperties
    * complex types ( Linq to Objects only, via IComparable, )
* $filter - simple properties
* $select - simple properties
* $inlinecount

In development:

* $select - sub properties & complex types
* $filter - sub properties
* Support for class indexers

Future roadmap:

* byte, decimal, double, single, guid, time, int64, datetimeoffset data types
* $expand (via EF Include method)
* Arithmetic operations (e.g abs, mod)
* Other functions (e.g endswith, floor)

* UIToQuerystring - JQuery plugin for building oData\Linq to Querystring expressions

Details
=======

Linq to Querystring uses an expression parser written in ANTLR to map a subset of odata-compatible expressions onto any .NET IQueryable.

Get going straight away by adding the [LinqToQueryable] attribute to your Asp.Net Web API controllers:

    [LinqToQueryable]
    public IQueryable<Movie> Get()
    
Work directly with Linq to Object IQueryables:

    var collection = new List<Dummy>
    {
       new Dummy("Apple", 5, new DateTime(2005, 01, 01), true),
       new Dummy("Custard", 3, new DateTime(2007, 01, 01), true),
       new Dummy("Banana", 2, new DateTime(2003, 01, 01), false),
       new Dummy("Eggs", 1, new DateTime(2000, 01, 01), true),
       new Dummy("Dogfood", 4, new DateTime(2009, 01, 01), false),
    }.AsQueryable();

    var ordered = collection.LinqToQuerystring("?$orderby=Complete,Age");
    var paged = collection.LinqToQuerystring("?$skip=2$top=2");

Also tested against Entity Framework:

    var query = this.unitOfWork.Data.Where(o => o.SomeRepoLevelFilter == x);
    var extended = query.LinqToQuerystring("?$filter=Complete eq true and name eq 'Eggs'");
