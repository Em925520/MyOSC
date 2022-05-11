using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//allow the script to reference ui
using TMPro;//the new TMP text

//https://www.youtube.com/watch?time_continue=694&v=D0lx90n0s-4&feature=emb_logo
//this script is to change text when we collect the object (to control everything
public class ScoringSystem : MonoBehaviour
    {
        public GameObject scoreText;
        public static int theScore;

    void Update()
    {
       scoreText.GetComponent<TextMeshProUGUI>().text = "SCORE : " + theScore;

    }
    
}

//previous code from youtube just changing text when you collect the object
    /*
    public GameObject scoreText;
    public int theScore;
    public AudioSource collectSound;//sound effects when the player touches the object

    void OnTriggerEnter2D(Collider2D other)
    {
        collectSound.Play();
        //before we change the score into 50
        theScore += 1;
        //reference to the game object text
        scoreText.GetComponent<Text>().text = "SCORE : " + theScore;
        Destroy(gameObject);
    }*/
