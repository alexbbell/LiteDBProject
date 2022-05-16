namespace LiteDBProject.Data.LiteDB
{

    public class LiteDbConfig 
    {
        public string DataBasePath { get; set; }

        public LiteDbConfig()
        {
            
          DataBasePath = @"Filename=C:\\temp\\mydata.db;connection=shared";
        }

    }
}
