using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VitalFlow.Models
{
    public class Zaliha
    {
        [Required]
        [Key]
        [Column(TypeName = "varchar(3)")]
        public KrvnaGrupa krvnaGrupa { get; set; }
        public int kolicina { get; set; }
        public int kriticnaLiinija { get; set; }

        [ForeignKey("HUB")]
        public int hubID { get; set; }

    }
}
