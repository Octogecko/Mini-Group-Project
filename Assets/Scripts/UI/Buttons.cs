using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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

    public void Resume()
    {

    }

    public void Pause()
    {
        
    }

    public void Quit()
    {
        
    }

    public void GameOver()
    {
        Invoke("Main", 3f);
    }
}
