Linq to Querystring v0.6.4
==========================

## What is it?

Linq to Querystring is an expression parser for .NET that aims to provide a lightweight subset of the OData URI Specification. We focus only on the query aspect of the specification which is one of the most useful and flexible elements of OData.

The project started out as an experiment of mine in ANLTR, and then grew as part of a requirement in a project I was on to perform OData queries against loosely typed data in MongoDB, which at the time of writing is functionality that no other OData provider can offer.

## Why are we doing this?

Currently the main proponents of OData are the Microsoft ASP.net team, and they're doing a great job with the OData specification and driving their implementation forward. However, it relies heavily on Microsoft technologies and is tied to the release cycle of MVC 4/Web API.

It's always beneficial for a technology to have multiple implementations, especially when those implementations can all contribute to an open standard. But rather than 'competing' with other offerings, Linq to Querystring specialies in implementing a part of the spec, that which pertains to querying data via URIs.

With smaller goals, a more focussed development effort and by addressing community concerns, Linq to Querystring can provide a more developer-centric implementation, with concise syntax, and increased interoperability, both with other web frameworks and database providers such as Mongo. And maybe we'll help push the standards forward along the way!

## Installation

* Nuget package: https://nuget.org/packages/LinqToQuerystring/
PM> Install-Package LinqToQuerystring

* Entity Framework package ($expand support): https://nuget.org/packages/LinqToQuerystring.EntityFramework/
PM> Install-Package LinqToQuerystring.EntityFramework

* Web Api package: https://nuget.org/packages/LinqToQuerystring.WebApi/
PM> Install-Package LinqToQuerystring.WebApi


* Nancy FX package: https://nuget.org/packages/LinqToQuerystring.Nancy/
PM> Install-Package LinqToQuerystring.Nancy

## Getting Started

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
##Key Release Notes

**_v0.6.4_** - Entity Framework and Web API libraries now support .net framework 4.0. Nullable types are now supported, along with the OData null keyword.

***

**_v0.6.3_** - $expand support is now available when directly interfacing with Linq to Entities queries.

***

**_v0.5.5_* the core library now targets .net 3.5 and above. Beware however that support prior to 4.5 is largely untested in a real-world scenario... if you use it in this version please let me know how it goes.

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
    
## Examples
    
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
    var extended = query.LinqToQuerystring("?$filter=Complete eq true and Name eq 'Eggs'");
    
Tested against Mongo DB

    var query = mongoCollection.AsQueryable();
    var extended = query.LinqToQuerystring("?$filter=[Complete] eq true and [Name] eq 'Eggs'");

## Current features

* String escape sequences: \\\\ \' \t \r \n \f ''
* Seamless integration with Asp.Net Web API using LinqToQueryable Attribute 
* Use Linq to Querystring with Nancy FX modules
* Linq to Objects, Entity framework & MongoDB
* Support for loosely typed datastructures
* string, int32, bool, datetime, byte, decimal, double, single, guid, long data types
* nullable types & the null keyword
* $top
* $skip (must be used in conjunction with orderby in Linq to Entities)
* $orderby:
    * simple types, 
    * subproperties
    * complex types ( Linq to Objects only, via IComparable, )
* $filter - simple properties & subproperties
* $select - simple properties
* $expand - when directly exposing entity framework queries
* $inlinecount
* Functions - startswith, endswith, substringof, tolower
* Collection Aggregates:
    * Any / All with predicates
    * Count, Sum, Average, Min, Max
* Unicode values
* UIToQuerystring (alpha) - JQuery plugin for building oData\Linq to Querystring expressions

## Future roadmap:

* Website & improved documentation
* $select - sub properties & complex types
* More functions/Arithmetic operations (e.g abs, mod)
* $expand (via EF Include method)
