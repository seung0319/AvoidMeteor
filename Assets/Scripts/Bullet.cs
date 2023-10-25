using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject[] items;

    private void Start()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Item")
        {
            int rand = Random.Range(0, items.Length);
            Destroy(gameObject);
            Destroy(collision.gameObject);
            Instantiate(items[rand], new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        }
        if (collision.gameObject.tag == "Top")
        {
            Destroy(gameObject);
        }
    }
}
