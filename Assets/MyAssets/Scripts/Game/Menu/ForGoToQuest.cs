using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ForGoToQuest : MonoBehaviour
{
    [SerializeField] Animator QuestAlertModalAnim;
    [SerializeField] Text textGoQuest;
    [SerializeField] Button btnAcept;
    [SerializeField] LevelSystem levelSystem;
    void Awake()
    {
        levelSystem = FindObjectOfType<LevelSystem>();
        btnAcept.onClick.AddListener(GoToQuest);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            QuestAlertModalAnim.SetBool("alertmodal", true);
            SetMessageQuest(levelSystem.CurrentLevel);
            StartCoroutine(PauseGame());
        }
    }
    void SetMessageQuest(int _level)
    {
        Action action = _level switch
        {
            11 => () => SetText("Vegetal"),
            22 => () => SetText("Fungi"),
            33 => () => SetText("Protista"),
            44 => () => SetText("Monera"),
            55 => () => SetTextFinal(),
            _ => () => Debug.Log("Case default"),
        };
        action();
    }
    void SetText(string _text)
    {
        textGoQuest.text = "Antes de Finalizar el juego " + _text + "realiza el siguiente Quiz. \n Para guardar tu calificación.";
    }
    void SetTextFinal()
    {
        textGoQuest.text = "Antes de Finalizar el juego realiza el Quiz del Reino Monera. \n Para guardar tu calificación.";
    }
    IEnumerator PauseGame()
    {
        GeneralSingleton.generalSingleton.MouseUnLock();
        yield return new WaitForSecondsRealtime(.8f);
        Time.timeScale = 0f;
    }
    void GoToQuest()
    {
        Time.timeScale = 1f;
        GeneralSingleton.generalSingleton.isMyProfile = true;
        StartCoroutine(ChageScene());
    }
    IEnumerator ChageScene()
    {
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene(3);
    }
}