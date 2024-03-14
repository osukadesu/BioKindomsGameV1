using UnityEngine;
using UnityEngine.UI;
public class CraftBuilderSystem : MonoBehaviour
{
    [SerializeField] CanvasManager _canvasManager;
    [SerializeField] InventoryItemData[] _inventoryItemDatas;
    public InventoryItemData[] _InventoryItemDatas { get => _inventoryItemDatas; set => _inventoryItemDatas = value; }
    [SerializeField] GameObject[] imageHide;
    [SerializeField] Button[] btnBuilder, btnItemCraft, btnInfo;
    [SerializeField] Animator[] animCheck, animInfo, animFillImgItem, animUnLock, animBtnItemCraft;
    [SerializeField] bool[] isCreated;
    public bool[] IsCreated { get => isCreated; set => isCreated = value; }
    public void Configure(CanvasManager canvasManager)
    {
        _canvasManager = canvasManager;
    }
    void Awake()
    {
        InicialState();
        ButtonsOnclick();
    }
    void ButtonsOnclick()
    {
        for (int i = 0; i < 5; i++)
        {
            int buttonNumber = i;
            btnBuilder[i].onClick.AddListener(() => _canvasManager.CraftItem(buttonNumber));
        }
    }
    void InicialState()
    {
        for (int i = 0; i < 5; i++)
        {
            isCreated[i] = false;
            btnInfo[i].enabled = false;
            btnBuilder[i].enabled = false;
            btnItemCraft[i].enabled = true;
            animCheck[i].SetBool("check", false);
            animInfo[i].SetBool("btninfoview", false);
            animUnLock[i].SetBool("itemunlock", false);
            animFillImgItem[i].SetBool("fillimgitem", false);
            animBtnItemCraft[i].SetBool("fillBtnItemCraft", false);
        }
        for (int i = 0; i < imageHide.Length; i++)
        {
            imageHide[i].SetActive(true);
        }
    }
    void Update()
    {
        UnlockBuildAll();
    }
    public void UnlockBuildAll()
    {
        for (int i = 0; i < 25; i++)
        {
            int btnIndex = i / 5;
            if (_inventoryItemDatas[i].itemIsCheck)
            {
                btnBuilder[btnIndex].enabled = true;
            }
            else
            {
                btnBuilder[btnIndex].enabled = false;
            }
        }
    }
    public void ButtonBuildItem(int index)
    {
        btnInfo[index].enabled = true;
        btnBuilder[index].enabled = false;
        btnItemCraft[index].enabled = false;
        animCheck[index].SetBool("check", true);
        animInfo[index].SetBool("btninfoview", true);
        animFillImgItem[index].SetBool("fillimgitem", true);
        isCreated[index] = true;
        animUnLock[index].SetBool("itemunlock", true);
        imageHide[index].SetActive(false);
        animBtnItemCraft[index].SetBool("fillBtnItemCraft", true);
    }
    /*
     public void ButtonBuildItem5()
     {
         btnBuilder[4].interactable = false;
         btnItemCraft[4].interactable = false;
         animCheck[4].SetBool("check", true);
         animInfo[4].SetBool("btninfoview", true);
         animFillImgItem[4].SetBool("fillimgitem", true);
         isCreated[4] = true;
         StartCoroutine(NextKindomDelay());
     }
     IEnumerator NextKindomDelay()
     {
         yield return new WaitForSeconds(1f);
         animUnLock[4].SetBool("itemunlock", true);
         imageHide[4].SetActive(false);
     }
    */
}