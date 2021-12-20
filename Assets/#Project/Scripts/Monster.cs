using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))]
public class Monster : MonoBehaviour
{
    public MonsterStatus currentState;
    public NavMeshAgent agent;
    public Transform targetCharacter;
                                                                                                                                                                                                                                                                                                                                                                                         
    [HideInInspector]
    public Vector3 actualDestination;
    [HideInInspector]
    public int indexNextDestination = 0;

   
    private protected Coroutine co;

    public float health = 5f;
    protected float damagePoint;
    public float happiness = 0f;
    public float happinessMax = 5f;
    protected float healingPoint;
    public SeedShoot seedShoot;
    protected PlayerStatus playerStatus;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        playerStatus = FindObjectOfType<PlayerStatus>();
        currentState = MonsterStatus.idle;
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
        currentState = MonsterStatus.hurt;
        //Animation de coup
        health -= damagePoint;
        Debug.Log("Monster HP: " + health);
        
        
        if(health <= 0)
        {
            health = 0f;
            //Animation de mort
            currentState = MonsterStatus.ko;
            if (gameObject.tag == "ennemy")
            { 
                gameObject.tag = "KO"; 
            }
        }
        currentState = MonsterStatus.hurt; 
                
    }
    protected void HealByPlayer()
    {
        happiness += healingPoint;
        //Animation de coup
        Debug.Log("Monster status: " + happiness);

        if(happiness >= happinessMax)
        {
            happiness = happinessMax;
            health = 5f;
            damagePoint = 0f;
            //Animation de joie
            currentState = MonsterStatus.happy;
            if (gameObject.tag == "Enemy")
            { 
                gameObject.tag = "Happy"; 
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("SHINE");
        if(other.CompareTag("Water"))
        {
            healingPoint = 2f;
            damagePoint = 0f;
            Destroy(other.gameObject);
        }
        else if(other.CompareTag("Feed")) 
        {
            healingPoint = 2f;
            damagePoint = 1f;
            Destroy(other.gameObject);
        }
        /*else if(other.CompareTag("Cut")) // Hitbox -> EmptyGameObject!
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


