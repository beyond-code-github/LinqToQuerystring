---
layout: default
title:  Syntax
---

## Query Syntax

Linq to Querystring uses a subset of the query syntax from OData, so most of the common queries will be compatible. This means you should be able to use Linq to Querystring to provide data for KendoUI, BreezeJS, and other awesome client libraries.

**Please note...** queries are case sensitive, operators must be seperated from operands by spaces and any reserved characters such as ?, & and = must be properly url encoded.

### Property Accessors

* **Named properties**	 			/Products?$orderby=Rating
* **Loosely typed properties**	 	/Products?$orderby=[Rating]
* **Sub properties**				/Products?$orderby=Category/Name

### Data Types

* **Null**				null
* **Boolean**			true|false
* **Byte**				0x22
* **DateTime**			datetime'2000-12-12T12:00'
* **Decimal**			2.345M
* **Double**			2.029
* **Single**			2.0f
* **Guid**				guid'12345678-aaaa-bbbb-cccc-ddddeeeeffff'
* **Int**               32
* **Long**              64L
* **String** 			'Hello OData'

### Ordering

* **Basic ascending**				/Products?$orderby=Rating
* **descending** 					/Products?$orderby=Rating desc
* **Multiple clauses**				/Products?$orderby=Rating asc,Category/Name desc

### Paging

*Paging will always be applied after ordering and filtering*

* **Top 5 products** 				/Products?$top=5
* **Top 5 ordered by rating** 		/Products?$top=5&$orderby=Rating
* **Skip 10, then return 5** 		/Products?$skip=10&$top=5
* **Return a total record count**   /Products?$inlinecount=allpages

*Count will be taken before any paging has been applied. Results and count returned in the following format:*
{% highlight json %}
    {
        "Count": 17,
        "Records": [
            ...
            ...
        ]
    }
{% endhighlight c# %}

### Filtering

* **eq**	Equal					/Suppliers?$filter=Address/City eq ‘Redmond’
* **ne**	Not equal				/Suppliers?$filter=Address/City ne ‘London’
* **gt**	Greater than			/Products?$filter=Price gt 20
* **ge**	Greater than or equal	/Products?$filter=Price ge 10
* **lt**	Less than				/Products?$filter=Price lt 20
* **le**	Less than or equal		/Products?$filter=Price le 100
* **and**	Logical and				/Products?$filter=Price le 200 and Price gt 3.5
* **or**	Logical or				/Products?$filter=Price le 3.5 or Price gt 200
* **not**	Logical negation		/Products?$filter=not Description eq ’milk’
* **( )**	Precedence grouping		/Products?$filter=(Price sub 5) gt 10

### Functions

* **substringof**					/Customers?$filter=substringof(‘Alfreds’, CompanyName) eq true
* **endswith**						/Customers?$filter=endswith(CompanyName, ‘Futterkiste’) eq true
* **startswith**					/Customers?$filter=startswith(CompanyName, ‘Alfr’) eq true
* **tolower**						/Customers?$filter=tolower(CompanyName) eq ‘alfreds futterkiste’
* **toupper**						/Customers?$filter=toupper(CompanyName) eq ‘ALFREDS FUTTERKISTE’

### Collection Operators

* **any**		 				/Categories?$filter=Products/any(p: p/Rating lt 4)
* **all**	 					/Categories?$filter=Products/all(p: p/Rating ge 7)
* **count** 					/Categories?$filter=Products/count() lt 10
* **min**						/Categories?$filter=Scores/min() gt 5
* **max**						/Categories?$filter=Scores/max() eq 10
* **sum**						/Categories?$filter=Scores/sum() gt 500
* **average**  					/Categories?$filter=Scores/average() gt 10

### Projections

* **Retrieve only price and name** 			/Products?$select=Price,Name
* **Retrieve price and category**			/Products?$select=Price,Category
* **Retreive price and category name**		/Products?$select=Price,Category/Name

## Expand (Entity Framework Only)

* **Invoke EF Include() on Property**       /Products?$expand=Category

*Unlike true OData, Linq to Querystring does not require that you use $expand before subproperties become available for use with $select. Additionally, you do not need to explicitly include a property using $select to see the results of $expand in your data set*