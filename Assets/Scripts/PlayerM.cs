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
    public float moveableRangex = 8.5f;
    public float moveableRangey = 4.5f;
    GameObject hpUp;
    GameObject bombUp;
    bool hpAct = false;
    bool bombAct = false;

    bool direction = false; // false = left, true = right

    private void Start()
    {
        hpUp = GameObject.Find("hpUP");
        bombUp = GameObject.Find("bombUP");
        hpUp.SetActive(false);
        bombUp.SetActive(false);
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
            direction = false;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveX = moveX + 1;
            sPlayer.flipX = false;
            direction = true;
        }
        
        transform.Translate(new Vector3(moveX, moveZ, 0) * speed);
        hpUp.transform.position = transform.position + new Vector3(0, 1f, 0);
        bombUp.transform.position = transform.position + new Vector3(0, 1f, 0);
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -moveableRangex, moveableRangex), Mathf.Clamp(transform.position.y, -moveableRangey, moveableRangey));
        if(hpAct == true)
        {
            hpUp.SetActive(true);
        }
        if(bombAct == true)
        {
            bombUp.SetActive(true);
        }
    }

    public void losePlayerLives()
    {
        this.lives -= 1;
    }

    public void upPlayerLives()
    {
        this.lives += 1;
        hpAct = true;
        //hpUp.SetActive(false);
    }
    public int getPlayerLives()
    {
        int life;
        return life = this.lives;
    }

    public bool getDirection()
    {
        return direction;
    }
}
