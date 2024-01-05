public class Weather
{
    // switch statement
    public static String Kind(Double temperature)
    {
        switch (temperature)
        {
            case < 5:
                return "COLD";
            case < 20:
                return "MEDIUM";
            case 20:
                return "SPECIAL20";
            default:
                return "HOT";
        }
    }

    public static String Kind2(Double temperature)
    {
        String res = "HOT";
        switch (temperature)
        {
            case < 5:
                res = "COLD";
                break;
            case < 19:
                res = "MEDIUM";
                break;
            case 19:
            case 20:
                res = "SPECIAL19_20";
                break;
        }
        return res;
    }

    // switch expression
    public static String Kind3(Double temperature)
    {
        String res = temperature switch
        {
            < 5 => "COLD",
            < 20 => "MEDIUM",
            20 =>  "SPECIAL20",
            _ => "HOT",
        };
        return res;
    }

    public static String Kind4(Double temperature) => temperature switch
    {
        < 5 => "COLD",
        < 20 => "MEDIUM",
        20 => "SPECIAL20",
        _ => "HOT",
    };
}

