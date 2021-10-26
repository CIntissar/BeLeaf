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
    public bool isCharacterClose;
    

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }


    void Update()
    {

        
        //Condition si le personnage est proche
        // if(agent.remainingDistance <= agent.stoppingDistance)
        // {
        //     //action contre le personnage
        // }
    }

    protected virtual void ChaseCharacter()
    {
        // if()
        // {
        //     actualDestination = targetCharacter.position;  // on peut obtenir un point en Vector3 qui sera sa destination actuelle
        //     agent.SetDestination(actualDestination); 

        // }
    }


}
