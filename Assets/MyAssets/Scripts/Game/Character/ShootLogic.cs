using System.Collections;
using UnityEngine;
public class ShootLogic : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] AudioSource shootAudio;
    public Transform spawnBullet;
    public float shootForce = 100f, shootRate = 1f, shootRateTime = 1f;
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
                bullet.transform.rotation = spawnBullet.rotation;
                Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
                bulletRb.velocity = Vector3.zero;
                bulletRb.AddForce(spawnBullet.forward * shootForce);
                shootRateTime = Time.time + shootRate;
                shootAudio.Play();
            }
        }
    }
    public void HideNewBullet() => bullet.SetActive(false);
    public void SetCanShoot() => StartCoroutine(IECanshot(true));
    IEnumerator IECanshot(bool _canShoot)
    {
        yield return new WaitForSeconds(.5f);
        canShoot = _canShoot;
    }
}