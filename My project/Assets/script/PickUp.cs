using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    private Inventory inventory;
    public GameObject item;
    [SerializeField] Canvas Canvas;
    bool cd= false;

    [SerializeField]
    AudioClip sound;
    // Start is called before the first frame update
    void Start()
    {

        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SoundManager.instance.PlaySingle(sound);

            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (!inventory.isFull[i] && !cd)
                {
                    inventory.isFull[i] = true;
                    Instantiate(item, inventory.slots[i].transform, false);
                    Canvas.transform.GetChild(i).GetComponent<Slot>().item = gameObject;
                    gameObject.SetActive(false);
                    break;
                }
                
            }
            cd = false;
        } 
    }
    public void pickUpCD()
    {
        cd = true;
    }
}
