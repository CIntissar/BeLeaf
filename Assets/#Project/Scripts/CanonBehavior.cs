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
        if(spriteR.flipX != true)
        {
            bulletRigidbody.velocity = feedOriginTransform.right * feedSpeed;
        }
        else
        {
            bulletRigidbody.velocity = -feedOriginTransform.right * feedSpeed;
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
        }
    }
    public void Flip(bool flipping)
    {
        Vector3 position = transform.localPosition;
        if(flipping && spriteR != null)
        {
            spriteR.flipX = true;
            position.x = - 0.35f;   
            transform.localPosition = position;
        }
        else if(!flipping && spriteR != null)
        {
            spriteR.flipX = false;
            position.x = 0.35f;
            transform.localPosition = position;
        }

    }
}
                              