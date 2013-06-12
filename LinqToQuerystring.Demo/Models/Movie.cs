namespace LinqToQuerystring.Demo.Models
{
    using System;
    using System.Collections.Generic;

    public class Movie
    {
        public string Title { get; set; }

        public int DurationInMinutes { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string Director { get; set; }

        public int MetaScore { get; set; }

        public bool Recommended { get; set; }

        public List<string> Tags { get; set; }

        public List<double> UserScores { get; set; }
    }
}