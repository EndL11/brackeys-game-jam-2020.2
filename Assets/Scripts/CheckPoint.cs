using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private Vector2 _position;
    private float _health;

    public void SetStats(GameObject player)
    {
        _position = player.transform.position;
        _health = player.GetComponent<PlayerStats>().GetHealth();
    }

    public Vector2 GetSavedPosition()
    {
        return _position;
    }

    public float GetSavedHealth()
    {
        return _health;
    }
}
