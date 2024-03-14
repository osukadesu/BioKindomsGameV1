using UnityEngine;
public class MenuAnimations : MonoBehaviour
{
    [SerializeField] CanvasGroup canvasGroup;
    [SerializeField] Animator _animFadeKindom, _animBtnKindom, _animContentKindom;
    public void Animal()
    {
        SetAnimation("inanimal", "btninanimal", "contentanimal", true);
        SetAnimation("govegetal", "btngovegetal", "contentgovegetal", false);
        SetAnimation("gofungi", "btngofungi", "contentgofungi", false);
        SetAnimation("goprotista", "btngoprotista", "contentgoprotista", false);
        SetAnimation("gomonera", "btngomonera", "contentgomonera", false);
    }
    public void Vegetal()
    {
        SetAnimation("inanimal", "btninanimal", "contentanimal", false);
        SetAnimation("govegetal", "btngovegetal", "contentgovegetal", true);
        SetAnimation("gofungi", "btngofungi", "contentgofungi", false);
        SetAnimation("goprotista", "btngoprotista", "contentgoprotista", false);
        SetAnimation("gomonera", "btngomonera", "contentgomonera", false);
    }
    public void Fungi()
    {
        SetAnimation("inanimal", "btninanimal", "contentanimal", false);
        SetAnimation("govegetal", "btngovegetal", "contentgovegetal", false);
        SetAnimation("gofungi", "btngofungi", "contentgofungi", true);
        SetAnimation("goprotista", "btngoprotista", "contentgoprotista", false);
        SetAnimation("gomonera", "btngomonera", "contentgomonera", false);
    }
    public void Protista()
    {
        SetAnimation("inanimal", "btninanimal", "contentanimal", false);
        SetAnimation("govegetal", "btngovegetal", "contentgovegetal", false);
        SetAnimation("gofungi", "btngofungi", "contentgofungi", false);
        SetAnimation("goprotista", "btngoprotista", "contentgoprotista", true);
        SetAnimation("gomonera", "btngomonera", "contentgomonera", false);
    }
    public void Monera()
    {
        SetAnimation("inanimal", "btninanimal", "contentanimal", false);
        SetAnimation("govegetal", "btngovegetal", "contentgovegetal", false);
        SetAnimation("gofungi", "btngofungi", "contentgofungi", false);
        SetAnimation("goprotista", "btngoprotista", "contentgoprotista", false);
        SetAnimation("gomonera", "btngomonera", "contentgomonera", true);
    }
    public void SetAnimation(string fadeAnim, string btnAnim, string contentAnim, bool state)
    {
        for (int i = 0; i < 5; i++)
        {
            Show();
            _animFadeKindom.SetBool(fadeAnim, state);
            _animBtnKindom.SetBool(btnAnim, state);
            _animContentKindom.SetBool(contentAnim, state);
        }
    }
    void Show()
    {
        canvasGroup.alpha = 1; canvasGroup.interactable = true; canvasGroup.blocksRaycasts = true;
    }
    public void CloseAll()
    {
        canvasGroup.alpha = 0; canvasGroup.interactable = false; canvasGroup.blocksRaycasts = false;
    }
}