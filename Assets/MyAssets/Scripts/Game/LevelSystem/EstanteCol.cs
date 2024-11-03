using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class EstanteCol : MonoBehaviour
{
    [SerializeField] LevelSystem levelSystemV2;
    [SerializeField] InventoryItemDataV2 referenceItem;
    [SerializeField] Animator txtAnim;
    [SerializeField] Text textGral;
    string textMessage;
    public int id;
    [SerializeField] public bool canpressG, canpressF;
    void Awake() => levelSystemV2 = FindObjectOfType<LevelSystem>();
    void Update()
    {
        if (canpressF)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                canpressF = false;
                levelSystemV2.ChangeLevel();
                HideText();
                GeneralSingleton.generalSingleton._kingdomIndex = id;
            }
        }
        if (canpressG)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                canpressG = false;
                GeneralSingleton.generalSingleton._kingdomIndex = id;
                SceneManager.LoadScene(6);
                HideText();
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
        Action action = value switch
        {
            1 => () => { textMessage = "Presiona 'G'."; ShowText(textMessage); }
            ,
            2 => () => { textMessage = "Presiona 'F'."; ShowText(textMessage); }
            ,
            _ => () => Debug.Log("Default case!"),
        };
        action();
    }
    IEnumerator WaitForHideText()
    {
        yield return new WaitForSeconds(.2f);
        HideText();
    }
    public void ShowText(string message)
    {
        textGral.text = message;
        txtAnim.SetBool("uiInteraction", true);
    }
    public void HideText()
    {
        textGral.text = "";
        txtAnim.SetBool("uiInteraction", false);
    }
}