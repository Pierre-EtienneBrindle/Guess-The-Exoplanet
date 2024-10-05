using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SingletonBehavior;
using System;

public class ExoplanetDataStorer : SingletonMonobehavior<ExoplanetDataStorer>
{
    [SerializeField] string planetSystemFn;
    [SerializeField] string[] otherFn;
    const string PATH_PREFIX = "Assets/Scripts/PlanetData/Data/";
    protected override void Awake()
    {
        base.Awake();

        string planetSysPath = PATH_PREFIX + planetSystemFn;
        int nbFile = otherFn.Length;
        string[] otherPath = new string[nbFile];
        for(int i = 0; i < nbFile; ++i)
            otherPath[i] = PATH_PREFIX + otherFn[i];

        Dictionary<string, Dictionary<string, string>> parsed = ExoplanetDataParser.GetParsedData(planetSysPath, otherPath);


        foreach(KeyValuePair<string, Dictionary<string,string>> planet in parsed)
        {
            
        }
    }
}
