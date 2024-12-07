using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform firePoint;
    public float fireRate = 1f;
    float nextFireTime = 0f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + fireRate;
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject bullet = BulletPool.instance.GetBullet();
        bullet.transform.position = firePoint.position;
        Vector2 direction = firePoint.right;
        bullet.GetComponent<Bullet>().Shoot(direction);
    }
}
