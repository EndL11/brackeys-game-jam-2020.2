﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public GameObject checkPointPrefab;
    public Slider _healthSlider;

    [SerializeField] private float _health = 100f;
    private float _maxHealth = 100f;
    private bool statsSaved = false;
    private CheckPoint _checkpoint = null;

    private void Awake()
    {
        _maxHealth = _health;
        _healthSlider.maxValue = _maxHealth;
        _healthSlider.value = _health;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && statsSaved == false)
        {
            CreateCheckPoint();
        }
        else if(Input.GetMouseButtonDown(1) && statsSaved == true)
        {
            ReturnToCheckPoint();
        }
    }

    private void ReturnToCheckPoint()
    {
        _health = _checkpoint.GetSavedHealth();
        transform.position = _checkpoint.GetSavedPosition();
        Destroy(_checkpoint.gameObject);
        _checkpoint = null;
        statsSaved = false;
    }

    private void CreateCheckPoint()
    {
        CheckPoint checkPoint = Instantiate(checkPointPrefab, transform.position, Quaternion.identity).GetComponent<CheckPoint>();
        checkPoint.SetStats(this.gameObject);
        _checkpoint = checkPoint;
        statsSaved = true;
    }

    public float GetHealth()
    {
        return _health;
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;

        _healthSlider.value = _health;

        if(_health <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
