using UnityEngine;

public class cameraFollow : MonoBehaviour
{

    public Transform player;

    public Vector3 offset;



    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    
    void Update()
    {
        
    }
}
