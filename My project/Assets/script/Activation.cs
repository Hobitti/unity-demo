using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Activation : MonoBehaviour
{
    public float damage;
    public AudioSource audioSource;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        transform.GetComponent<Animator>().Play("Spikes");
    //    }
    //}
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            anim.SetTrigger("activate");
            print(anim);
            //other.transform.GetComponent<Player>().damaged();
            audioSource.Play();
            
        }
    }
}
