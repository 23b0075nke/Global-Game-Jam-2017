using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character;

namespace Node
{
	public class SubNode : MonoBehaviour 
	{
		public const string tagName = "SubNode";
		public const string ID = "";
		public CenterNode parent; 
		
		private string nodeName; // Pulled from MonoBehavior name; must be unique
		
		[SerializeField] 
		private SubNode[] connections;
		
		private bool connected;

		// Use this for initialization
		void Start () 
		{
			connected = false;
			nodeName = name;
			print( "subnode name set to " + nodeName );
		}
		
		// Update is called once per frame
		void Update () 
		{
			
		}

		void OnTriggerEnter2D( Collider2D collider )
		{
			print( "Trigger enter!!" );
			Player player = collider.GetComponent<Player>();
			// If the collider is the player character
			if ( collider.tag == player.tag )
			{
				print( "Player entered subnode" );
				// Update metadata from player collision
				//player.CollideWithSubNode( this );
				
				// Pick up this node if we're circling the same star or if we don't currently have one
				if ( player.package == null || player.package.parent == this.parent )
				{
					player.PickUpSubNode( this );
				}
				// Otherwise, test to see if we should drop off the package
				// Package should be delivered if the it matches defined connections
				else if ( IsDeliverable( player.package ) )
				{
					Connect( player );
				}
			}
		}

		/*
		 * Connection behavior - flip the connected bool
		 * Triggers parent connection check; parent will connect if all children are connected.
		 */
		private void Connect( Player player )
		{
			print( "Call to connect" );
			this.connected = true;
			this.parent.ConnectSubNode();
			
			// Console log
			print( "Child node connected!" );
			
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
		* Returns true if the package matches any of this node's connections
		*/ 
		private bool IsDeliverable( SubNode package )
		{
			foreach( SubNode connection in connections )
			{
				if ( package.nodeName == connection.nodeName )
				{
					return true;
				}
			}
			
			return false;
		}
	}
}


