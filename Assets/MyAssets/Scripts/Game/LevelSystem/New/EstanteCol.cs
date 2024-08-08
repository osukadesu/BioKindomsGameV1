using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EstanteCol : MonoBehaviour
{
    [SerializeField] LevelSystemV2 levelSystemV2;
    [SerializeField] InventoryItemDataV2 referenceItem;
    [SerializeField] TextGralController textInfo;
    [SerializeField] InfoViewController infoViewController;
    string textMessage;
    public int id;
    [SerializeField] bool canpressG, canpressF;
    void Awake()
    {
        levelSystemV2 = FindObjectOfType<LevelSystemV2>();
        infoViewController = FindObjectOfType<InfoViewController>();
    }
    void Update()
    {
        if (canpressF)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                canpressF = false;
                levelSystemV2.ChangeLevel();
            }
        }
        if (canpressG)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                canpressG = false;
                infoViewController._kingdomIndex = id;
                SceneManager.LoadScene(6);
            }
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (referenceItem.itemIsCheck)
            {
                SetInfo(1); canpressG = true;
            }
            else
            {
                SetInfo(2); canpressF = true;
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            textInfo.HideText(); canpressG = false; canpressF = false;
        }
    }
    public void SetInfo(int value)
    {
        switch (value)
        {
            case 1:
                textMessage = "Presiona la tecla 'G' para ver la reliquia.";
                StartCoroutine(IETextShow(textMessage));
                break;
            case 2:
                textMessage = "Presiona la tecla 'F' y recupera la reliquia.";
                StartCoroutine(IETextShow(textMessage));
                break;
        }
    }
    IEnumerator IETextShow(string text)
    {
        textInfo.ShowText(text);
        yield return new WaitForSeconds(4f);
        textInfo.HideText();
    }
}