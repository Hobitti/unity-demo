using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTrap : MonoBehaviour
{
    public GameObject arrowProjectile;
    public Transform spawnLocation;
    public Quaternion spawnRotation;
    public float spawnTime = 0.5f;
    private float timeSinceSpawned = 0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //timeSinceSpawned += Time.deltaTime;
        //if (timeSinceSpawned >= spawnTime)
        //{
        //    Instantiate(arrowProjectile, spawnLocation.position,spawnLocation.rotation);
        //    timeSinceSpawned = 0f;
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            Instantiate(arrowProjectile, spawnLocation.position, spawnLocation.rotation);

        }
    }
}
