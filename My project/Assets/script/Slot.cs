using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    private Inventory inventory;
    public int i;
    public GameObject item;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    private void Update()
    {
        if(transform.childCount <= 0)
        {
            inventory.isFull[i]= false;
        }
    }
    

    public void DropItem()
    {
        foreach ( Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
            item.GetComponent<Renderer>().enabled = true;
            item.GetComponent<PickUp>().pickUpCD();
            item.transform.position = GameObject.FindGameObjectWithTag("Player").transform.position;
            item.transform.position = new  Vector3(item.transform.position.x, 2f, item.transform.position.z);
        }
    }


}
