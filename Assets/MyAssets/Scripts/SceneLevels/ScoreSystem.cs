using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ScoreSystem : MonoBehaviour
{
    [SerializeField] Button btnInfo;
    [SerializeField] Text txtScores, txtFinalScore;
    [SerializeField] int scoreAnimal, finalScore;
    void Awake()
    {
        btnInfo.onClick.AddListener(() => GoInfo());
    }
    void Start()
    {
        scoreAnimal = 0;
        finalScore = scoreAnimal / 1;
        txtScores.text = "Puntaje Acumulado = " + scoreAnimal;
        txtFinalScore.text = "Puntaje Final = " + finalScore;
    }
    void GoInfo()
    {
        SceneManager.LoadScene(5);
    }
}
/*
void GoInfo(int _btnId)
    {
        menuController._btnId = _btnId switch
        {
            0 => 0,
            1 => 1,
            2 => 2,
            3 => 3,
            4 => 4,
            _ => 0,
        };
        menuController.IsInfo = true;
        SceneManager.LoadScene(3);
    }
*/