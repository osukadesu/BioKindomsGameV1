using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LearnedInfo : MonoBehaviour
{
    [SerializeField] InfoKindomData infoKindomData;
    [SerializeField] TextInfoAnimations textInfoAnimations;
    [SerializeField] GameObject cardContent, cardInfo, objec3D;
    [SerializeField] Transform transform3D;
    [SerializeField] Button btnClose, btnBack, btnInfoText1, btnInfoText2;
    [SerializeField] Button[] btnInfo;
    [SerializeField] Text textName, text2, textInfo, textInfo2;
    void Awake()
    {
        objec3D = GameObject.FindGameObjectWithTag("object3D").GetComponent<GameObject>();
        transform3D = GameObject.FindGameObjectWithTag("object3D").GetComponent<Transform>();
        for (int i = 0; i < btnInfo.Length; i++)
        {
            int buttonNumber = i;
            btnInfo[i].onClick.AddListener(() => ShowInfo(buttonNumber));
        }
        ButtonsOnclick();
    }
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        ShowContent();
    }
    void ButtonsOnclick()
    {
        btnInfoText1.onClick.AddListener(() => SetTextInfo(1));
        btnInfoText2.onClick.AddListener(() => SetTextInfo(2));
        btnClose.onClick.AddListener(Close);
        btnBack.onClick.AddListener(Back);
    }
    void ShowInfo(int value)
    {
        cardInfo.SetActive(true);
        cardContent.SetActive(false);
        switch (value)
        {
            case 0:
                textName.text = "Carpa Asiática Dorada";
                text2.text = "Vista 3D";
                textInfo.text = "La carpa asiática dorada es como una celebridad entre los peces, con colores súper brillantes. Les encanta nadar en estanques y lucirse. Aunque son originarias de Asia, a veces las llevamos a otros lugares para que más personas las conozcan.";
                textInfo2.text = "\n Clase: Pez.\n Vive en el agua y puede respirar en ella gracias a sus branquias. \n Tipo: Vertebrado. \n tiene huesos en su cuerpo.";
                objec3D = Instantiate(infoKindomData.Kindom[0], transform3D);
                break;
            case 1:
                textName.text = "Chipichipi";
                text2.text = "Vista 3D";
                textInfo.text = "El chipichipi es un molusco pequeñito que vive en el mar, es como el tesoro escondido de la arena. Estos diminutos amigos tienen conchas lindas y pueden enterrarse en la playa. Si alguna vez estás construyendo castillos de arena puede que encuentres uno.";
                textInfo2.text = "\n \n Clase: Molusco. \n Tipo: Invertebrado.\n No tiene huesos en su cuerpo.";
                objec3D = Instantiate(infoKindomData.Kindom[1], transform3D);
                break;
            case 2:
                textName.text = "Colibrí de Mulsant";
                text2.text = "Vista 3D";
                textInfo.text = "El colibrí de Mulsant es un ave diminuto y brillante. Como un pequeño arco iris con alas, le encanta chupar néctar de las flores. A menudo se encuentran en zonas montañosas de América del Sur y América Central. ¡Es como una bailarina mágica del aire!";
                textInfo2.text = "\n \n Clase: Ave. \n  Tipo: Vertebrado. \n tiene huesos en su cuerpo.";
                objec3D = Instantiate(infoKindomData.Kindom[2], transform3D);
                break;
            case 3:
                textName.text = "Iguana Verde";
                text2.text = "Vista 3D";
                textInfo.text = "La iguana verde es como el dinosaurio pequeño de los días modernos. Vive en lugares cálidos, es buena escaladora de árboles, se broncea todo el día y tiene una cola larga. Con su piel verde, es como una supermodelo de la selva.";
                textInfo2.text = "\n \n Clase: Reptil. \n  Tipo: Vertebrado. \n tiene huesos en su cuerpo.";
                objec3D = Instantiate(infoKindomData.Kindom[3], transform3D);
                break;
            case 4:
                textName.text = "Mariposa Monarca";
                text2.text = "Vista 3D";
                textInfo.text = "La mariposa monarca es como la reina de las mariposas cada año viajan muy lejos cruzando paises, Son como pequeñas exploradoras con alas mágicas. Además, es famosa por sus colores naranjas y negros. ¡Una verdadera belleza voladora";
                textInfo2.text = "\n \n Clase: Insecto.\n Tipo: Invertebrado.\n No tiene huesos en su cuerpo.";
                objec3D = Instantiate(infoKindomData.Kindom[4], transform3D);
                break;
            case 5:
                Destroy(objec3D);
                textName.text = "";
                text2.text = "";
                textInfo.text = "";
                break;
        }
    }
    void ShowContent()
    {
        cardContent.SetActive(true);
        cardInfo.SetActive(false);
    }
    void Back()
    {
        ShowInfo(5);
        ShowContent();
    }
    void Close()
    {
        SceneManager.LoadScene(2);
    }
    void SetTextInfo(int value)
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
/*
void ShowInfo(int infoId)
    {
        cardInfo.SetActive(true);
        switch (infoId)
        {
            case 0:
                txtTitle.text = "Reino Animal";
                txtInfo.text = "Reino Animal";
                break;
            case 1:
                txtTitle.text = "Reino Vegetal";
                txtInfo.text = "Reino Vegetal";
                break;
            case 2:
                txtTitle.text = "Reino Fungi";
                txtInfo.text = "Reino Fungi";
                break;
            case 3:
                txtTitle.text = "Reino Protista";
                txtInfo.text = "Reino Protista"; ;
                break;
            case 4:
                txtTitle.text = "Reino Monera";
                txtInfo.text = "Reino Monera";
                break;
        }
    }
*/