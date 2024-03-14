using UnityEngine;
using UnityEngine.UI;
public class TextInfoAnimations : MonoBehaviour
{
    [SerializeField] Animator viewInfoText;
    [SerializeField] Text text3;
    public void viewInfoText1()
    {
        viewInfoText.SetBool("intextinfo1", true);
        viewInfoText.SetBool("gotextinfo2", false);
        text3.text = "Pág 1.";
    }
    public void viewInfoText2()
    {
        viewInfoText.SetBool("intextinfo1", false);
        viewInfoText.SetBool("gotextinfo2", true);
        text3.text = "Pág 2.";
    }
}
