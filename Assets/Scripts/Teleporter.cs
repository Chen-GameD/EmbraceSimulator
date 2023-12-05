using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] private GameObject TargetPositionObj;
    [SerializeField] private GameObject PlayerDetection;
    [SerializeField] private GameObject Player;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (other.gameObject == PlayerDetection)
        {
            Player.transform.position = TargetPositionObj.transform.position;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Debug.Log(other.name);
    }

    private void OnTriggerStay(Collider other)
    {
        //Debug.Log(other.name);
    }
}
