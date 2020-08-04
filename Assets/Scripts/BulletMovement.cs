using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    private void Update()
    {
        transform.Translate(Vector2.right * 15f * Time.deltaTime);
    }

}
