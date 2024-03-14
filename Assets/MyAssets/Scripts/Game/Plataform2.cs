using UnityEngine;
public class Plataform2 : MonoBehaviour
{
    [SerializeField] GameObject plataform1;
    void Update()
    {
        this.gameObject.transform.position = plataform1.transform.position;
    }
    
}