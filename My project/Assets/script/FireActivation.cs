using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class FireActivation : MonoBehaviour
{

    public ParticleSystem fire;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            fire.Play();
            other.transform.GetComponent<Player>().damaged();

            if (fire.isPlaying)
            {
                audioSource.Play();
                
            }
            if (!fire.isPlaying)
            {
                audioSource.Stop();
            }

        }
    }

    private void OnParticleCollision(GameObject other)
    {
        other.transform.GetComponent<Player>().damaged();
    }

}
