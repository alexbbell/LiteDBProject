using LiteDB;
using LiteDBProject.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace LiteDBProject.Data
{


    [DataContract]
    public class Vitamin //: VitaminPost
    {
        [Key]
        [DataMember]
        public int VitaminId { get; set; }
        //public int vitaminId { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Rastvor { get; set; }
        //Navigation properties
        [DataMember]
        public ICollection<PremixVitamin> PremixVitamins { get; set; }
    }



    [DataContract]
    public class Premix
    { 
        [DataMember]
        //[BsonField("_id")]
        [Key]
        public int PremixId { get; set; }
        [BsonField("Name")]
        [DataMember]
        [Required]
        public string Title { get; set; }
        [Required]
        [DataMember]
        public string Vid { get; set; }
        [DataMember]
        public string Age { get; set; }
        [DataMember]
        public string Tu { get; set; }
        [DataMember]
        public int DeveloperId { get; set; }
        public Developer? Developer { get; set; }

        //Navigations Properties
        public ICollection<PremixVitamin> PremixVitamins { get; set; }

    }


  




}
