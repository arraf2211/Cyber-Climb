using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapGenerator : MonoBehaviour
{
    public GameObject[] horizontalPresets;
    public GameObject[] upPresets;
    public GameObject[] dropPresets;

    public GameObject[,] map;
    public Tilemap targetMap;

    // Start is called before the first frame update
    void Start()
    {
        // Random.InitState(1);

        map = new GameObject[4,4];

        GenerateMap();
    }

    void GenerateMap()
    {
        int section = GetRandomNotI(0, 4, -1);

        for (int i = 0; i < 3; i++)
        {
            GameObject upPreset = upPresets[Random.Range(0, upPresets.Length)];
            map[i, section] = Instantiate<GameObject>(upPreset, new Vector3(16 * section, 12 * i, 0), Quaternion.identity);
            map[i, section].transform.parent = transform;

            GameObject dropPreset = dropPresets[Random.Range(0, dropPresets.Length)];
            map[i+1, section] = Instantiate<GameObject>(dropPreset, new Vector3(16 * section, 12 * (i+1), 0), Quaternion.identity);
            map[i+1, section].transform.parent = transform;
      

            section = GetRandomNotI(0, 4, section);
        }

        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
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
}
