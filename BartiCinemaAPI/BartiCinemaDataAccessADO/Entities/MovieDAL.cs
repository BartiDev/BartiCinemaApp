using System;
using System.Collections.Generic;
using System.Text;

namespace BartiCinemaDataAccessADO.Entities
{
    public class MovieDAL
    {
        public MovieDAL() {}
        public MovieDAL(int id, string title, string director, string genres, DateTime releaseDate
            , string description, string certificate, decimal imdbRating, int runtime, string posterLink)
        {
            Id = id;
            Title = title;
            Director = director;
            Genres = genres;
            ReleaseDate = releaseDate;
            Description = description;
            Certificate = certificate;
            ImdbRating = imdbRating;
            Runtime = runtime;
            PosterLink = posterLink;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public string Genres { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; }
        public string Certificate { get; set; }
        public decimal ImdbRating { get; set; }
        public int Runtime { get; set; }
        public string PosterLink { get; set; }
    }
}
