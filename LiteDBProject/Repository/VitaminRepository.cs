using LiteDBProject.Data;
using LiteDBProject.Data.SQLite;
using LiteDBProject.Interfaces;

namespace LiteDBProject.Repository
{
    public class VitaminRepository : IVitaminRepository
    {
        private PremixContext _context;

        public VitaminRepository(PremixContext context)
        {
            _context = context;
        }

        public bool CreateVitamin(Vitamin vitamin)
        {
            _context.Vitamins.Add(vitamin);
            return Save();
        }

        public bool DeleteVitamin(Vitamin vitamin)
        {
            _context.Vitamins.Remove(vitamin);
            return Save();
            
        }

        public Vitamin GetVitamin(int id)
        {
            return _context.Vitamins.FirstOrDefault(v => v.VitaminId == id);
        }

        public ICollection<Vitamin> GetVitamins()
        {
            return _context.Vitamins.ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateVitamin(Vitamin vitamin)
        {
            _context.Update(vitamin);
            return Save();
        }

        public bool VitaminExists(int id)
        {
            return _context.Vitamins.Any(v=>v.VitaminId == id);
        }
    }
}
