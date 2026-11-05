using UnityEngine;

public class ParralaxSystem : MonoBehaviour
{
    [SerializeField] private GameObject Cam;
    private Vector3 CamPos;
    //[Header("Layers")]
    //[SerializeField] private LayerMask Foregroudlayer, FirstBackGround, SecondBackGround;
    [Header("Ref")]
    [SerializeField] private GameObject GMForegroudlayer, GMFirstBackground, GMSky;
    [Header("Strengh")]
    [SerializeField] private float StenghForegroudlayer, StenghFirstBackground, StenghSky;
    void Start()
    {
        CamPos = Cam.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (CamPos != Cam.transform.position)
        {
            GMForegroudlayer.transform.position += new Vector3((Cam.transform.position.x - CamPos.x) * (StenghForegroudlayer * Time.deltaTime), 0, 0);

            GMFirstBackground.transform.position += new Vector3((Cam.transform.position.x - CamPos.x) * (StenghForegroudlayer * Time.deltaTime), 0, 0);

            GMSky.transform.position += new Vector3((Cam.transform.position.x - CamPos.x) * (StenghForegroudlayer * Time.deltaTime), 0, 0);


            CamPos = Cam.transform.position;
        }
    }
}
