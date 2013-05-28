namespace LinqToQueryString.Tests
{
    using System;

    public static class InstanceBuilders
    {
        public static ConcreteClass BuildConcrete(string name, int age, DateTime date, bool complete)
        {
            return new ConcreteClass { Name = name, Date = date, Age = age, Complete = complete };
        }

        public static EdgeCaseClass BuildEdgeCase(string name, int age, DateTime date, bool complete)
        {
            return new EdgeCaseClass { Name = name, Date = date, Age = age, Complete = complete };
        }
    }
}