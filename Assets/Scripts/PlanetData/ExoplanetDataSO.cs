using UnityEngine;

public class ExoplanetDataSO : ScriptableObject
{
    [SerializeField] string planetName;
    public string PlanetName { get => planetName; }
    [SerializeField] string systemName;
    public string SystemName { get => systemName; }
    [SerializeField] int nbStars;
    public int NbStars { get => nbStars; }
    [SerializeField] int nbPlanet;
    public int NbPlanet { get => nbPlanet; }
    [SerializeField] float planetRadius;
    public float PlanetRadius { get => planetRadius; }
    [SerializeField] float temperature;
    public float Temperature { get => temperature; }
    [SerializeField] float massInEarth;
    public float MassInEarth { get => massInEarth; }
    [SerializeField] float orbitDurationInDays;
    public float OrbitDurationInDays { get => orbitDurationInDays; }
    [SerializeField] float distanceFromEarth;
    public float DistanceFromEarth {  get => distanceFromEarth; }
    [SerializeField] DiscoveryMethodOptions discoveryMethod;
    public DiscoveryMethodOptions DiscoveryMethod { get => discoveryMethod;}
    [SerializeField] float transitDuration;
    public float TransitDuration { get => transitDuration; }
}