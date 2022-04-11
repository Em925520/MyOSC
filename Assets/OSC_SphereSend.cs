/* Copyright (c) 2020 ExT (V.Sigalkin) */

using UnityEngine;

namespace extOSC.Examples
{
	public class OSC_SphereSend : MonoBehaviour
	{
		#region Public Vars

		public string Address = "/unitysphere";

		[Header("OSC Settings")]
		public OSCTransmitter Transmitter;

		#endregion

		#region Unity Methods

		protected virtual void Start() //it is visible only inside this class and classes derived from it. virtual means that it can be overriden in derived classes.
		{
			var OSCmessage = new OSCMessage(Address);//creates a new message and
			float currentSize = transform.localScale.x;
			// the line above : checking if the scale of the object is changed then send the float data to console
			OSCmessage.AddValue(OSCValue.Float(currentSize));
			OSCmessage.AddValue(OSCValue.Float(3.14159f));
			//OSCmessage.AddValue(OSCValue.String("Hello, world!"));//adding a value of a string called hello world

			Transmitter.Send(OSCmessage);
			Debug.Log("send OSC + " + OSCmessage);
		}

		#endregion
	}
}