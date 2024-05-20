using System.ComponentModel.DataAnnotations;

namespace VitalFlow.Models
{
    public class Termin
    {
        [Key]
        public int terminID { get; set; }
        public DateOnly datum {  get; set; }
        public Sale sala { get; set; }
        public string jmbg { get; set; }
        public int kapacitet { get; set; }

    }
}
