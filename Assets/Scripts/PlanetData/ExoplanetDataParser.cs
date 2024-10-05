using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro.Examples;
using UnityEngine;

public class ExoplanetDataParser : MonoBehaviour
{
    private string planetarySytemDataPath;
    private string transitDataPath;

    public Dictionary<string, Dictionary<string, string>> GetParsedData()
    {
        Dictionary<string, Dictionary<string, string>> data = new();

        string planetarySystemData = File.ReadAllText(planetarySytemDataPath);
        string[] fieldNames = { };
        foreach (string line in planetarySystemData.Split("\n"))
        {
            if (line.StartsWith('#'))
            {
                continue;
            }
            string[] fields = line.Split("\t");
            if (fieldNames.Length == 0)
            {
                fieldNames = fields;
                continue;
            }

            string planetName = fields[0];
            data.Add(planetName, new());
            for (int i = 1; i < fieldNames.Length; i++)
            {
                if (fieldNames[i].Contains("err") || fieldNames[i].Contains("lim"))
                {
                    continue;
                }
                data[planetName].Add(fieldNames[i], fields[i]);
            }
        }

        string transitData = File.ReadAllText(transitDataPath);
        fieldNames = new string[] { };
        foreach (string line in transitData.Split("\n"))
        {
            if (line.StartsWith('#'))
            {
                continue;
            }

            string[] fields = line.Split("\t");
            if (fieldNames.Length == 0)
            {
                fieldNames = fields;
                continue;
            }

            string planetName = fields[0];
            if (!data.ContainsKey(planetName))
            {
                continue;
            }

            for (int i = 1; i < fields.Length; i++)
            {
                if (fieldNames[i].Contains("err") || fieldNames[i].Contains("lim"))
                {
                    continue;
                }
                data[planetName].Add(fieldNames[i], fields[i]);
            }
        }

        return data;
    }
}
