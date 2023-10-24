using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject BombEffect;

    private void Start()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("2");
            Destroy(gameObject);
            Destroy(collision.gameObject);
            Instantiate(BombEffect, new Vector2(transform.position.x, transform.position.y + 0.5f), Quaternion.identity);
        }
        if (collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
