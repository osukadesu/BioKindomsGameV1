using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LearnedInfo : MonoBehaviour
{
    [SerializeField] Camera camera;
    [SerializeField] InfoViewController _infoViewController;
    [SerializeField] InfoKindomData infoKindomData;
    [SerializeField] TextInfoAnimations textInfoAnimations;
    [SerializeField] GameObject objec3D;
    [SerializeField] CanvasGroup kingdomContent;
    [SerializeField] GameObject[] imageKingdom;
    [SerializeField] Transform transform3D;
    [SerializeField] Button btnClose, btnBack, btnInfoText1, btnInfoText2, btnKingdomContent;
    // [SerializeField] Button[] btnInfo;
    [SerializeField] Text textName, text2, textInfo, textInfo2, textTitle, textInfoKingdom;
    void Awake()
    {
        _infoViewController = FindObjectOfType<InfoViewController>();
        objec3D = GameObject.FindGameObjectWithTag("object3D").GetComponent<GameObject>();
        transform3D = GameObject.FindGameObjectWithTag("object3D").GetComponent<Transform>();
        ShowInfo(_infoViewController._kingdomIndex);
        ButtonsOnclick();
    }
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        ShowContent(0, 15, false);
    }
    void ButtonsOnclick()
    {
        btnInfoText1.onClick.AddListener(() => SetTextInfo(1));
        btnInfoText2.onClick.AddListener(() => SetTextInfo(2));
        btnClose.onClick.AddListener(Close);
        btnBack.onClick.AddListener(Back);
        btnKingdomContent.onClick.AddListener(() => ShowContent(1, 80, true));
    }
    void ShowInfo(int value)
    {
        switch (value)
        {
            case 0:
                ShowForKingdom(0);
                textName.text = "Carpa Asiática Dorada";
                text2.text = "Vista 3D";
                textInfo.text = "La carpa asiática dorada es como una celebridad entre los peces, con colores súper brillantes. Les encanta nadar en estanques y lucirse. Aunque son originarias de Asia, a veces las llevamos a otros lugares para que más personas las conozcan.";
                textInfo2.text = "\n Clase: Pez.\n Vive en el agua y puede respirar en ella gracias a sus branquias. \n Tipo: Vertebrado. \n tiene huesos en su cuerpo.";
                objec3D = Instantiate(infoKindomData.Kindom[0], transform3D);
                break;
            case 1:
                ShowForKingdom(0);
                textName.text = "Chipichipi";
                text2.text = "Vista 3D";
                textInfo.text = "El chipichipi es un molusco pequeñito que vive en el mar, es como el tesoro escondido de la arena. Estos diminutos amigos tienen conchas lindas y pueden enterrarse en la playa. Si alguna vez estás construyendo castillos de arena puede que encuentres uno.";
                textInfo2.text = "\n \n Clase: Molusco. \n Tipo: Invertebrado.\n No tiene huesos en su cuerpo.";
                objec3D = Instantiate(infoKindomData.Kindom[1], transform3D);
                break;
            case 2:
                ShowForKingdom(0);
                textName.text = "Colibrí de Mulsant";
                text2.text = "Vista 3D";
                textInfo.text = "El colibrí de Mulsant es un ave diminuto y brillante. Como un pequeño arco iris con alas, le encanta chupar néctar de las flores. A menudo se encuentran en zonas montañosas de América del Sur y América Central. ¡Es como una bailarina mágica del aire!";
                textInfo2.text = "\n \n Clase: Ave. \n  Tipo: Vertebrado. \n tiene huesos en su cuerpo.";
                objec3D = Instantiate(infoKindomData.Kindom[2], transform3D);
                break;
            case 3:
                ShowForKingdom(0);
                textName.text = "Iguana Verde";
                text2.text = "Vista 3D";
                textInfo.text = "La iguana verde es como el dinosaurio pequeño de los días modernos. Vive en lugares cálidos, es buena escaladora de árboles, se broncea todo el día y tiene una cola larga. Con su piel verde, es como una supermodelo de la selva.";
                textInfo2.text = "\n \n Clase: Reptil. \n  Tipo: Vertebrado. \n tiene huesos en su cuerpo.";
                objec3D = Instantiate(infoKindomData.Kindom[3], transform3D);
                break;
            case 4:
                ShowForKingdom(0);
                textName.text = "Mariposa Monarca";
                text2.text = "Vista 3D";
                textInfo.text = "La mariposa monarca es como la reina de las mariposas cada año viajan muy lejos cruzando paises, Son como pequeñas exploradoras con alas mágicas. Además, es famosa por sus colores naranjas y negros. ¡Una verdadera belleza voladora";
                textInfo2.text = "\n \n Clase: Insecto.\n Tipo: Invertebrado.\n No tiene huesos en su cuerpo.";
                objec3D = Instantiate(infoKindomData.Kindom[4], transform3D);
                break;
            case 5:
                /*
                ShowForKingdom(0);
                Destroy(objec3D);
                textName.text = "";
                text2.text = "";
                textInfo.text = "";
                */
                break;
        }
    }
    void ShowContent(int _alpha, int FOV, bool _interactible)
    {
        camera.fieldOfView = FOV;
        kingdomContent.alpha = _alpha;
        kingdomContent.interactable = _interactible;
        kingdomContent.blocksRaycasts = _interactible;
    }
    void ShowForKingdom(int idKingdom)
    {
        switch (idKingdom)
        {
            case 0:
                textTitle.text = "Reino Animal"; SetImageK(0);
                textInfoKingdom.text = "El reino animal, también conocido como reino Animalia, es uno de los principales grupos de organismos vivos en la Tierra. Está compuesto por una amplia variedad de seres vivos, desde invertebrados como insectos y gusanos, hasta vertebrados como peces, aves, mamíferos y reptiles.";
                break;
            case 1:
                textTitle.text = "Reino Vegetal"; SetImageK(1);
                textInfoKingdom.text = "El reino vegetal está formado por plantas, como los árboles, las flores y las hierbas. Estas plantas hacen su propia comida usando la luz del sol en un proceso llamado fotosíntesis. Las plantas son muy importantes porque nos dan aire fresco para respirar y son el principio de la cadena de alimentos.";
                break;
            case 2:
                textTitle.text = "Reino Fungi"; SetImageK(2);
                textInfoKingdom.text = "El reino fungi son diferentes de las plantas y los animales. Los hongos no hacen su propia comida como las plantas, en su lugar, obtienen nutrientes descomponiendo materia orgánica. Los hongos son útiles para descomponer cosas en la naturaleza y algunos son comestibles.";
                break;
            case 3:
                textTitle.text = "Reino Protista"; SetImageK(3);
                textInfoKingdom.text = "El reino protista es como una mezcla de diferentes tipos de seres vivos. Aquí encontramos organismos unicelulares y algunos pocos multicelulares. Los protistas viven en el agua y pueden ser muy pequeños. Los protistas son variados y únicos en su forma y forma de vida.";
                break;
            case 4:
                textTitle.text = "Reino Monera"; SetImageK(4);
                textInfoKingdom.text = "El reino monera se compone principalmente de bacterias. Estos son seres microscópicos sin núcleo definido en sus células. Las bacterias se pueden encontrar en todas partes, algunas bacterias son útiles, como las que nos ayudan a digerir los alimentos,otras pueden causar enfermedades.";
                break;
        }
    }
    private void SetImageK(int _index)
    {
        switch (_index)
        {
            case 0:
                imageKingdom[0].SetActive(true);
                imageKingdom[1].SetActive(false);
                imageKingdom[2].SetActive(false);
                imageKingdom[3].SetActive(false);
                imageKingdom[4].SetActive(false);
                break;
            case 1:
                imageKingdom[0].SetActive(false);
                imageKingdom[1].SetActive(true);
                imageKingdom[2].SetActive(false);
                imageKingdom[3].SetActive(false);
                imageKingdom[4].SetActive(false);
                break;
            case 2:
                imageKingdom[0].SetActive(false);
                imageKingdom[1].SetActive(false);
                imageKingdom[2].SetActive(true);
                imageKingdom[3].SetActive(false);
                imageKingdom[4].SetActive(false);
                break;
            case 3:
                imageKingdom[0].SetActive(false);
                imageKingdom[1].SetActive(false);
                imageKingdom[2].SetActive(false);
                imageKingdom[3].SetActive(true);
                imageKingdom[4].SetActive(false);
                break;
            case 4:
                imageKingdom[0].SetActive(false);
                imageKingdom[1].SetActive(false);
                imageKingdom[2].SetActive(false);
                imageKingdom[3].SetActive(false);
                imageKingdom[4].SetActive(true);
                break;
        }
    }
    void Back()
    {
        ShowContent(0, 15, false);
    }
    void Close()
    {
        SceneManager.LoadScene(4);
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