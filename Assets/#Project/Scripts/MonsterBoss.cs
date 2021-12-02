using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBoss : Monster
{
    public BossShoot seedShootUp;
    public BossShoot seedShootLeft;
    public BossShoot seedShootRight;
    public BossShoot seedShootDown;

    void Update()
    {
        if(Vector3.Distance(playerStatus.transform.position, transform.position)<= playerStatus.distance)
        {
            Debug.Log("coucou");
            //active animation attack
            if(co==null)
            {
                co = StartCoroutine(seedShootUp.MonsterShoot());
                co = StartCoroutine(seedShootLeft.MonsterShoot());
                co = StartCoroutine(seedShootRight.MonsterShoot());
                co = StartCoroutine(seedShootDown.MonsterShoot());
            }
        }
        else
        {
            //stop animation -> retour idle
            StopAllCoroutines();
            co =null;
        }
    }
}
