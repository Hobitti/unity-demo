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


    private void OnCollisionEnter(Collision collision)//dmg trigger    
    {
        print("test");
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.GetComponent<Player>().damaged();
        }
    }
}
