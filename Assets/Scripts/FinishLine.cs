using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    public Timer timerRef;

    [Header("Canvas final")]
    public GameObject winCanvas;
    public GameObject newRecordText;

    private bool isNewRecord = false;
    

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == Tags.Player){
            FinishRacePrototipe();
        }
    }

    public void FinishRacePrototipe(){
        //Set record
        if(timerRef.currentTime < PlayerPrefs.GetFloat("Record", Mathf.Infinity)){
            PlayerPrefs.SetFloat("Record", timerRef.currentTime);
            isNewRecord = true;
        }
            
        
        //Stop Timer
        timerRef.Pause();

        //Mostrar menu win
        timerRef.gameObject.SetActive(false);
        winCanvas.SetActive(true);
        if(isNewRecord) newRecordText.SetActive(true);

    }

    public void FinishRace(){

    }

    public void Reset(){
        
        Scene actualScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(actualScene.name);
    }

}
