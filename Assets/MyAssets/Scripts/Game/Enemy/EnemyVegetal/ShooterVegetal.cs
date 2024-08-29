using System.Collections;
using UnityEngine;
public class ShooterVegetal : MonoBehaviour
{
    public GameObject bullet, newBullet;
    [SerializeField] Animator shooterVegetalAnim;
    public Transform spawnBullet;
    public float shootForce = 1500f, velAttack = 1f;
    public bool canShoot;
    void Start()
    {
        shooterVegetalAnim.SetBool("attack", false);
        canShoot = true;
    }

    void Update()
    {
        if (canShoot)
        {
            SetCanShoot(velAttack);
        }
    }
    public void DestroyNewBullet()
    {
        Destroy(newBullet);
    }
    void SetCanShoot(float _velAttack) => StartCoroutine(IECanshot(_velAttack));
    IEnumerator IECanshot(float _velAttack)
    {
        canShoot = false;
        shooterVegetalAnim.SetBool("attack", true);
        newBullet = Instantiate(bullet, spawnBullet.position, spawnBullet.rotation);
        newBullet.GetComponent<Rigidbody>().AddForce(spawnBullet.forward * shootForce);
        yield return new WaitForSeconds(_velAttack);
        shooterVegetalAnim.SetBool("attack", false);
        canShoot = true;
    }
}