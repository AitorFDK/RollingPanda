using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colisionable : MonoBehaviour
{

    public enum TipoColision { Rebote, ParadaSeca, RomperFrenar }
    public float multiplicador;
    public TipoColision tipo;
    public LayerMask playerLayer;
    public AudioClip[] onHitClip;
    [Range(0,1)]
    public float minVolume;
    [Range(0,1)]
    public float maxVolume;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.tag != Tags.Player && other.gameObject.layer != playerLayer) return;

        switch (tipo)
        {

            case TipoColision.Rebote:
                PlayHitClip();
                other.gameObject.GetComponent<Rigidbody>().AddForce(other.impulse.normalized * other.relativeVelocity.magnitude * multiplicador, ForceMode.Impulse);
                break;

            case TipoColision.ParadaSeca:
                PlayHitClip();
                other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                break;
        }

    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag != Tags.Player && other.gameObject.layer != playerLayer) return;

        switch (tipo)
        {
            case TipoColision.RomperFrenar:            
                other.gameObject.GetComponent<Rigidbody>().velocity *= multiplicador;
                PlayHitClip();
                Destroy(this.gameObject, .1f);
                break;
        }
    }

    private void PlayHitClip() {
        if (onHitClip.Length == 0) return;
        
        AudioSource asource = GetComponent<AudioSource>();
        if (asource != null) {
            AudioClip c = onHitClip[Random.Range(0,onHitClip.Length)];
            asource.volume = Random.Range(minVolume, maxVolume);
            asource.PlayOneShot(c);
        }
    }
}
