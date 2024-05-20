namespace VitalFlow.Models
{
    public class Korisnik
    {
        public string imeIPrezime {  get; set; }
        public string Email { get; set; }
        public string password { get; set; }
        public string brojTelefona { get; set; }
        public string datumRođenja { get; set; }
        public string jmbg {  get; set; }
        public string krvnaGrupa {  get; set; }
        public int brojOtkazivanja { get; set; }
        public int ID {  get; set; }
        public int Zahtjev {  get; set; }

        public Korisnik() { }
    }
}
