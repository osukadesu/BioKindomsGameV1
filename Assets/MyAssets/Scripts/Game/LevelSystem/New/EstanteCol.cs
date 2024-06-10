using UnityEngine;
public class EstanteCol : MonoBehaviour
{
    bool isRecovered;
    string textMessage;
    [SerializeField] protected TextGralController textInfo;
    void Start()
    {
        isRecovered = true;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (isRecovered)
            {
                textMessage = "Presiona la tecla 'E' para ver la reliquia.";
                textInfo.ShowText(textMessage);
            }
            else
            {
                textMessage = "Presiona la tecla 'F' y recupera la reliquia.";
                textInfo.ShowText(textMessage);
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            textInfo.HideText();
        }
    }
}
