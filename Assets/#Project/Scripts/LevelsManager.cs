using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsManager : MonoBehaviour
{
    public int[] ennemis = new int[6];
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ennemis.Length < 0)
        {
            SceneManager.LoadScene("BossScene");
        }
        /*else if( boss vaincu )
        {
            SceneManager.LoadScene("EndScene");
        }
        */
    }

}
