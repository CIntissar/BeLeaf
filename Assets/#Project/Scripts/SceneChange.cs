using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{   
    public void Change(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Exit() {
        {
            Application.Quit();
        }
    }
}