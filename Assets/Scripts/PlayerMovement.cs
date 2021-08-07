using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    public Transform _camera;

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

    [Header("Gravity")]
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplayer = 2f;

    public enum PandaState { Walking, Rolling}
    public PandaState pandaState;

    public Vector3 direction;
    private Vector2 inputMovement;
    private Rigidbody rb;
    private bool jumpPressed;
    private bool grounded;

    private Vector3 forward;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Application.targetFrameRate = 60;
        forward = Vector3.forward;
    }

    // Update is called once per frame
    void Update()
    {
        direction = new Vector3(inputMovement.x, 0, inputMovement.y);

        if (rb.velocity.magnitude >= 0.2f)
            forward = rb.velocity.normalized;

        

        //Movimiento
        switch (pandaState) {
            case PandaState.Walking:
                Vector3 aux = transform.localPosition + direction * walkVelocity * Time.deltaTime;
                rb.MovePosition(aux);
                break;
            case PandaState.Rolling:
                //transform.forward = forward;
                //rb.AddForce(direction * movementForce * Time.deltaTime, ForceMode.Acceleration);
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

        //Rotacio personaje
        /*if( direction != Vector3.zero)
        {
            transform.forward = Vector3.Slerp(transform.forward, direction, 1f * Time.deltaTime);

        }*/
        //transform.right = direction.x;


        //Gravedad
        if (rb.velocity.y < -1)
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y + 1 * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime, rb.velocity.z);
        }
        else
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y + 1 * Physics.gravity.y * (lowJumpMultiplayer - 1) * Time.deltaTime, rb.velocity.z);
        }


        //Limitadores de velocidad

        if (rb.velocity.magnitude >= velocityLimit)
        {
            rb.velocity = forward * velocityLimit;
        }




        if (inputMovement == Vector2.zero && rb.velocity.magnitude <= 1f && grounded)
            rb.velocity = Vector3.zero;
            

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
        //CameraUtil.shakeCamera();
    }

    public void ChangeMode(InputAction.CallbackContext context)
    {
        if (pandaState == PandaState.Walking) pandaState = PandaState.Rolling;
        else pandaState = PandaState.Walking;
    }


}
