
namespace LiteDBProject.Data
{
    public interface IPremixData
    {
        IEnumerable<Premix> GetAll();
        Premix GetItemById(int id);
    }
}