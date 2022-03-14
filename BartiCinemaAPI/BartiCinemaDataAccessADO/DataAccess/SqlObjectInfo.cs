using System;
using System.Collections.Generic;
using System.Text;

namespace BartiCinemaDataAccessADO.DataAccess
{
    public class SqlObjectInfo
    {
        public string Schema { get; set; }
        public string ObjectName { get; set; }
        public string ObjectType { get; set; }
        public List<SqlObjectParameter> Parameters { get; set; }
    }
}
