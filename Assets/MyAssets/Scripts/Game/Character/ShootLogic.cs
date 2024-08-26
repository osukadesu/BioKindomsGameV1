using System.Collections;
using UnityEngine;
public class ShootLogic : MonoBehaviour
{
    [SerializeField] GameObject bullet, newBullet;
    public Transform spawnBullet;
    public float shootForce = 1500f, shootRate = 0.5f, shootRateTime = 0.5f;
    public bool canShoot;
    void Start() => canShoot = false;
    void Update()
    {
        if (canShoot && Input.GetButtonDown("Fire1"))
        {
            if (Time.time > shootRateTime)
            {
                bullet = ShootingPool.shootingPool.RequestBullet();
                bullet.transform.position = spawnBullet.position;
                bullet.GetComponent<Rigidbody>().AddForce(spawnBullet.forward * shootForce);
                shootRateTime = Time.time + shootRate;
            }
        }
    }
    public void HideNewBullet() => bullet.SetActive(false);
    public void SetCanShoot() => StartCoroutine(IECanshot(true));
    IEnumerator IECanshot(bool _canShoot)
    {
        yield return new WaitForSeconds(1f);
        canShoot = _canShoot;
    }
}