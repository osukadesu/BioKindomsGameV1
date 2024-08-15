using System;
using UnityEngine;
public class ShootLogic : MonoBehaviour
{
    public GameObject bullet, newBullet;
    public Transform spawnBullet;
    public float shootForce = 1500f, shootRate = 0.5f, shootRateTime = 0.5f;
    public bool canShoot;
    void Start()
    {
        canShoot = false;
    }
    void Update()
    {
        if (canShoot && Input.GetButtonDown("Fire1"))
        {
            if (Time.time > shootRateTime)
            {
                newBullet = Instantiate(bullet, spawnBullet.position, spawnBullet.rotation);
                newBullet.GetComponent<Rigidbody>().AddForce(spawnBullet.forward * shootForce);
                shootRateTime = Time.time + shootRate;
            }
        }
    }
    public void DestroyNewBullet()
    {
        Destroy(newBullet, .5f);
    }
}