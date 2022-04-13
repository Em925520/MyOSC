using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace extOSC
{
    public class lcdSphereSendTest : MonoBehaviour
    {
        #region Public Vars

		public string Address = "/unitysphere/lcd";
        private bool onOff = flase;
        private Renderer theRenderer;

		[Header("OSC Settings")]
		public OSCTransmitter Transmitter;

		#endregion

		#region Unity Methods

        private void Start(){
            SendOSCOnOff();
            theRenderer = GetComponent<Renderer>();
            Debug.Log(theRenderer);
        }

		protected virtual void Update()
        {

		}

        private void OnMouseUp()
        {
            SendOSCOnOff();
        }

        private void SendOSCOnOff()
        {
            var OSCmessage = new OSCMessage(Address);

            //switch bool state;
            onOff = !onOff;

            if (onOff)
            {
                OSCmessage.AddValue(OSCValue.String("on"));
                //theRenderer.materail.SetColor("_Color",Color.yellow);
                GetComponent<Renderer>().materail.SetColor("_Color",Color.yellow);
            }else{
                OSCmessage.AddValue(OSCValue.String("off"));
                //theRenderer.materail.SetColor("_Color",Color.gray);
                GetComponent<Renderer>().materail.SetColor("_Color",Color.gray);
            }

            // //add current size as float to second value;
            float currentSize = transform.localScale.x;
            OSCmessage.AddValue(OSCValue.Float(currentSize));

            Transmitter.Send(OSCmessage){
                Debug.Log("send OSC: "+ OSCmessage);
            }
        }

		#endregion
    }
}