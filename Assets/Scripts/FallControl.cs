using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallControl : MonoBehaviour
{

    public LayerMask groundMask;
    public float timeToReset;
    public float checkInterval;


    float currentTime = 0f;
    float timeFalling = 0f;

    Vector3 savedPosition;
    RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        savedPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        currentTime += Time.deltaTime;

        bool hit = Physics.Raycast(transform.position, Vector3.down, 100f, groundMask, QueryTriggerInteraction.Ignore);
        if (hit) timeFalling = 0;
        else timeFalling += Time.deltaTime;

        if (timeFalling > timeToReset){
            Reset();
        }

        if (currentTime > checkInterval) {
            if (hit) {
                hit = Physics.Raycast(transform.position, Vector3.down, 1f, groundMask, QueryTriggerInteraction.Ignore);

                if (hit) {
                    savedPosition = transform.position;
                }
            }

            currentTime = 0;
        }
    }


    void Reset() {
        transform.position = savedPosition;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}
