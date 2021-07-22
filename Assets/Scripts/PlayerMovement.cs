using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    public InputAction controls;
    public float walkVelocity;
    public float movementForce;
    public bool drawDirection;
    public float velocityLimit;

    public enum PandaState { Walking, Rolling}
    public PandaState pandaState;

    private Vector3 direction;
    private Vector2 inputMovement;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        direction = new Vector3(inputMovement.x, 0, inputMovement.y);

        switch (pandaState) {
            case PandaState.Walking:
                Vector3 aux = transform.localPosition + direction * walkVelocity * Time.deltaTime;
                rb.MovePosition(aux);
                break;
            case PandaState.Rolling:
                rb.AddForce(direction * movementForce * Time.deltaTime, ForceMode.Acceleration);
                break;
        }

        if (drawDirection && direction != Vector3.zero)
        {
            Debug.DrawLine(transform.position, transform.position + direction * 5, Color.red);
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        inputMovement = context.ReadValue<Vector2>();
    }

    public void Jump(InputAction.CallbackContext context)
    {
        Debug.Log(context.ReadValueAsObject());
    }

    public void ChangeMode(InputAction.CallbackContext context)
    {
        if (pandaState == PandaState.Walking) pandaState = PandaState.Rolling;
        else pandaState = PandaState.Walking;
    }
}
