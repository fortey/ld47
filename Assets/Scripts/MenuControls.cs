using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControls : MonoBehaviour
{
    public AudioSource audsor;
    public void PlayPressed()
    {
        SceneManager.LoadScene("Lvl_01");
        DontDestroyOnLoad(audsor);
    }
    public void ExitPressed()
    {
        Application.Quit();
    }

    
}
