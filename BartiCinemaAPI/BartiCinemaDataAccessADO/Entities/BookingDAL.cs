using System;
using System.Collections.Generic;
using System.Text;

namespace BartiCinemaDataAccessADO.Entities
{
    public class BookingDAL
    {
        public int Id { get; set; }
        public int ScreeningId { get; set; }
        public int CustomerId { get; set; }
    }
}
