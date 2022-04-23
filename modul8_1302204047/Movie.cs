using System;
using System.Collections.Generic;

namespace modul8_1302204047
{
    public class Movie
    {
        public string Title { get; set; }
        public string Director { get; set; }

        public List<string> Stars { get; set; }

        public string Description { get; set; }

        public Movie(string title, string director, List<string> starts, string description)
        {
            this.Title = title;
            this.Director = director;
            this.Stars = starts;
            this.Description = description;
        }

    }
}