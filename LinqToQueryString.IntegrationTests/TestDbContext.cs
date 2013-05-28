namespace LinqToQueryString.IntegrationTests.Sql
{
    using System.Data.Entity;

    using LinqToQueryString.Tests;

    public class TestDbContext : DbContext
    {
        public DbSet<ConcreteClass> ConcreteCollection { get; set; }

        public DbSet<ComplexClass> ComplexCollection { get; set; }

        public DbSet<EdgeCaseClass> EdgeCaseCollection { get; set; }
    }
}
