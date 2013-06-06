namespace LinqToQueryString.Tests
{
    using System.Collections.Generic;

    public class IndexedClass
    {
        private readonly Dictionary<string, object> dictionary;

        public IndexedClass(Dictionary<string, object> dictionary)
        {
            this.dictionary = dictionary;
        }

        public object this[string index]
        {
            get
            {
                return this.dictionary[index];
            }
            set
            {
                this.dictionary[index] = value;
            }
        }
    }
}
