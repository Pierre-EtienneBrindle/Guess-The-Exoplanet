using System.Collections.Generic;

public class ExoplanetData
{
    public string PlanetName { get; private set; } = null;
    public string SystemName { get; private set; } = null;
    public int? NbStars { get; private set; } = null;
    public int? NbPlanet { get; private set; } = null;
    public int? NbMoon { get; private set; } = null;
    public float? RadiusInEarth { get; private set; } = null;
    public float? Temperature { get; private set; } = null ;
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
                    OrbitDurationInDays = float.Parse(keyValue.Value);
                    break;
                case "pl_rade":
                    RadiusInEarth = float.Parse(keyValue.Value);
                    break;
                case "pl_masse":
                    MassInEarth = float.Parse(keyValue.Value);
                    break;
                case "pl_eqt":
                    Temperature = float.Parse(keyValue.Value);
                    break;
                case "sy_dist":
                    DistanceFromEarth = float.Parse(keyValue.Value);
                    break;
                default:
                    break;
            }
        }
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
