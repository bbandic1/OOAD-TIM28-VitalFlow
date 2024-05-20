using System.ComponentModel.DataAnnotations;

namespace VitalFlow.Models
{
    public class HUB
    {
        public int terminID { get; set; }
        public int zahtjevID { get; set; }

        [Key]
        public int hubID { get; set; }
        public HUB() { }
    }
}
