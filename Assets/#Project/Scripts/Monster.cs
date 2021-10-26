using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Monster : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform targetCharacter;
    public Vector3 actualDestination;
    public int indexNextDestination = 0;
   

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }


    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) 
    {
        //active animation attack
        Debug.Log("DIE");
    }

    private void OnTriggerExit(Collider other) 
    {
        //stop animation
        Debug.Log("Nobody's here");
    }

}



