using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprinklerBehavior : MonoBehaviour
{
    public GameObject waterPrefab;
    public Transform waterOriginTransform;
    public float waterSpeed = 0.1f;
    
    public void Water() 
    {
        GameObject newWater = Instantiate(waterPrefab, waterOriginTransform.position, waterOriginTransform.rotation);
        Rigidbody bulletRigidbody = newWater.GetComponent<Rigidbody>();
        bulletRigidbody.velocity = waterOriginTransform.right * waterSpeed;
    }

    private void OnTriggerExit(Collider other) 
    {
        Destroy(gameObject);
    }


}
