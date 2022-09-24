
using System.Threading.Tasks;
using SQLite1.DTO;

namespace SQLite1.Interface
{
    public interface IRestService
    {
        Task<int> SaveRegistro(DTORegistrado item, bool isNewItem);
    }
}
