using LiteDB;

namespace LiteDBProject.Data
{
    public interface IBaseRepository<T>
    {
        T Create(T data);
        IEnumerable<T> All();
        T FindById(int id);
        void Update(T entity);
        bool Delete(int id);
    }

    public abstract class BaseRepository<T> : IBaseRepository<T>
    {
        public ILiteDatabase DB { get; set; }
        public ILiteCollection<T> Collection { get; set; }

        protected BaseRepository(ILiteDatabase db)
        {
            DB = db;
            Collection = db.GetCollection<T>();
        }
        public IEnumerable<T> All()
        {
            return Collection.FindAll();
        }

        public T Create(T entity)
        {
            var newId = Collection.Insert(entity);
            return Collection.FindById(newId.AsInt32);
        }

        public bool Delete(int id)
        {
            return Collection.Delete(id);
        }

        public T FindById(int id)
        {
            return Collection.FindById(id);
        }

        public void Update(T entity)
        {
            Collection.Upsert(entity);
        }
    }
}
