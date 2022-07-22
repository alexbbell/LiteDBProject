using LiteDBProject.Data;
using LiteDBProject.Data.Models;
using LiteDBProject.Data.SQLite;
using LiteDBProject.Interfaces;

namespace LiteDBProject.Repository
{
    public class PremixRepository : IPremixRepository
    {

        private PremixContext _context;

        public PremixRepository(PremixContext context)
        {
            _context = context;
        }
        public bool CreatePremix(List<int> vitamins, Premix premix)
        {
            //var vitaminsInPremix = _context.Vitamins.Where(v=>v.VitaminId.Equals(premix.PremixVitamins)).ToList();


            //var premixVitamin = new PremixVitamin()
            //{
            //    Premix = premix,
            //    Vitamin = vitaminsInPremix.FirstOrDefault()
            //};

            _context.Add(premix);
            _context.SaveChanges();

            ICollection<PremixVitamin> premixVitamins = new List<PremixVitamin>();
            foreach(var vitamin in vitamins) 
            {
                premixVitamins.Add(new PremixVitamin { PremixId = premix.PremixId, VitaminId = vitamin });
            }


            _context.AddRange(premixVitamins);
            _context.SaveChanges();


            return Save();
        }

        public bool DeletePremix(Premix premix)
        {
            _context.Premixes.Remove(premix);
            return Save();
        }

        public PremixDto GetPremix(int id)
        {
            

            var premix_forForm = _context.Premixes.Where(p => p.PremixId == id).Select(premix => new PremixDto()
            {
                PremixId = premix.PremixId,
                DeveloperId = premix.DeveloperId,
                DeveloperName = premix.Developer.Name,
                Age = premix.Age,
                Title = premix.Title,
                Vid = premix.Vid,
                Tu = premix.Tu
                ,                Vitamins = premix.PremixVitamins.Select(pv => pv.Vitamin.Title).ToList()
                //Where(pv => pv.PremixId == id).
            }).FirstOrDefault();
            return premix_forForm;
            //return _context.Premixes.Where(p=>p.PremixId == id).FirstOrDefault();
        }

        public ICollection<Premix> GetPremixes()
        {
            return _context.Premixes.ToList();
        }

        public bool PremixExists(int id)
        {
            var premix = _context.Premixes.Any(p=>p.PremixId==id);
            return premix;
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdatePremix(Premix premix)
        {
            throw new NotImplementedException();
        }
    }
}
