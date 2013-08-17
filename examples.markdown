---
layout: default
title:  Examples
---
## Examples
    
Linq to Querystring uses an expression parser written in ANTLR to map a subset of odata-compatible expressions onto any .NET IQueryable.

Work directly with Linq to Object IQueryables:
{% highlight c# %}
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
{% endhighlight %}
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