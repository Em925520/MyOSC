using UnityEngine;

namespace extOSC.Examples
{
	public class Dragon_Receive : MonoBehaviour
	{

		#region Public Vars

		
		public string Address = "/Dragon_movement";
		// public string num;
		//which osc address it is going to listen to
		//change this osc adress according to the other script so it matches

		[Header("OSC Settings")]
		public OSCReceiver Receiver;

		#endregion

		#region Unity Methods

		protected virtual void Start()
		{
			Receiver.Bind(Address, ReceivedMessage);
		}

		#endregion

		// void Update()
		// {
			
		// }


		#region Private Methods

		private void ReceivedMessage(OSCMessage message)		
		{	
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




			
			string scaleRaw0 = message.Values[0].StringValue;
			Debug.Log("val[0]: " + scaleRaw0);
			float scaleInt0 = float.Parse(message.Values[0].StringValue);
			transform.position = new Vector2(transform.position.x, transform.position.y+scaleInt0);//喷火

			string scaleRaw1 = message.Values[1].StringValue;
			Debug.Log("val[1]: " + scaleRaw1);
			float scaleInt1 = float.Parse(message.Values[1].StringValue);
			transform.position = new Vector2(transform.position.x + scaleInt1, transform.position.y);
			Debug.Log("move right");
			//unity接受并处理收到的arduino的信息，控制龙往右边移动；

			string scaleRaw2 = message.Values[2].StringValue;
			Debug.Log("val[2]: " + scaleRaw2);
			float scaleInt2 = float.Parse(message.Values[2].StringValue);
			transform.position = new Vector2(transform.position.x - scaleInt2, transform.position.y);
			Debug.Log("move left");
		}
		#endregion
	}
}