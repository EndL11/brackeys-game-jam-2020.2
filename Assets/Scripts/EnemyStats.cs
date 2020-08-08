using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStats : MonoBehaviour
{
    public Slider _healthSlider;
    [SerializeField] private float _health;
    private float _maxHealth;

    private void Start()
    {
        _healthSlider.gameObject.SetActive(false);
        _maxHealth = _health;
        _healthSlider.maxValue = _maxHealth;
        _healthSlider.value = _health;

    }

    public void TakeDamage(float _damage)
    {
        _health -= _damage;

        _healthSlider.value = _health;
        StartCoroutine(ShowAndHideHealthBar());
        if (_health <= 0f)
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator ShowAndHideHealthBar()
    {
        _healthSlider.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        _healthSlider.gameObject.SetActive(false);
    }

}
