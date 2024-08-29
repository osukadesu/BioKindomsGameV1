using UnityEngine;
public class DamagePlayer : DamageSystem
{
    [SerializeField] protected internal LifeController lifeControllerPlayer;
    void Awake()
    {
        lifeControllerPlayer = GameObject.FindGameObjectWithTag("PlayerDamage").GetComponent<LifeController>();
    }
    void OnTriggerEnter(Collider other) => SubtractLife(other);
    void OnTriggerStay(Collider other) => SubtractLife(other);
    protected internal override void SubtractLife(Collider other)
    {
        if (other.CompareTag("PlayerDamage"))
        {
            lifeControllerPlayer.RestarVida(daño);
        }
    }
}