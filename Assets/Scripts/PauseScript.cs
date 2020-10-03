using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public GameObject menu;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
            menu.SetActive(true);
        }
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }

    public void PauseGame()
    {
        Time.timeScale = 0;

    }
    public void ContinueGame()
    {
        Time.timeScale = 1;
       
    }
}
