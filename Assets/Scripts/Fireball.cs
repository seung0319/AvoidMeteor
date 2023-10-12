using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    PlayerM p;
    public GameObject Boom;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 3.0f);
        p = GameObject.Find("Player").GetComponent<PlayerM>();
        speed = -0.15f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(speed * - 1, speed * Time.deltaTime, 0);

        /*
        if(transform.position.y < -4.5f)
        {
            Instantiate(Boom, transform.position, Quaternion.identity);
            //Boom�� �ش� ��ũ��Ʈ�� ���� �ִ� ������Ʈ�� ��ġ�� �����մϴ�.
            //ȸ�� ���� �����ϴ�.
            Destroy(gameObject, 0.5f);
        }
        */
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("fireball");
            Instantiate(Boom, transform.position, Quaternion.identity);
            //Boom�� �ش� ��ũ��Ʈ�� ���� �ִ� ������Ʈ�� ��ġ�� �����մϴ�.
            //ȸ�� ���� �����ϴ�.
            Destroy(gameObject);
            if(p.getPlayerLives() == 0)
            {

            }
            else
                p.losePlayerLives();

        }

        if (collision.gameObject.name == "BoundaryL" || collision.gameObject.name == "BoundaryB")
        {
            Destroy(gameObject);
        }
    }
}
