---
layout: default
title:  Home
---
## What is it?

Linq to Querystring is an expression parser for .NET that aims to provide a lightweight subset of the OData URI Specification. We focus only on the query aspect of the specification which is one of the most useful and flexible elements of OData.

The project started out as an experiment of mine in ANLTR, and then grew as part of a requirement in a project I was on to perform OData queries against loosely typed data in MongoDB, which at the time of writing is functionality that no other OData provider can offer.

Check out the demo site here: [http://linqtoquerystring.azurewebsites.net/](http://linqtoquerystring.azurewebsites.net/)

## Installation

* Nuget package: [https://nuget.org/packages/LinqToQuerystring/](https://nuget.org/packages/LinqToQuerystring/)
PM> Install-Package LinqToQuerystring

* Entity Framework package ($expand support): [https://nuget.org/packages/LinqToQuerystring.EntityFramework/](https://nuget.org/packages/LinqToQuerystring.EntityFramework/)
PM> Install-Package LinqToQuerystring.EntityFramework

* Web Api package: [https://nuget.org/packages/LinqToQuerystring.WebApi/](https://nuget.org/packages/LinqToQuerystring.WebApi/)
PM> Install-Package LinqToQuerystring.WebApi

* Nancy FX package: [https://nuget.org/packages/LinqToQuerystring.Nancy/](https://nuget.org/packages/LinqToQuerystring.Nancy/)
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
##Release Notes

**_v0.7.0_** - Date and time functions added, courtesy of https://github.com/xt0rted

**_v0.6.8_** - Decimal data type is now supported. Please note when dealing with dynamic identifiers such as [Score] decimal constants must use m suffix e.g 0.4m

**_v0.6.7_** - Better management of URL encoding

**_v0.6.6_** - Unrecognised query operators should be ignored, String functions now working against Dictionary&lt;string, object&gt;

**_v0.6.5_** - Now using AndAlso and OrElse expressions, fixed an issue when targeting .Net 3.5, and with content negotiation in Web API.

**_v0.6.4_** - Entity Framework and Web API libraries now support .net framework 4.0. Nullable types are now supported, along with the OData null keyword.

**_v0.6.3_** - $expand support is now available when directly interfacing with Linq to Entities queries.

**_v0.5.5_** - Core library now targets .net 3.5 and above. Beware however that support prior to 4.5 is largely untested in a real-world scenario... if you use it in this version please let me know how it goes.