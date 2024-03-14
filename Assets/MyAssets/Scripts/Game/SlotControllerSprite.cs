using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class SlotControllerSprite : MonoBehaviour, IDropHandler
{
    public int id;
    [SerializeField] Text textMessage;
    [SerializeField] Transform textPos, textPos2;
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Item Dropped");
        if (eventData.pointerDrag != null)
        {
            if (eventData.pointerDrag.GetComponent<MoveSprite>().id == id)
            {
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = this.GetComponent<RectTransform>().anchoredPosition;
                textMessage.text = "Excelente! :)";
                textMessage.color = new Color(0, 1, 0, 1);
                textMessage.transform.position = textPos.position;
            }
            else
            {
                eventData.pointerDrag.GetComponent<MoveSprite>().ResetPosition();
                textMessage.text = "Incorrecto! :(";
                textMessage.color = new Color(1, 0, 0, 1);
                textMessage.transform.position = textPos2.position;
            }
        }
    }
}