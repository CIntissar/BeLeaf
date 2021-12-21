using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnteringDungeon : MonoBehaviour
{   
    public Animator animator;
    public string levelToLoad;
    public void FadeToLevel(string name)
    {
        levelToLoad = name;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player") && GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            FadeToLevel(levelToLoad);
        }
    }

    private void OnDrawGizmos() // Pour dessiner un Gizmos sur un empty object
    {
        Vector3 cubeSize = new Vector3(3.8f,0.5f,0.5f);
        Gizmos.color = new Color(0.5f,0.5f,0.5f,0.4f); 
        Gizmos.DrawCube(transform.position,(cubeSize)); // => (position, longueur)
    }
}
