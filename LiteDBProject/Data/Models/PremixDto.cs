using LiteDB;
using LiteDBProject.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace LiteDBProject.Data
{



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
        public List<VitaminJS> Vitamins { get; set; }

        //[BsonRef("Vitamin")]
        


    }







}
