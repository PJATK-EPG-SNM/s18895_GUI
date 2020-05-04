using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public int currentTime = 3;
    public TextMeshProUGUI displayTime;
    public TextMeshProUGUI displayGO;
    public Image blur;
    public Image violetBG;

    void Start()
    {
        StartCoroutine(CountDown());
        blur.gameObject.SetActive(true);
        violetBG.gameObject.SetActive(true);
        displayTime.gameObject.SetActive(true);
    }

    IEnumerator CountDown()
    {
        displayGO.gameObject.SetActive(false);
        while (currentTime > 0)
        {
            displayTime.text = currentTime.ToString("0");
            yield return new WaitForSecondsRealtime(1f);
            displayTime.text = "";
            yield return new WaitForSecondsRealtime(1f);
            currentTime--;
        }
        displayTime.text = "";
        displayGO.gameObject.SetActive(true);
        displayGO.text = "GO!";
        yield return new WaitForSecondsRealtime(2f);
        displayGO.gameObject.SetActive(false);
        blur.gameObject.SetActive(false);
        violetBG.gameObject.SetActive(false);
        displayTime.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
