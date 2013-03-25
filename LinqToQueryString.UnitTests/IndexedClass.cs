namespace TestHarness
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
                return dictionary[index];
            }
            set
            {
                dictionary[index] = value;
            }
        }
    }
}
