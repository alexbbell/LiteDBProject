using System.ComponentModel.DataAnnotations;

namespace LiteDBProject.Data.Models
{
    public class PremixVitamin
    {
        [Key]
        public int Id { get; set; }
        public int PremixId { get; set; }
        public Premix Premix { get; set; }

        public int VitaminId { get; set; }
        public Vitamin Vitamin { get; set; }
    }
}
