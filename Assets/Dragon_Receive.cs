using UnityEngine;

namespace extOSC.Examples
{
	public class Dragon_Receive : MonoBehaviour
	{
		#region Public Vars

		
		public string Address = "/Dragon_movement";
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

		#region Private Methods

		private void ReceivedMessage(OSCMessage message)
		{
			string scaleRaw0 = message.Values[0].StringValue;
			Debug.Log("val[0]: " + scaleRaw0);
			float scaleInt0 = float.Parse(message.Values[0].StringValue)*10;
			transform.position = new Vector2(transform.position.x, transform.position.y+scaleInt0);//喷火

			string scaleRaw1 = message.Values[1].StringValue;
			Debug.Log("val[1]: " + scaleRaw1);
			float scaleInt1 = float.Parse(message.Values[1].StringValue)*10;
			transform.position = new Vector2(transform.position.x + scaleInt1, transform.position.y);
			Debug.Log("move right");
			//unity接受并处理收到的arduino的信息，控制龙往右边移动；

			string scaleRaw2 = message.Values[2].StringValue;
			Debug.Log("val[2]: " + scaleRaw2);
			float scaleInt2 = float.Parse(message.Values[2].StringValue)*10;
			transform.position = new Vector2(transform.position.x - scaleInt2, transform.position.y);
			Debug.Log("move left");







		}

		#endregion
	}
}


/*
			//only changing the string of values into an integer 
			//string radData0 = message.Values[0].StringValue;
			string rawData0 = message.Values[0].StringValue;
			float floatData0 = float.Parse(rawData0);
			float floatData0mapped = floatData0 / 200;
			Debug.Log(floatData0mapped);
			//changing the object size when you hit play

			transform.localScale = new Vector3(floatData0mapped, floatData0mapped, floatData0mapped);

			string rawData1 = message.Values[0].StringValue;
			float floatData1 = float.Parse(rawData0);
			float floatData1mapped = floatData0 / 200;

			transform.position = new Vector3(floatData1mapped, 0, 0);

			//Debug.LogFormat("Received: {0}", message);
			*/