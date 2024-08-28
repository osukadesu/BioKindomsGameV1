using System.Collections;
using UnityEngine;
public class ShooterVegetal : MonoBehaviour
{
    public GameObject bullet, newBullet;
    public Transform spawnBullet;
    public float shootForce = 1500f, velocityShoot = 1f;
    private bool canShoot = true;
    void Update()
    {
        if (canShoot)
        {
            StartCoroutine(IEShoot(velocityShoot));
        }
    }
    IEnumerator IEShoot(float _velocityShoot)
    {
        canShoot = false;
        newBullet = Instantiate(bullet, spawnBullet.position, spawnBullet.rotation);
        newBullet.GetComponent<Rigidbody>().AddForce(spawnBullet.forward * shootForce);
        yield return new WaitForSeconds(_velocityShoot);
        canShoot = true;
    }
    public void DestroyNewBullet()
    {
        Destroy(newBullet);
    }
}