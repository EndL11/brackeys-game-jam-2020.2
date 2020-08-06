using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public GameObject projectile;
    public Transform firePoint;
    public Transform weaponPoint;

    private float fireRate = 3f;
    private float fireTime;

    void Start()
    {
        
    }


    void Update()
    {
        RotateToMouse();

        if (Input.GetMouseButton(0) && CanShoot())
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        Instantiate(projectile, firePoint.position, weaponPoint.rotation);
        fireTime = Time.time + (1f / fireRate);
    }

    private bool CanShoot()
    {
        return Time.time >= fireTime;
    }

    private void RotateToMouse()
    {
        if(Camera.main.ScreenToWorldPoint(Input.mousePosition).x < weaponPoint.position.x)
        {
            weaponPoint.GetChild(0).GetComponent<SpriteRenderer>().flipY = true;
        }
        else
        {
            weaponPoint.GetChild(0).GetComponent<SpriteRenderer>().flipY = false;
        }

        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();

        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        weaponPoint.rotation = Quaternion.Euler(0f, 0f, rotZ);
    }
}
