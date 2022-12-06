using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireActivation : MonoBehaviour
{

    public ParticleSystem fire;
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
        if (other.gameObject.CompareTag("Player"))
        {
            fire.Play();
<<<<<<< Updated upstream
=======
            other.transform.GetComponent<Player>().damaged();
>>>>>>> Stashed changes

        }
    }
}
