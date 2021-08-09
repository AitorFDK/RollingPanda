using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PositionTracker : MonoBehaviour
{
    public enum InitialState { Recording, Playing, NaDeNa };

    public InitialState initialState = InitialState.NaDeNa;
    public string trackName;
    public float recordInterval;
    public Track track = new Track();
    private Coroutine recordingCoroutine;
    private float time;

    private bool playingTrack = false;
    private int currentIndex;
    LinkedListNode<PositionInTime> node;

    // Start is called before the first frame update
    void Start()
    {
        switch (initialState)
        {
            case InitialState.Recording:
                StartRecording();
                break;

            case InitialState.Playing:
                LoadTrack();
                PlayTrack();
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (playingTrack)
        {
            int iTime = (int)(time * 1000000);
            float currentTime = iTime / 1000000f;

            if (node != null && node.Value != null)
            {
                if (currentTime > node.Value.time)
                    node = node.Next;

                if (node != null)
                    transform.position = node.Value.position;
            }
        }
    }

    void StartRecording()
    {
        if (recordingCoroutine == null)
        {
            track.Clear();
            time = 0;
            recordingCoroutine = StartCoroutine(RecordTrack());
        }
    }

    void StopRecording()
    {
        if (recordingCoroutine != null)
        {
            StopCoroutine(recordingCoroutine);
            recordingCoroutine = null;
        }
    }

    IEnumerator RecordTrack()
    {
        while (true)
        {
            track.Add(time, transform.position);
            yield return new WaitForSeconds(recordInterval);
        }
    }

    public void PlayTrack()
    {
        StopRecording();
        playingTrack = true;
        time = 0;
        node = track.track.First;
    }

    public void SaveTrack()
    {
        if (recordingCoroutine != null)
        {
            string json = JsonUtility.ToJson(track);
            Track t = JsonUtility.FromJson<Track>(json);
            File.WriteAllText(string.Format("{0}/Tracks/{1}.json", Application.persistentDataPath, trackName), json);
        }
    }

    public void LoadTrack()
    {
        if (File.Exists(string.Format("{0}/Tracks/{1}.json", Application.persistentDataPath, trackName)))
        {
            string json = File.ReadAllText(string.Format("{0}/Tracks/{1}.json", Application.persistentDataPath, trackName));
            track = JsonUtility.FromJson<Track>(json);
        }
        else
        {
            Debug.LogWarning(string.Format("NO ESISTE: {0}/Tracks/{1}.json", Application.persistentDataPath, trackName));
            this.gameObject.SetActive(false);
        }
    }
}
