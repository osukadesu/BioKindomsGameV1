using UnityEngine;
using UnityEngine.UI;
public class TabView : MonoBehaviour
{
    [SerializeField] MouseController mouseController;
    [SerializeField] Text textTab;
    [SerializeField] bool active = false;
    void Awake()
    {
        mouseController = FindObjectOfType<MouseController>();
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
                mouseController.MouseLock();
            }
            else
            {
                mouseController.MouseUnLock();
            }
        }
    }
}