using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ShieldBrokenSound : MonoBehaviour
{
    public AudioSource audioSource;
    public GameObject item;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(item == null)
        {
            Debug.Log("Shield has been destroyed");
            audioSource.Play();
        }
    }
}
