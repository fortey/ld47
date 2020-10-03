using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControls : MonoBehaviour
{
    public AudioSource audsor;
    public void PlayPressed()
    {
        SceneManager.LoadScene("SampleScene");
        DontDestroyOnLoad(audsor);
    }
    public void ExitPressed()
    {
        Application.Quit();
    }

    
}
