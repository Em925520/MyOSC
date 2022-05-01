using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this is where it collects (math
public class Collect_Food : MonoBehaviour
{
    public AudioSource collectSound;

    void OnTriggerEnter2D(Collider2D other)
    {
        collectSound.Play();

        ScoringSystems.theScore += 1;

        Destroy(gameObject);
    }
}