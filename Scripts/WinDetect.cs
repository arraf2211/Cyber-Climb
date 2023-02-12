using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinDetect : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null && collision.gameObject.tag.Equals("Finish"))
        {
            GameManager.global.OnWin();
        }
    }
}
