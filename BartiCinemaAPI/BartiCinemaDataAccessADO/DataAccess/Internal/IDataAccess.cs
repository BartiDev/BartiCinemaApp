using System.Collections.Generic;
using System.Threading.Tasks;

namespace BartiCinemaDataAccessADO.DataAccess
{
    internal interface IDataAccess
    {
        Task<List<U>> LoadData<U>(string connectionString, SqlMessage sqlMessage);
    }
}