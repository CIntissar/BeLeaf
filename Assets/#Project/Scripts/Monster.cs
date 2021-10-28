using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Monster : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform targetCharacter;

    [HideInInspector]
    public Vector3 actualDestination;
    [HideInInspector]
    public int indexNextDestination = 0;

    public SeedShoot seedShoot;
   
   private Coroutine co;

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
        co = StartCoroutine(seedShoot.MonsterShoot());
        
    }

    private void OnTriggerExit(Collider other) 
    {
        //stop animation -> retour idle
        Debug.Log("Nobody's here");
        StopCoroutine(co);        
  
    }

}



