using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioSingleton : MonoBehaviour {
	private static AudioSingleton instance;	
	public static bool isDead = false;

	public AnimationCurve fadeCurve;

	[Range(0, 1)]
	public float minVolume;
	[Range(0, 1)]
	public float maxVolume;

	[Range(0,1)]
	public float deathVolume;

	public float fadeDuration = 2f;
	public float timeBetweenSongs = 1f;
	public AudioClip[] songs;

	private AudioClip currentSong;
	private AudioSource source;
	private float volume;

	public static AudioSingleton GetInstnce(){
		return instance;
	}

	private void Awake() {
		if (instance == null){
			instance = this;
			source = GetComponent<AudioSource>();
			Play();
			DontDestroyOnLoad(this.gameObject);
		} else 
		{
			Destroy(this.gameObject);
		}
	}

	public void Stop() {
		source.Stop();
		
	}

	public void Play() {
		// if (PlayerPrefs.GetInt("MusicOn") == 1)
		StartCoroutine(DJCoroutine());
	}

	private void Update() {
		if (volume < deathVolume)
			source.volume = volume;
		else
			source.volume = isDead ? deathVolume : volume;
	}

	IEnumerator DJCoroutine() {

		currentSong = nextSong();
		source.clip = currentSong;
		source.Play();

		volume = minVolume;
	
		while (source.time < fadeDuration) {
			volume = fadeCurve.Evaluate(source.time / fadeDuration) * maxVolume;
			yield return new WaitForEndOfFrame();
		}
		
		volume = maxVolume;

		yield return new WaitForSeconds(currentSong.length - fadeDuration * 2);

		float t = 0;
		while (t < fadeDuration) {
			t += Time.deltaTime;
			volume = fadeCurve.Evaluate((fadeDuration - t) / fadeDuration) * maxVolume;
			yield return new WaitForEndOfFrame();
		}

		volume = minVolume;

		yield return new WaitForSeconds(timeBetweenSongs);

		StartCoroutine(DJCoroutine());
	}

	AudioClip nextSong() {
		int i = Random.Range(0, songs.Length);
		
		if (currentSong == songs[i]) return nextSong();

		return songs[i];
	}



}
