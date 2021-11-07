using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedShoot : MonoBehaviour
{

    public List<GameObject> seeds = new List<GameObject>(); // réserve de Seeds
    public Transform seedOriginTransform; // pour avoir la position nécessaire à la création des instances. Peut etre fait avec un gameObject.
    public GameObject seedPrefab;
    public float seedSpeed = 10f;
    public float delay = 1f;
    public float deathDelay = 2f;

    public IEnumerator MonsterShoot()
    {
        while(true)
        {
            GameObject newSeed = Instantiate(seedPrefab, seedOriginTransform.position, seedOriginTransform.rotation);
            Rigidbody seedRigidbody = newSeed.GetComponent<Rigidbody>();
            seeds.Add(newSeed);
            seedRigidbody.velocity = seedOriginTransform.forward * seedSpeed;
            yield return new WaitForSeconds(delay);
            DeleteSeed();
        }
    }

    public void DeleteSeed() 
    {
        for(int i = 0; i < seeds.Count; i++) 
        {
            Destroy(seeds[i]);
        }
        seeds.Clear();
    }

}
