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
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Restart();
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
