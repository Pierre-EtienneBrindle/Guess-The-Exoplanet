using System.Collections.Generic;
using System;
using System.IO;
using SingletonBehavior;
using TMPro.Examples;
using UnityEngine;

public class ExoplanetSpriteGenerator : SingletonMonobehavior<ExoplanetSpriteGenerator>
{
    [SerializeField] string planetTemplatesPath;

    public Sprite GenerateSprite(ExoplanetData planet)
    {
        int hash = Math.Abs(planet.GetHashCode());
        List<string> files = new();
        foreach (string file in Directory.GetFiles(planetTemplatesPath))
        {
            if (file.Contains(".meta") || file.Contains(".bmp"))
            {
                continue;
            }
            files.Add(file);
        }
        string filepath = files[hash % files.Count];

        Texture2D texture = new(64, 64);
        texture.LoadImage(File.ReadAllBytes(filepath));
        Func<float, Color> colorOffsetFromTemperature = (float temp) =>
        {
            // Sigmoïde pour smoother la température, devrait ressembler à ça:
            // https://www.desmos.com/calculator/pmvyquj2nb 

            float offset = 0.5f - 1f / ((float) Math.Exp((temp - 1000f) / 700f));
            offset *= 0.5f;
            if (offset > 0)
            {
                return new Color(offset, 0, 0, 1);
            }
            else
            {
                return new Color(0, 0, -offset, 1);
            }
        };

        Color colorToAdd = planet.Temperature.HasValue ? colorOffsetFromTemperature(planet.Temperature.Value) : new Color(0, 0, 0, 1);
        Color[] pixels = texture.GetPixels();
        for (int i = 0; i < pixels.Length; i++)
        {
            if (pixels[i].a <= 0.01)
            {
                continue;
            }
            pixels[i] = pixels[i] + colorToAdd;
        }

        texture.SetPixels(pixels);
        texture.Apply();
        return Sprite.Create(texture, new Rect(0, 0, 64, 64), new Vector2(0.5f, 0.5f));
    }
}
