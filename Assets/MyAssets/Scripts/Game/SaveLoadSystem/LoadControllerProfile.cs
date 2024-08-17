using UnityEngine;
public class LoadControllerProfile : MonoBehaviour
{
    [SerializeField] protected bool loadProfile;
    public bool LoadProfile { get { return loadProfile; } set { loadProfile = value; } }
    void Awake()
    {
        LoadControllerMethod();
    }
    void LoadControllerMethod()
    {
        loadProfile = !GeneralSingleton.generalSingleton.isNewGame && GeneralSingleton.generalSingleton.isMyProfile;
    }
}