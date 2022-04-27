/* Copyright (c) 2020 ExT (V.Sigalkin) */

using UnityEngine;

namespace extOSC.Examples
{
	public class Dragon_Send : MonoBehaviour
	{
		#region Public Vars

		public string Address = "/unitydragon";

		[Header("OSC Settings")]
		public OSCTransmitter Transmitter;

		/*shang shang arduiono stuff
		private bool onOff = false;
		private Renderer theRenderer;
		*/

		//dragon player movement
		Vector2 left;
		Vector2 right;
		//Vector2 up;
		public Vector2 localPosition;


		public int speed = 20;
		public int jumpForce = 300;
		Rigidbody2D _rigidbody;
		Animator _animator;
		public Transform feet; //assigned with empty game object and tag on the player's feet
		public LayerMask groundLayer;
		public bool isGrounded = false;//bool checks if a statement is true or false
									   // public GameObject FallingPlatform;
		AudioSource _audioSource;
		public AudioClip Blowing_FireSound;
		public AudioClip DragonWalking_Sound;
		public AudioClip BG_Sound;
		public AudioClip End_Sound;//entering the castle at the end
		public AudioClip StartMenu_Sound;
		
		bool dragonblowing_fire = false;
		//bool dragonflying = false;
		public GameObject OSCdragon;
		float up_Speed = 10f;
		

		#endregion

		#region Unity Methods

		// protected virtual void Start()
		// {

		// }

        // private void OnMouseDown()
        // {
		// 	Debug.Log("sending OSC");
		// 	var message = new OSCMessage(Address);
		// 	message = new OSCMessage(Address);
		// 	message.AddValue(OSCValue.Float(1));
		// 	// message.AddValue(OSCValue.String("a second value"));

		// 	Transmitter.Send(message);
		// }

		 void Start()
		{

            /*shang shang 's arduino stuff
			SendOSCOnOff();
			theRenderer = GetComponent<Renderer>();
			Debug.Log(theRenderer);
			*/



            // Ayo's feedback : if player moves > 100; then send osc message data and replace it with a new position value
            //Daniel's feedback: checking the osc mesage every frame isn't a prblem but checking the data and then send it within a certain position/time
            //store the variable of the position as async separate variable 
            //checking every frame isn't the problem, the problem is sending data every frame


            // Move the object to the same position as the parent:
            //transform.localPosition = new Vector2(0, 0);
            //transform.localPosition = new Vector2(-transform.localScale.x, transform.localScale.y);
            
				right = transform.localScale;
				left = new Vector2(-transform.localScale.x, transform.localScale.y);

			
			
			_rigidbody = GetComponent<Rigidbody2D>();
			_animator = GetComponent<Animator>();

			_audioSource = GetComponent<AudioSource>();//add more codes onto "fire" if your player will fire



		}
        
       void Update()
        {
			//player code

			float xSpeed = Input.GetAxis("Horizontal") * speed;
			//rb.velocity = new Vector2(xSpeed, 0);//move character left and right but now there is a bug that the player won't drop on the platform because the y is "0" there every frame it will reset velocity
			if (xSpeed > 0 || xSpeed < 0)
			{
				_rigidbody.velocity = new Vector2(xSpeed, _rigidbody.velocity.y);// character drop onto the platform and slide left and right
																				 //remember to go to contraints in the rigid body inspector and lock z : the player can stop at the edge 

				if (xSpeed < 0 && transform.localScale.x > 0)
				{
					transform.localScale = left;
					_rigidbody.velocity = transform.up * up_Speed;
				}
				else if (xSpeed > 0 && transform.localScale.x < 0)
				{
					transform.localScale = right;
					_rigidbody.velocity = transform.up * up_Speed;
				}

				//making sure the dragon is flying in both directions checking within speed
				_animator.SetFloat("Speed", Mathf.Abs(xSpeed));//you want an abosolute value of the x  speed or else now it is only walking on the right not the lef

			}
			/*if (Input.GetKeyDown("space"))
			{
				//checking if dragon is blowing fire left or right
				dragonblowing_fire = true;
				_animator.SetBool("isblowingLR_fire", true);

				//checking if dragon is blowing fire down

				//_animator.SetBool("isblowingdown_fire", true);
			}
			else {
				if(Input.GetKeyUp("space")){
					dragonblowing_fire = false;
					_animator.SetBool("isblowingLR_fire", false);
				}
			}
			*/

			//this might be better to do if we have a separate controller for flying up and left and right for the pressure sencor
			if (Input.GetKey(KeyCode.UpArrow))
			{
				//Move the Rigidbody upwards constantly at speed you define (the green arrow axis in Scene view)
				_rigidbody.velocity = transform.up * up_Speed;
			}

			if (Input.GetKey(KeyCode.DownArrow))
			{
				//Move the Rigidbody downwards constantly at the speed you define (the green arrow axis in Scene view)
				_rigidbody.velocity = -transform.up * up_Speed;
			}


			var OSCmessage = new OSCMessage(Address);//creates a new message
													 //check if the position of the dragon is changed then send the float data of the position to console 
													 //sending this data to osc
			float Dragon_position = transform.localPosition.x;
			
			// OSCmessage.AddValue(OSCValue.Float(Dragon_position));//update dragon position in  osc message
			// OSCmessage.AddValue(OSCValue.String("Hello, Dragon is moving"));
			// // Debug.Log("send OSC + " + OSCmessage);
			// Transmitter.Send(OSCmessage);
			
		}

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
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 *you can create an event to trigger when something happens so this can check if player is landing the group then stop jumping
 *https://www.youtube.com/watch?v=hkaysu1Z-N8
 * 
 * public void OnLanding()
        {
			_animator.SetBool("jumping", false);
		}
*/

/*
 * 
 * doesnt work
			if(transform.position.y > 50 )
            {
				_rigidbody.velocity = -transform.up * up_Speed;
			}*/