using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace LiteDBProject.Data
{
    [DataContract]
    public class Developer
    {
        [Key]
        [DataMember]
        public int DeveloperId { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Country { get; set; }

    }
}
