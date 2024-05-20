namespace VitalFlow.Models
{
    public class Termin
    {
        public int TerminID { get; set; }
        public DateOnly datum {  get; set; }
        public Sale sala { get; set; }
        public string jmbg { get; set; }
        public int kapacitet { get; set; }

    }
}
