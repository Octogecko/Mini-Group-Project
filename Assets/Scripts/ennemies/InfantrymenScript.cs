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
            Debug.Log(player + " is higher " + gameObject);
            //Protection animation active
        }

        else
        {
            Debug.Log("No worries.");
            //Protection animation disabled
        }
    }

    bool PlayerIsHigher(Transform player, Transform infantryman)
    {
        return player.position.y > infantryman.position.y;
    }
}
