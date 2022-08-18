using LiteDBProject.Data;

namespace LiteDBProject.Interfaces
{
    public interface IPremixRepository
    {
        ICollection<Premix> GetPremixes();
        PremixDto GetPremix(int id);
        bool PremixExists(int id);
        bool CreatePremix( Premix premix);
        bool UpdatePremix(int premixId, Premix premix);
        bool DeletePremix(Premix premix);
        bool Save();

    }
}
