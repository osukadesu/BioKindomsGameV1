using UnityEngine;
public class NextLevel : MonoBehaviour
{
    [SerializeField] GameObject[] nextLevel;
    [SerializeField] Animator nextLevelAnim;
    [SerializeField] LoadLevelSystem loadLevelSystem;
    [SerializeField] LevelSystem levelSystem;
    void Awake()
    {
        levelSystem = FindObjectOfType<LevelSystem>();
        loadLevelSystem = FindObjectOfType<LoadLevelSystem>();
    }
    void Update()
    {
        NextLevelWin(levelSystem.CurrentLevel);
    }
    protected internal void NextLevelWin(int level)
    {
        switch (level)
        {
            case 3:
                ItemCondition(0);
                break;
            case 4:
                ItemConditionV2(0, 1);
                break;
            case 5:
                ItemCondition(1);
                break;
            case 6:
                ItemConditionV2(1, 2);
                break;
            case 7:
                ItemCondition(2);
                break;
            case 8:
                ItemConditionV2(2, 3);
                break;
            case 9:
                ItemCondition(3);
                break;
            case 10:
                ItemConditionV2(3, 4);
                break;
            case 11:
                ItemCondition(4);
                break;
            case 12:
                ItemConditionV2(4, 5);
                break;
        }
    }
    protected internal void ItemCondition(int itemIndex)
    {
        if (loadLevelSystem.IOA1[itemIndex].IsNextLevel)
        {
            NextLevelMethod(6, true, "nextLevelShow", true);
        }
        else
        {
            NextLevelMethod(6, false, "nextLevelShow", false);
        }
    }
    protected internal void ItemConditionV2(int itemIndex, int _nextLevelFight)
    {
        if (loadLevelSystem.IOA1[itemIndex].IsNextLevel)
        {
            NextLevelMethod(_nextLevelFight, false, "nextLevelShow", false);
        }
    }
    protected internal void NextLevelCase(int _type)
    {
        switch (_type)
        {
            case 0:
                NextLevelMethod(1, true, "nextLevelShow", true);
                NextLevelMethod(2, true, "nextLevelShow", true);
                NextLevelMethod(3, true, "nextLevelShow", true);
                NextLevelMethod(4, true, "nextLevelShow", true);
                NextLevelMethod(5, true, "nextLevelShow", true);
                break;
            case 1:
                NextLevelMethod(1, false, "nextLevelShow", false);
                break;
            case 2:
                NextLevelMethod(1, false, "nextLevelShow", false);
                NextLevelMethod(2, false, "nextLevelShow", false);
                break;
            case 3:
                NextLevelMethod(1, false, "nextLevelShow", false);
                NextLevelMethod(2, false, "nextLevelShow", false);
                NextLevelMethod(3, false, "nextLevelShow", false);
                break;
            case 4:
                NextLevelMethod(1, false, "nextLevelShow", false);
                NextLevelMethod(2, false, "nextLevelShow", false);
                NextLevelMethod(3, false, "nextLevelShow", false);
                NextLevelMethod(4, false, "nextLevelShow", false);
                break;
            case 5:
                NextLevelMethod(1, false, "nextLevelShow", false);
                NextLevelMethod(2, false, "nextLevelShow", false);
                NextLevelMethod(3, false, "nextLevelShow", false);
                NextLevelMethod(4, false, "nextLevelShow", false);
                NextLevelMethod(5, false, "nextLevelShow", false);
                break;
            case 6:
                NextLevelMethod(7, true, "nextLevelShow", true);
                break;
        }
    }
    protected internal void NextLevelMethod(int _nextLevel, bool _value, string anim, bool boolAnim)
    {
        nextLevel[_nextLevel].SetActive(_value);
        nextLevelAnim.SetBool(anim, boolAnim);
    }
}