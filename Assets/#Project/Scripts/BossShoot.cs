using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShoot : MonoBehaviour
{
    public GameObject seedPrefab;
    public Transform seedOriginTransform; // pour avoir la position nécessaire à la création des instances. Peut etre fait avec un gameObject.
    public float seedSpeed = 2f;
    public float delay = 1f;
    public float lifetime = 5f;
    private GameObject newSeed;

    public IEnumerator MonsterShoot()
    {
        while(true)
        {
            newSeed = Instantiate(seedPrefab, seedOriginTransform.position, seedOriginTransform.rotation);
            Rigidbody seedRigidbody = newSeed.GetComponent<Rigidbody>();
            seedRigidbody.velocity = seedOriginTransform.forward * seedSpeed;
            Destroy(newSeed,lifetime);
            yield return new WaitForSeconds(delay);
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player")|| other.CompareTag("Background"))
        {
            Destroy(newSeed);
        }
        // Destroy(seeds[seeds.Count-1].gameObject);
        // seeds.RemoveAt(seeds.Count-1);
    
        // for(int i = 0; i < seeds.Count; i++)
        // {
        //     Destroy(seeds[i]);
        // }
        //seeds.Clear();
    }
    //Systeme de Pool -> moins couteux
    
}
