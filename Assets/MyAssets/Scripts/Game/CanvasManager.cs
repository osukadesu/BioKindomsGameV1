using UnityEngine;
using UnityEngine.UI;
public class CanvasManager : MonoBehaviour
{
    [SerializeField] ViewMenu _viewMenu;
    [SerializeField] CardMenu _cardMenu;
    //[SerializeField] InfoContent _infoContent;
    void Awake()
    {
        _viewMenu.Configure(this);
        _cardMenu.Configure(this);
        //_infoContent.Configure(this);
        ClosingAll();
    }
    public void ButtonGoKindomV2(int index)
    {
        _cardMenu.SetContent(index);
    }
    public void ButtonGoKindomMethod(int btnSelect)
    {
        switch (btnSelect)
        {
            case 0:
                _cardMenu.SetContent(0);
                break;
            case 1:
                _cardMenu.SetContent(1);
                break;
            case 2:
                _cardMenu.SetContent(2);
                break;
            case 3:
                _cardMenu.SetContent(3);
                break;
            case 4:
                _cardMenu.SetContent(4);
                break;
            default:
                _cardMenu.SetContent(0);
                break;
        }
        //_infoContent.SetInfo(25);
        ClosingAll();
    }
    public void CraftItem(int index)
    {
        ButtonGoKindomV2(index);
    }
    public void CloseInfo()
    {
        //_infoContent.SetInfo(25);
        _cardMenu.SetContent(0);
    }
    public void InfoText1()
    {
        //_infoContent.SetTextInfo(1);
    }
    public void InfoText2()
    {
        //_infoContent.SetTextInfo(2);
    }
    public void TabViewMenu()
    {
        _viewMenu.TabVieW();
    }
    public void ButtonCloseTab()
    {
        _viewMenu.CloseTabView();
        //_infoContent.SetInfo(25);
    }
    public void CloseTabViewv2()
    {
        //_infoContent.SetInfo(25);
    }
    public void BackCraft()
    {
        _cardMenu.SetContent(0);
    }
    public void ViewKindom(int index)
    {
        _cardMenu.SetContent(5);
    }
    public void InfoKindom(int index)
    {
        //_infoContent.SetInfo(index);
        _cardMenu.SetContent(5);
        InfoText1();
    }
    public void ClosingAll()
    {
        CloseInfoV2();
    }
    private void CloseInfoV2()
    {
        //_infoContent.Hide();
    }
}