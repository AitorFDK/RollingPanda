using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMove : MonoBehaviour
{

    public float force;
    public bool drawDirection;

    float h;
    float v;
    Vector3 direction;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        h = -Input.GetAxis("Horizontal");
        v = -Input.GetAxis("Vertical");

        direction = new Vector3(h, 0, v).normalized;
        Debug.Log(direction);

        rb.AddForce(direction * force * Time.deltaTime, ForceMode.Acceleration);

        if (drawDirection && direction != Vector3.zero)
        {
            Debug.DrawLine(transform.position, transform.position + direction * 5, Color.red);
        }
    }
}
