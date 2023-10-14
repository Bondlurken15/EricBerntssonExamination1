using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float winTime = 30;

    float currentTime;

    void FixedUpdate()
    {
        currentTime += Time.deltaTime;
        timerText.text = currentTime.ToString("00");

        if (currentTime >= 30)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}