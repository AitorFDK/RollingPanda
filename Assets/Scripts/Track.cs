using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[Serializable]
public class Track : ISerializationCallbackReceiver
{
    [NonSerialized] public LinkedList<PositionInTime> track;
    [SerializeField] List<PositionInTime> _trackList;

    public Track() {
        track = new LinkedList<PositionInTime>();
    }

    public void Add(float time, Vector3 position) => track.AddLast(new PositionInTime(time, position));
    public void Add(PositionInTime p) => track.AddLast(p);
    public void Clear() => track.Clear();

    public void OnAfterDeserialize()
    {
        track = new LinkedList<PositionInTime>(_trackList);
    }

    public void OnBeforeSerialize()
    {
        _trackList = track.ToList();
    }
}
