using UnityEngine;
public class CanvasManager : MonoBehaviour
{
    [SerializeField] ViewMenu _viewMenu;
    [SerializeField] CardMenu _cardMenu;
    [SerializeField] CardCraftingContent _cardCraftingContent;
    [SerializeField] InfoContent _infoContent;
    [SerializeField] CraftBuilderSystem _craftBuilderSystem;
    void Awake()
    {
        _viewMenu.Configure(this);
        _cardMenu.Configure(this);
        _infoContent.Configure(this);
        //_cardCraftingContent.Configure(this);
        //_craftBuilderSystem.Configure(this);
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
        _infoContent.SetInfo(25);
        //_cardCraftingContent.SetCrafting(25);
        ClosingAll();
    }
    public void CraftItem(int index)
    {
        //_cardCraftingContent.SetCrafting(25);
        //_craftBuilderSystem.ButtonBuildItem(index);
        ButtonGoKindomV2(index);
    }
    /*
    public void CraftAnimal5()
    {
        craftinCode = 25;
        _cardCraftingContent.SetCrafting();
        _craftBuilderSystem.ButtonBuildItem5();
        StartCoroutine(GoNextKindom(ButtonGoAnimalV2, ButtonGoVegetalV2, ButtonGoAnimalV2));
    }
    IEnumerator GoNextKindom(Action firstAction, Action secondAction, Action thirdAction)
    {
        firstAction.Invoke();
        yield return new WaitForSeconds(1f);
        secondAction.Invoke();
        yield return new WaitForSeconds(2f);
        thirdAction.Invoke();
    }
    */
    public void CloseInfo()
    {
        _infoContent.SetInfo(25);
        _cardMenu.SetContent(0);
    }
    public void InfoText1()
    {
        _infoContent.SetTextInfo(1);
    }
    public void InfoText2()
    {
        _infoContent.SetTextInfo(2);
    }
    public void TabViewMenu()
    {
        _viewMenu.TabVieW();
    }
    public void ButtonCloseTab()
    {
        _viewMenu.CloseTabView();
        _infoContent.SetInfo(25);
    }
    public void CloseTabViewv2()
    {
        _infoContent.SetInfo(25);
    }
    public void BackCraft()
    {
        // _cardCraftingContent.SetCrafting(25);
        _cardMenu.SetContent(0);
    }
    public void ViewKindom(int index)
    {
        //_cardCraftingContent.SetCrafting(index);
        _cardMenu.SetContent(5);
    }
    public void InfoKindom(int index)
    {
        _infoContent.SetInfo(index);
        _cardMenu.SetContent(5);
        //_cardCraftingContent.SetCrafting(25);
        InfoText1();
    }
    public void ClosingAll()
    {
        //CloseCraft();
        CloseInfoV2();
    }
    private void CloseCraft()
    {
        //_cardCraftingContent.SetCrafting(25);
    }
    private void CloseInfoV2()
    {
        _infoContent.Hide();
    }
}