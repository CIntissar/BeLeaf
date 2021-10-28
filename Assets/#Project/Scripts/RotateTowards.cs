using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowards : MonoBehaviour
{
    public Transform targetCharacter;
    public float turn_speed = 5.0f;
    public void RotatingTowards() {
        Vector3 to = targetCharacter.position;
    
        Quaternion _lookRotation = 
            Quaternion.LookRotation((to - transform.position).normalized);
        
        //over time
        transform.rotation = 
            Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * turn_speed);
        
        //instant
        //transform.rotation = _lookRotation;
    }

    private void Update() 
    {
        RotatingTowards();
    }
}
