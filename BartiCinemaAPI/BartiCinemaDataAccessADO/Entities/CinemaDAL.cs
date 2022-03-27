using System;
using System.Collections.Generic;
using System.Text;

namespace BartiCinemaDataAccessADO.Entities
{
    public class CinemaDAL
    {
        public CinemaDAL(int id, string name, string city)
        {
            Id = id;
            Name = name;
            City = city;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
    }
}
