using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionPoint : MonoBehaviour
{
    public PlayerMovement playerRef;

    private void LateUpdate()
    {
        transform.position =  Vector3.Lerp(transform.position, playerRef.transform.position - playerRef.direction * 5f, 1f * Time.deltaTime);

    }



}
