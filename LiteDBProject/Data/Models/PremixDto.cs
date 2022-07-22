using LiteDB;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace LiteDBProject.Data
{


    [DataContract]
    public class VitaminDto //: VitaminPost
    {

        public int vitaminId { get; set; }
        //public int vitaminId { get; set; }
        [DataMember]
        public string title { get; set; }
        [DataMember]
        public string rastvor { get; set; }        
    }

    [DataContract]
    public class DeveloperDto
    {

        public string developerId { get; set; }
        public string name { get; set; }
        public string country { get; set; }

    }

    [DataContract]
    public class PremixDto
    { 
        [DataMember]
        public int PremixId { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Vid { get; set; }
        [DataMember]
        public string? Age { get; set; }
        [DataMember]
        public string? Tu { get; set; }
        [DataMember]
        public int DeveloperId { get; set; }
        [DataMember]
        public string DeveloperName { get; set; }
        [DataMember]
        public List<string> Vitamins { get; set; }

        //[BsonRef("Vitamin")]
        


    }







}
