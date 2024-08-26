using UnityEngine;
using UnityEngine.UI;
public class TextCount : MonoBehaviour
{
    public Text[] myTextCount;
    public int numItem;
    void Start() => SetCount(0);
    public void SetCount(int _numItem)
    {
        for (int i = 0; i < myTextCount.Length; i++)
        {
            numItem = _numItem;
            myTextCount[i].text = numItem + "/5";
        }
    }
}