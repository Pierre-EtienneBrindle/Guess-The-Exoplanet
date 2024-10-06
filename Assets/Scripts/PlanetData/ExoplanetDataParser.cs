using System.Collections.Generic;
using System.IO;

public static class ExoplanetDataParser
{
    //string planetarySytemDataPath = "Assets/Scripts/PlanetData/Data/PlanetarySystem.tab";
    //private string transitDataPath = "Assets/Scripts/PlanetData/Data/TransitData.tab";
    
    public static Dictionary<string, Dictionary<string, string>> GetParsedData(string planetarySystemDataPath, string[] otherDataPath)
    {
        Dictionary<string, Dictionary<string, string>> data = new();

        string planetarySystemData = File.ReadAllText(planetarySystemDataPath);
        string[] fieldNames = { };
        foreach (string line in planetarySystemData.Split("\n"))
        {
            if (line.StartsWith('#'))
                continue;
            
            string[] fields = line.Split(",");
            if (fields.Length == 0)
                continue;
            
            if (fieldNames.Length == 0)
            {
                fieldNames = fields;
                continue;
            }

            string planetName = fields[0];
            if (data.ContainsKey(planetName))
                continue;
            
            data.Add(planetName, new());
            for (int i = 1; i < System.Math.Min(fieldNames.Length, fields.Length); i++)
            {
                if (string.IsNullOrEmpty(fields[i]))
                    continue;

                data[planetName].Add(fieldNames[i], fields[i]);
            }
            
        }

        foreach (string dataPath in otherDataPath)
        {
            string transitData = File.ReadAllText(dataPath);
            fieldNames = new string[] { };
            foreach (string line in transitData.Split("\n"))
            {
                if (line.StartsWith('#'))
                    continue;
                
                string[] fields = line.Split(",");
                if (fields.Length == 0)
                    continue;
                
                if (fieldNames.Length == 0)
                {
                    fieldNames = fields;
                    continue;
                }

                string planetName = fields[0];
                if (!data.ContainsKey(planetName))
                    continue;

                for (int i = 1; i < System.Math.Min(fieldNames.Length, fields.Length); i++)
                {   
                    if (data[planetName].ContainsKey(fieldNames[i]) || string.IsNullOrEmpty(fields[i]))
                        continue;
                    
                    data[planetName].Add(fieldNames[i], fields[i]);
                }
            }
        }
        return data;
    }
}