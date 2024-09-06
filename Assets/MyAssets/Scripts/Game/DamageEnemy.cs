using UnityEngine;
public class DamageEnemy : DamageSystem
{
    [SerializeField] protected internal LifeController lifeControllerEnemy;
    [SerializeField] protected internal Animator damageAnim;
    [SerializeField] protected internal ShootLogic shootLogic;
    [SerializeField] GameObject[] enemies;
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            if (enemy.activeInHierarchy)
            {
                lifeControllerEnemy = enemy.GetComponent<LifeController>();
                damageAnim = enemy.GetComponent<Animator>();
            }
        }
        shootLogic = FindObjectOfType<ShootLogic>();
    }
    void OnTriggerEnter(Collider other) => SubtractLife(other);
    protected internal override void SubtractLife(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            lifeControllerEnemy.RestarVida(daño);
            damageAnim.SetTrigger("damage");
            shootLogic.HideNewBullet();
        }
        if (other.CompareTag("DestroyerBullet")) { shootLogic.HideNewBullet(); }
    }
}