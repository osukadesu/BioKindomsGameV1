using UnityEngine;
using UnityEngine.EventSystems;
public class HoverScore : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Animator scoreHover;
    void Start()
    {
        scoreHover.SetBool("showinfoscore", false);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        scoreHover.SetBool("showinfoscore", true);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        scoreHover.SetBool("showinfoscore", false);
    }
}