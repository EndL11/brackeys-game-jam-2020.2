using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private GameObject player;
    private float cameraSpeed = 3.5f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    
    void Update()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        if(player == null)
        {
            return;
        }

        if (Vector2.Distance(transform.position, player.transform.position) > 0.2f)
        {
            Vector3 newPos = player.transform.position;
            newPos = Vector2.Lerp(transform.position, newPos, cameraSpeed * Time.deltaTime);
            newPos.z = -10f;
            transform.position = newPos;
        }
    }

    public void SetPlayer(GameObject _player)
    {
        player = _player;
    }
}
