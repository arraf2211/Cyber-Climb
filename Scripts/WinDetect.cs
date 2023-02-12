using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Networking;

public class WinDetect : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Finish"))
        {


            GameManager.global.OnWin();
        }
        else if (collision.gameObject.tag.Equals("Spikes") || collision.gameObject.tag.Equals("GlitchHitBox"))
        {
            GameManager.global.Restart();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("GlitchHitBox"))
        {
            GameManager.global.Restart();
        }
    }
}
