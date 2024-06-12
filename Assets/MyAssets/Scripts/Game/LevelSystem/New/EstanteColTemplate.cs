using UnityEngine;
public abstract class EstanteColTemplate : MonoBehaviour
{
    [SerializeField] protected internal LevelSystemV2 levelSystemV2;
    [SerializeField] protected internal InventoryItemDataV2 referenceItem;
    [SerializeField] protected internal TextGralController textInfo;
    protected internal string textMessage;
    protected internal bool canpressG, canpressF;
    protected internal abstract void WhenEnter(Collider other);
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            textInfo.HideText(); canpressG = false; canpressF = false;
        }
    }
    public void SetInfo(int value)
    {
        switch (value)
        {
            case 1:
                textMessage = "Presiona la tecla 'G' para ver la reliquia.";
                textInfo.ShowText(textMessage);
                break;
            case 2:
                textMessage = "Presiona la tecla 'F' y recupera la reliquia.";
                textInfo.ShowText(textMessage);
                break;
        }
    }
}