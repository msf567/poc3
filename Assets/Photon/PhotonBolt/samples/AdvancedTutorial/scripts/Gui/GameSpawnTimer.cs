using UnityEngine;
using System.Collections;
using UnityEngine.UI;
namespace Bolt.AdvancedTutorial
{
	public class GameSpawnTimer : Bolt.GlobalEventListener
	{
		BoltEntity me;
		IPlayerState meState;

		[SerializeField]
		Text timer;

		public override void ControlOfEntityGained (BoltEntity arg)
		{
			if (arg.GetComponent<PlayerController> ()) {
				me = arg;
				meState = me.GetState<IPlayerState> ();
			}
		}

		public override void ControlOfEntityLost (BoltEntity arg)
		{
			if (arg.GetComponent<PlayerController> ()) {
				me = null;
				meState = null;
			}
		}

		void Update ()
		{
			// lock in middle of screen
			transform.position = Vector3.zero;

			// update timer
			if (me && meState != null) {
				if (meState.Dead) {
					timer.text =  Mathf.Max (0, (meState.respawnFrame - BoltNetwork.Frame) / BoltNetwork.FramesPerSecond).ToString ();
				} else {
					timer.text = "";
				}
			} else {
				timer.text = "";
			}
		}
	}
}