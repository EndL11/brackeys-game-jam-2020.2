using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{

    public float _damage = 15f;

    private void Start()
    {
        Destroy(gameObject, 5f);   
    }

    private void Update()
    {
        transform.Translate(Vector2.right * 15f * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground") || collision.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
