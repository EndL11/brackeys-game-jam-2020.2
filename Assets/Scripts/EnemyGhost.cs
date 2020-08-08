using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGhost : MonoBehaviour
{
    public GameObject _sprite;

    private GameObject player;
    private float speed = 1.7f;
    [SerializeField] private float _damage = 25f;
    private EnemyStats _enemyStats;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        _enemyStats = GetComponent<EnemyStats>();
    }

    void Update()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        _sprite.GetComponent<SpriteRenderer>().flipX = player.transform.position.x > transform.position.x ? true : false;
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerStats>().TakeDamage(_damage);
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Bullet"))
        {
            _enemyStats.TakeDamage(collision.GetComponent<BulletMovement>()._damage);
        }
    }
}
