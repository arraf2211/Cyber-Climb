using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager global;

    private void Start()
    {
        global = this;
        #if !(UNITY_EDITOR)
        Debug.unityLogger.logEnabled = false;
        #endif
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            ExitToMenu();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            Restart();
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            OnWin();
        }
    }

    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnWin() {
        SceneManager.LoadScene("Win");
    }

    public void ExitToMenu() {
        SceneManager.LoadScene("Menu");
    }
}
