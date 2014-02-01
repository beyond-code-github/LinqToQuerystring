namespace LinqToQuerystring.Exceptions
{
    using System;

    public class FunctionNotSupportedException : Exception
    {
        public FunctionNotSupportedException(Type type, string function)
            : base(string.Format("{0} does not support the '{1}' function.", type, function))
        {
        }
    }
}
