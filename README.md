v0.3 Overview
=============

Linq to Querystring is an expression parser for .NET that aims to provide a lightweight subset of the OData URI Specification. Currently supports:

* string, int32, bool, datetime data types
* $top
* $skip (must be used in conjunction with orderby in Linq to Entities)
* $orderby:
    * simple types, 
    * subproperties
    * complex types ( Linq to Objects only, via IComparable, )
* $filter - simple properties
* $select - simple properties

In development:

* $select - sub properties & complex types
* $filter - sub properties
* Support for class indexers
* Demo Site\API

Future roadmap:

* byte, decimal, double, single, guid, time, int64, datetimeoffset data types
* $expand (via EF Include method)
* $inlinecount
* Arithmetic operations (e.g abs, mod)
* Other functions (e.g endswith, floor)
* MediaTypeFormatter for Web API
* LinqToQueryable Attribute 
* UIToQuerystring - JQuery plugin for building oData\Linq to Querystring expressions

Details
=======

Linq to Querystring uses an expression parser written in ANTLR to map a subset of odata-compatible expressions onto any .NET IQueryable.

Linq to Objects:

    var collection = new List<Dummy>
    {
       new Dummy("Apple", 5, new DateTime(2005, 01, 01), true),
       new Dummy("Custard", 3, new DateTime(2007, 01, 01), true),
       new Dummy("Banana", 2, new DateTime(2003, 01, 01), false),
       new Dummy("Eggs", 1, new DateTime(2000, 01, 01), true),
       new Dummy("Dogfood", 4, new DateTime(2009, 01, 01), false),
    }.AsQueryable();

    var ordered = collection.ExtendFromOData("?$orderby=Complete,Age");
    var paged = collection.ExtendFromOData("?$skip=2$top=2");

Linq to Entities:

    var query = this.unitOfWork.Data.Where(o => o.SomeRepoLevelFilter == x);
    var extended = query.ExtendFromOData("?$filter=Complete eq true and name eq 'Eggs'");
