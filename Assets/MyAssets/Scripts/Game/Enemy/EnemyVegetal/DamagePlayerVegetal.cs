using UnityEngine;
public class DamagePlayerVegetal : DamagePlayer
{
    [SerializeField] protected internal ShooterVegetal shooterVegetal;
    void Update()
    {
        if (lifeControllerPlayer.gameObject.activeInHierarchy)
        {
            lifeControllerPlayer = GameObject.FindGameObjectWithTag("PlayerDamage").GetComponent<LifeController>();
        }
        shooterVegetal = FindObjectOfType<ShooterVegetal>();
    }
    protected internal override void SubtractLife(Collider other)
    {
        if (other.CompareTag("DestroyerBullet"))
        {
            shooterVegetal.DestroyNewBullet();
        }
        if (other.CompareTag("PlayerDamage"))
        {
            lifeControllerPlayer.RestarVida(daño);
            shooterVegetal.DestroyNewBullet();
        }
    }
}