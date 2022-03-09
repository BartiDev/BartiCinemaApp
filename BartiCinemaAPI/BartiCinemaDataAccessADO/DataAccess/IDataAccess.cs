using System.Collections.Generic;

namespace BartiCinemaDataAccessADO.DataAccess
{
    public interface IDataAccess
    {
        List<U> LoadData<U>(string connectionString, string functionName);
    }
}