using System.Collections;
using UnityEngine;
public class ShootLogic : MonoBehaviour
{
    [SerializeField] GameObject bullet, newBullet;
    public Transform spawnBullet;
    public float shootForce = 1600f;
    public bool canShoot;
    void Start() => canShoot = false;
    void Update()
    {
        if (canShoot && Input.GetButtonDown("Fire1"))
        {
            newBullet = Instantiate(bullet, spawnBullet.position, spawnBullet.rotation);
            newBullet.GetComponent<Rigidbody>().AddForce(spawnBullet.forward * shootForce);
        }
    }
    public void DestroyNewBullet()
    {
        Destroy(newBullet);
    }
    public void SetCanShoot() => StartCoroutine(IECanshot(true));
    IEnumerator IECanshot(bool _canShoot)
    {
        yield return new WaitForSeconds(.5f);
        canShoot = _canShoot;
    }
}