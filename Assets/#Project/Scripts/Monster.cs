using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum MonsterState
{
    idle,
    walk,
    hurt,
    attack,
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

    public float health = 5f;
    protected float damagePoint;
    public float happiness = 0f;
    protected float healingPoint;
    protected PlayerStatus playerStatus;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        playerStatus = FindObjectOfType<PlayerStatus>();
        currentState = MonsterState.idle;
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


    }
    protected void TakeDamage()
    {       
        health -= damagePoint;
        //Animation de coup
        Debug.Log("Monster HP: " + health);
        
        if(health <= 0)
        {
            health = 0f;
            //Animation de mort
            currentState = MonsterState.ko;
        }
                
    }
    protected void HealByPlayer()
    {
        happiness += healingPoint;
        //Animation de coup
        Debug.Log("Monster status: " + happiness);

        if(happiness >= 5)
        {
            happiness = 5f;
            health = 5f;
            damagePoint = 0f;
            //Animation de joie
            currentState = MonsterState.happy;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("SHINE");
        if(other.CompareTag("Water"))
        {
            healingPoint += 2f;
            damagePoint = 0f;
            Destroy(other.gameObject);
        }
        else if(other.CompareTag("Feed")) 
        {
            healingPoint += 2f;
            damagePoint += 1f;
            Destroy(other.gameObject);
        }
        /*else if(|| other.CompareTag("Cut"))
        {
            healingPoint += 1f;
            damagePoint += 2f;
            Destroy(other.gameObject);
        }
        */
        TakeDamage();
        HealByPlayer();
        
        

    }

}


