using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    //public Slider slider; slider pour les points de vie!
    //public Gradient gradient; Si je veux faire un gradient au niveau des couleurs
    // Voir vidéo How to make a Health Bar par Brackeys
    public float distance = 2.5f;
    public int lifes = 3; // Redéfinir à l'avenir
    public float pushStrengh = 1f;
    public bool isInvulnerable  = false;
    private int damage = 1;

    [SerializeField]
    private float timeInvunerability = 1.5f;

    [SerializeField]
    private float deltaTimeInvunerability = 0.15f;

    [SerializeField]
    private GameObject spriteModel;
    
    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Seed") || other.CompareTag("Enemy"))
        {
            Debug.Log("HIT!!!");
            LooseLife(); 
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, distance);
    }

    public void LooseLife()
    {       
        lifes -= damage;
        //Animation de coup
        StartCoroutine("OnInvulnerability");
        Debug.Log("HP: " + lifes);
        
        if(lifes <= 0)
        {
            lifes = 0;
            //Animation de mort
            SceneManager.LoadScene("GameOverScene");
            Debug.Log("You're dead");
        }
                
    }

    IEnumerator OnInvulnerability()
    {
        Debug.Log("I'M UNSTOPPABLE!");
        isInvulnerable = true;
        damage = 0;

        for(float i = 0; i < timeInvunerability; i += deltaTimeInvunerability)
        {
            if(spriteModel.transform.localScale == Vector3.one)
            {
                ScaleModelTo(Vector3.zero);
            }
            else
            {
                ScaleModelTo(Vector3.one);
            }

            yield return new WaitForSeconds(deltaTimeInvunerability); //how long player invulnerable
        }

        Debug.Log("I'm weak again...");
        ScaleModelTo(Vector3.one);
        damage = 1;
        isInvulnerable = false;
    }

    private void ScaleModelTo(Vector3 scale)
    {
        spriteModel.transform.localScale = scale;
    }

}
