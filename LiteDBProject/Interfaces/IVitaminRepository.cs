using LiteDBProject.Data;
using LiteDBProject.Data.Models;

namespace LiteDBProject.Interfaces
{
    public interface IVitaminRepository
    {
        ICollection<Vitamin> GetVitamins();
        Vitamin GetVitamin(int id);
        bool VitaminExists(int id);
        bool CreateVitamin(Vitamin vitamin);
        bool UpdateVitamin(Vitamin vitamin);
        bool DeleteVitamin(Vitamin vitamin);
        bool Save();
    }
}
