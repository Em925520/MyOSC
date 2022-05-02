using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testingAudio : MonoBehaviour
{
    public AudioClip testing_audio;
    public AudioSource _audioSource;
   
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            Debug.Log("pressed");
            _audioSource.Play();
         
        }
       
    }
}
