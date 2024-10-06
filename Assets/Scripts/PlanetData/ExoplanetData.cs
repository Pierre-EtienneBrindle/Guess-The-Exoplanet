using System.Collections.Generic;

public class ExoplanetData
{
    public string PlanetName { get; private set; } = null;
    public string SystemName { get; private set; } = null;
    public int? NbStars { get; private set; } = null;
    public int? NbPlanet { get; private set; } = null;
    public int? NbMoon { get; private set; } = null;
    public float? RadiusInEarth { get; private set; } = null;
    public float? Temperature { get; private set; } = null;
    public float? MassInEarth { get; private set; } = null;
    public float? OrbitDurationInDays { get; private set; } = null;
    public float? DistanceFromEarth { get; private set; } = null;
    public float? TransitDuration { get; private set; } = null;

    public ExoplanetData(string name, Dictionary<string, string> keyValuePairs)
    {
        PlanetName = name;
        foreach (var keyValue in keyValuePairs)
        {
            switch (keyValue.Key)
            {
                case "hostname":
                    SystemName = keyValue.Value;
                    break;
                case "sy_snum":
                    NbStars = int.Parse(keyValue.Value);
                    break;
                case "sy_pnum":
                    NbPlanet = int.Parse(keyValue.Value);
                    break;
                case "sy_mnum":
                    NbMoon = int.Parse(keyValue.Value);
                    break;
                case "pl_orbper":
                    OrbitDurationInDays = MyFloatParser(keyValue.Value);
                    break;
                case "pl_rade":
                    RadiusInEarth = MyFloatParser(keyValue.Value);
                    break;
                case "pl_masse":
                    MassInEarth = MyFloatParser(keyValue.Value);
                    break;
                case "pl_eqt":
                    Temperature = MyFloatParser(keyValue.Value);
                    break;
                case "sy_dist":
                    DistanceFromEarth = MyFloatParser(keyValue.Value);
                    break;
                default:
                    break;
            }
        }
    }

    private static float MyFloatParser(string init)
    {
        float value = 0;
        int i = 0;
        int length = init.Length;

        while (i < length && init[i] != '.')
        {
            value *= 10;
            value += GetInt(init[i]);
            ++i;
        }
        ++i;
        float multiplier = 1 / 10f;
        while (i < length)
        {
            value += multiplier * GetInt(init[i]);
            ++i;
            multiplier /= 10;
        }
        return value;
    }

    private static int GetInt(char val)
    {
        switch (val)
        {
            case '1': return 1;
            case '2': return 2;
            case '3': return 3;
            case '4': return 4;
            case '5': return 5;
            case '6': return 6;
            case '7': return 7;
            case '8': return 8;
            case '9': return 9;
        }
        return 0;
    }
}