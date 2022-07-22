using LiteDBProject.Data;

namespace LiteDBProject.Interfaces
{
    public interface IPremixRepository
    {
        ICollection<Premix> GetPremixes();
        PremixDto GetPremix(int id);
        bool PremixExists(int id);
        bool CreatePremix(List<int> vitamins, Premix premix);
        bool UpdatePremix(Premix premix);
        bool DeletePremix(Premix premix);
        bool Save();

    }
}
