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
            string key = keyValue.Key.Trim();
            string value = keyValue.Value.Trim();
            switch (key)
            {
                case "hostname":
                    SystemName = value;
                    break;
                case "sy_snum":
                    NbStars = int.Parse(value);
                    break;
                case "sy_pnum":
                    NbPlanet = int.Parse(value);
                    break;
                case "sy_mnum":
                    NbMoon = int.Parse(value);
                    break;
                case "pl_orbper":
                    OrbitDurationInDays = MyFloatParser(value);
                    break;
                case "pl_rade":
                    RadiusInEarth = MyFloatParser(value);
                    break;
                case "pl_masse":
                    MassInEarth = MyFloatParser(value);
                    break;
                case "pl_eqt":
                    Temperature = MyFloatParser(value);
                    break;
                case "sy_dist":
                    DistanceFromEarth = MyFloatParser(value);
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


    public static bool operator==(ExoplanetData left, ExoplanetData right)
    {
        return left.PlanetName == right.PlanetName &&
               left.SystemName == right.SystemName &&
               left.NbStars == right.NbStars &&
               left.NbMoon == right.NbMoon &&
               left.RadiusInEarth == right.RadiusInEarth &&
               left.Temperature == right.Temperature &&
               left.MassInEarth == right.MassInEarth &&
               left.OrbitDurationInDays == right.OrbitDurationInDays &&
               left.DistanceFromEarth == right.DistanceFromEarth &&
               left.TransitDuration == right.TransitDuration;
    }
    public static bool operator!=(ExoplanetData left, ExoplanetData right)
    {
        return !(left == right);
    }

    public override bool Equals(object obj)
    {
        if (obj is ExoplanetData) {
            return this == (ExoplanetData)obj;
        }
        throw new System.ArgumentException("obj isn't an ExoplanetData");
    }

    public override int GetHashCode()
    {
        return PlanetName.GetHashCode() ^
        SystemName.GetHashCode() ^
        NbStars.GetHashCode() ^
        NbMoon.GetHashCode() ^
        RadiusInEarth.GetHashCode() ^
        Temperature.GetHashCode() ^
        MassInEarth.GetHashCode() ^
        OrbitDurationInDays.GetHashCode() ^
        DistanceFromEarth.GetHashCode() ^
        TransitDuration.GetHashCode();
    }
}