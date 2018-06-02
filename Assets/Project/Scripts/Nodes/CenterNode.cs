using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Node;
using Mgmt;
using Music;

namespace Node
{
	/*
	* CenterNode tracks connections made between sub-nodes and represents and intermediate victory state.
	* Once all SubNodes are connected, the CenterNode is then connected.
	* Once all CenterNodes are connected, the level is complete.
	*/
	public class CenterNode : MonoBehaviour 
	{
		public const string TAG_NAME = "CenterNode";
		private const string ACTIVATION_ANIM = "FlowerActivation";
		private const string ACTIVATED_IDLE_ANIM = "ActivatedFlowerIdle";

		private SubNode[] children;
		private bool connected;
		private bool connectionAnimationComplete;

		private MusicController musicController;
		private SFXController sfxController;

		private Animator animController;
		
		// Use this for initialization
		void Start () 
		{
			connected = false;
			connectionAnimationComplete = false;
			children = GetComponentsInChildren<SubNode>();
			print (name + " " + children);

			// Get reference to animation controller
			animController = this.gameObject.GetComponent<Animator>();

			// Get reference to music handler
			musicController = GameObject.Find( "MusicHandler" ).GetComponent<MusicController>();
			sfxController = GameObject.Find ("SFXHandler").GetComponent<SFXController> ();
		}
		
		// Update is called once per frame
		void Update () 
		{
			
		}
		
		/* 
		* Status check on member list of child nodes. 
		* Returns true if all nodes in list are connected
		*/
		bool AllChildrenConnected()
		{
			int connected = 0;
			foreach (SubNode child in children)
			{
				if ( child.IsConnected() )
				{
					connected++;
				}
			}
			
			return (connected == children.Length);
		}
		/*
		* Checks connectivity of children
		* If all children are connected, flips connected to true
		*/
		public void ConnectSubNode()
		{
			if ( AllChildrenConnected() )
			{
				print( "!!! OBJECTIVE: Parent node connected!" );

				// Set connected var
				connected = true;

				// Update progress tracker
				ProgressTracker tracker = GameObject.Find( ProgressTracker.TRACKER_NAME ).GetComponent<ProgressTracker>();
				tracker.update( this );

				// Trigger animation sequence
				PlayConnectionAnimation();

				// Play sfx and music
				sfxController.PlayNodeConnectionSound( tracker.connected.Count, tracker.starCount );
				musicController.AddMusicLayer();
			}
		}
		
		public bool IsConnected()
		{
			return connected;
		}

		private void PlayConnectionAnimation()
		{
			if (animController != null) 
			{
				animController.SetInteger ("state", 1);
			}
		}
	}
}
