using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CountDownTimer : MonoBehaviour
{
    private Text textField;
    public int allowedTime = 90;
    private int currentTime;
    void Start()
    {
        Cursor.visible = true;
        Screen.lockCursor = false;
    }

    void Awake()
    {
        currentTime = allowedTime;
        textField = GetComponent<Text>();
        UpdateTimerText();
        // start the timer ticking 
        StartCoroutine(TimerTick());
        
    }

    void UpdateTimerText()
    {
        textField.text = currentTime.ToString();
    }
    IEnumerator TimerTick()
    {
        if (currentTime == 0) // has the game ended
        {
            SceneManager.LoadScene("menu");
        }
        else
        {
            yield return new WaitForSeconds(1); // wait for 1 second 
            currentTime--;
            UpdateTimerText();
            StartCoroutine(TimerTick()); // reduce the time 
        }
    }
}