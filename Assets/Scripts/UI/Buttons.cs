using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public bool paused = false;

    public GameObject panel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            NextScene();
        }

        else if (Input.GetKeyDown(KeyCode.JoystickButton2))
        {
            Controls();
        }

        else if (Input.GetKeyDown(KeyCode.JoystickButton1))
        {
            Quit();
        }


    }

    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Main()
    {
        SceneManager.LoadScene(0);
    }

    public void Pause()
    {
        if (paused)
        {
            paused = false;
            Time.timeScale = 1f;
        }
        else
        {
            paused = true;
            Time.timeScale = 0f;
        }
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void GameOver()
    {
        Invoke("Main", 3f);
    }

    public void Controls()
    {
        if (panel.activeSelf)
        {
            panel.SetActive(false);
        }
        else if (!panel.activeSelf)
        {
            panel.SetActive(true);
        }
    }
}
