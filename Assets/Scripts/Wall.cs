using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.XR.CoreUtils;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] private GameObject LeftHandPoint;
    [SerializeField] private GameObject RightHandPoint;

    private GameObject LeftHand;
    private GameObject RightHand;

    //private GameObject WallObject;

    public float MoveSpeed = 0.2f;
    private bool IsStartToMove = false;
    private Vector3 WallEndLocation = Vector3.zero;
    private Vector3 WallEndlocationAndDir = Vector3.zero;

    // Delete timer
    //private float DeleteTimer = 10.0f;
    //private float CurrentTimer = 0.0f;

    private GameObject TriggerArea;

    // By default, the performance of the current wall should be bad.
    private E_PerformanceLevel PerformanceLevel = E_PerformanceLevel.Bad;
    // Distance <= PerfectDistance means get perfect score
    private float PerfectDistance;
    // PerfectDistance <= Distance <= GoodDistance means get good score
    private float GoodDistance;
    // BadDistance <= Distance means get bad performance, lose HP
    private float BadDistance;

    // Start is called before the first frame update
    void Start()
    {
        //WallObject = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsStartToMove)
        {
            this.gameObject.transform.Translate(WallEndlocationAndDir * Time.deltaTime * MoveSpeed);
            //CurrentTimer += Time.deltaTime;
            //Debug.Log("Test");
        }
    }

    public void InitHands(GameObject i_LeftHand, GameObject i_RightHnad)
    {
        LeftHand = i_LeftHand;
        RightHand = i_RightHnad;
    }

    public void InitDistanceData(float i_PerfectDis, float i_GoodDis, float i_BadDis)
    {
        PerfectDistance = i_PerfectDis;
        GoodDistance = i_GoodDis;
        BadDistance = i_BadDis;
    }

    public Vector3 GetLeftHandPointPosition()
    {
        return LeftHandPoint.transform.position;
    }

    public Vector3 GetRightHandPointPosition() 
    {
        return RightHandPoint.transform.position;
    }

    public void StartMove(Vector3 EndLocation)
    {
        //this.gameObject.transform.Translate(EndLocation);
        WallEndLocation = EndLocation;
        WallEndlocationAndDir = EndLocation - this.transform.position;
        IsStartToMove = true;
    }

    public void UpdateTriggerArea(GameObject i_Obj)
    {
        TriggerArea = i_Obj;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == TriggerArea)
        {
            float LeftDistance = (LeftHand.transform.position - LeftHandPoint.transform.position).magnitude;
            float RightDistance = (RightHand.transform.position - RightHandPoint.transform.position).magnitude;
            Debug.Log("LeftHand: " + LeftDistance + "-------------" + "RightHand: " + RightDistance);
            if (LeftDistance <= PerfectDistance && RightDistance <= PerfectDistance)
            {
                PerformanceLevel = E_PerformanceLevel.Perfect;
                Debug.Log("Perfect");
            }
            else if ((LeftDistance > BadDistance || RightDistance > BadDistance) && (PerformanceLevel != E_PerformanceLevel.Perfect || PerformanceLevel != E_PerformanceLevel.Good))
            {
                PerformanceLevel = E_PerformanceLevel.Bad;
                Debug.Log("Bad");
            }
            else
            {
                PerformanceLevel = E_PerformanceLevel.Good;
                Debug.Log("Good");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == TriggerArea)
        {
            Debug.Log("Exit trigger");
            GameManager.Instance.UpdateNewPerformance(PerformanceLevel);
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == TriggerArea)
        {
            
        }
    }
}
