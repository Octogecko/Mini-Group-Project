using UnityEngine;
using UnityEngine.SceneManagement;
public class videoFini : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke("passeALaSuite", 21f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void passeALaSuite()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
