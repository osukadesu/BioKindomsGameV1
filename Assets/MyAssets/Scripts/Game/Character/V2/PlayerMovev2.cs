using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(LineRenderer))]
public class PlayerMovev2 : MonoBehaviour
{
    [SerializeField] private NavMeshAgent myAgent;
    [SerializeField] private GameObject clickFx;
    [SerializeField] private Transform visualObjectsParent;
    [SerializeField] private LineRenderer myLineR;
    [SerializeField] private Animator myAnim;
    public bool canMove = true;
    private Ray myray;
    private RaycastHit infoRay;
    void Start()
    {
        myAnim.SetBool("idle", true);
        myAnim.SetBool("run", false);
        clickFx.SetActive(false);
        myLineR.startWidth = 0.12f;
        myLineR.endWidth = 0.12f;
        myLineR.positionCount = 0;

    }
    void Update()
    {

        Moving();

        if (Vector3.Distance(myAgent.destination, transform.position) <= 0.95)
        {
            canMove = true;
            myAnim.SetBool("idle", true);
            myAnim.SetBool("run", false);
            clickFx.transform.SetParent(transform);
            clickFx.SetActive(false);
        }
        else if (myAgent.hasPath)
        {
            DrawPath();
        }
    }
    private void Moving()
    {
        if (Input.GetMouseButtonDown(1) && canMove)
        {
            ClickToMove();
            canMove = false;
        }
    }
    private void ClickToMove()
    {
        myray = Camera.main.ScreenPointToRay(Input.mousePosition);
        bool hashit = Physics.Raycast(myray, out infoRay);
        if (hashit)
        {
            SetDestination(infoRay.point);
        }
    }
    private void SetDestination(Vector3 target)
    {
        myAnim.SetBool("run", true);
        myAnim.SetBool("idle", false);
        clickFx.transform.SetParent(visualObjectsParent);
        clickFx.SetActive(true);
        clickFx.transform.position = target;
        myAgent.SetDestination(target);
    }
    private void DrawPath()
    {
        myLineR.positionCount = myAgent.path.corners.Length;
        myLineR.SetPosition(0, transform.position);

        if (myAgent.path.corners.Length < 2)
        {
            return;
        }
        for (int i = 1; i < myAgent.path.corners.Length; i++)
        {
            Vector3 pointPosition = new Vector3(myAgent.path.corners[i].x, myAgent.path.corners[i].y, myAgent.path.corners[i].z);
            myLineR.SetPosition(i, pointPosition);
        }
    }
}