using UnityEngine;
public abstract class DamageSystem : MonoBehaviour
{
    [SerializeField] protected internal int daño;
    [SerializeField] protected internal LifeController lifeControllerEnemy, lifeControllerPlayer;
    [SerializeField] protected internal PlayerEstanteCol playerEstanteCol;
    [SerializeField] protected internal ShootLogic shootLogic;
    [SerializeField] protected internal Animator damageAnim;
    void Awake()
    {
        lifeControllerPlayer = GameObject.FindGameObjectWithTag("PlayerDamage").GetComponent<LifeController>();
        lifeControllerEnemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<LifeController>();
        damageAnim = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Animator>();
        playerEstanteCol = FindObjectOfType<PlayerEstanteCol>();
        shootLogic = FindObjectOfType<ShootLogic>();
    }
    protected internal abstract void SubtractLife(Collider other);
}