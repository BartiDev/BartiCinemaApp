using BartiCinemaDataAccessADO.Entities;
using System.Threading.Tasks;

namespace BartiCinemaDataAccessADO.DataAccess
{
    public interface ICinemaData
    {
        Task<CinemaDAL> GetCinema();
    }
}