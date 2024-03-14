using UnityEngine;
using UnityEngine.UI;
public class CardMenu : MonoBehaviour
{
    [SerializeField] CanvasManager _canvasManager;
    [SerializeField] MenuAnimations menuAnimations;
    [SerializeField] Button[] ButtonGoKindom;
    void Awake()
    {
        ButtonsOnClick();
    }
    void ButtonsOnClick()
    {
        for (int i = 0; i < 5; i++)
        {
            int buttonNumber = i;
            ButtonGoKindom[i].onClick.AddListener(() => _canvasManager.ButtonGoKindomMethod(buttonNumber));
        }
    }
    public void Configure(CanvasManager canvasManager)
    {
        _canvasManager = canvasManager;
    }
    public void SetContent(int value)
    {
        switch (value)
        {
            case 0:
                menuAnimations.Animal();
                break;
            case 1:
                menuAnimations.Vegetal();
                break;
            case 2:
                menuAnimations.Fungi();
                break;
            case 3:
                menuAnimations.Protista();
                break;
            case 4:
                menuAnimations.Monera();
                break;
            case 5:
                menuAnimations.CloseAll();
                break;
            default:
                menuAnimations.Animal();
                break;
        }
    }
}