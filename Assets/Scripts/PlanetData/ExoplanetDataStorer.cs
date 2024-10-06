using System.Collections.Generic;
using UnityEngine;
using SingletonBehavior;

public class ExoplanetDataStorer : SingletonMonobehavior<ExoplanetDataStorer>
{
    [SerializeField] string planetSystemFn;
    [SerializeField] string[] otherFn;
    const string PATH_PREFIX = "Assets/Scripts/PlanetData/Data/";
    public List <ExoplanetData> Planets { get; private set; }
    protected override void Awake()
    {
        base.Awake();

        string planetSysPath = PATH_PREFIX + planetSystemFn;
        int nbFile = otherFn.Length;
        string[] otherPath = new string[nbFile];
        for(int i = 0; i < nbFile; ++i)
            otherPath[i] = PATH_PREFIX + otherFn[i];

        Dictionary<string, Dictionary<string, string>> parsed = ExoplanetDataParser.GetParsedData(planetSysPath, otherPath);
        Planets = new List<ExoplanetData>();
        foreach (KeyValuePair<string, Dictionary<string,string>> planet in parsed)
            Planets.Add(new ExoplanetData(planet.Key, planet.Value));
        Planets.Sort((a,b) => a.PlanetName.CompareTo(b.PlanetName));
    }

    public ExoplanetData GetRandomExoplanet()
        => Planets[Random.Range(0, Planets.Count)];
    
}
