using UnityEngine;

public class SpawnerBarrel : MonoBehaviour
{

    public GameObject barrelPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke("spawner", 4f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawner()
    {
        Instantiate(barrelPrefab, transform.position, Quaternion.identity);
        Invoke("spawner", 4f);

    }
}
