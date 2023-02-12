using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomizer : MonoBehaviour
{
    public GameObject[] enemies;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate<GameObject>(enemies[Random.Range(0,enemies.Length)], transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
