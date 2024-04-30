using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ScoreSystem : MonoBehaviour
{
    [SerializeField] Button btnInfo;
    [SerializeField] Text txtFinalScore, txtPF;
    [SerializeField] protected internal int finalScore;
    [SerializeField] protected internal bool questFinished;
    void Awake()
    {
        btnInfo.onClick.AddListener(() => GoInfo());
    }
    void Start()
    {
        finalScore = 0;
        txtFinalScore.text = "P.F";
    }
    void Update()
    {
        txtPF.text = finalScore.ToString();
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            finalScore = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            finalScore = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            finalScore = 3;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            finalScore = 4;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            finalScore = 5;
        }
        if (finalScore > 2)
        {
            questFinished = true;
        }
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