using UnityEngine;

namespace extOSC.Examples
{
	public class Dragon_Receive : MonoBehaviour
	{

		#region Public Vars
		Rigidbody2D _rigidbody;
		public int speed = 20;
		Animator _animator;
		float up_Speed = 10f;

		//dragon player movement
		Vector2 left;
		Vector2 right;


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

			//player code
		// public void update(){
		// 	float xSpeed = Input.GetAxis("Horizontal") * speed;
			
		// 	_rigidbody.velocity = new Vector2(xSpeed, _rigidbody.velocity.y);
		// 	if (xSpeed < 0 && transform.localScale.x > 0 )
		// 	{
		// 		transform.localScale = left;
		// 		_rigidbody.velocity = transform.up * up_Speed;
				

		// 	}
		// 	else if (xSpeed > 0 && transform.localScale.x < 0 )
		// 	{
		// 		transform.localScale = right;
		// 		_rigidbody.velocity = transform.up * up_Speed;
				

		// 	}
			


		// 	 _animator.SetFloat("Speed", Mathf.Abs(xSpeed));
		// }

			

		#endregion

		


		#region Private Methods

		private void ReceivedMessage(OSCMessage message)		
		{
			float xSpeed = 0;//every frame
            // var data = message.Values[0].StringValue;
            // Debug.Log("val[0]"+data.Split(new char[]{';'})[0]);
            // Debug.Log("val[1]"+data.Split(new char[]{';'})[1]);
            // Debug.Log("val[2]"+data.Split(new char[]{';'})[2]);
            //num=data.Split(new char[]{','})[0];
            //var num = data.Split(",")[0];
            // var blow = data[0];
            // Debug.Log("blow： " + blow);
            // var left = data[2];
            // Debug.Log("left: " + left);
            // var right = data[4];
            // Debug.Log("right: " + right);





            //BLOW SENSOR
            string blowValRaw = message.Values[0].StringValue;
            //Debug.Log("blowValRaw: " + blowValRaw);
            float blowValFloat = float.Parse(blowValRaw);
            //transform.position = new Vector2(transform.position.x, transform.position.y + scaleInt0);//喷火
			//transform.position替换成喷火效果，blowValFloat==1的时候，喷火；blowValFloat==0或者不等于1的时候不喷火；
            //***RIGHT;
            string rightValRaw = message.Values[1].StringValue;	//read the stirng array		
			float rightValFloat = float.Parse(rightValRaw);      //convert into float
			if(rightValFloat > 0)
            {
				xSpeed = 1;
				Debug.Log("move right");
			}

			//unity接受并处理收到的arduino的信息，控制龙往右边移动；

			//***LEFT;
			string leftValRaw = message.Values[2].StringValue;
			float leftValeFloat = float.Parse(leftValRaw);
			if (leftValeFloat > 0)
			{
				xSpeed = -1;
				Debug.Log("move left");
			}




			Debug.Log("speed: " + xSpeed);
			//rb.velocity = new Vector2(xSpeed, 0);//move character left and right but now there is a bug that the player won't drop on the platform because the y is "0" there every frame it will reset velocity
			_rigidbody.velocity = new Vector2(xSpeed*speed, _rigidbody.velocity.y);// character drop onto the platform and slide left and right
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

			if (xSpeed < 0 || xSpeed > 0)
			{
				//making sure the dragon is flying in both directions checking within speed
				_animator.SetFloat("Speed", Mathf.Abs(xSpeed*speed));//you want an abosolute value of the x  speed or else now it is only walking on the right not the lef
			}
		}
		#endregion
	}
}