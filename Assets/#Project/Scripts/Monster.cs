using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum MonsterState
{
    normal,
    happy,
    ko

}
[RequireComponent(typeof(NavMeshAgent))]
public class Monster : MonoBehaviour
{
    public MonsterState currentState;
    public NavMeshAgent agent;
    public Transform targetCharacter;

    [HideInInspector]
    public Vector3 actualDestination;
    [HideInInspector]
    public int indexNextDestination = 0;

    public SeedShoot seedShoot;
   
    private Coroutine co;

    public float health = 5;
    public float happiness = 0;
    protected PlayerStatus playerStatus;

    void Start()
    {
        currentState = MonsterState.normal;
        agent = GetComponent<NavMeshAgent>();
        playerStatus = FindObjectOfType<PlayerStatus>();
    }

    void Update()
    {
        if(co==null && Vector3.Distance(playerStatus.transform.position, transform.position)<= playerStatus.distance)
        {
            //active animation attack
            co = StartCoroutine(seedShoot.MonsterShoot());
        }
        if(co!=null && Vector3.Distance(playerStatus.transform.position, transform.position) > playerStatus.distance)
        {
            //stop animation -> retour idle
            StopCoroutine(co);
            co =null;
        }

        if(happiness == 5)
        {
            currentState = MonsterState.happy;
        }
        else if(health == 0)
        {
            currentState = MonsterState.ko;
        }
        else
        {
            currentState = MonsterState.normal;
        }
    }

}



