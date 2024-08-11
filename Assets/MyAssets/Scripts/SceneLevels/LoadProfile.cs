using UnityEngine;
using UnityEngine.UI;
public class LoadProfile : MonoBehaviour
{
    [SerializeField] ScoreAnimations[] scoreAnimations;
    [SerializeField] ProfileSystem levelSelect;
    [SerializeField] Text txtScoreA, txtScoreV, txtScoreF, txtScoreP, txtScoreM, txtFinalScore;
    public int numA, numV, numF, numP, numM, finalScore;
    void Awake()
    {
        levelSelect = FindObjectOfType<ProfileSystem>();
    }
    protected internal void GoNewProfile()
    {
        levelSelect.currentLevel = 1;
        levelSelect.ShowLevel(levelSelect.currentLevel);
        txtScoreA.text = numA.ToString();
        txtScoreV.text = numV.ToString();
        txtScoreF.text = numF.ToString();
        txtScoreP.text = numP.ToString();
        txtScoreM.text = numM.ToString();
        txtFinalScore.text = FinalScore().ToString();
        scoreAnimations[0].SwitchAnimations(numA);
        scoreAnimations[1].SwitchAnimations(numV);
        scoreAnimations[2].SwitchAnimations(numF);
        scoreAnimations[3].SwitchAnimations(numP);
        scoreAnimations[4].SwitchAnimations(numM);
        scoreAnimations[5].SwitchAnimations(finalScore);
    }
    int FinalScore()
    {
        return finalScore = (numA + numV + numF + numP + numM) / 5;
    }
    protected internal void GoLoadProfile()
    {
        PlayerData playerData = SaveAndLoadManager.LoadLevel();
        ScoreData scoreData = SaveScoreData.LoadScore();
        SettingLevelsSelect(playerData);
        SettScore(scoreData);
    }
    protected internal void SettingLevelsSelect(PlayerData playerData)
    {
        levelSelect.currentLevel = playerData.currentLevelData;
        levelSelect.ShowLevel(levelSelect.currentLevel);
        Debug.Log("LevelSelect: " + levelSelect.currentLevel);
    }
    public void SettScore(ScoreData scoreData)
    {
        numA = scoreData.scoreA;
        numV = scoreData.scoreV;
        numF = scoreData.scoreF;
        numP = scoreData.scoreP;
        numM = scoreData.scoreM;
        finalScore = scoreData.finalScore;
        txtScoreA.text = scoreData.scoreA.ToString();
        txtScoreV.text = scoreData.scoreV.ToString();
        txtScoreF.text = scoreData.scoreF.ToString();
        txtScoreP.text = scoreData.scoreP.ToString();
        txtScoreM.text = scoreData.scoreM.ToString();
        txtFinalScore.text = scoreData.finalScore.ToString();
        scoreAnimations[0].SwitchAnimations(numA);
        scoreAnimations[1].SwitchAnimations(numV);
        scoreAnimations[2].SwitchAnimations(numF);
        scoreAnimations[3].SwitchAnimations(numP);
        scoreAnimations[4].SwitchAnimations(numM);
        scoreAnimations[5].SwitchAnimations(finalScore);
        Debug.Log("score load: " + scoreData.scoreA + " " + scoreData.scoreV + " " + scoreData.scoreF + " " + scoreData.scoreP + " " + scoreData.scoreM);
    }
}