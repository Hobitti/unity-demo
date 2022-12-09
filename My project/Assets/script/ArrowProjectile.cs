using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowProjectile : MonoBehaviour
{
    public float velocity;



    void Start()
    {
        
    }

    void Update()
    {
        transform.position += velocity * gameObject.transform.up * Time.deltaTime;
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        print("You have been hit");
            

    //    }
    //}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            collision.transform.GetComponent<Player>().damaged();
        }
        if (collision.collider.tag == "Shield")
        {
            Debug.Log("Blocked");
            Destroy(gameObject,0.1f);
            GameObject.Find("skull shield").GetComponent<ShieldScript>().hasBlocked = false;
        }

    }

   
}
