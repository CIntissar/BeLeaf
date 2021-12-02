using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBoss : Monster
{
    public SeedShoot seedShoot2;
    public SeedShoot seedShoot3;
    public SeedShoot seedShoot4;

    void Update()
    {
        if(co==null && Vector3.Distance(playerStatus.transform.position, transform.position)<= playerStatus.distance)
        {
            //active animation attack
            co = StartCoroutine(seedShoot.MonsterShoot());
            // co = StartCoroutine(seedShoot2.MonsterShoot());
            // co = StartCoroutine(seedShoot3.MonsterShoot());
            // co = StartCoroutine(seedShoot4.MonsterShoot());
        }
        if(co!=null && Vector3.Distance(playerStatus.transform.position, transform.position) > playerStatus.distance)
        {
            //stop animation -> retour idle
            StopCoroutine(co);
            co =null;
        }
    }
}
