using UnityEngine;
using UnityEngine.UI;
public class InfoContent : MonoBehaviour
{
    //Deprecated
    [SerializeField] CanvasGroup canvasGroup;
    [SerializeField] InfoKindomData infoKindomData;
    [SerializeField] TextInfoAnimations textInfoAnimations;
    [SerializeField] CanvasManager _canvasManager;
    [SerializeField] GameObject objec3D;
    [SerializeField] Transform transform3D;
    [SerializeField] Text textName;
    [SerializeField] Text text2;
    [SerializeField] Text textInfo, textInfo2;
    [SerializeField] Button btnInfoText1, btnInfoText2, btnBackInfo;
    [SerializeField] Button[] btnInfoKindom;
    void Awake()
    {
        objec3D = GameObject.FindGameObjectWithTag("object3D").GetComponent<GameObject>();
        transform3D = GameObject.FindGameObjectWithTag("object3D").GetComponent<Transform>();
        ButtonsOnclick();
    }
    void Start()
    {
        Hide();
    }
    void Update()
    {
        FindBtns();
    }
    void ButtonsOnclick()
    {
        btnInfoText1.onClick.AddListener(() => _canvasManager.InfoText1());
        btnInfoText2.onClick.AddListener(() => _canvasManager.InfoText2());
        btnBackInfo.onClick.AddListener(() => _canvasManager.CloseInfo());
    }
    void FindBtns()
    {
        GameObject[] btnInfoObjects = GameObject.FindGameObjectsWithTag("btnInfo");
        btnInfoKindom = new Button[btnInfoObjects.Length];
        for (int i = 0; i < btnInfoObjects.Length; i++)
        {
            btnInfoKindom[i] = btnInfoObjects[i].GetComponent<Button>();
            int buttonNumber = i;
            btnInfoKindom[i].onClick.AddListener(() => _canvasManager.InfoKindom(buttonNumber));
        }
    }
    public void Configure(CanvasManager canvasManager)
    {
        _canvasManager = canvasManager;
    }
    public void Show()
    {
        canvasGroup.alpha = 1; canvasGroup.interactable = true; canvasGroup.blocksRaycasts = true;
    }
    public void Hide()
    {
        canvasGroup.alpha = 0; canvasGroup.interactable = false; canvasGroup.blocksRaycasts = false;
    }
    public void SetInfo(int value)
    {
        if (objec3D == null)
        {
            switch (value)
            {
                case 0:
                    Show();
                    textName.text = "Carpa Asiática Dorada";
                    text2.text = "Vista 3D";
                    textInfo.text = "La carpa asiática dorada es como una celebridad entre los peces, con colores súper brillantes. Les encanta nadar en estanques y lucirse. Aunque son originarias de Asia, a veces las llevamos a otros lugares para que más personas las conozcan.";
                    textInfo2.text = "\n Clase: Pez.\n Vive en el agua y puede respirar en ella gracias a sus branquias. \n Tipo: Vertebrado. \n tiene huesos en su cuerpo.";
                    objec3D = Instantiate(infoKindomData.Kindom[0], transform3D);
                    break;
                case 1:
                    Show();
                    textName.text = "Chipichipi";
                    text2.text = "Vista 3D";
                    textInfo.text = "El chipichipi es un molusco pequeñito que vive en el mar, es como el tesoro escondido de la arena. Estos diminutos amigos tienen conchas lindas y pueden enterrarse en la playa. Si alguna vez estás construyendo castillos de arena puede que encuentres uno.";
                    textInfo2.text = "\n \n Clase: Molusco. \n Tipo: Invertebrado.\n No tiene huesos en su cuerpo.";
                    objec3D = Instantiate(infoKindomData.Kindom[1], transform3D);
                    break;
                case 2:
                    Show(); textName.text = "Colibrí de Mulsant";
                    text2.text = "Vista 3D";
                    textInfo.text = "El colibrí de Mulsant es un ave diminuto y brillante. Como un pequeño arco iris con alas, le encanta chupar néctar de las flores. A menudo se encuentran en zonas montañosas de América del Sur y América Central. ¡Es como una bailarina mágica del aire!";
                    textInfo2.text = "\n \n Clase: Ave. \n  Tipo: Vertebrado. \n tiene huesos en su cuerpo.";
                    objec3D = Instantiate(infoKindomData.Kindom[2], transform3D);
                    break;
                case 3:
                    Show();
                    textName.text = "Iguana Verde";
                    text2.text = "Vista 3D";
                    textInfo.text = "La iguana verde es como el dinosaurio pequeño de los días modernos. Vive en lugares cálidos, es buena escaladora de árboles, se broncea todo el día y tiene una cola larga. Con su piel verde, es como una supermodelo de la selva.";
                    textInfo2.text = "\n \n Clase: Reptil. \n  Tipo: Vertebrado. \n tiene huesos en su cuerpo.";
                    objec3D = Instantiate(infoKindomData.Kindom[3], transform3D);
                    break;
                case 4:
                    Show();
                    textName.text = "Mariposa Monarca";
                    text2.text = "Vista 3D";
                    textInfo.text = "La mariposa monarca es como la reina de las mariposas cada año viajan muy lejos cruzando paises, Son como pequeñas exploradoras con alas mágicas. Además, es famosa por sus colores naranjas y negros. ¡Una verdadera belleza voladora";
                    textInfo2.text = "\n \n Clase: Insecto.\n Tipo: Invertebrado.\n No tiene huesos en su cuerpo.";
                    objec3D = Instantiate(infoKindomData.Kindom[4], transform3D);
                    break;
                case 5:
                    Show();
                    textName.text = "Vegetal1";
                    text2.text = "Vista 3D";
                    textInfo.text = "Info";
                    //objec3D = infoKindomData.Vegetal1;
                    break;
                case 6:
                    Show();
                    textName.text = "Vegetal2";
                    text2.text = "Vista 3D";
                    textInfo.text = "Info";
                    //objec3D = infoKindomData.Vegetal2;
                    break;
                case 7:
                    Show();
                    textName.text = "Vegetal3";
                    text2.text = "Vista 3D";
                    textInfo.text = "Info";
                    //objec3D = infoKindomData.Vegetal3;
                    break;
                case 8:
                    Show();
                    textName.text = "Vegetal4";
                    text2.text = "Vista 3D";
                    textInfo.text = "Info";
                    //objec3D = infoKindomData.Vegetal4;
                    break;
                case 9:
                    Show();
                    textName.text = "Vegetal5";
                    text2.text = "Vista 3D";
                    textInfo.text = "Info";
                    //objec3D = infoKindomData.Vegetal5;
                    break;
                case 10:
                    Show();
                    textName.text = "Fungi1";
                    text2.text = "Vista 3D";
                    textInfo.text = "Info";
                    //objec3D = infoKindomData.Fungi1;
                    break;
                case 11:
                    Show();
                    textName.text = "Fungi2";
                    text2.text = "Vista 3D";
                    textInfo.text = "Info";
                    //objec3D = infoKindomData.Fungi2;
                    break;
                case 12:
                    Show();
                    textName.text = "Fungi3";
                    text2.text = "Vista 3D";
                    textInfo.text = "Info";
                    //objec3D = infoKindomData.Fungi3;
                    break;
                case 13:
                    Show();
                    textName.text = "Fungi4";
                    text2.text = "Vista 3D";
                    textInfo.text = "Info";
                    //objec3D = infoKindomData.Fungi4;
                    break;
                case 14:
                    Show();
                    textName.text = "Fungi5";
                    text2.text = "Vista 3D";
                    textInfo.text = "Info";
                    //objec3D = infoKindomData.Fungi5;
                    break;
                case 15:
                    Show();
                    textName.text = "Protista1";
                    text2.text = "Vista 3D";
                    textInfo.text = "Info";
                    //objec3D = infoKindomData.Protista1;
                    break;
                case 16:
                    Show();
                    textName.text = "Protista2";
                    text2.text = "Vista 3D";
                    textInfo.text = "Info";
                    // objec3D = infoKindomData.Protista2;
                    break;
                case 17:
                    Show();
                    textName.text = "Protista3";
                    text2.text = "Vista 3D";
                    textInfo.text = "Info";
                    //objec3D= infoKindomData.Protista3;
                    break;
                case 18:
                    Show();
                    textName.text = "Protista4";
                    text2.text = "Vista 3D";
                    textInfo.text = "Info";
                    //objec3D= infoKindomData.Protista4;
                    break;
                case 19:
                    Show();
                    textName.text = "Protista5";
                    text2.text = "Vista 3D";
                    textInfo.text = "Info";
                    //objec3D = infoKindomData.Protista5;
                    break;
                case 20:
                    Show();
                    textName.text = "Monera1";
                    text2.text = "Vista 3D";
                    textInfo.text = "Info";
                    //objec3D = infoKindomData.Monera1;
                    break;
                case 21:
                    Show();
                    textName.text = "Monera2";
                    text2.text = "Vista 3D";
                    textInfo.text = "Info";
                    //objec3D = infoKindomData.Monera2;
                    break;
                case 22:
                    Show();
                    textName.text = "Monera3";
                    text2.text = "Vista 3D";
                    textInfo.text = "Info";
                    //objec3D = infoKindomData.Monera3;
                    break;
                case 23:
                    Show();
                    textName.text = "Monera4";
                    text2.text = "Vista 3D";
                    textInfo.text = "Info";
                    //objec3D= infoKindomData.Monera4;
                    break;
                case 24:
                    Show();
                    textName.text = "Monera5";
                    text2.text = "Vista 3D";
                    textInfo.text = "Info";
                    //objec3D = infoKindomData.Monera5;
                    break;
                case 25:
                    Hide();
                    textName.text = "";
                    text2.text = "";
                    textInfo.text = "";
                    break;
                default:
                    Hide();
                    textName.text = "";
                    text2.text = "";
                    textInfo.text = "";
                    break;
            }
        }
        if (objec3D != null && value == 25)
        {
            Destroy(objec3D);
        }
    }
    public void SetTextInfo(int value)
    {
        switch (value)
        {
            case 1:
                textInfoAnimations.viewInfoText1();
                break;
            case 2:
                textInfoAnimations.viewInfoText2();
                break;
            default:
                textInfoAnimations.viewInfoText1();
                break;
        }
    }
}