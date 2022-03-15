using System;
using System.Collections.Generic;
using System.Text;

namespace BartiCinemaDataAccessADO.DataAccess
{
    internal class SqlMessage
    {
        public string SqlBody { get; set; }
        public SqlMessageType Type { get; set; }
        public SqlMessageParameter[] Parameters { get; set; }
    }

    internal enum SqlMessageType
    {
        Query,
        UserDefinedFunction,
        UserDefinedStoredProcedure
    }
}
