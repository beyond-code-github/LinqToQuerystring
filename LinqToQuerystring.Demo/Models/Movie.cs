namespace LinqToQuerystring.Demo.Models
{
    using System;

    public class Movie
    {
        public string Title { get; set; }

        public int DurationInMinutes { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string Director { get; set; }

        public int MetaScore { get; set; }

        public bool Recommended { get; set; }
    }
}