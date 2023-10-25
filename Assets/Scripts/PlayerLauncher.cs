using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLauncher : MonoBehaviour
{
    public GameObject bulletPrefab;
    PlayerM p;

    // Start is called before the first frame update
    void Start()
    {
        p = GameObject.Find("Player").GetComponent<PlayerM>();
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
    }

    private void Fire()
    {
        // 0 - 마우스 왼쪽
        // 1 - 마우스 오른쪽
        // 2 - 마우스 휠
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bulletObj = Instantiate(bulletPrefab, new Vector2(transform.position.x, transform.position.y), Quaternion.Euler(0, 0, 0));
            Rigidbody2D rbody = bulletObj.GetComponent<Rigidbody2D>();
            rbody.AddForce(Vector2.up * 10.0f, ForceMode2D.Impulse);

            //bool direction = p.getDirection();

            //if (direction)
            //{
            //    GameObject bulletObj = Instantiate(bulletPrefab, new Vector2(transform.position.x, transform.position.y), Quaternion.Euler(0, 0, -90));
            //    Rigidbody2D rbody = bulletObj.GetComponent<Rigidbody2D>();
            //    rbody.AddForce(Vector2.right * 10.0f, ForceMode2D.Impulse);
            //}
            //else
            //{
            //    GameObject bulletObj = Instantiate(bulletPrefab, new Vector2(transform.position.x, transform.position.y), Quaternion.Euler(0, 0, 90));
            //    Rigidbody2D rbody = bulletObj.GetComponent<Rigidbody2D>();
            //    rbody.AddForce(Vector2.left * 10.0f, ForceMode2D.Impulse);
            //}
            // 총알 생성

            // transform.position : 현 스크립트를 가지고 있는 오브젝트의 위치
            // Quaternion.identity : 회전값이 0임을 표현하는 코드

            // 위로 발사

            // ForceMode2D : 물리 엔진 작업 시에 힘의 처리를 설정하는 enum
            // Force : 서서히 힘을 가함
            // Impulse : 순간적인 힘을 가함

        }
    }
}
