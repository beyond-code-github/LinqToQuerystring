Overview
========

LinqToQuerystring is an expression parser for .NET that aims to provide a lightweight subset of the OData URI Specification. Currently supports:

* $top
* $skip
* $orderby (simple types, complex types via IComparable, subproperties)

In development:

* Support for class indexers
* $filter (logic operators, parenthesis)

Future roadmap:

* $select
* $expand (via 
* $inlinecount

* Arithmetic operations (e.g abs, mod)
* Other functions (e.g endswith, floor)

* MediaTypeFormatter for Web API

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
