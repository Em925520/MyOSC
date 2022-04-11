/* Copyright (c) 2020 ExT (V.Sigalkin) */

using UnityEngine;

namespace extOSC.Examples
{
	public class Dragon_Send : MonoBehaviour
	{
		#region Public Vars

		public string Address = "/unitysphere";

		[Header("OSC Settings")]
		public OSCTransmitter Transmitter;

		#endregion

		#region Unity Methods

		protected virtual void Start()
		{
			//sending dragon's movement by aruino
			//ex press a button in arduio then send dragon movement (playermovement)
			var OSCmessage = new OSCMessage(Address);//creates a new message
													 //check if the position of the dragon is changed then send the float data of the position to console
			float Dragon_position = transform.localPosition.x;
			
			transform.localScale = new Vector3(floatData0mapped, floatData0mapped, floatData0mapped);










			/*
			var OSCmessage = new OSCMessage(Address);//creates a new message and
			float currentSize = transform.localScale.x;
			// the line above : checking if the scale of the object is changed then send the float data to console
			OSCmessage.AddValue(OSCValue.Float(currentSize));
			OSCmessage.AddValue(OSCValue.Float(3.14159f));
			//OSCmessage.AddValue(OSCValue.String("Hello, world!"));//adding a value of a string called hello world

			Transmitter.Send(OSCmessage);
			Debug.Log("send OSC + " + OSCmessage);
			*/
		}

		#endregion
	}
}