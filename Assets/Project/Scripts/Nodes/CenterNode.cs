using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Node;

namespace Node
{
	public class CenterNode : MonoBehaviour 
	{
		public const string tagName = "CenterNode";
		public const string ID = "";

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
				print( "Parent node connected!" );
				connected = true;
				// TODO - trigger animation sequence?
			}
		}
	}
}
