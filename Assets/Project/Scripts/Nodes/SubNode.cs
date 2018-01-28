using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character;

namespace Node
{
	/*
	* SubNodes form 1:1 connections between different CenterNodes.
	* A CenterNode needs one SubNode for each other CenterNode it is connected to.
	*/
	public class SubNode : MonoBehaviour 
	{
		public const string TAG_NAME = "SubNode";
		public const string ID = "";
		public CenterNode parent;
		
		// Pulled from MonoBehavior name; must be unique
		public string nodeName;	
		
		[SerializeField] 
		private SubNode connection;
		
		private bool connected;
		private bool grabbed;

		// Use this for initialization
		void Start () 
		{
			connected = false;
			grabbed = false;
			nodeName = name;
		}
		
		// Update is called once per frame
		void Update () 
		{
		}

		void OnTriggerEnter2D( Collider2D collider )
		{
			Player player = collider.GetComponent<Player>();
			// If the collider is the player character

			if ( (collider != null ) && collider.tag == player.tag )
			{
				// If player is already carrying this object, clear it
				if ( (player.startNode != null) && ( this.equals( player.startNode ) ) )
				{
					player.ClearPackage();
				}
				// Pick up this node if we're circling the same star or if we don't currently have one
				else if ( player.startNode == null || player.startNode.parent == this.parent )
				{
					player.PickUpSubNode( this );
				}
				// Otherwise, test to see if we should drop off the package
				// Package should be delivered if the it matches defined connections
				else if ( (player.startNode != null) && IsDeliverable( player.startNode ) && !connected )
				{
					// Connect this SubNode and package SubNode
					Connect();
					player.startNode.Connect();
					
					// Let parent know it's got a new connection.
					// 		This will also trigger a check to see if its completely connected.
					ConnectParentSubNode();
					player.startNode.ConnectParentSubNode();
					
					// Reset player data
					player.ClearPackage();
				}
			}
		}

		/*
		 * Connection behavior - flip the connected bool
		 * Triggers parent connection check; parent will connect if all children are connected.
		 */
		public void Connect()
		{
			this.connected = true;
			
			print( "---UPDATE: Child node " + nodeName + " connected!" );
			
			// TODO - manually trigger animation? 
		}
		
		/*
		* Returns true if this node is connected 
		*/
		public bool IsConnected()
		{
			return connected;
		}

		/*
		 * Set "grabbed" status to true
		 */
		public void grab()
		{
			// Make a copy of the object 
			this.grabbed = true;
		}
		
		/*
		* Returns true if the package matches any of this node's connections
		*/ 
		private bool IsDeliverable( SubNode package )
		{
			return ( package.nodeName == connection.nodeName );
		}
		
		/* 
		* Returns true if two nodes share a name
		*/
		private bool equals( SubNode sub )
		{
			if ( sub.nodeName.Equals(this.nodeName) )
			{
				return true;
			}
			
			return false;
		}
		
		public void ConnectParentSubNode()
		{
			this.parent.ConnectSubNode();
		}
	}
}


