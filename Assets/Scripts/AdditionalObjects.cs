using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdditionalObjects : MonoBehaviour
{

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = -0.075f;
    }

    void FixedUpdate()
    {
        transform.Translate(speed * -1, speed * Time.deltaTime, 0);

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

    private void OnTriggerEnter2D(Collider2D collision)
    {

    }
}
