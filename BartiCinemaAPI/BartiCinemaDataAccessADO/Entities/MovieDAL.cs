using System;
using System.Collections.Generic;
using System.Text;

namespace BartiCinemaDataAccessADO.Entities
{
    public class MovieDAL
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public string Genres { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; }
        public string Certificate { get; set; }
        public double ImdbRating { get; set; }
        public int Runtime { get; set; }
        public string PosterLink { get; set; }
    }
}
