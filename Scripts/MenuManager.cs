using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using UnityEngine.Networking;


public class MenuManager : MonoBehaviour
{
    public InputField seedInput;

    public Text winText;

    private void Start()
    {
        if (winText != null)
        {

            StartCoroutine(Upload());
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


    IEnumerator Upload()
    {

        int seed = MapGenerator.GetSeed();
        WWWForm form = new WWWForm();

        string req = "http://localhost:3000/mintSeed/?seed=" + seed.ToString() + "&publicKey=0x408569717abA1a5EC1cB2D1Cd371227570DA8832&time=82";


        using (UnityWebRequest www = UnityWebRequest.Post(req, form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Form upload complete!");
            }
        }
    }
}
