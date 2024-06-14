using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VitalFlow.Models
{
    public class Termin
    {
        [Key]
        public int terminID { get; set; }

        public DateOnly datum { get; set; }
        public Sale sala { get; set; }
        public int kapacitet { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public Vrijeme vrijeme { get; set; }

        public string donorID {  get; set; }
        
        public string email { get; set; }

        public string jmbg { get; set; }

    }
}
