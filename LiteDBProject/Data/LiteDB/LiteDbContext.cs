using LiteDB;
using Microsoft.Extensions.Options;
using System;

namespace LiteDBProject.Data.LiteDB
{


    //public class LiteDbContext : IDbContext
    //{
    //    public readonly LiteDatabase _context;
    //    public LiteDbContext(IOptions<LiteDbConfig> configs)
    //    {
    //        try
    //        {
    //            var db = new LiteDatabase(configs.Value.DataBasePath);
    //            if(db != null) _context = db;
    //        }
    //        catch (Exception ex)
    //        {
    //            throw new Exception("Cant find or create LiteDb. ", ex);
    //        }
    //    }



    //    public int getLastPremixId(string table)
    //    {
    //        int id = -1;
    //        var col = _context.GetCollection<Premix>("premixes").FindOne(Query.All(Query.Descending));
    //        if(col != null) id = col.Id;

    //        return id;
    //    }
    //    public Boolean AddPremixWithVit()
    //    {
    //        Boolean result = false;
    //        //List<Vitamin> vits = new List<Vitamin>();

    //        //Vitamin v1 = new Vitamin { Id = 1, title = "A" } ;
    //        //Vitamin v6 = new Vitamin { Id = 6, title = "йод" };
    //        //vits.Add(v1);
    //        //vits.Add(v6);

    //        //List<Premix> premixes = new List<Premix>();
    //        //Premix p1 =  new Premix { Id = 12, title = "title 1", vid = "первый вид", vitamins = vits };

    //        //premixes.Add(new Premix { Id = 1, title = "title 1", vid = "первый вид", vitamins = vits });
    //        var col = _context.GetCollection<Premix>("premixes");
    //        //col.Insert(p1);
    //        //col.Update(p1);


    //        return result;
    //    }
    //    public Boolean AddVitamin()
    //    {
    //        Boolean result = false;
    //        //Vitamin v1 = new Vitamin { title = "A" } ;
    //        //Vitamin v2 = new Vitamin { title = "D3" };
    //        //Vitamin v3 = new Vitamin { title = "B6" };
    //        //Vitamin v4 = new Vitamin { title = "инулин" };
    //        //Vitamin v5 = new Vitamin { title = "кальций" };
    //        //Vitamin v6 = new Vitamin { title = "йод" };
    //        //var col = _context.GetCollection<Vitamin>();
    //        //col.Insert(v1);
    //        //col.Insert(v2);
    //        //col.Insert(v3);
    //        //col.Insert(v4);
    //        //col.Insert(v5);
    //        //col.Insert(v6);
    //        //col.Update(v1);
    //        //col.Update(v2);
    //        //col.Update(v3);
    //        //col.Update(v4);
    //        //col.Update(v5);
    //        //col.Update(v6);

    //        return result;
    //    }


        

    //    public IEnumerable<Premix> GetPremix()
    //    {
    //        List<Premix> premixes = new List<Premix>();
    //        var col = _context.GetCollection<Premix>("premixes");
    //        premixes = col.Query().OrderBy(x => x.title).ToList();

    //        string s = "avvbabb";
    //        char[] vs = s.ToArray();

    //        List<string> ss = new List<string>();
    //        foreach(Char c in vs)
    //        {

    //        }

    //        return premixes;
    //    }

    //    public Premix GetPremix(int id )
    //    {
    //        Premix premix = new Premix();
    //        //premix = _context.GetCollection<Premix>("premixes").Find(x => x.Id == id).FirstOrDefault(x => x.Id == id);            
    //        premix = _context.GetCollection<Premix>("premixes")
    //                .Include(x => x.vitamins)
    //            .FindOne(Query.EQ("_id", id)); //.FirstOrDefault(x => x.Id == id);            
            
    //        return premix;
    //    }


    //    public Boolean PostPremix(Premix premix)
    //    {
    //        //int lastCurrentId = getLastPremixId("premix");
            
    //        Boolean isAdded = false;
    //        try
    //        {
    //            var col = _context.GetCollection<Premix>("premixes");
    //            int lastId = col.FindOne(Query.All(Query.Descending)).Id;
    //            premix.Id = lastId + 1;
    //            col.Insert(premix);
    //            isAdded = true;
    //        }
    //        catch (Exception ex)
    //        {
    //            isAdded = false;
    //            //Response.WriteAsync("Ошибка" + ex.Message.ToString());
    //        }
    //        return isAdded;
    //    }


    //    public Boolean PostDeveloper(Developer developer)
    //    {
    //        Boolean isAdded = false;
    //        try
    //        {
    //            var col = _context.GetCollection<Developer>();
    //            col.Insert(developer);
    //            col.Update(developer);


    //        }
    //        catch  (Exception ex)
    //        {
    //            isAdded = false; 
    //        }
            
            
    //        //col.Insert(v1);

