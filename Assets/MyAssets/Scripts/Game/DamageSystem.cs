using UnityEngine;
public abstract class DamageSystem : MonoBehaviour
{
    [SerializeField] protected internal int daño;
    [SerializeField] protected internal LifeController lifeControllerEnemy, lifeControllerPlayer;
    void Awake()
    {
        lifeControllerPlayer = GameObject.FindGameObjectWithTag("PlayerDamage").GetComponent<LifeController>();
        lifeControllerEnemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<LifeController>();
    }
    protected internal abstract void SubtractLife(Collider other);
}