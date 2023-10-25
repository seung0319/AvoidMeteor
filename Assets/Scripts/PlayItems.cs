using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class PlayItems : MonoBehaviour
{
    public float speed;
    PlayerM p;
    Rigidbody2D rbody;
    float randomX, randomY;
    Vector2 dir;
    

    // Start is called before the first frame update
    void Start()
    {
        
        speed = 5.0f;
        p = GameObject.Find("Player").GetComponent<PlayerM>();
        rbody = gameObject.GetComponent<Rigidbody2D>();
        randomX = Random.Range(-1f, 1f);
        randomY = Random.Range(-1f, 1f);
        dir = new Vector2(randomX, randomY).normalized;
        rbody.AddForce(dir * speed, ForceMode2D.Impulse);
        Destroy(gameObject, 10.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if(gameObject.name == "Heart")
            {
                p.upPlayerLives();
                
            }
                
            else if(gameObject.name == "Bomb")
            {
                p.upPlayerLives(); // ³ªÁß¿¡ ÆøÅºÀ¸·Î

            }
                
            Destroy(gameObject);
            
        }
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Top"))
        {
            Debug.Log("WallTop");

            rbody.AddForce(dir * speed);
            //rbody.AddForce(new Vector2(Random.Range(1, 6), Random.Range(1, 6)), ForceMode2D.Impulse);
        }
    }
}
