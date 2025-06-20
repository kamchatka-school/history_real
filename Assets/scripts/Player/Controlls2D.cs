using UnityEngine;
using UnityEngine.InputSystem;


public class Controlls2D : MonoBehaviour
{
    public float speed = 5f;
    public Animator animator;
    private Rigidbody2D _rigitbody;


    private void Awake()
    {
        _rigitbody = gameObject.GetComponent<Rigidbody2D>();
    }


    void LateUpdate()
    {
        // Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
        // bool isWalking = input.x != 0 || input.y != 0;
        // animator.SetBool("isWalking", isWalking);
        Flip();
    }


    void Flip()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.localEulerAngles = new Vector3(0, 0, 0);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            transform.localEulerAngles = new Vector3(0, 180, 0);
        }
    }


    public void OnMove(InputValue input)
    {
        _rigitbody.linearVelocity = input.Get<Vector2>() * new Vector2(speed, speed);
    }


}