using System;
using UnityEngine;
public class EnemyStats : MonoBehaviour
{
    [SerializeField] EnemyStateManager[] enemyStateManager;
    [SerializeField] AttackStateF[] attackStateF;
    [SerializeField] DamagePlayer[] damagePlayer;
    [SerializeField] DamagePlayerVegetal[] damagePlayerVegetal;
    [SerializeField] PlayerEstanteCol playerEstanteCol;
    void Awake()
    {
        playerEstanteCol = FindObjectOfType<PlayerEstanteCol>();
    }
    /*
    void Update()
    {
        damagePlayerVegetal = FindObjectsOfType<DamagePlayerVegetal>();
    }
    */
    public void SetKingdomStatsInLevel(int _level)
    {
        Action action = _level switch
        {
            2 => () => SetKingdomStats(0, 0),
            4 => () => SetKingdomStats(0, 1),
            6 => () => SetKingdomStats(0, 2),
            8 => () => SetKingdomStats(0, 3),
            10 => () => SetKingdomStats(0, 4),
            24 => () => SetKingdomStats(2, 0),
            26 => () => SetKingdomStats(2, 1),
            28 => () => SetKingdomStats(2, 2),
            30 => () => SetKingdomStats(2, 3),
            32 => () => SetKingdomStats(2, 4),
            /*
             13 => () => SetKingdomStats(1, 0),
             15 => () => SetKingdomStats(1, 1),
             17 => () => SetKingdomStats(1, 2),
             19 => () => SetKingdomStats(1, 3),
             21 => () => SetKingdomStats(1, 4),
             35 => () => SetKingdomStats(3, 0),
             37 => () => SetKingdomStats(3, 1),
             39 => () => SetKingdomStats(3, 2),
             41 => () => SetKingdomStats(3, 3),
             43 => () => SetKingdomStats(3, 4),
             46 => () => SetKingdomStats(4, 0),
             48 => () => SetKingdomStats(4, 1),
             50 => () => SetKingdomStats(4, 2),
             52 => () => SetKingdomStats(4, 3),
             54 => () => SetKingdomStats(4, 4),
            */
            _ => () => Debug.Log("Default case!"),
        };
        action();
    }
    void SetKingdomStats(int _enemyKingdom, int enemyIndex)
    {
        Action action = _enemyKingdom switch
        {
            0 => () => SetAnimalStats(enemyIndex),
            1 => () => SetVegetalStats(enemyIndex),
            2 => () => SetFungiStats(enemyIndex),
            3 => () => SetProtistaStats(enemyIndex),
            4 => () => SetMoneraStats(enemyIndex),
            _ => () => Debug.Log("Default case!"),
        };
        action();
    }
    void SetAnimalStats(int _type)
    {
        Action action = _type switch
        {
            0 => () => SetEnemyStatsAnimal(4, 5, 4.5f, 2.5f),
            1 => () => SetEnemyStatsAnimal(8, 4, 4, 2),
            2 => () => SetEnemyStatsAnimal(12, 3, 3.5f, 1.5f),
            3 => () => SetEnemyStatsAnimal(16, 2, 3, 1),
            4 => () => SetEnemyStatsAnimal(20, 2, 3, 1),
            _ => () => Debug.Log("Default case!"),
        };
        action();
    }
    void SetEnemyStatsAnimal(int _damage, float _attackSpeed, float _walkSpeed, float _animSpeed)
    {
        ChangeDamage(_damage);
        ChangeAttackSpeed(_attackSpeed);
        ChangeWalkSpeed(_walkSpeed, _animSpeed);
    }
    void SetVegetalStats(int _type)
    {
        Action action = _type switch
        {
            0 => () => SetEnemyStatsVegetal(4, 1f),
            1 => () => SetEnemyStatsVegetal(6, 1.5f),
            2 => () => SetEnemyStatsVegetal(8, 2),
            3 => () => SetEnemyStatsVegetal(10, 2.5f),
            4 => () => SetEnemyStatsVegetal(12, 3),
            _ => () => Debug.Log("Default case!"),
        };
        action();
    }
    void SetEnemyStatsVegetal(int _damage, float _attackSpeed)
    {
        ChangeDamageVegetal(_damage);
        ChangeAttackSpeedVegetal(_attackSpeed);
    }
    void SetFungiStats(int _type)
    {
        Action action = _type switch
        {
            0 => () => SetEnemyStatsFungi(4, 5, 4.5f, 2.5f),
            1 => () => SetEnemyStatsFungi(8, 4, 4, 2),
            2 => () => SetEnemyStatsFungi(12, 3, 3.5f, 1.5f),
            3 => () => SetEnemyStatsFungi(16, 2, 3, 1),
            4 => () => SetEnemyStatsFungi(20, 2, 3, 1),
            _ => () => Debug.Log("Default case!"),
        };
        action();
    }
    void SetEnemyStatsFungi(int _damage, float _attackSpeed, float _walkSpeed, float _animSpeed)
    {
        ChangeDamage(_damage);
        ChangeAttackSpeedF(_attackSpeed);
        ChangeWalkSpeedF(_walkSpeed, _animSpeed);
    }
    float ChangeAttackSpeedF(float _attackSpeed)
    {
        return attackStateF[playerEstanteCol.setId].attackSpeed = _attackSpeed;
    }
    float ChangeWalkSpeedF(float _walkSpeed, float _animSpeed)
    {
        // attackStateF[playerEstanteCol.setId].enemiAnim.SetFloat("speed", _animSpeed);
        return attackStateF[playerEstanteCol.setId].walkSpeed = _walkSpeed;
    }
    void SetProtistaStats(int _type)
    {
        Action action = _type switch
        {
            0 => () => SetEnemyStatsProtista(4, 5),
            1 => () => SetEnemyStatsProtista(6, 4),
            2 => () => SetEnemyStatsProtista(8, 3),
            3 => () => SetEnemyStatsProtista(10, 2),
            4 => () => SetEnemyStatsProtista(12, 2),
            _ => () => Debug.Log("Default case!"),
        };
        action();
    }
    void SetEnemyStatsProtista(int _damage, float _attackSpeed)
    {
        ChangeDamage(_damage);
        ChangeAttackSpeed(_attackSpeed);
    }
    void SetMoneraStats(int _type)
    {
        Action action = _type switch
        {
            0 => () => SetEnemyStatsMonera(4, 5, 4, 2),
            1 => () => SetEnemyStatsMonera(6, 4, 3, 1.5f),
            2 => () => SetEnemyStatsMonera(8, 3, 2, 1),
            3 => () => SetEnemyStatsMonera(10, 2, 1, 1),
            4 => () => SetEnemyStatsMonera(12, 2, 1, 0.5f),
            _ => () => Debug.Log("Default case!"),
        };
        action();
    }
    void SetEnemyStatsMonera(int _damage, float _attackSpeed, float _walkSpeed, float _animSpeed)
    {
        ChangeDamage(_damage);
        ChangeAttackSpeed(_attackSpeed);
        ChangeWalkSpeed(_walkSpeed, _animSpeed);
    }
    float ChangeAttackSpeed(float _attackSpeed)
    {
        return enemyStateManager[playerEstanteCol.setId].attackSpeed = _attackSpeed;
    }
    float ChangeAttackSpeedVegetal(float _attackSpeedVegetal)
    {
        return damagePlayerVegetal[playerEstanteCol.setId].shooterVegetal.velAttack = _attackSpeedVegetal;
    }
    float ChangeWalkSpeed(float _walkSpeed, float _animSpeed)
    {
        enemyStateManager[playerEstanteCol.setId].enemiAnim.SetFloat("speed", _animSpeed);
        return enemyStateManager[playerEstanteCol.setId].walkSpeed = _walkSpeed;
    }
    float ChangeDamage(int newDamage)
    {
        return damagePlayer[playerEstanteCol.setId].daño = newDamage;
    }
    float ChangeDamageVegetal(int newDamage)
    {
        return damagePlayerVegetal[playerEstanteCol.setId].daño = newDamage;
    }
}