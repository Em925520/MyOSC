using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDisable : MonoBehaviour
{
    // Start is called before the first frame update
  
    public GameObject Food;
 

    void OnCollisionEnter2D(Collision2D other)
    {// if the player touches the object then disable itself (it will disappear
        if (other.gameObject.CompareTag( "Player"))
        {
            //Food.SetActive(false); //disable the object
            Destroy(Food); //this will also work, same to the code line above
            Debug.Log("yum yumm");
         
            ScoringSystem.theScore += 1; // plus one whenver you ate a food
        }
    }

  
}
