using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    float startPos;
    public GameObject cam;
    public float parallaxEffect; //background speed relative to the cam

    void Start()
    {
        startPos = transform.position.x;
    }

    void Update()
    {
        float distance = transform.position.x * parallaxEffect; // the frathest background will have a speed of 0.5 (practicaly immobile) and so and so.
        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);
    }
}
