using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MonsterMoving : Monster
{
    public List<TargetPoint> targetPoints = new List<TargetPoint>(); 
    // récupérer la liste de targets points pour le déplacement des ennemis mobiles


    void Update()
    {
        if(agent.remainingDistance <= agent.stoppingDistance)
        {
            NextDestination();
        }

        if(Vector3.Distance(playerStatus.transform.position, transform.position)<= playerStatus.distance)
        {
            //active animation attack
            actualDestination = targetCharacter.position;  
            agent.SetDestination(actualDestination); 

        }
        if(Vector3.Distance(playerStatus.transform.position, transform.position) > playerStatus.distance)
        {
            //stop animation -> retour idle
            NextDestination();

        }
    }

    public void NextDestination()
    {
        actualDestination = targetPoints[indexNextDestination].GivePoint();  // on peut obtenir un point en Vector3 qui sera sa destination actuelle
        agent.SetDestination(actualDestination); // il va dire à l'agent, sa destination à chaque frame.

        indexNextDestination++; 
        
        if(indexNextDestination >= targetPoints.Count )
        {
            indexNextDestination = 0;
        }
    }


}
