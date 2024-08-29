using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LearnedInfo : MonoBehaviour
{
    [SerializeField] Camera _camera;
    [SerializeField] InfoKindomData infoKindomData;
    [SerializeField] TextInfoAnimations textInfoAnimations;
    [SerializeField] GameObject objec3D;
    [SerializeField] CanvasGroup kingdomContent;
    [SerializeField] GameObject[] imageKingdom;
    [SerializeField] Transform transform3D;
    [SerializeField] Button btnClose, btnBack, btnInfoText1, btnInfoText2, btnKingdomContent;
    [SerializeField] Text textName, text2, textInfo, textInfo2, textTitle, textInfoKingdom;
    [SerializeField] Image topColor, contentColorItem, contentColorKingdom, contentText, btnKingdom;
    void Awake()
    {
        objec3D = GameObject.FindGameObjectWithTag("object3D").GetComponent<GameObject>();
        transform3D = GameObject.FindGameObjectWithTag("object3D").GetComponent<Transform>();
        ShowInfo(GeneralSingleton.generalSingleton._kingdomIndex);
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
        text2.text = "Vista 3D";
        switch (value)
        {
            case 0:
                ShowForKingdom(0);
                textName.text = infoKindomData.TextName[0];
                textInfo.text = infoKindomData.TextInfo[0];
                textInfo2.text = "\n Clase: Pez.\n Vive en el agua y puede respirar en ella gracias a sus branquias. \n Tipo: Vertebrado. \n tiene huesos en su cuerpo.";
                objec3D = Instantiate(infoKindomData.Kindom[0], transform3D);
                break;
            case 1:
                ShowForKingdom(0);
                textName.text = infoKindomData.TextName[1];
                textInfo.text = infoKindomData.TextInfo[1];
                textInfo2.text = "\n \n Clase: Molusco. \n Tipo: Invertebrado.\n No tiene huesos en su cuerpo.";
                objec3D = Instantiate(infoKindomData.Kindom[1], transform3D);
                break;
            case 2:
                ShowForKingdom(0);
                textName.text = infoKindomData.TextName[2];
                textInfo.text = infoKindomData.TextInfo[2];
                textInfo2.text = "\n \n Clase: Ave. \n  Tipo: Vertebrado. \n tiene huesos en su cuerpo.";
                objec3D = Instantiate(infoKindomData.Kindom[2], transform3D);
                break;
            case 3:
                ShowForKingdom(0);
                textName.text = infoKindomData.TextName[3];
                textInfo.text = infoKindomData.TextInfo[3];
                textInfo2.text = "\n \n Clase: Reptil. \n  Tipo: Vertebrado. \n tiene huesos en su cuerpo.";
                objec3D = Instantiate(infoKindomData.Kindom[3], transform3D);
                break;
            case 4:
                ShowForKingdom(0);
                textName.text = infoKindomData.TextName[4];
                textInfo.text = infoKindomData.TextInfo[4];
                textInfo2.text = "\n \n Clase: Insecto.\n Tipo: Invertebrado.\n No tiene huesos en su cuerpo.";
                objec3D = Instantiate(infoKindomData.Kindom[4], transform3D);
                break;
            case 5:
                ShowForKingdom(1);
                textName.text = infoKindomData.TextName[5];
                textInfo.text = infoKindomData.TextInfo[5];
                textInfo2.text = "\n \n Ambiente: Desiertos y áreas áridas. \n Tipo: Cactus \n ";
                objec3D = Instantiate(infoKindomData.Kindom[5], transform3D);
                break;
            case 6:
                ShowForKingdom(1);
                textName.text = infoKindomData.TextName[6];
                textInfo.text = infoKindomData.TextInfo[6];
                textInfo2.text = "\n \n Ambiente: bosques y selvas. \n Tipo: Helecho \n ";
                objec3D = Instantiate(infoKindomData.Kindom[6], transform3D);
                break;
            case 7:
                ShowForKingdom(1);
                textName.text = infoKindomData.TextName[7];
                textInfo.text = infoKindomData.TextInfo[7];
                textInfo2.text = "\n \n Ambiente: Bosques y áreas frías o templadas. \n Tipo: Cónifera \n ";
                objec3D = Instantiate(infoKindomData.Kindom[7], transform3D);
                break;
            case 8:
                ShowForKingdom(1);
                textName.text = infoKindomData.TextName[8];
                textInfo.text = infoKindomData.TextInfo[8];
                textInfo2.text = "\n \n Ambiente: Zonas templadas y cálidas. Se cultiva en huertos y jardines. \n Tipo: Arbol frutal \n ";
                objec3D = Instantiate(infoKindomData.Kindom[8], transform3D);
                break;
            case 9:
                ShowForKingdom(1);
                textName.text = infoKindomData.TextName[9];
                textInfo.text = infoKindomData.TextInfo[9];
                textInfo2.text = "\n \n Ambiente: Fondos marinos. \n Tipo: Alga Marina \n ";
                objec3D = Instantiate(infoKindomData.Kindom[9], transform3D);
                break;
            case 10:
                ShowForKingdom(2);
                textName.text = infoKindomData.TextName[10];
                textInfo.text = infoKindomData.TextInfo[10];
                textInfo2.text = "\n \n Ambiente: Lugares oscuros y humedos. \n Tipo: Comestible. \n ";
                objec3D = Instantiate(infoKindomData.Kindom[10], transform3D);
                break;
            case 11:
                ShowForKingdom(2);
                textName.text = infoKindomData.TextName[11];
                textInfo.text = infoKindomData.TextInfo[11];
                textInfo2.text = "\n \n Ambiente: En bosques, especialmente cerca de abedules y pinos. \n Tipo: Venenoso no comestible. \n ";
                objec3D = Instantiate(infoKindomData.Kindom[11], transform3D);
                break;
            case 12:
                ShowForKingdom(2);
                textName.text = infoKindomData.TextName[12];
                textInfo.text = infoKindomData.TextInfo[12];
                textInfo2.text = "\n \n Ambiente: En bosques, bajo el suelo, cerca de las raíces de ciertos árboles. \n Tipo: Comestible. \n ";
                objec3D = Instantiate(infoKindomData.Kindom[12], transform3D);
                break;
            case 13:
                ShowForKingdom(2);
                textName.text = infoKindomData.TextName[13];
                textInfo.text = infoKindomData.TextInfo[13];
                textInfo2.text = "\n \n En lugares húmedos y en alimentos en descomposición. \n Tipo: No Comestible. \n ";
                objec3D = Instantiate(infoKindomData.Kindom[13], transform3D);
                break;
            case 14:
                ShowForKingdom(2);
                textName.text = infoKindomData.TextName[14];
                textInfo.text = infoKindomData.TextInfo[14];
                textInfo2.text = "\n \n Ambiente: Está en el aire y en la piel de frutas, y se usa en la cocina. \n Tipo: Comestible. \n ";
                objec3D = Instantiate(infoKindomData.Kindom[14], transform3D);
                break;
        }
    }
    void ShowContent(int _alpha, int FOV, bool _interactible)
    {
        _camera.fieldOfView = FOV;
        kingdomContent.alpha = _alpha;
        kingdomContent.interactable = _interactible;
        kingdomContent.blocksRaycasts = _interactible;
    }
    void ShowForKingdom(int idKingdom)
    {
        switch (idKingdom)
        {
            case 0:
                textTitle.color = new Color(0, 0, 0);
                topColor.color = new Color(1, 1, 0);
                contentColorItem.color = new Color(1, 1, .8f);
                contentColorKingdom.color = new Color(1, 1, .8f);
                contentText.color = new Color(1, 1, .8f);
                btnKingdom.color = new Color(1, 1, .8f);
                textTitle.text = "Reino Animal"; SetImageK(0);
                textInfoKingdom.text = "El reino animal, también conocido como reino Animalia, es uno de los principales grupos de organismos vivos en la Tierra. Está compuesto por una amplia variedad de seres vivos, desde invertebrados como insectos y gusanos, hasta vertebrados como peces, aves, mamíferos y reptiles.";
                break;
            case 1:
                textTitle.color = new Color(1, 1, 1);
                topColor.color = new Color(0, 1, 0);
                contentColorItem.color = new Color(.8f, 1, .8f);
                contentColorKingdom.color = new Color(.8f, 1, .8f);
                contentText.color = new Color(.8f, 1, .8f);
                btnKingdom.color = new Color(.8f, 1, .8f);
                textTitle.text = "Reino Vegetal"; SetImageK(1);
                textInfoKingdom.text = "El reino vegetal está formado por plantas, como los árboles, las flores y las hierbas. Estas plantas hacen su propia comida usando la luz del sol en un proceso llamado fotosíntesis. Las plantas son muy importantes porque nos dan aire fresco para respirar y son el principio de la cadena de alimentos.";
                break;
            case 2:
                textTitle.color = new Color(1, 1, 1);
                topColor.color = new Color(1, .5f, 0);
                contentColorItem.color = new Color(1, .8f, .8f);
                contentColorKingdom.color = new Color(1, .8f, .8f);
                contentText.color = new Color(1, .8f, .8f);
                btnKingdom.color = new Color(1, .8f, .8f);
                textTitle.text = "Reino Fungi"; SetImageK(2);
                textInfoKingdom.text = "El reino fungi son diferentes de las plantas y los animales. Los hongos no hacen su propia comida como las plantas, en su lugar, obtienen nutrientes descomponiendo materia orgánica. Los hongos son útiles para descomponer cosas en la naturaleza y algunos son comestibles.";
                break;
            case 3:
                textTitle.color = new Color(1, 1, 1);
                topColor.color = new Color(0, 0, 1);
                contentColorItem.color = new Color(.8f, .8f, 1);
                contentColorKingdom.color = new Color(.8f, .8f, 1);
                contentText.color = new Color(.8f, .8f, 1);
                btnKingdom.color = new Color(.8f, .8f, 1);
                textTitle.text = "Reino Protista"; SetImageK(3);
                textInfoKingdom.text = "El reino protista es como una mezcla de diferentes tipos de seres vivos. Aquí encontramos organismos unicelulares y algunos pocos multicelulares. Los protistas viven en el agua y pueden ser muy pequeños. Los protistas son variados y únicos en su forma y forma de vida.";
                break;
            case 4:
                textTitle.color = new Color(1, 1, 1);
                topColor.color = new Color(1, 0, 0);
                contentColorItem.color = new Color(1, .8f, .8f);
                contentColorKingdom.color = new Color(1, .8f, .8f);
                contentText.color = new Color(1, .8f, .8f);
                btnKingdom.color = new Color(1, .8f, .8f);
                textTitle.text = "Reino Monera"; SetImageK(4);
                textInfoKingdom.text = "El reino monera se compone principalmente de bacterias. Estos son seres microscópicos sin núcleo definido en sus células. Las bacterias se pueden encontrar en todas partes, algunas bacterias son útiles, como las que nos ayudan a digerir los alimentos,otras pueden causar enfermedades.";
                break;
        }
    }
    private void SetImageK(int _index)
    {
        for (int i = 0; i < imageKingdom.Length; i++)
        {
            imageKingdom[i].SetActive(i == _index);
        }
    }
    void Back()
    {
        ShowContent(0, 15, false);
    }
    void Close()
    {
        GeneralSingleton.generalSingleton.iscloseInfo[GeneralSingleton.generalSingleton._kingdomIndex] = true;
        SceneManager.LoadScene(4);
    }
    void SetTextInfo(int value)
    {
        Action action = value switch
        {
            1 => () => textInfoAnimations.viewInfoText1(),
            2 => () => textInfoAnimations.viewInfoText2(),
            _ => () => textInfoAnimations.viewInfoText1(),
        };
        action();
    }
}