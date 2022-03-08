using System;
using System.Collections.Generic;
using System.Text;

namespace BartiCinemaDataAccessADO.Entities
{
    public class ScreeningDAL
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int RoomId { get; set; }
        public DateTime StartTime { get; set; }
    }
}
