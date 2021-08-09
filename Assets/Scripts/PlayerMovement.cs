using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    public Transform _camera;
    public GameObject fantasmaGO;

    [Header("Movement parameters")]
    public float walkVelocity;
    public float movementForce;
    public float airMovementForce;
    public bool drawDirection;
    public float velocityLimit;

    [Header("Jump parameters")]
    public AnimationCurve jumpCurve;
    public float coyoteTime;
    public float maxJumpTime;
    private float airTime;
    private float jumpTime;
    public float castGroundDistance;
    public float sphereCastRadious;
    public LayerMask groundMask;

    [Header("Gravity")]
    public float fallMultiplier = 2.5f;

    public enum PandaState { Walking, Rolling }
    public PandaState pandaState;


    public Vector3 direction;
    private Vector2 inputMovement;
    private Rigidbody rb;
    private bool jumpPressed;
    private bool grounded;
    private float jumpY = 0;
    private float jumps = 0;
    private bool trackStarted = false;

    private Vector3 forward;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Application.targetFrameRate = 120;

        maxJumpTime = jumpCurve.keys[jumpCurve.length - 1].time;

        
        GameObject.FindObjectOfType<Timer>().Pause();
        rb.constraints = RigidbodyConstraints.FreezeAll;

        fantasmaGO.SetActive(false);
    }

    // private void FixedUpdate() {
    //     rb.rotation = Quaternion.Lerp(Quaternion.LookRotation(rb.velocity.normalized, Vector3.up), Quaternion.LookRotation(direction.normalized, Vector3.up), .1f);
    // }


    void Update()
    {
        direction = new Vector3(inputMovement.x, 0, inputMovement.y);

        if (!trackStarted && direction.magnitude >= .3f) {
            rb.constraints = RigidbodyConstraints.None;
            trackStarted = true;
            GameObject.FindObjectOfType<Timer>().Reset();
            GameObject.FindObjectOfType<Timer>().Resume();
            PositionTracker pt = GetComponent<PositionTracker>();
            pt.StopRecording();
            pt.StartRecording();

            fantasmaGO.SetActive(true);
            fantasmaGO.GetComponent<PositionTracker>().LoadTrack();
            fantasmaGO.GetComponent<PositionTracker>().PlayTrack();
        }

        if (!trackStarted) return;

        ////////////// MOVIMIENTO
        switch (pandaState)
        {
            case PandaState.Walking:
                Vector3 aux = transform.localPosition + direction * walkVelocity * Time.deltaTime;
                rb.MovePosition(aux);
                break;
            case PandaState.Rolling:
                rb.AddForce(direction * (grounded ? movementForce : airMovementForce) * Time.deltaTime, ForceMode.Acceleration);
                break;
        }

        ////////////// TOCANDO EL SUELO???
        RaycastHit hitInfo;

        if (grounded = Physics.SphereCast(transform.position + Vector3.up * 0.12f, sphereCastRadious, Vector3.down, out hitInfo, castGroundDistance, groundMask))
        {
            // if (airTime > 1) {
            //     rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            //     transform.position = hitInfo.point + Vector3.up * 0.5f;
            // }
            airTime = 0;
            jumpTime = 0;
            jumps = 0;
        }
        else
            airTime += Time.deltaTime;

        ////////////// GRAVEDAD
        if (!grounded && (jumpTime == 0 || jumpTime >= maxJumpTime))
        {
            rb.velocity = rb.velocity + Vector3.down * -Physics.gravity.y * (fallMultiplier * Time.deltaTime);
        }

        ////////////// SALTO
        if (!jumpPressed) jumpTime = 0;

        if (jumpPressed && (grounded || airTime < coyoteTime) && jumps == 0)
        {
            jumpTime = 0.000001f; // pirulilla para que entre en el timing de saltar
            jumpY = transform.position.y;
            jumps++;
        }

        if (jumpTime > 0 && jumpTime < maxJumpTime)
        {
            jumpTime += Time.deltaTime;

            float yOffset = jumpCurve.Evaluate(jumpTime);
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);

            Vector3 p = transform.position;
            transform.position = new Vector3(p.x, jumpY + yOffset, p.z);
        }

        ////////////// LIMITADOR VELOCIDAD
        if (rb.velocity.magnitude >= velocityLimit) rb.velocity = rb.velocity.normalized * velocityLimit;

        // if (rb.velocity.magnitude >= velocityLimit)
        // {
        //     rb.velocity = forward * velocityLimit;
        // }




        if (inputMovement == Vector2.zero && rb.velocity.magnitude <= 1f && grounded)
            rb.velocity = Vector3.zero;
            

        ////////////// DEBUG INFO
        if (drawDirection && direction != Vector3.zero)
        {
            Debug.DrawLine(transform.position, transform.position + direction * 5, Color.red);
        }

        if (drawDirection)
        {
            Debug.DrawLine(transform.position, transform.position + rb.velocity.normalized * 5, Color.blue);
        }


    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position + Vector3.up * 0.12f, Vector3.down * castGroundDistance);

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
