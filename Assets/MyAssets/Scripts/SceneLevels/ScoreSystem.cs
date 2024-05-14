using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ScoreSystem : MonoBehaviour
{
    [SerializeField] Button btnInfoGo;
    [SerializeField] Text txtFinalScore;
    [SerializeField] protected internal int finalScore;
    [SerializeField] protected internal bool questFinished;
    void Awake()
    {
        btnInfoGo.onClick.AddListener(() => GoInfo());
    }
    void Start()
    {
        finalScore = 0;
        txtFinalScore.text = "P.F";
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