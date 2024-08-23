using UnityEngine;
public abstract class DeadManager : MonoBehaviour
{
    [SerializeField] protected internal LevelSystem levelSystemV2;
    [SerializeField] protected internal PlayerEstanteCol playerEstanteCol;
    [SerializeField] protected internal LifeController[] lifeControllerEnemy;
    [SerializeField] protected internal LifeController lifeControllerPlayer;
    [SerializeField] protected internal AlertModalManager alertModalManager;
    [SerializeField] protected internal ShootLogic shootLogic;
    [SerializeField] protected internal LevelWinMethod levelWinMethod;
    [SerializeField] protected internal EnemyStateManager[] enemyStateManager;
    void Awake()
    {
        levelSystemV2 = FindObjectOfType<LevelSystem>();
        lifeControllerPlayer = GameObject.FindGameObjectWithTag("PlayerDamage").GetComponent<LifeController>();
        alertModalManager = FindObjectOfType<AlertModalManager>();
        shootLogic = FindObjectOfType<ShootLogic>();
        levelWinMethod = FindObjectOfType<LevelWinMethod>();
    }
    void Update()
    {
        DeadActions();
    }
    protected internal abstract void DeadActions();
}