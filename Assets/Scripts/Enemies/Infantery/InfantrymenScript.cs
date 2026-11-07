using UnityEngine;

public class InfantrymenScript : MonoBehaviour
{
    public GameObject player;
    void Start()
    {
        
    }


    void FixedUpdate()
    {
        if (PlayerIsHigher(player.transform, gameObject.transform))
        {
            GetComponent<Animator>().SetBool("shield", true);
        }

        else
        {
            GetComponent<Animator>().SetBool("shield",false);
        }
    }

    bool PlayerIsHigher(Transform player, Transform infantryman)
    {
        return player.position.y > infantryman.position.y;
    }
}
