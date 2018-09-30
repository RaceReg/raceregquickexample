using System.Threading.Tasks;

namespace raceregquickexample.Model
{
    public interface IDataService
    {
        Task<DataItem> GetData();
    }
}