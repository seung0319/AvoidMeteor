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
        // 0 - ���콺 ����
        // 1 - ���콺 ������
        // 2 - ���콺 ��
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
            // �Ѿ� ����

            // transform.position : �� ��ũ��Ʈ�� ������ �ִ� ������Ʈ�� ��ġ
            // Quaternion.identity : ȸ������ 0���� ǥ���ϴ� �ڵ�

            // ���� �߻�

            // ForceMode2D : ���� ���� �۾� �ÿ� ���� ó���� �����ϴ� enum
            // Force : ������ ���� ����
            // Impulse : �������� ���� ����

        }
    }
}
