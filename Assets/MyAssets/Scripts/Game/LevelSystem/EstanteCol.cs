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
            (canpressG, canpressF) = referenceItem.itemIsCheck ? (true, false) : (false, true);
            SetInfo(referenceItem.itemIsCheck ? 1 : 2);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(WaitForHideText()); canpressG = false; canpressF = false;
        }
    }
    public void SetInfo(int value)
    {
        switch (value)
        {
            case 1:
                textMessage = "Presiona la tecla 'G' para ver la reliquia.";
                break;
            case 2:
                textMessage = "Presiona la tecla 'F' y recupera la reliquia.";
                break;
        }
        textInfo.ShowText(textMessage);
    }
    IEnumerator WaitForHideText()
    {
        yield return new WaitForSeconds(.5f);
        textInfo.HideText();
    }
}