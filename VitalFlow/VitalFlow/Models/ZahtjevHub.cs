using System.ComponentModel.DataAnnotations;

namespace VitalFlow.Models
{
    public class ZahtjevHub
    {
        [Key]
        public int id { get; set; }
        public int zahtjevID { get; set; }
        public string email { get; set; }
    }
}
