using UnityEngine;
using UnityEngine.UI;
public class TabView : MonoBehaviour
{
    [SerializeField] Text textTab, textEsc;
    [SerializeField] bool active = false;
    void Update()
    {
        textTab.text = "Presiona \"Tab\" para activar o desactivar el mouse!";
        textEsc.text = "Presiona \"Esc\" para salir!";
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