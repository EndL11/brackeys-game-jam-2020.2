using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField] private float _health;
    private float _maxHealth;

    void Start()
    {
        _maxHealth = _health;
    }


    void Update()
    {
        
    }

    public void TakeDamage(float _damage)
    {
        _health -= _damage;

        if(_health <= 0f)
        {
            Destroy(gameObject);
        }
    }

}
