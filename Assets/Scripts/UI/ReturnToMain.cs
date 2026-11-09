using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMain : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke("Menu", 18f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Menu()
    {
        SceneManager.LoadScene(1);
    }
}
