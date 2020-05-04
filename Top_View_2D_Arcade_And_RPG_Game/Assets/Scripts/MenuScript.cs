using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public Image start;
    public Image about;
    public Image option;
    public Image quit;

    public void Awake()
    {
        Time.timeScale = 1;
        start.gameObject.SetActive(true);
        about.gameObject.SetActive(true);
        option.gameObject.SetActive(true);
        quit.gameObject.SetActive(true);
    }

    public void PlayGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("LevelOne");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
