---
layout: default
title:  Home
---
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

**_v0.5.5_** the core library now targets .net 3.5 and above. Beware however that support prior to 4.5 is largely untested in a real-world scenario... if you use it in this version please let me know how it goes.

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