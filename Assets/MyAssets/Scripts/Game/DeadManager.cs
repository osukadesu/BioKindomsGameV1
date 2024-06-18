using UnityEngine;
public abstract class DeadManager : MonoBehaviour
{
    [SerializeField] protected internal PlayerEstanteCol playerEstanteCol;
    [SerializeField] protected internal LevelSystemV2 levelSystem;
    [SerializeField] protected internal LifeController[] lifeControllerEnemy;
    [SerializeField] protected internal LifeController lifeControllerPlayer;
    [SerializeField] protected internal AlertModalManager alertModalManager;
    [SerializeField] protected internal ShootLogic shootLogic;
    [SerializeField] protected internal LevelWinMethod levelWinMethod;
    void Awake()
    {
        levelSystem = FindObjectOfType<LevelSystemV2>();
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