using UnityEngine;
[CreateAssetMenu(fileName = "Quest Level Data", menuName = "Create Quest", order = 0)]
[System.Serializable]
public class QuestLevelData : ScriptableObject
{
    public int[] idQuest;
    public string[] texQuest;
    public Sprite[] imageKindom;
}
