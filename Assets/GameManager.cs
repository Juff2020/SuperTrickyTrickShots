using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject completeLeveIU;
    public GameObject pausedIU;
    public float levelCompleteDelay = 2f;
    private bool isPaused;

    public float levelCompleteTimer;
    public float completeTimerStart;
    public float completeTimerRemaining;
    public bool ballStillInHoop;

    private void Start()
    {
        isPaused = false;
        ballStillInHoop = false;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }


        //check ball stays in hoop

        completeTimerRemaining -= Time.deltaTime;

        if (completeTimerRemaining < 0 && ballStillInHoop == true)
        {
            CompleteLevel();
        }
    }

    public void ballInHoopTimerStart()
    {
        completeTimerRemaining = completeTimerStart;
    }

    public void ballInHoopTimerStop()
    {
        completeTimerRemaining = completeTimerStart;
    }

    public void CompleteLevel()
    {
            completeLeveIU.SetActive(true);
    }

    public void Pause()
    {
        if (isPaused == false)
        {
            isPaused = true;
            pausedIU.SetActive(true);
        }
        else if (isPaused == true)
        {
            isPaused = false;
            pausedIU.SetActive(false);
        }        
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Quit()
    {
        Application.Quit();
    }

}
