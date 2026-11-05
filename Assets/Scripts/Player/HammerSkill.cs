using UnityEngine;
using UnityEngine.InputSystem;

public class HammerSkill : MonoBehaviour
{
    //Constantes
    [SerializeField] private int hammerStrengh = 10;


    public bool Usinghammer = false;

    public void UseHammer(InputAction.CallbackContext context)
    {
        Usinghammer = true;
        Rigidbody2D RB = GetComponent<Rigidbody2D>();
        RB.linearVelocity = Vector3.zero;
        RB.gravityScale = hammerStrengh;
    }

}
