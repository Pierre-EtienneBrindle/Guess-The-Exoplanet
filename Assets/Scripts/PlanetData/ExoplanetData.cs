public class ExoplanetData
{
    public string PlanetName { get; private set; }
    public string SystemName { get; private set; }
    public int NbStars { get; private set; }
    public int NbPlanet { get; private set; }
    public float PlanetRadius { get; private set; }
    public float Temperature { get; private set; }
    public float MassInEarth { get; private set; }
    public float OrbitDurationInDays { get; private set; }
    public float DistanceFromEarth { get; private set; }
    public DiscoveryMethodOptions DiscoveryMethod { get; private set; }
    public float TransitDuration { get; private set; }
}