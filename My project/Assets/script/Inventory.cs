using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool[] isFull;
    public GameObject[] slots;
    public GameObject[] indicator;
    private int slotNumber;
    [SerializeField] GameObject Canvas;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            slotNumber = 0;
            updateSelectedSlot();
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            slotNumber = 1;
            updateSelectedSlot();
        }
        if (Input.GetKey(KeyCode.Alpha3))
        { 
            slotNumber = 2;
            updateSelectedSlot();
        }
        if (Input.GetKey(KeyCode.Alpha4))
        {
            slotNumber = 3;
            updateSelectedSlot();
        }

        if (Input.GetKey(KeyCode.Alpha5))                                       
        {                                                                       
            slotNumber = 4;
            updateSelectedSlot();
        }

        if (Input.GetKey(KeyCode.Q))
        {
            Canvas.transform.GetChild(slotNumber).GetComponent<Slot>().DropItem();
                
        }
    }

    private void updateSelectedSlot()
    {
        for (int i = 0; i < 5; i++)
        {
            if (i == slotNumber) indicator[i].SetActive(true);
            else indicator[i].SetActive(false);
        }
        
        
            
    }
}
