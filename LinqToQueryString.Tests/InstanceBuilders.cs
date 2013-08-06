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

        public static ConcreteClass BuildConcrete(string name, int age, DateTime date, bool complete, long population, double value, float cost, byte code, Guid guid)
        {
            return new ConcreteClass { Name = name, Date = date, Age = age, Complete = complete, Population = population, Value = value, Cost = cost, Code = code, Guid = guid };
        }

        public static NullableClass BuildNull()
        {
            return new NullableClass();
        }

        public static NullableClass BuildNull(int? age, DateTime? date, bool? complete, long? population, double? value, float? cost, byte? code, Guid? guid)
        {
            return new NullableClass { Date = date, Age = age, Complete = complete, Population = population, Value = value, Cost = cost, Code = code, Guid = guid };
        }
    }
}