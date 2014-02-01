namespace LinqToQuerystring.IntegrationTests.WebApi.Controllers
{
    using System;

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
                return this.name;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }
        }

        public bool Awesome
        {
            get
            {
                return this.awesome;
            }
        }

        public DataClass(string name, int age, bool awesome)
        {
            this.name = name;
            this.age = age;
            this.awesome = awesome;
        }
    }
}