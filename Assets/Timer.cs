using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;//the new TMP text
using Unity.UI;

namespace extOSC.Examples
{
    public class Timer : MonoBehaviour
    {   
        #region Public Vars
        public float TimeToDisplay = 90;
        //public Canvas youLostText;
        // public float timeValue = 90;
        //public Text timertext;    this doesn't work anymore since you updated newer versions of unity
        public TextMeshProUGUI timerText;
        bool timerStarted = false;

        public string Address = "/time";
		[Header("OSC Settings")]
		public OSCTransmitter Transmitter;

		#endregion

        #region Unity Methods
        void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player") && !timerStarted)//if the player touches this object and timer did not start yet
            {
                StartCoroutine(TimerStarted());//start the timer after a mini pause
                timerStarted = true;//turn the timer on to start because it was false before
            }
        }
        IEnumerator TimerStarted()
        {
            //while Loops can execute a block of code as long as a specified condition is reached.
            while (true)//this is a loop to check if it is true
            {
                if (TimeToDisplay > 0)//TimeToDisplay is at 90 right now if it's bigger than zero, then start -1
                {
                    TimeToDisplay -= 1;
                }
                else if (TimeToDisplay == 0)//if TimeToDisplay turns into zero, then blablabla happens
                {
                    Debug.Log("yessssssss time ran out");
                    //TimeToDisplay -= 1;
                    // youLostText.enabled = true;

                    Debug.Log("timer: sending OSC");
                    var timeMessage = new OSCMessage(Address);
                    timeMessage = new OSCMessage(Address);
                    timeMessage.AddValue(OSCValue.Float(1));
                    // message.AddValue(OSCValue.String("a second value"));
                    Transmitter.Send(timeMessage);

                }


                //to display the time correctly, both minutes and seconds need to be calculted individually from the raw time value 
                float minutes = Mathf.FloorToInt(TimeToDisplay / 60);
                float seconds = Mathf.FloorToInt(TimeToDisplay % 60);//modulo operation that will returns the remainder, after dividison of one number by another
                                                                    //in this example, modulo is used to return the number of seconds from the total time value that do not make up a whole minute
                timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
                //{0:00} formating option with zerops as placeholders       this is variable "1" seconds
                //{1:00} this is variable "2" minutes
                //TimeToDisplay += 1;//this is the same thing to TimeToDisplay++
                // TimeToDisplay -= 1;
                yield return new WaitForSeconds(1);

                //break;
            }

        }
		#endregion
    }
}