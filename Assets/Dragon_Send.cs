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
			//每次update传一下position        那个vector3 event接收
			/*
			 *  sending dragon's movement by arudino through osc
			 *  
			 *  1. write down dragon controller script with the basic movements in start
			 *  2. send dragon (player)'s position in update whenever player moves
			 *  3. send dragon's data on pressing a button to blow fire 
			 *  (if statement that 0 is not blowing fire and 1 is blowing fire once a button is pressed
			 *  4. if fire collides with enemy twice, destory(enemy)
			 * 
			 * 
			 * 
			 * receiving data through osc
			 * 
			 * 1. detect if the dragon is moving
			 * 2. if the dragon is moving in the scene, receive the data of the dragon position
			 * 3. detect if dragon is blowing fire or not, if the dragon is blowing-- receiving "1", if dragon is not blowing receiving "0"
			 * 4. receiveing data of the #times the fire is blowing colliding with enemy
			
			
			

			var OSCmessage = new OSCMessage(Address);//creates a new message
			//check if the position of the dragon is changed then send the float data of the position to console 
			//sending this data to osc
			float Dragon_position = transform.localPosition.x;
			OSCmessage.AddValue(OSCValue.Float(Dragon_position));
			transform.position = new Vector2(floatData0mapped, floatData0mapped);







			Debug.Log("send OSC + " + OSCmessage);
			Transmitter.Send(OSCmessage);

		/*
			
			OSCmessage.AddValue(OSCValue.Float(3.14159f));
			//OSCmessage.AddValue(OSCValue.String("Hello, world!"));//adding a value of a string called hello world

			;
			
			*/
		}

		#endregion
	}
}