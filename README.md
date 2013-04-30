v0.5.5 Overview
===============

Linq to Querystring is an expression parser for .NET that aims to provide a lightweight subset of the OData URI Specification.

As of v0.5.5 the core library now targets .net 3.5 and above. Beware however that support prior to 4.5 is largely untested in a real-world scenario... if you use it in this version please let me know how it goes.

Check out the demo site here: http://linqtoquerystring.azurewebsites.net/

***
**_BREAKING CHANGE AS OF v0.5.5_**

The parameters of the substringof function have been swapped around so that they are now in line with the OData specification
http://www.odata.org/documentation/odata-v2-documentation/uri-conventions/#45_Filter_System_Query_Option_filter
***
**_BREAKING CHANGE AS OF v0.5.3_**

The LinqToQueryable Action Filter for Web API is **no longer provided** with the main Linq to Querystring package. 

Please install the **LinqToQuerystring.WebApi** nuget package.
***

Installation
============

* Nuget package: https://nuget.org/packages/LinqToQuerystring/
PM> Install-Package LinqToQuerystring

* Web Api package: https://nuget.org/packages/LinqToQuerystring.WebApi/
PM> Install-Package LinqToQuerystring.WebApi

* Nancy FX package: https://nuget.org/packages/LinqToQuerystring.Nancy/
PM> Install-Package LinqToQuerystring.Nancy

Addressing issues with OData
============================

The OData specification itself is very extensive, and Linq to Querystring does not claim (or intend) to support all of it. In fact, OData itself seems to split opinion – see here for example: http://stackoverflow.com/questions/9577938/odata-with-servicestack.

In to the answer above, Mythz states some concerns that proponents of REST often have about OData, which Linq to Querystring goes some way towards addressing:

* **Poor development practices** – Linq to Querystring is simple, flexible and open source, so it can respond to new technologies and paradigms.
* **Promotes bad web service practices** – No longer tied to your DBMS as it works with any IQueryable, so you don’t have to expose your data model through your services.
* **Only used in Microsoft technologies** – The main expression parsing engine of Linq to Querystring is written in ANTLR so can be easily ported to other languages that support construction of expression trees.
* **OData is slow** - Leaving out certain elements of the protocol helps to keep things fast compared to full blown OData implementations. All Linq to Querystring does is map the AST produced by ANTLR onto an IQueryable expression tree.

Currently supported
===================

* String escape sequences: \\\\ \' \t \r \n \f ''
* Seamless integration with Asp.Net Web API using LinqToQueryable Attribute 
* Use Linq to Querystring with Nancy FX modules
* Linq to Objects, Entity framework & MongoDB
* Support for loosely typed datastructures
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
* Functions - startswith, endswith, substringof
* Unicode values

In development:

* $select - sub properties & complex types
* $filter - sub properties
* Remaining functions
* Arithmetic operations (e.g abs, mod)

Future roadmap:

* byte, decimal, double, single, guid, time, int64, datetimeoffset data types
* $expand (via EF Include method)

* UIToQuerystring - JQuery plugin for building oData\Linq to Querystring expressions

Getting Started
===============

### Asp.Net Web API

Get going straight away by adding the [LinqToQueryable] attribute to your Asp.Net Web API controllers:

    [LinqToQueryable]
    public IQueryable<Movie> Get()
    
### Nancy FX

    public MoviesModule()
    {
        Get["/"] =
            _ => this.moviesService.Get().LinqToQuerystring((IDictionary<string, object>)this.Context.Request.Query)
    }
    
### General
    
Linq to Querystring uses an expression parser written in ANTLR to map a subset of odata-compatible expressions onto any .NET IQueryable.

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
    
Work with Dynamic objects:

    var item1 = new Dictionary<string, object>();
    item1["Age"] = 25;
    item1["Name"] = "Kathryn";

    var item2 = new Dictionary<string, object>();
    item2["Age"] = 28;
    item2["Name"] = "Pete";

    collection = new List<Dictionary<string, object>> { item1, item2 }.AsQueryable();
    
    var ordered = collection.LinqToQuerystring("?$orderby=[Age] desc");
    
Tested against Entity Framework:

    var query = this.unitOfWork.Data.Where(o => o.SomeRepoLevelFilter == x);
    var extended = query.LinqToQuerystring("?$filter=Complete eq true and name eq 'Eggs'");
