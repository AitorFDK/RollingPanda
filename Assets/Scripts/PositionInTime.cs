using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PositionInTime : ISerializationCallbackReceiver
{
    [NonSerialized] public float time;
    [NonSerialized] public Vector3 position;
    
    [SerializeField] private int _time;
    [SerializeField] private int x;
    [SerializeField] private int y;
    [SerializeField] private int z;


    public PositionInTime(float time, Vector3 pos) {
        this.time = time;
        this.position = pos;
    }

    public void OnAfterDeserialize()
    {
        time = _time / 10000f;
        position = new Vector3(x / 1000f, y / 1000f, z / 1000f);
    }

    public void OnBeforeSerialize()
    {
        _time = (int)(time * 10000);
        x = (int)(position.x * 1000);
        y = (int)(position.y * 1000);
        z = (int)(position.z * 1000);
    }
}
