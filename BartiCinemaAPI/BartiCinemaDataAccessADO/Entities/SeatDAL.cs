using System;
using System.Collections.Generic;
using System.Text;

namespace BartiCinemaDataAccessADO.Entities
{
    public class SeatDAL
    {
        public int Id { get; set; }
        public int Row { get; set; }
        public int Number { get; set; }
        public int RoomId { get; set; }
    }
}
