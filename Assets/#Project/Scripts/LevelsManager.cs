using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsManager : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    void Start()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();        
    }

    // Update is called once per frame
    void Update()
    {
        /*else if( boss vaincu )
        {
            SceneManager.LoadScene("EndScene");
        }
        */
        if(GameObject.FindGameObjectsWithTag("Enemy").Length <= 0)
        {
            this.spriteRenderer.enabled = true; 
            this.GetComponent<BoxCollider>().isTrigger = true;
        }

    }
    void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            SceneManager.LoadScene("BossScene");
        }
    }

}
