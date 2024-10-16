using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalTrigger : MonoBehaviour
{

    public int points;
    public UpdateCounter updateCounter;
    public SpawnBall spawnBall;
    public AudioSource audioClip;
    public ParticleSystem particleSystem;
    
    void OnTriggerEnter(Collider other)
    {
        updateCounter.incrementCounter(points);
        spawnBall.respawnBall();
        audioClip.Play();
        particleSystem.Play();
    }
}
