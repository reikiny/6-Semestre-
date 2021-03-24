using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class LevelGenerator : MonoBehaviour
{
    public Texture2D map;
    public ColorToPrefab[] colorMappings;

    public float multiplicador;

    public bool instantiated;

    void Start()
    {
        if (!instantiated)
        {
            GenerateLevel();
            instantiated = true;
        }

    }

    public void GenerateLevel()
    {
        for (int x = 0; x < map.width; x++)
        {
            for (int y = 0; y < map.height; y++)
            {
                GenerateTile(x, y);

            }
        }
    }


    public void GenerateTile(int x, int y)
    {
        Color pixelColor = map.GetPixel(x, y);

        if (pixelColor.a == 0)
        {
            //pixel é transparente. FAZ NADA

            return;
        }

        foreach (ColorToPrefab colorMapping in colorMappings)
        {

            if (colorMapping.color.Equals(pixelColor))
            {
                Vector3 position = new Vector3(x * multiplicador, 0, y * multiplicador);
                Instantiate(colorMapping.prefab, position, Quaternion.identity, transform);
            }
        }
    }
}
