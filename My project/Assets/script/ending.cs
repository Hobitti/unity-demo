using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ending : MonoBehaviour
{

    [SerializeField] GameObject player;
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
        print(other.tag);
       bool completed= GameObject.FindGameObjectWithTag("Item").GetComponent<PickUp>().StartTimer;
        if (other.tag == ("Player")&& completed)
        {
            print("hey");
            player.GetComponent<Player>().levelCompleted();
        }
    }


}
