using System.Collections.Generic;
using UnityEngine;
public class ShootingPool : MonoBehaviour
{
    public static ShootingPool shootingPool;
    [SerializeField] GameObject prefabBullet;
    [SerializeField] List<GameObject> bulletList;
    [SerializeField] readonly int poolSize = 10;
    void Awake() => Singleton();
    void Start() => AddBulletInPool(poolSize);
    void AddBulletInPool(int _length)
    {
        for (int i = 0; i < _length; i++)
        {
            GameObject bullet = Instantiate(prefabBullet);
            bullet.SetActive(false);
            bulletList.Add(bullet);
            bullet.transform.parent = transform;
        }
    }
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
    public GameObject RequestBullet()
    {
        for (int i = 0; i < bulletList.Count; i++)
        {
            if (!bulletList[i].activeSelf)
            {
                bulletList[i].SetActive(true);
                return bulletList[i];
            }
        }
        AddBulletInPool(1);
        bulletList[^1].SetActive(true);
        return bulletList[^1];
    }
}