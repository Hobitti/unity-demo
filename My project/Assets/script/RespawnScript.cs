using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnScript : MonoBehaviour
{
    [SerializeField] private Transform playerUnit;
    [SerializeField] private Transform respawnPoint;
    [SerializeField] Player Player;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            playerUnit.transform.position = respawnPoint.transform.position;
            Physics.SyncTransforms();
            Player.damaged();
        }
    }

}
