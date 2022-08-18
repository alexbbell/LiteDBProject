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
        public bool CreatePremix( Premix premix)
        {
            //var vitaminsInPremix = _context.Vitamins.Where(v=>v.VitaminId.Equals(premix.PremixVitamins)).ToList();


            //var premixVitamin = new PremixVitamin()
            //{
            //    Premix = premix,
            //    Vitamin = vitaminsInPremix.FirstOrDefault()
            //};

            _context.Add(premix);
            //_context.SaveChanges();

            //ICollection<PremixVitamin> premixVitamins = new List<PremixVitamin>();
            //if (premix.PremixVitamins != null)
            //{
            //    foreach (var vitamin in premix.PremixVitamins)
            //    {
            //        premixVitamins.Add(new PremixVitamin { PremixId = premix.PremixId, VitaminId = vitamin.VitaminId });
            //    }
            //    _context.AddRange(premixVitamins);
            //    _context.SaveChanges();

            //}



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
                //,                Vitamins = premix.PremixVitamins.Select(pv => pv.Vitamin.Title).ToList()
                ,
                Vitamins = premix.PremixVitamins.Select(
                    pv => new VitaminJS
                    {
                         VitaminId = pv.VitaminId,
                         VitaminTitle =pv.Vitamin.Title
                    }                    
                ).ToList()
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

        public bool UpdatePremix(int premixId, Premix updatePremix)
        {
            var _premix = _context.Premixes.FirstOrDefault(p => p.PremixId == premixId);
            if(_premix != null)
            {
                _premix.Title = updatePremix.Title;
                _premix.Age = updatePremix.Age;
                _premix.Tu = updatePremix.Tu;
                _premix.Vid = updatePremix.Vid;
                _premix.DeveloperId = updatePremix.DeveloperId;
                _premix.PremixVitamins = updatePremix.PremixVitamins;
            }
             _context.Update(_premix);
            return Save();
            //throw new NotImplementedException();
        }
    }
}
