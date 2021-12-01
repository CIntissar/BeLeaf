using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonBehavior : MonoBehaviour
{
    public GameObject feedPrefab;
    private SpriteRenderer spriteR;
    public Transform feedOriginTransform;
    public float feedSpeed = 5f;
    
    private void Start() 
    {
        spriteR = GetComponent<SpriteRenderer>(); 
    }
    public void Fire() 
    {
        GameObject newFeed = Instantiate(feedPrefab, feedOriginTransform.position, feedOriginTransform.rotation);
        Rigidbody bulletRigidbody = newFeed.GetComponent<Rigidbody>();
        bulletRigidbody.velocity = feedOriginTransform.right * feedSpeed;
    }

    public void Flip()
    {
        spriteR.flipX = !spriteR.flipX;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
