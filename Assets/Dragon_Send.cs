/* Copyright (c) 2020 ExT (V.Sigalkin) */

using UnityEngine;

namespace extOSC.Examples
{
	
	public class Dragon_Send : MonoBehaviour
	{
		#region Public Vars

		public string Address = "/gameStatus";

		[Header("OSC Settings")]
		public OSCTransmitter Transmitter;

		#endregion



		#region Unity Methods

		void Start()
		{

           
		}
        
       void Update()
        {
			// Debug.Log("score: "+ScoringSystem.theScore);
			var gameStatusOSCmessage = new OSCMessage(Address);//creates a new message
													 //check if the position of the dragon is changed then send the float data of the position to console 
													 //sending this data to osc
			gameStatusOSCmessage = new OSCMessage(Address);
			// if(ScoringSystem.theScore ==0){//win
			// 	gameStatusOSCmessage.AddValue(OSCValue.Float(1));
			// 	Debug.Log("score: "+ScoringSystem.theScore);
			// 	Transmitter.Send(gameStatusOSCmessage);
			// }
		}

		//换成trigger;
		// private void OnMouseDown()
        // {
		// 	Debug.Log("sending OSC");
		// 	var message = new OSCMessage(Address);
		// 	message = new OSCMessage(Address);
		// 	message.AddValue(OSCValue.Float(1));
		// 	// message.AddValue(OSCValue.String("a second value"));

		// 	Transmitter.Send(message);
		// }

		#endregion
	}
}

























//OSC SENDING MESSAGE CONCEPT


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
 * 
 * 
 * 
 * 
 * 
 */