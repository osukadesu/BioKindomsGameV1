using UnityEngine;
public class LoadProfileSingleton : MonoBehaviour
{
    public static LoadProfileSingleton loadProfileSingleton;
    public int[] _num = new int[5];
    public bool isFirtsTime, wasFirtsTime;
    void Awake()
    {
        Singleton();
    }
    void Singleton()
    {
        if (loadProfileSingleton == null)
        {
            loadProfileSingleton = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
