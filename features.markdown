---
layout: default
title:  Features
---
## Current features

* String escape sequences: \\\\ \\' \t \r \n \f ''
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
* Date and time - year, years, month, day, days, hour, hours, minute, minutes, second, seconds
* Collection Aggregates:
    * Any / All with predicates
    * Count, Sum, Average, Min, Max
* Unicode values
* UIToQuerystring (alpha) - JQuery plugin for building oData/Linq to Querystring expressions

## Future roadmap:

* $select - sub properties & complex types (this should already work, but not tested)
* More functions/Arithmetic operations (e.g abs, mod)
* $expand for Lazy<T> and DTOs