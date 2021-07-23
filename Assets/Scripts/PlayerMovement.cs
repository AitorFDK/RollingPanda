using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    [Header("Movement parameters")]
    public float walkVelocity;
    public float movementForce;
    public bool drawDirection;
    public float velocityLimit;

    [Header("Jump parameters")]
    public float jumpForce;
    public float coyoteTime;
    public float maxJumpTime;
    private float airTime;
    private float jumpTime;
    public float castGroundDistance;
    public float sphereCastRadious;
    public LayerMask groundMask;

    public enum PandaState { Walking, Rolling}
    public PandaState pandaState;

    private Vector3 direction;
    private Vector2 inputMovement;
    private Rigidbody rb;
    private bool jumpPressed;
    private bool grounded;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        direction = new Vector3(inputMovement.x, 0, inputMovement.y);

        //Movimiento
        switch (pandaState) {
            case PandaState.Walking:
                Vector3 aux = transform.localPosition + direction * walkVelocity * Time.deltaTime;
                rb.MovePosition(aux);
                break;
            case PandaState.Rolling:
                rb.AddForce(direction * movementForce * Time.deltaTime, ForceMode.Acceleration);
                break;
        }

        // grounded
        RaycastHit hitInfo;

        if (grounded = Physics.SphereCast(transform.position + Vector3.up * 0.12f, sphereCastRadious, Vector3.down, out hitInfo, castGroundDistance, groundMask))
        {
            airTime = 0;
            jumpTime = 0;
        }
        else
            airTime += Time.deltaTime;

        //Salto
        if (jumpPressed && jumpTime < maxJumpTime) {
            if (grounded || airTime < coyoteTime)
            {
                float jumpVelocity = jumpForce * (rb.velocity.magnitude / velocityLimit);
                //rb.AddForce(Vector3.up * jumpForce * Time.deltaTime, ForceMode.Impulse);
                rb.velocity = new Vector3(rb.velocity.x, jumpVelocity, rb.velocity.z);
                jumpTime += Time.deltaTime;
            }
        }


        //Limitadores de velocidad
        if (rb.velocity.magnitude >= velocityLimit) rb.velocity = rb.velocity.normalized * velocityLimit;

        if (inputMovement == Vector2.zero && rb.velocity.magnitude <= 1f && grounded) rb.velocity = Vector3.zero;

        // Lineas de debug
        if (drawDirection && direction != Vector3.zero)
        {
            Debug.DrawLine(transform.position, transform.position + direction * 5, Color.red);
        }

       
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position + Vector3.up * 0.12f , Vector3.down * castGroundDistance);
        
    }



    public void Move(InputAction.CallbackContext context)
    {
        inputMovement = context.ReadValue<Vector2>();
    }

    public void Jump(InputAction.CallbackContext context)
    {
        jumpPressed = context.ReadValue<float>() != 0;
    }

    public void ChangeMode(InputAction.CallbackContext context)
    {
        if (pandaState == PandaState.Walking) pandaState = PandaState.Rolling;
        else pandaState = PandaState.Walking;
    }


}
