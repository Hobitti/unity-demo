using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeDamage : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        Debug.Log("You have been Hit");
    //        other.transform.GetComponent<Player>().damaged();
    //    }
    //}

    public void OnCollisionStay(Collision collision)
    {
        //Pick up item on key press, parent to hand and disable rigidbody
        if (collision.gameObject.CompareTag("Player"))
        {

            Debug.Log("You have been Hit");
            collision.transform.GetComponent<Player>().damaged();
        }

    }


    
}
