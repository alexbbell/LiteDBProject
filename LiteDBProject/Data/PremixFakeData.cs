namespace LiteDBProject.Data
{
    public class PremixFakeData : IPremixData
    {
        private List<Premix> _premixes { get; set; }

        public PremixFakeData()
        {
            List<Premix> premixes = new List<Premix>();
            premixes.Add(new Premix { Id = 1, title = "title 1", vid = "первый вид" });
            premixes.Add(new Premix { Id = 2, title = "title 2", vid = "второй вид" });
            premixes.Add(new Premix { Id = 3, title = "title 3", vid = "третий вид" });
            premixes.Add(new Premix { Id = 4, title = "title 4", vid = "четвертый вид" });

            _premixes = premixes;
        }

        public Premix GetItemById(int id)
        {
            return _premixes.Where(p => p.Id == id).FirstOrDefault();
        }
        public IEnumerable<Premix> GetAll()
        {
            return _premixes;
        }


    }
}
