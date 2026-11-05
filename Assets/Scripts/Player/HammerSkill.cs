using UnityEngine;
using UnityEngine.InputSystem;

public class HammerSkill : MonoBehaviour
{
    //Constantes
    [SerializeField] private int hammerStrengh = 10;

    
    Rigidbody2D RB;

    public bool Usinghammer = false;

    private void Start()
    {
        Rigidbody2D RB = GetComponent<Rigidbody2D>();
    }

    public void UseHammer(InputAction.CallbackContext context)
    {
        Usinghammer = true;
        RB.linearVelocity = Vector3.zero;
        RB.gravityScale = hammerStrengh;
    }

}
