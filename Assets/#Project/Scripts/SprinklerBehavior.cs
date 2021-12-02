using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprinklerBehavior : MonoBehaviour
{
    public GameObject waterPrefab;
    public Transform waterOriginTransform;
    private SpriteRenderer spriteR;
    public float waterSpeed = 0.1f;
    
    private void Start() 
    {
        spriteR = GetComponent<SpriteRenderer>(); 
    }
    public void Water() 
    {
        GameObject newWater = Instantiate(waterPrefab, waterOriginTransform.position, waterOriginTransform.rotation);
        Rigidbody bulletRigidbody = newWater.GetComponent<Rigidbody>();
        bulletRigidbody.velocity = waterOriginTransform.right * waterSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("SHINE");
        if(other.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
        }
    }
    public void Flip(bool flipping)
    {
        Vector3 position = transform.localPosition;
        if(flipping)
        {
            spriteR.flipX = true;
            position.x = - 0.3f;
            transform.localPosition = position;
        }
        else
        {
            spriteR.flipX = false;
            position.x = 0.3f;
            transform.localPosition = position;
        }
    }

}
