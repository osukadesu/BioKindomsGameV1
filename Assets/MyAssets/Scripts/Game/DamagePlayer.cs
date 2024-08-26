using UnityEngine;
public class DamagePlayer : DamageSystem
{
    void OnTriggerEnter(Collider other) => SubtractLife(other);
    void OnTriggerStay(Collider other) => SubtractLife(other);
    protected internal override void SubtractLife(Collider other)
    {
        if (other.tag == "PlayerDamage")
        {
            lifeControllerPlayer.RestarVida(daño);
        }
    }
}