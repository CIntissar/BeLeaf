using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutterBehavior : MonoBehaviour
{
    private SpriteRenderer spriteR;

    void Start()
    {
        spriteR = GetComponent<SpriteRenderer>(); 
    }

    public void Slash()
    {
        // SetActive emptyobject 
    }

    public void Flip(bool flipping)
    {
        Vector3 position = transform.localPosition;
        if(flipping)
        {
            spriteR.flipX = true;
            position.x = - 0.3f;   
        }
        else
        {
            spriteR.flipX = false;
            position.x = 0.3f;
        }
        transform.localPosition = position;
    }
}
