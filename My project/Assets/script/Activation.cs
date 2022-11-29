using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activation : MonoBehaviour
{
    public float damage;

    // Start is called before the first frame update
    void Start()
    {
        
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
            transform.GetComponent<Animator>().Play("Spikes");
        }
    }
}
