namespace LinqToQuerystring.Exceptions
{
    using System;

    public class InvalidEscapeSequenceException : Exception
    {
        public InvalidEscapeSequenceException(string text)
            : base(string.Format("Invalid escape sequence {0}", text))
        {
        }
    }
}
