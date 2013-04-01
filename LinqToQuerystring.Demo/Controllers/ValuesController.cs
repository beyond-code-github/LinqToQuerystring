namespace LinqToQuerystring.Demo.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;

    using LinqToQuerystring.Demo.Models;

    public class ValuesController : ApiController
    {
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
                                Director = "Wachowski Brothers",
                                Recommended = true
                            },
                        new Movie
                            {
                                Title = "Avatar",
                                ReleaseDate = new DateTime(2009, 12, 17),
                                DurationInMinutes = 162,
                                MetaScore = 83,
                                Director = "James Cameron",
                                Recommended = false
                            },
                        new Movie
                            {
                                Title = "Spaceballs",
                                ReleaseDate = new DateTime(1987, 6, 24),
                                DurationInMinutes = 96,
                                MetaScore = 46,
                                Director = "Mel Brooks",
                                Recommended = true
                            },
                        new Movie
                            {
                                Title = "Return of the Jedi",
                                ReleaseDate = new DateTime(1983, 6, 2),
                                DurationInMinutes = 134,
                                MetaScore = 52,
                                Director = "Richard Marquand",
                                Recommended = true
                            },
                        new Movie
                            {
                                Title = "Fellowship of the ring (The)",
                                ReleaseDate = new DateTime(2001, 12, 10),
                                DurationInMinutes = 228,
                                MetaScore = 92,
                                Director = "Peter Jackson",
                                Recommended = true
                            },
                        new Movie
                            {
                                Title = "There and Back Again, An Unexpected Journey",
                                ReleaseDate = new DateTime(2012, 12, 14),
                                DurationInMinutes = 169,
                                MetaScore = 58,
                                Director = "Peter Jackson",
                                Recommended = false
                            },
                    }.AsQueryable();
        }
    }
}