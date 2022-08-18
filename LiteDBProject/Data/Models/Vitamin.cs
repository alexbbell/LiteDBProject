using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace LiteDBProject.Data.Models
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

    public class VitaminJS
    {
        [DataMember]
        public int VitaminId { get; set; }
        [DataMember]

        public string? VitaminTitle { get; set; }
    }

    public class VitaminDto
    {
        [DataMember]
        public int VitaminId { get; set; }
        [DataMember]
        public string VitaminTitle { get; set; }
        [DataMember]
        public string Rastvor { get; set; }

    }
}
