using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Pool;

public class PlayerM : MonoBehaviour
{
    public static GameObject player;
    public SpriteRenderer sPlayer;
    public GameObject Boom;
    public int lives;
    public float speed;

    private void Start()
    {
        speed = 0.1f;
        lives = 5;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveX = 0;
        float moveZ = 0;

        if (Input.GetKey(KeyCode.W))
        {
            moveZ = moveZ + 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveZ = moveZ - 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveX = moveX - 1;
            sPlayer.flipX = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveX = moveX + 1;
            sPlayer.flipX = false;
        }

        transform.Translate(new Vector3(moveX, moveZ, 0) * speed);
    }

    public void losePlayerLives()
    {
        this.lives -= 1;
    }

    public int getPlayerLives()
    {
        int life;
        return life = this.lives;
    }
}
