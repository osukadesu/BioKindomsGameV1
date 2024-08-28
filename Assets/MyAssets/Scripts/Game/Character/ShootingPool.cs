using System;
using System.Collections.Generic;
using UnityEngine;
public class ShootingPool : MonoBehaviour
{
    public static ShootingPool shootingPool;
    [SerializeField] protected internal GameObject prefabBullet, bullet;
    [SerializeField] List<GameObject> playerBulletList;
    [SerializeField] readonly int poolSize = 5;
    void Awake()
    {
        Singleton();
    }
    void Start() => AddBulletInPool(poolSize);
    void Singleton()
    {
        if (shootingPool == null)
        {
            shootingPool = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void AddBulletInPool(int _length)
    {
        for (int i = 0; i < _length; i++)
        {
            bullet = Instantiate(prefabBullet);
            bullet.SetActive(false);
            playerBulletList.Add(bullet);
            bullet.transform.parent = transform;
        }
    }
    public GameObject RequestBullet()
    {
        foreach (var bullet in playerBulletList)
        {
            if (!bullet.activeSelf)
            {
                bullet.SetActive(true);
                return bullet;
            }
        }
        AddBulletInPool(1);
        playerBulletList[^1].SetActive(true);
        return playerBulletList[^1];
    }
    public void HideNewBullet() => bullet.SetActive(false);
}