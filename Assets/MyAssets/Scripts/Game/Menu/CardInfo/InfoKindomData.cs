using UnityEngine;
[CreateAssetMenu(fileName = "InfoKindom", menuName = "Create Info Kindom", order = 0)]
public class InfoKindomData : ScriptableObject
{
    [SerializeField] string[] textName;
    [SerializeField] string[] textInfo;
    [SerializeField] GameObject[] kindom;
    public GameObject[] Kindom { get => kindom; set => kindom = value; }
    public string[] TextName { get => textName; set => textName = value; }
    public string[] TextInfo { get => textInfo; set => textInfo = value; }
}