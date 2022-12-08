using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour
{
    private Rigidbody itemRb;
    public Transform rightHand;
    public GameObject item;
    public bool isEquipped;
    // Start is called before the first frame update
    void Start()
    {
        isEquipped = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKey(KeyCode.F) && isEquipped)
        {
            this.transform.parent = null;
            itemRb = item.gameObject.GetComponent<Rigidbody>();

            isEquipped = false;
            itemRb.isKinematic = false;
            itemRb.detectCollisions = true;
            itemRb.useGravity = true;
        }
    }

    public void OnCollisionStay(Collision collision)
    {
        //Pick up item on key press, parent to hand and disable rigidbody
        if (collision.gameObject.CompareTag("Player") && Input.GetKey(KeyCode.E) && !isEquipped)
        {
            isEquipped = true;
            print("YES");
            Debug.Log(isEquipped);
            item.transform.position = rightHand.position;
            item.transform.rotation = rightHand.rotation;
            isEquipped = true;


            itemRb = item.gameObject.GetComponent<Rigidbody>();
            itemRb.transform.parent = rightHand.transform;
            itemRb.isKinematic = true;
            itemRb.detectCollisions = false;


        }


    }

}