    //        return isAdded;
    //    }


    //}    //public class LiteDbContext : IDbContext
    //{
    //    public readonly LiteDatabase _context;
    //    public LiteDbContext(IOptions<LiteDbConfig> configs)
    //    {
    //        try
    //        {
    //            var db = new LiteDatabase(configs.Value.DataBasePath);
    //            if(db != null) _context = db;
    //        }
    //        catch (Exception ex)
    //        {
    //            throw new Exception("Cant find or create LiteDb. ", ex);
    //        }
    //    }



    //    public int getLastPremixId(string table)
    //    {
    //        int id = -1;
    //        var col = _context.GetCollection<Premix>("premixes").FindOne(Query.All(Query.Descending));
    //        if(col != null) id = col.Id;

    //        return id;
    //    }
    //    public Boolean AddPremixWithVit()
    //    {
    //        Boolean result = false;
    //        //List<Vitamin> vits = new List<Vitamin>();

    //        //Vitamin v1 = new Vitamin { Id = 1, title = "A" } ;
    //        //Vitamin v6 = new Vitamin { Id = 6, title = "йод" };
    //        //vits.Add(v1);
    //        //vits.Add(v6);

    //        //List<Premix> premixes = new List<Premix>();
    //        //Premix p1 =  new Premix { Id = 12, title = "title 1", vid = "первый вид", vitamins = vits };

    //        //premixes.Add(new Premix { Id = 1, title = "title 1", vid = "первый вид", vitamins = vits });
    //        var col = _context.GetCollection<Premix>("premixes");
    //        //col.Insert(p1);
    //        //col.Update(p1);


    //        return result;
    //    }
    //    public Boolean AddVitamin()
    //    {
    //        Boolean result = false;
    //        //Vitamin v1 = new Vitamin { title = "A" } ;
    //        //Vitamin v2 = new Vitamin { title = "D3" };
    //        //Vitamin v3 = new Vitamin { title = "B6" };
    //        //Vitamin v4 = new Vitamin { title = "инулин" };
    //        //Vitamin v5 = new Vitamin { title = "кальций" };
    //        //Vitamin v6 = new Vitamin { title = "йод" };
    //        //var col = _context.GetCollection<Vitamin>();
    //        //col.Insert(v1);
    //        //col.Insert(v2);
    //        //col.Insert(v3);
    //        //col.Insert(v4);
    //        //col.Insert(v5);
    //        //col.Insert(v6);
    //        //col.Update(v1);
    //        //col.Update(v2);
    //        //col.Update(v3);
    //        //col.Update(v4);
    //        //col.Update(v5);
    //        //col.Update(v6);

    //        return result;
    //    }


        

    //    public IEnumerable<Premix> GetPremix()
    //    {
    //        List<Premix> premixes = new List<Premix>();
    //        var col = _context.GetCollection<Premix>("premixes");
    //        premixes = col.Query().OrderBy(x => x.title).ToList();

    //        string s = "avvbabb";
    //        char[] vs = s.ToArray();

    //        List<string> ss = new List<string>();
    //        foreach(Char c in vs)
    //        {

    //        }

    //        return premixes;
    //    }

    //    public Premix GetPremix(int id )
    //    {
    //        Premix premix = new Premix();
    //        //premix = _context.GetCollection<Premix>("premixes").Find(x => x.Id == id).FirstOrDefault(x => x.Id == id);            
    //        premix = _context.GetCollection<Premix>("premixes")
    //                .Include(x => x.vitamins)
    //            .FindOne(Query.EQ("_id", id)); //.FirstOrDefault(x => x.Id == id);            
            
    //        return premix;
    //    }


    //    public Boolean PostPremix(Premix premix)
    //    {
    //        //int lastCurrentId = getLastPremixId("premix");
            
    //        Boolean isAdded = false;
    //        try
    //        {
    //            var col = _context.GetCollection<Premix>("premixes");
    //            int lastId = col.FindOne(Query.All(Query.Descending)).Id;
    //            premix.Id = lastId + 1;
    //            col.Insert(premix);
    //            isAdded = true;
    //        }
    //        catch (Exception ex)
    //        {
    //            isAdded = false;
    //            //Response.WriteAsync("Ошибка" + ex.Message.ToString());
    //        }
    //        return isAdded;
    //    }


    //    public Boolean PostDeveloper(Developer developer)
    //    {
    //        Boolean isAdded = false;
    //        try
    //        {
    //            var col = _context.GetCollection<Developer>();
    //            col.Insert(developer);
    //            col.Update(developer);


    //        }
    //        catch  (Exception ex)
    //        {
    //            isAdded = false; 
    //        }
            
            
    //        //col.Insert(v1);

    //        return isAdded;
    //    }


    //}
}
