using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    public GameObject pausePanel;

    float timeScale = 0;

    private bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                SetResume();
            } else
            {
                SetPause();
            }
        }
    }

    public void SetPause()
    {
        if (!isPaused)
        {
            timeScale = Time.timeScale;
            Time.timeScale = 0;
            pausePanel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            isPaused = true;

        }
    }

    public void SetResume()
    {
        Time.timeScale = timeScale;
        isPaused = false;
        pausePanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void QuitGame()
    {
        Time.timeScale = timeScale;
        SceneManager.LoadScene(0);
    }
}
