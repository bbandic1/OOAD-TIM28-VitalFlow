namespace VitalFlow.Models
{
    public static class EnumExtensions
    {
        public static string GetDisplayName(this KrvnaGrupa value)
        {
            switch (value)
            {
                case KrvnaGrupa.A_Pozitivna:
                    return "A+";
                case KrvnaGrupa.A_Negativna:
                    return "A-";
                case KrvnaGrupa.B_Pozitivna:
                    return "B+";
                case KrvnaGrupa.B_Negativna:
                    return "B-";
                case KrvnaGrupa.O_Pozitivna:
                    return "O+";
                case KrvnaGrupa.O_Negativna:
                    return "O-";
                case KrvnaGrupa.AB_Pozitivna:
                    return "AB+";
                case KrvnaGrupa.AB_Negativna:
                    return "AB-";
                default:
                    return value.ToString();
            }
        }
    }
}