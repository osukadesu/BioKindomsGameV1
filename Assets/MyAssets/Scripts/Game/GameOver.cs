using UnityEngine;
public class GameOver : MonoBehaviour
{
    [SerializeField] EscapeLogicV1 escapeLogicV1;
    void Awake()
    {
        escapeLogicV1 = FindObjectOfType<EscapeLogicV1>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            escapeLogicV1.EscapeMethod();
        }
    }
}