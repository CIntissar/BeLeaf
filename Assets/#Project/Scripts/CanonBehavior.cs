using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonBehavior : MonoBehaviour
{
    public GameObject feedPrefab;
    public Transform feedOriginTransform;
    public float feedSpeed = 5f;
    
    public void Fire() 
    {
        GameObject newFeed = Instantiate(feedPrefab, feedOriginTransform.position, feedOriginTransform.rotation);
        Rigidbody bulletRigidbody = newFeed.GetComponent<Rigidbody>();
        bulletRigidbody.velocity = feedOriginTransform.right * feedSpeed;
    }
}
