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
