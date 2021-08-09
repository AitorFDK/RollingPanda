using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    public Timer timerRef;

    [Header("Canvas final")]
    public GameObject winCanvas;
    public GameObject newRecordText;

    private bool isNewRecord = false;
    private GameObject player;
    private bool isEnd = false;
    public InputAction resetButton;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == Tags.Player)
        {
            isEnd = true;
            player = other.gameObject;
            FinishRacePrototipe();
        }
    }

    public void ClicarBoton() {
        if (isEnd) {
            Reset();
        }
    }

    public void FinishRacePrototipe()
    {
        //Set record
        if (timerRef.currentTime < PlayerPrefs.GetFloat("Record", Mathf.Infinity))
        {
            PlayerPrefs.SetFloat("Record", timerRef.currentTime);
            isNewRecord = true;
        }


        //Stop Timer
        timerRef.Pause();

        //Mostrar menu win
        timerRef.gameObject.SetActive(false);
        winCanvas.SetActive(true);
        player.GetComponent<PlayerMovement>().enabled = false;
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        player.GetComponent<FallControl>().enabled = false;
        
        if (isNewRecord)
        {
            player.GetComponent<PositionTracker>().SaveTrack();
            newRecordText.SetActive(true);
        }

    }

    public void FinishRace()
    {

    }

    public void Reset()
    {

        Scene actualScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(actualScene.name);
    }

}
