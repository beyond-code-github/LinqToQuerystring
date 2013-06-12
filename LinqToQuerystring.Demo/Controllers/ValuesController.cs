namespace LinqToQuerystring.Demo.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;

    using LinqToQuerystring.Demo.Filters;
    using LinqToQuerystring.Demo.Models;
    using LinqToQuerystring.WebApi;

    public class ValuesController : ApiController
    {
        [ApiExceptionFilter]
        [LinqToQueryable]
        public IQueryable<Movie> Get()
        {
            return
                new List<Movie>
                    {
                        new Movie
                            {
                                Title = "Matrix (The)",
                                ReleaseDate = new DateTime(1999, 3, 31),
                                DurationInMinutes = 136,
                                MetaScore = 73,
                                Director = "Andy Wachowski\\Lana Wachowski",
                                Recommended = true,
                                Tags = new List<string> { "Sci Fi", "Action" },
                                UserScores = new List<double>  { 73.5, 66.8, 87.3 }
                            },
                        new Movie
                            {
                                Title = "Avatar",
                                ReleaseDate = new DateTime(2009, 12, 17),
                                DurationInMinutes = 162,
                                MetaScore = 83,
                                Director = "James Cameron",
                                Recommended = false,
                                Tags = new List<string>  { "Sci Fi", "Action" },
                                UserScores = new List<double>  { 45.6, 72.0, 91.2, 83.12 }
                            },
                        new Movie
                            {
                                Title = "Spaceballs",
                                ReleaseDate = new DateTime(1987, 6, 24),
                                DurationInMinutes = 96,
                                MetaScore = 46,
                                Director = "Mel Brooks",
                                Recommended = true,
                                Tags = new List<string>  { "Sci Fi", "Comedy" },
                                UserScores = new List<double>  { 45.6, 32.0, 65.2 }
                            },
                        new Movie
                            {
                                Title = "Return of the Jedi",
                                ReleaseDate = new DateTime(1983, 6, 2),
                                DurationInMinutes = 134,
                                MetaScore = 52,
                                Director = "Richard Marquand",
                                Recommended = true,
                                Tags = new List<string>  { "Sci Fi", "Epic" },
                                UserScores = new List<double>  { 98, 87.9, 91.3, 97.5 }
                            },
                        new Movie
                            {
                                Title = "Fellowship of the ring (The)",
                                ReleaseDate = new DateTime(2001, 12, 10),
                                DurationInMinutes = 228,
                                MetaScore = 92,
                                Director = "Peter Jackson",
                                Recommended = true,
                                Tags = new List<string>  { "Fantasy", "Epic" },
                                UserScores = new List<double>  { 75.1, 66.5, 82, 86.3 }
                            },
                        new Movie
                            {
                                Title = "There and Back Again, An Unexpected Journey",
                                ReleaseDate = new DateTime(2012, 12, 14),
                                DurationInMinutes = 169,
                                MetaScore = 58,
                                Director = "Peter Jackson",
                                Recommended = false,
                                Tags = new List<string>  { "Fantasy" },
                                UserScores = new List<double>  { 55.1, 42.5, 39.8, 61.0 }
                            },
                        new Movie
                            {
                                Title = "Ferris Bueller's Day Off",
                                ReleaseDate = new DateTime(2012, 6, 11),
                                DurationInMinutes = 103,
                                MetaScore = 60,
                                Director = "John Hughes",
                                Recommended = true,
                                Tags = new List<string>  { "Comedy" },
                                UserScores = new List<double>  { 50.1, 63.6, 61, 73.9 }
                            }
                    }.AsQueryable();
        }
    }
}