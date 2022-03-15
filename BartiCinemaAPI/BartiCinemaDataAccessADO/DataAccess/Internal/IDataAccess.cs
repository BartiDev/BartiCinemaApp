using System.Collections.Generic;

namespace BartiCinemaDataAccessADO.DataAccess
{
    internal interface IDataAccess
    {
        List<U> LoadData<U>(string connectionString, SqlMessage sqlMessage);
    }
}