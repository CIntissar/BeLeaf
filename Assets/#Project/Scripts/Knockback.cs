using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public float pushStrengh = 1f;
    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            Vector3 direction = other.transform.position - transform.position;
            direction = direction.normalized;
            other.transform.position = new Vector3(transform.position.x + direction.x * pushStrengh , 0,transform.position.z + direction.z * pushStrengh);
        }
    }

}
