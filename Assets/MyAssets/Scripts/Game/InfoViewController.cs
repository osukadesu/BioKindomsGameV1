using UnityEngine;
public class InfoViewController : MonoBehaviour
{
    public static InfoViewController infoViewController;
    public int _kingdomIndex;
    void Awake()
    {
        Singleton();
    }
    void Singleton()
    {
        if (infoViewController == null)
        {
            infoViewController = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}