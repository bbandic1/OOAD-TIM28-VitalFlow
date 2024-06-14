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

        public static string GetDisplayNameVrijeme(this Vrijeme value)
        {
            switch(value)
            {
                case Vrijeme._07_00:
                    return "7:00";
                case Vrijeme._07_30:
                    return "7:30";
                case Vrijeme._08_00:
                    return "8:00";
                case Vrijeme._08_30:
                    return "8:30";
                case Vrijeme._09_00:
                    return "9:00";
                case Vrijeme._09_30:
                    return "9:30";
                case Vrijeme._10_00:
                    return "10:00";
                case Vrijeme._10_30:
                    return "10:30";
                case Vrijeme._11_00:
                    return "11:00";
                case Vrijeme._11_30:
                    return "11:30";
                case Vrijeme._12_00:
                    return "12:00";
                case Vrijeme._12_30:
                    return "12:30";
                case Vrijeme._13_00:
                    return "13:00";
                case Vrijeme._13_30:
                    return "13:30";
                case Vrijeme._14_00:
                    return "14:00";
                case Vrijeme._14_30:
                    return "14:30";
                case Vrijeme._15_00:
                    return "15:00";
                case Vrijeme._15_30:
                    return "15:30";
                case Vrijeme._16_00:
                    return "16:00";
                case Vrijeme._16_30:
                    return "16:30";
                case Vrijeme._17_00:
                    return "17:00";
                case Vrijeme._17_30:
                    return "17:30";
                case Vrijeme._18_00:
                    return "18:00";
                case Vrijeme._18_30:
                    return "18:30";
                case Vrijeme._19_00:
                    return "19:00";
                case Vrijeme._19_30:
                    return "19:30";
                case Vrijeme._20_00:
                    return "20:00";
                case Vrijeme._20_30:
                    return "20:30";
                default:
                    return value.ToString();
            }
        }
    }
}