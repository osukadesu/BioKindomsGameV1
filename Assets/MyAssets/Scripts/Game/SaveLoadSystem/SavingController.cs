using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SavingController : MonoBehaviour
{
    [SerializeField] SaveMethod saveMethod;
    [SerializeField] GameObject SavingBackground;
    [SerializeField] protected MenuController menuController;
    void Awake()
    {
        menuController = FindObjectOfType<MenuController>();
        saveMethod = FindObjectOfType<SaveMethod>();
        if (menuController.IsSavingGame)
        {
            StartCoroutine(SavingGame());
        }
    }
    void Start()
    {
        SavingBackground.SetActive(false);
    }
    IEnumerator SavingGame()
    {
        SavingBackground.SetActive(true);
        saveMethod.SaveGame();
        yield return new WaitForSeconds(1f);
        SavingBackground.SetActive(false);
        SceneManager.LoadScene(1);
    }
}