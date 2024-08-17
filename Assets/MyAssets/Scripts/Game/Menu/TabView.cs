using UnityEngine;
using UnityEngine.UI;
public class TabView : MonoBehaviour
{
    [SerializeField] Text textTab;
    [SerializeField] bool active = false;
    void Awake()
    {
    }
    void Update()
    {
        textTab.text = "Presiona \"Tab\" para activar o desactivar el mouse!";
        TabVieW();
    }
    public void TabVieW()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            active = !active;
            if (!active)
            {
                GeneralSingleton.generalSingleton.MouseLock();
            }
            else
            {
                GeneralSingleton.generalSingleton.MouseUnLock();
            }
        }
    }
}