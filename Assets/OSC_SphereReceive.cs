using UnityEngine;

namespace extOSC.Examples
{
	public class OSC_SphereReceive : MonoBehaviour
	{
		#region Public Vars

		//public string Address = "/example/1";
		public string Address = "/vals";
		//which osc address it is going to listen to
		//change this to /val bc it is according to the /val in the other script

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
		}

		#endregion
	}
}