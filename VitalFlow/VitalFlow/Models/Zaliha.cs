using System.ComponentModel.DataAnnotations;

namespace VitalFlow.Models
{
    public class Zaliha
    {
        public KrvnaGrupa krvnaGrupa { get; set; }
        public int kolicina { get; set; }
        public int kriticnaLinija { get; set; }

        [Key]
        public int hubID { get; set; }

    }
}
