using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovBehaviour : MonoBehaviour
{
    // To fix the rotation
    Transform t;
    public float fixedRotation = 0;

    void Start() 
    {
        t = transform;
    }
    
    void Update() 
    {
        t.eulerAngles = new Vector3 (t.eulerAngles.x, fixedRotation, t.eulerAngles.z);
    }
}
