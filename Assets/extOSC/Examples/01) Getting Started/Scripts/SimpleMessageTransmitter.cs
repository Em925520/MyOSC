/* Copyright (c) 2020 ExT (V.Sigalkin) */

using UnityEngine;

namespace extOSC.Examples
{
	public class SimpleMessageTransmitter : MonoBehaviour
	{
		#region Public Vars

		public string Address = "/example/1";

		[Header("OSC Settings")]
		public OSCTransmitter Transmitter;

		#endregion

		#region Unity Methods

		protected virtual void Start()
		{
			var message = new OSCMessage(Address);//creates a new message and
			message.AddValue(OSCValue.String("Hello, world!"));//adding a value of a string called hello world

			Transmitter.Send(message);
		}

		#endregion
	}
}