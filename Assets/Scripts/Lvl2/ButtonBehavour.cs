using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class ButtonBehavour : MonoBehaviour
{

    private bool HasPlayer;
    private Vector3 BasePos;

    [SerializeField] private GameObject InteractObject;

    private void Start()
    {
        BasePos = transform.localPosition;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMovement>())
        {
            HasPlayer = true;
            InteractObject.GetComponent<BPI_Button>().Push();
            StartCoroutine(GoDown());
        }
    }



    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMovement>())
        {
            HasPlayer = false;
            StartCoroutine(GoDUp());
        }
    }


    IEnumerator Pushhh()
    {
        if (transform.localPosition.y >= BasePos.y - 0.2f)
        {
            transform.position -= new Vector3(BasePos.x, (BasePos.y - 0.2f) / 20, BasePos.z);
            yield return new WaitForEndOfFrame();
            StartCoroutine(Pushhh());
        }
    }



    IEnumerator GoDown()
    {
        if (HasPlayer)
        {
            if (transform.localPosition.y >= BasePos.y - 0.2f)
            {
                transform.position -= new Vector3(BasePos.x, (BasePos.y - 0.2f)/20, BasePos.z);
                yield return new WaitForEndOfFrame();
                StartCoroutine(GoDown());
            }
        }
    }

    IEnumerator GoDUp()
    {
        if (!HasPlayer)
        {
            if (transform.localPosition.y <= BasePos.y)
            {
                transform.position += new Vector3(BasePos.x, (BasePos.y) / 20, BasePos.z);
                yield return new WaitForEndOfFrame();
                StartCoroutine(GoDUp());
            }
        }
    }
}
