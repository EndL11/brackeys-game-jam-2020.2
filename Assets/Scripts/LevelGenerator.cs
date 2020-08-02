using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public Texture2D map;
    public ColorToPrefab[] levelPrefabs;

    private void Start()
    {
        GenerateLevel();
    }

    private void GenerateLevel()
    {
        for (int x = 0; x < map.width; x++)
        {
            for (int y = 0; y < map.height; y++)
            {
                GenerateTile(x, y);
            }
        }
    }

    private void GenerateTile(int x, int y)
    {
        Color pixelColor = map.GetPixel(x, y);
        if(pixelColor.a == 0)
        {
            //  this pixel is transperant, ignore
            return;
        }

        foreach(ColorToPrefab levelPrefab in levelPrefabs)
        {
            if (levelPrefab.color.Equals(pixelColor))
            {
                Vector2 _position = new Vector2(x, y);
                Instantiate(levelPrefab.prefab, _position, Quaternion.identity);
            }
        }

    }
}
