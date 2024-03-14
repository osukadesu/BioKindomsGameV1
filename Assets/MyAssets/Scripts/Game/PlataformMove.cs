using UnityEngine;
public class PlataformMove : MonoBehaviour
{
    [SerializeField] GameObject[] wayPoints;
    [SerializeField] float plataformSpeed = 2;
    [SerializeField] int wayPointsIndex;
    void FixedUpdate()
    {
        MovePlataform();
    }
    void MovePlataform()
    {
        if (Vector3.Distance(transform.position, wayPoints[wayPointsIndex].transform.position) < .1f)
        {
            wayPointsIndex++;
            if (wayPointsIndex >= wayPoints.Length)
            {
                wayPointsIndex = 0;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, wayPoints[wayPointsIndex].transform.position, plataformSpeed * Time.deltaTime);
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.SetParent(transform);
        }
    }
    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.SetParent(null);
        }
    }
}