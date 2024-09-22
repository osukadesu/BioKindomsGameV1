using System.Collections;
using UnityEngine;
public class PlayerEstanteCol : MonoBehaviour
{
    public int setId;
    void OnTriggerEnter(Collider other)
    {
        EstanteCol objectID = other.GetComponent<EstanteCol>();
        if (objectID != null)
        {
            Debug.Log("Id Estante: " + objectID.id);
            Debug.Log("Set Id: " + setId);
            setId = objectID.id;
        }
    }
    void OnTriggerExit(Collider other)
    {
        //Debug.Log("Set Id: " + setId);
        //StartCoroutine(IEWaitSetId());
    }
    IEnumerator IEWaitSetId()
    {
        yield return new WaitForSeconds(0.5f);
        setId = -1;
    }
}