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
    public MonsterState currentstate;
    public NavMeshAgent agent;
    public Transform targetCharacter;

    [HideInInspector]
    public Vector3 actualDestination;
    [HideInInspector]
    public int indexNextDestination = 0;

    public SeedShoot seedShoot;
   
    private Coroutine co;
    protected PlayerStatus playerStatus;

    public float healthPointM = 5;
    public float happinessPoint = 0;

    void Start()
    {
        currentstate = MonsterState.normal;
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

        if(happinessPoint == 5)
        {
            currentstate = MonsterState.happy;
        }
        else if(healthPointM == 0)
        {
            currentstate = MonsterState.ko;
        }
        else
        {
            currentstate = MonsterState.normal;
        }
    }

        protected void OnTriggerEnter(Collider other) 
        {
            //animation de dégat
            playerStatus.LooseLife();
            Debug.Log("HEADSHOT");
        }







}



