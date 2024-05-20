using System.ComponentModel.DataAnnotations;

namespace VitalFlow.Models
{
    public class TerminHub
    {
        public string jmbg { get; set; }

        [Key]
        public int id { get; set; }
        public int terminID { get; set; }
    }
}
