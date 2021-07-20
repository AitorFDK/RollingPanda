using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class FallControl : MonoBehaviour
{

    public LayerMask groundMask;
    public float timeToReset;
    public float delayOnReset;
    public float checkInterval;

    public Volume postProcess;
    public float timeToStartVignette = 1f;

    float currentTime = 0f;
    float timeFalling = 0f;

    Vector3 savedPosition;
    RaycastHit hit;
    Vignette vg;

    // Start is called before the first frame update
    void Start()
    {
        savedPosition = transform.position;
        postProcess.profile.TryGet<Vignette>(out vg);
    }

    // Update is called once per frame
    void Update()
    {
        
        currentTime += Time.deltaTime;

        bool hit = Physics.Raycast(transform.position, Vector3.down, 100f, groundMask, QueryTriggerInteraction.Ignore);
        if (hit) timeFalling = 0;
        else timeFalling += Time.deltaTime;

        if (timeFalling > timeToStartVignette) {
            vg.intensity.value = (timeFalling-timeToStartVignette) / timeToReset;
        } else {
            vg.intensity.value = 0f;
        }

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
        
        StartCoroutine(BlockMovement(delayOnReset));
        
    }

    IEnumerator BlockMovement(float time) {
        
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;

        rb.isKinematic = true;

        MeshRenderer mr = GetComponent<MeshRenderer>();
        
        float timeElapsed = 0f;

        while (timeElapsed < time) {
            
            mr.enabled = !mr.enabled;

            yield return new WaitForSeconds(.25f);

            timeElapsed += .25f;
        }

        mr.enabled = true;
        rb.isKinematic = false;

    }
}
