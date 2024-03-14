using System.Collections;
using UnityEngine;
using UnityEngine.AI;
public class EnemyIA : MonoBehaviour
{
    public int time;
    public float vel, rotationSpeed = 5f, rotY, distance;
    public GameObject target;
    public NavMeshAgent agent;
    public bool idle, timerotate;
    public Animator enemiAnim;

    void Update()
    {
        time += 1;
        if (idle)
        {
            enemiAnim.SetBool("attack", false);
            transform.Translate(Vector3.forward * vel * Time.deltaTime);
            transform.Rotate(new Vector3(0, rotY, 0));
            if (time >= Random.Range(100, 1000))
            {
                Rotate();
                time = 0;
                timerotate = true;
            }
            if (timerotate)
            {
                if (time >= Random.Range(10, 30))
                {
                    rotY = 0;
                    timerotate = false;
                }
            }
        }
        if (Vector3.Distance(target.transform.position, transform.position) < distance)
        {
            idle = false;
            agent.SetDestination(target.transform.position);
            agent.speed = 2;
            StartCoroutine(EnemyAttack());
        }
        else
        {
            idle = true;
            agent.speed = 0;
            StopCoroutine(EnemyAttack());
        }
    }
    IEnumerator EnemyAttack()
    {
        yield return new WaitForSeconds(1f);
        enemiAnim.SetBool("attack", true);
    }
    public void Rotate()
    {
        rotY = Random.Range(0, 4);
    }
}