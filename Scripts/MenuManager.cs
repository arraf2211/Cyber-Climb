using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MenuManager : MonoBehaviour
{
    public InputField seedInput;

    public Text winText;

    private void Start()
    {
        if (winText != null)
        {
            winText.text = "You Now Own: Level-" + MapGenerator.GetSeed().ToString();
        }
    }

    public void onPlay()
    {
        int seed;

        if (int.TryParse(seedInput.text, out seed))
        {
            MapGenerator.SetSeed(seed);
        }
        else
        {
            MapGenerator.SetSeed(Random.Range(0, 1000000));
        }

        SceneManager.LoadScene("Test2");
    }
}
