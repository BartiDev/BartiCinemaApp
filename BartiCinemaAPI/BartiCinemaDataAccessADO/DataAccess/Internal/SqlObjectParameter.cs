using System;
using System.Collections.Generic;
using System.Text;

namespace BartiCinemaDataAccessADO.DataAccess
{
    internal class SqlObjectParameter
    {
        public int ParameterId { get; set; }
        public string ParameterName { get; set; }
        public string ParameterDataType { get; set; }
        public int ParameterMaxBytes { get; set; }
        public bool IsOutputParameter { get; set; }
    }
}
