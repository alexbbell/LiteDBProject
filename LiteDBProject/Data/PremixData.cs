using LiteDB;
using LiteDBProject.Data.LiteDB;

namespace LiteDBProject.Data
{
    public class PremixData : IPremixData
    {
        private List<Premix> _premixes { get; set; }
        LiteDatabase _litedb;  
        LiteDbConfig _dbContext;


        public PremixData()
        {
            _premixes = new List<Premix>();
            //LiteDbContext dbContext = new LiteDbContext();
        }

        IEnumerable<Premix> IPremixData.GetAll()
        {
            return _litedb.GetCollection<Premix>("premixes").FindAll();
        }

        Premix IPremixData.GetItemById(int id)
        {
            Premix premix = _litedb.GetCollection<Premix>("premixes").FindById(id);

            return premix;
        }



    }
}
