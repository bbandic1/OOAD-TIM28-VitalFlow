using System.ComponentModel.DataAnnotations;

namespace VitalFlow.Models
{
    public class Zahtjev
    {
        [Key]
        public int zahtjevID { get; set; }
        public int kolicina { get; set; }
        public string email { get; set; }
        public string opis { get; set; }
        public KrvnaGrupa krvnaGrupa { get; set; }
    }
}
