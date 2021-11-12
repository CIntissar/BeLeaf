using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStatus : MonoBehaviour
{
    public float distance = 2.5f;
    public int lifes = 3;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LooseLife()
    {   
        lifes--;

        if(lifes < 0)
        {
            //Animation de mort
            SceneManager.LoadScene("GameOverScene");
            Debug.Log("You're dead");
        }
        else
        {
            //Animation de coup
            Debug.Log(lifes);
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, distance);
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Seed"))
        {
            Debug.Log("HEADSHOT!!!");
            LooseLife(); // Nom du script suivi de la méthode!!!
        }
    }
}
