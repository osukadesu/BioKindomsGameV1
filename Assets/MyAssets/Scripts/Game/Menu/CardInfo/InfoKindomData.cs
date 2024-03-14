using UnityEngine;
[CreateAssetMenu(fileName = "InfoKindom", menuName = "Create Info Kindom", order = 0)]
public class InfoKindomData : ScriptableObject
{
    [SerializeField] string textName = "";
    [SerializeField] string text2 = "";
    [SerializeField] string textInfo = "";
    [SerializeField] GameObject[] kindom;
    public GameObject[] Kindom { get => kindom; set => kindom = value; }
    public string TextName { get { return textName; } set { textName = value; } }
    public string Text2 { get { return text2; } set { text2 = value; } }
    public string TextInfo { get { return textInfo; } set { textInfo = value; } }
}