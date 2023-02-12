using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapGenerator : MonoBehaviour
{
    static int seed;

    public GameObject[] horizontalPresets;
    public GameObject[] upPresets;
    public GameObject[] dropPresets;
    public GameObject[] winPresets;

    public GameObject[,] map;
    public Tilemap targetMap;

    const int height = 8;
    const int width = 4;

    // Start is called before the first frame update
    void Start()
    {
        Random.InitState(seed);

        map = new GameObject[height,width];

        GenerateMap();
    }

    void GenerateMap()
    {
        int section = GetRandomNotI(0, width, -1);

        for (int i = 0; i < height - 1; i++)
        {
            GameObject upPreset = upPresets[Random.Range(0, upPresets.Length)];
            map[i, section] = Instantiate<GameObject>(upPreset, new Vector3(16 * section, 12 * i, 0), Quaternion.identity);
            map[i, section].transform.parent = transform;

            GameObject dropPreset = dropPresets[Random.Range(0, dropPresets.Length)];
            map[i+1, section] = Instantiate<GameObject>(dropPreset, new Vector3(16 * section, 12 * (i+1), 0), Quaternion.identity);
            map[i+1, section].transform.parent = transform;
      

            section = GetRandomNotI(0, width, section);
        }

        GameObject winPreset = winPresets[Random.Range(0, winPresets.Length)];
        map[height - 1, section] = Instantiate<GameObject>(winPreset, new Vector3(16 * section, 12 * (height - 1), 0), Quaternion.identity);
        map[height - 1, section].transform.parent = transform;

        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                if (map[i, j] != null) { continue; }

                GameObject preset = horizontalPresets[Random.Range(0, horizontalPresets.Length)];
                map[i, j] = Instantiate<GameObject>(preset, new Vector3(16 * j, 12 * i, 0), Quaternion.identity);
                map[i, j].transform.parent = transform;
            }
        }
    }

    public int GetRandomNotI(int min, int max, int exc)
    {
        int i;
        do
        {
            i = Random.Range(min, max);
        } 
        while (i == exc);
        return i;
    }

    public static void SetSeed(int v) {
        seed = v;
    }

    public static int GetSeed()
    {
        return seed;
    }
}
