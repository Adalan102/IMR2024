using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBall : MonoBehaviour
{

    public Transform spawnPoint;
    public GameObject ballPrefab;

    public void respawnBall() {

        ballPrefab.transform.position = spawnPoint.position;
        ballPrefab.transform.rotation = Quaternion.identity;
        
        Rigidbody rb = ballPrefab.GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }
}
