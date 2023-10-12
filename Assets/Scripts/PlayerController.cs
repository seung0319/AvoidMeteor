using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject player;
    public SpriteRenderer sPlayer;

    public void OnLButtonEnter()
    {
        player.transform.Translate(-1, 0, 0);
        sPlayer.flipX = true;
    }

    public void OnRButtonEnter()
    {
        player.transform.Translate(1, 0, 0);
        sPlayer.flipX = false;
    }
}
