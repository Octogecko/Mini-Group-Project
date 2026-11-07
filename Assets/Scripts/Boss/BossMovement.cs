using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using System.Runtime.CompilerServices;

public class BossMovement : MonoBehaviour
{
    public GameObject player;
    private float distance;
    public float speed = 5f;
    public float BossRange = 10.0f;
    private bool wokenUp = false;
    

    void Start()
    {
               
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.localPosition, player.transform.position);
        if (distance < BossRange || wokenUp == true)
        {
            wokenUp = true;
            GetComponent<Animator>().SetBool("WakeUp", true);
            StartCoroutine(AnimationEnded());
            GetComponent<Animator>().SetBool("Walk", true);
            if (distance < 0.3f)
            {                
                GetComponent<Animator>().SetBool("Attack", true);
                GetComponent<Animator>().SetBool("Walk", false);
            }
        }
        else if (distance > BossRange)
        {
            GetComponent<Animator>().SetBool("Walk", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Axe"))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y);
            GetComponent<Animator>().SetBool("Death", true);
            StartCoroutine(AnimationEnded2());            
        }
    }
    private IEnumerator AnimationEnded()
    {
        yield return new WaitForSeconds(2.3f);
        Vector3 targetPosition = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        if (transform.position.x < player.transform.position.x)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    private IEnumerator AnimationEnded2()
    {
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }

    //public void OnDrawGizmos()
    //{
    //    Gizmos.DrawSphere(transform.position, 10f);
    //}
}
