using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSpawn : MonoBehaviour
{
    [SerializeField] private PlayerMovement player;
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Spawnpoint")
        {
            player.setRespawnPoint(gameObject.transform.position);
        }
    }
}
