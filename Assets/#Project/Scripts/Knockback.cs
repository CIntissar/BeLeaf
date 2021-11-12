using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) 
    {

        if(other.CompareTag("Player"))
        {
            Vector3 direction = other.transform.position - transform.position;
            transform.position = new Vector3(transform.position.x + direction.x, 0,transform.position.z + direction.z);
           
        }
    }

}
