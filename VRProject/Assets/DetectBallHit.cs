using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectBallHit : MonoBehaviour
{
    public Rigidbody ballRigidbody;
    public float forceAmount;

    public void AddSpeed()
    {
        ballRigidbody.velocity *= forceAmount; 
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("bat"))
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.isKinematic = false;
        }
    }
}
