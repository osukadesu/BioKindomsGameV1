using UnityEngine;
[CreateAssetMenu(fileName = "Answer Button", menuName = "Create Answer", order = 0)]
[System.Serializable]
public class AnswerButtonData : ScriptableObject
{
    public int idAnswer;
    public Sprite[] imageItem;
}