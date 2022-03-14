using System;
using System.Collections.Generic;
using System.Text;

namespace BartiCinemaDataAccessADO.DataAccess
{
    public class SqlMessage
    {
        public string SqlBody { get; set; }
        public SqlMessageType Type { get; set; }
        public SqlMessageParameter[] Parameters { get; set; }
    }

    public enum SqlMessageType
    {
        Query,
        UserDefinedFunction,
        UserDefinedStoredProcedure
    }
}
