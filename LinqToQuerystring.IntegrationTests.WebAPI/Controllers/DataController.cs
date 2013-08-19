namespace LinqToQuerystring.IntegrationTests.WebApi.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;

    using LinqToQuerystring.WebApi;

    public class DataController : ApiController
    {
        [Serializable]
        public class DataClass
        {
            private readonly string name;

            private readonly int age;

            private readonly bool awesome;

            public string Name
            {
                get
                {
                    return name;
                }
            }

            public int Age
            {
                get
                {
                    return age;
                }
            }

            public bool Awesome
            {
                get
                {
                    return awesome;
                }
            }

            public DataClass(string name, int age, bool awesome)
            {
                this.name = name;
                this.age = age;
                this.awesome = awesome;
            }
        }

        [LinqToQueryable]
        public IQueryable<DataClass> Get()
        {
            return
                new List<DataClass>
                {
                    new DataClass("Peter", 29, true),
                    new DataClass("Kathryn", 26, false)
                }.AsQueryable();
        }
    }
}
