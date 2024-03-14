using UnityEngine;
public class DamageEnemy : DamageSystem
{
    void OnTriggerEnter(Collider other)
    {
        SubtractLife(other);
    }
    protected internal override void SubtractLife(Collider other)
    {
        if (other.tag == "Enemy")
        {
            lifeControllerEnemy.RestarVida(daño);
        }
    }
}