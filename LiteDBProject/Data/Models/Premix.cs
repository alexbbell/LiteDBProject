using LiteDB;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace LiteDBProject.Data
{
    [DataContract]
    public class Premix
    {
        [DataMember]
        [BsonField("_id")]
        public int Id { get; set; }
        [BsonField("Name")]
        [DataMember]
        public string title { get; set; }
      
        public string vid { get; set; }
        [JsonIgnore]
        public string age { get; set; }
        [JsonIgnore] 
        public string tu { get; set; }
        [JsonIgnore]
        public string developer { get; set; }

        [BsonRef("Vitamin")]
        public List<Vitamin> vitamins { get; set; }

        public Premix () { 
            BsonMapper.Global.Entity<Premix>().DbRef(x=>x.vitamins, "Vitamin");
        }

    }
    [DataContract]
    public class Vitamin
    {
        [BsonField("_id")]
        public int Id { get; set; }
        [JsonIgnore]
        public string title { get; set; }
        [JsonIgnore]
        public string rastvor { get; set; }

    }


}
