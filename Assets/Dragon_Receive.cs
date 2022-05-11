using UnityEngine;

namespace extOSC.Examples
{
	public class Dragon_Receive : MonoBehaviour
	{

		#region Public Vars

		//dragon player movement
		Vector2 left;
		Vector2 right;

		Rigidbody2D _rigidbody;
		public int speed = 20;
		Animator _animator;
		public int flyForce = 300;
		public Transform feet; //assigned with empty game object and tag on the player's feet
		public LayerMask groundLayer;
		public bool isGrounded = false;//bool checks if a statement is true or false
									// public GameObject FallingPlatform;

		//control blow animation;
		bool dragonblowing_fire = false;

		public string Address = "/Dragon_movement";
		// public string num;
		//which osc address it is going to listen to
		//change this osc adress according to the other script so it matches

		[Header("OSC Settings")]
		public OSCReceiver Receiver;

		// Vector2 left;
		// Vector2 right;
		// public int speed = 20;
		//public int jumpForce = 300;
		// Rigidbody2D _rigidbody;
		// Animator _animator;
		// float up_Speed = 10f;

		#endregion

		#region Unity Methods

		protected virtual void Start()
		{
			Receiver.Bind(Address, ReceivedMessage);

			right = transform.localScale;
			left = new Vector2(-transform.localScale.x, transform.localScale.y);
			_rigidbody = GetComponent<Rigidbody2D>();
			_animator = GetComponent<Animator>();
		}


			

		#endregion

		


		#region Private Methods

		private void ReceivedMessage(OSCMessage message)		
		{
			float xSpeed = 0;//every frame
      
            //BLOW SENSOR
            string blowValRaw = message.Values[0].StringValue;
            //Debug.Log("blowValRaw: " + blowValRaw);
            float blowValFloat = float.Parse(blowValRaw);
			if(blowValFloat == 1)
            {
				dragonblowing_fire = true;
				_animator.SetBool("isblowingLR_fire", true);
			} else if(blowValFloat == 0){
				dragonblowing_fire = false;
				_animator.SetBool("isblowingLR_fire", false);
			}

            //***RIGHT;
            string rightValRaw = message.Values[1].StringValue;	//read the stirng array		
			float rightValFloat = float.Parse(rightValRaw);      //convert into float
			if(rightValFloat > 0)
            {
				xSpeed = 2;
				Debug.Log("move right");
			}

			//unity接受并处理收到的arduino的信息，控制龙往右边移动；

			//***LEFT;
			string leftValRaw = message.Values[2].StringValue;
			float leftValeFloat = float.Parse(leftValRaw);
			if (leftValeFloat > 0)
			{
				xSpeed = -2;
				Debug.Log("move left");
			}

			_animator.SetFloat("Speed", Mathf.Abs(xSpeed));//you want an abosolute value of the x  speed or else now it is only walking on the right not the lef

			isGrounded = Physics2D.OverlapCircle(feet.position, 0.3f, groundLayer);
			_animator.SetBool("Grounded", isGrounded);

			if ( isGrounded)//force jump while grounded on the ground floor
			{//remember to tag ground in ground layer that are created then drag ground to "ground" in player inspecter
				_rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0); //set velocity to 0 before addforce there the player won't jump extra or launch themselves after pressing on jump mutiple time
				_rigidbody.AddForce(new Vector2(xSpeed, flyForce));

			}


			Debug.Log("speed: " + xSpeed);
			//rb.velocity = new Vector2(xSpeed, 0);//move character left and right but now there is a bug that the player won't drop on the platform because the y is "0" there every frame it will reset velocity
			_rigidbody.velocity = new Vector2(xSpeed*speed, _rigidbody.velocity.y);// character drop onto the platform and slide left and right
																			 //remember to go to contraints in the rigid body inspector and lock z : the player can stop at the edge 

			if (xSpeed < 0 && transform.localScale.x > 0)
			{
				transform.localScale = left;
				// _rigidbody.velocity = transform.up * up_Speed;
			}
			else if (xSpeed > 0 && transform.localScale.x < 0)
			{
				transform.localScale = right;
				// _rigidbody.velocity = transform.up * up_Speed;
			}

			if (xSpeed < 0 || xSpeed > 0)
			{
				
				//making sure the dragon is flying in both directions checking within speed
				_animator.SetFloat("Speed", Mathf.Abs(xSpeed*speed));//you want an abosolute value of the x  speed or else now it is only walking on the right not the lef
			}
		}
		#endregion
	}
}