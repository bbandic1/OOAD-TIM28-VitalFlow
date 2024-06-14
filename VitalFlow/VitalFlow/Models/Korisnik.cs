using System.ComponentModel.DataAnnotations;

namespace VitalFlow.Models
{
    public class Korisnik
    {
        public string imeIPrezime {  get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string brojTelefona { get; set; }
        public DateOnly datumRođenja { get; set; }
        public string jmbg {  get; set; }
        public KrvnaGrupa krvnaGrupa {  get; set; }
        public int brojOtkazivanja { get; set; }

        [Key]
        public int id {  get; set; }
        public int? zahtjevID {  get; set; }

        public string identityID { get; set; }

        public Korisnik() { }
    }
}
