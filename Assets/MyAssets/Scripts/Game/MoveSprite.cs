using UnityEngine;
using UnityEngine.EventSystems;
public class MoveSprite : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] RectTransform rectTransform;
    [SerializeField] Transform initPos;
    [SerializeField] Canvas myCanvas;
    [SerializeField] CanvasGroup myCanvasGroup;
    public int id;
    public void ResetPosition()
    {
        transform.position = initPos.position;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        myCanvasGroup.blocksRaycasts = false;
    }
    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / myCanvas.scaleFactor;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        myCanvasGroup.blocksRaycasts = true;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
    }
}