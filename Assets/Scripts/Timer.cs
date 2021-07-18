using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{

    public float currentTime { get; private set; }
    public bool runOnStart = true;
    public bool paused = false;
    public TextMeshProUGUI [] textMeshes;
    

    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0f;
        paused = !runOnStart;
    }

    // Update is called once per frame
    void Update()
    {
        if (!paused) {
            currentTime += Time.deltaTime;
            Draw();
        }
    }

    public void Draw() {
        string str = FormatTime(currentTime);

        for (int i = 0; i < textMeshes.Length; i++) {
            textMeshes[i].text = str;
        }
    }

    private string FormatTime (float time) {
        int minutes = (int)(time / 60f);
        int seconds = (int)(time % 60);
        int fraction = (int)(time * 1000);
        fraction = fraction % 1000;
        
        return string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, fraction);
    }

    public void Reset()  {
        currentTime = 0f;
    }

    public float GetTime() {
        return currentTime;
    }

    public void Pause() {
        paused = true;
    }

    public void Resume() {
        paused = false;
    }
}
