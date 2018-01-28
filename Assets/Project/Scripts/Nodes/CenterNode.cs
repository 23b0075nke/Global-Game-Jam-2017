using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Node;
using Mgmt;

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

		private SubNode[] children;
		private bool connected;
		
		// Use this for initialization
		void Start () 
		{
			connected = false;
			children = GetComponentsInChildren<SubNode>();
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
				connected = true;
				ProgressTracker tracker = GameObject.Find( ProgressTracker.TRACKER_NAME ).GetComponent<ProgressTracker>();
				tracker.update( this );
				
				// TODO - trigger animation sequence?
			}
		}
		
		public bool IsConnected()
		{
			return connected;
		}
	}
}
