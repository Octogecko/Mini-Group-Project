using UnityEngine;

public class ParralaxSystem : MonoBehaviour
{
    private Camera Cam;
    [Header("Layers")]
    [SerializeField] private LayerMask Foregroudlayer, FirstBackGround, SecondBackGround;
    [Header("Ref")]
    [SerializeField] private GameObject GMForegroudlayer, GMFirstBackGround, GMSecondBackGround;
    [Header("Strengh")]
    [SerializeField] private float StenghForegroudlayer, StenghFirstBackGround, StenghSecondBackGround;
    void Start()
    {
        Cam = Camera.main;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        GMForegroudlayer.transform.position += new Vector3(StenghForegroudlayer * Time.deltaTime, 0, 0);

        GMFirstBackGround.transform.position += new Vector3(StenghForegroudlayer * Time.deltaTime, 0, 0);

        GMSecondBackGround.transform.position += new Vector3(StenghForegroudlayer * Time.deltaTime, 0, 0);
    }
}
