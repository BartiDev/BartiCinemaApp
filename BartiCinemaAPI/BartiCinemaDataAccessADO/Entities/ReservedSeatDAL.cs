using System;
using System.Collections.Generic;
using System.Text;

namespace BartiCinemaDataAccessADO.Entities
{
    public class ReservedSeatDAL
    {
        public int Id { get; set; }
        public int BookingId { get; set; }
        public int SeatId { get; set; }
    }
}
