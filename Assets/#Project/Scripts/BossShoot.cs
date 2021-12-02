using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShoot : MonoBehaviour
{

    public List<GameObject> seeds = new List<GameObject>(); // réserve de Seeds
    public GameObject seedPrefab;
    public Transform seedOriginTransform; // pour avoir la position nécessaire à la création des instances. Peut etre fait avec un gameObject.
    public float seedSpeed = 2f;
    public float delay = 1f;

    public IEnumerator MonsterShoot()
    {
        while(true)
        {
            GameObject newSeed = Instantiate(seedPrefab, seedOriginTransform.position, seedOriginTransform.rotation);
            Rigidbody seedRigidbody = newSeed.GetComponent<Rigidbody>();
            seeds.Add(newSeed);
            seedRigidbody.velocity = seedOriginTransform.forward * seedSpeed;
            yield return new WaitForSeconds(delay);
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        // Destroy(seeds[seeds.Count-1].gameObject);
        // seeds.RemoveAt(seeds.Count-1);
    
        for(int i = 0; i < seeds.Count; i++)
        {
            Destroy(seeds[i]);
        }
        //seeds.Clear();
    }
    //Systeme de Pool -> moins couteux
    
}
