using System;
using System.Collections.Generic;
using System.Text;

namespace BartiCinemaDataAccessADO.Entities
{
    public class RoomDAL
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CinemaId { get; set; }
        public int SeatsQty { get; set; }
    }
}
