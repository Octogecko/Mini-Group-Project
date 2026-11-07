using UnityEngine;

public class ParralaxSystem : MonoBehaviour
{
    [SerializeField] private GameObject Cam;
    private Vector3 CamPos;
    [Header("Ref")]
    [SerializeField] private GameObject GMForegroudlayer, GMFirstBackground, GMSky;
    [Header("Strengh")]
    [SerializeField] private float StenghForegroudlayer, StenghFirstBackground, StenghSky;
    void Start()
    {
        CamPos = Cam.transform.position;
    }


    void Update()
    {
        if (CamPos != Cam.transform.position)
        {
            GMForegroudlayer.transform.position += new Vector3((Cam.transform.position.x - CamPos.x) * (StenghForegroudlayer), 0, 0);

            GMFirstBackground.transform.position += new Vector3((Cam.transform.position.x - CamPos.x) * (StenghFirstBackground), 0, 0);

            GMSky.transform.position += new Vector3((Cam.transform.position.x - CamPos.x) * (StenghSky), 0, 0);


            CamPos = Cam.transform.position;
        }
    }
}
