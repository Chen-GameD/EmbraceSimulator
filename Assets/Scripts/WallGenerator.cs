using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGenerator : MonoBehaviour
{
    [SerializeField] private List<GameObject> WallRefs;
    [SerializeField] private GameObject LeftHand;
    [SerializeField] private GameObject RightHand;

    // Distance <= PerfectDistance means get perfect score
    [SerializeField] private float PerfectDistance;
    // PerfectDistance <= Distance <= GoodDistance means get good score
    [SerializeField] private float GoodDistance;
    // BadDistance <= Distance means get bad performance, lose HP
    [SerializeField] private float BadDistance;

    private GameObject TargetArea;

    // Start is called before the first frame update
    void Start()
    {
        /////////////////////// Test //////////////////////////
        //GenerateNewWall(new Vector3(0, 0, 0), new Vector3(0, 0, 1000));
    }

    public void Init(GameObject i_TargetArea)
    {
        TargetArea = i_TargetArea;
    }

    public void GenerateNewWall(Vector3 StartLocation, Vector3 EndLocation)
    {
        int RandIndex = UnityEngine.Random.Range(0, WallRefs.Count);
        GameObject CurrentWallObj = WallRefs[RandIndex];
        // Instantiate at position (0, 0, 0) and zero rotation.
        GameObject NewWall = Instantiate(CurrentWallObj, StartLocation, Quaternion.identity);
        Wall CurrentWall = NewWall.GetComponent<Wall>();
        CurrentWall.UpdateTriggerArea(TargetArea);
        CurrentWall.InitHands(LeftHand, RightHand);
        CurrentWall.InitDistanceData(PerfectDistance, GoodDistance, BadDistance);
        CurrentWall.StartMove(EndLocation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
