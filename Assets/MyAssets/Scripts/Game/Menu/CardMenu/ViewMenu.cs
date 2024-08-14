using UnityEngine;
using UnityEngine.UI;
public class ViewMenu : MonoBehaviour
{
    [SerializeField] CanvasManager _canvasManager;
    [SerializeField] MouseController mouseController;
    [SerializeField] Animator animTabView;
    [SerializeField] bool active;
    [SerializeField] Button btnClose;
    [SerializeField] protected Text messageText;
    [SerializeField] Text textTab;
    void Awake()
    {
        mouseController = FindObjectOfType<MouseController>();
        messageText = GameObject.FindGameObjectWithTag("txtGral").GetComponent<Text>();
        animTabView = GameObject.FindGameObjectWithTag("cardMenuAnim").GetComponent<Animator>();
        btnClose = GameObject.FindGameObjectWithTag("btnClose").GetComponent<Button>();
        btnClose.onClick.AddListener(() => _canvasManager.ButtonCloseTab());
        messageText.color = new Color(0f, .5f, 1f, 1f);
    }
    void Start()
    {
        active = false;
    }
    void Update()
    {
        _canvasManager.TabViewMenu();
        textTab.text = "Presiona \"Tab\" para activar el mouse!";
    }
    public void Configure(CanvasManager canvasManager)
    {
        _canvasManager = canvasManager;
    }
    public void TabVieW()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            mouseController.MouseUnLock();
            /*
            active = !active;
            animTabView.SetBool("tabview", active);
            if (!active)
            {
                messageText.color = new Color(0f, .5f, 1f, 1f);
                _canvasManager.CloseTabViewv2();
                mouseController.MouseLock();
            }
            else
            {
                messageText.color = new Color(0f, 0f, 0f, 0f);
                _canvasManager.ButtonGoKindomV2(0);
                mouseController.MouseUnLock();
            }
            */
        }
    }
    public void CloseTabView()
    {
        animTabView.SetBool("tabview", false);
        messageText.color = new Color(0f, .5f, 1f, 1f);
        mouseController.MouseLock();
    }
}