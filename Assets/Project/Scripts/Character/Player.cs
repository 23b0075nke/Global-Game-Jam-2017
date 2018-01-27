using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Node;

namespace Character
{
	public class Player : MonoBehaviour 
	{
		public const string tagName = "Player";
		public SubNode package; // Subnode the player is carrying to form a connection
		
		// Use this for initialization
		void Start () {
			package = null;
		}
		
		// Update is called once per frame
		void Update () {
			
		}

		/*
		* SubNode collision check/behavior 
		* @param collided: SubNode the player interacted with
		*/
		public void CollideWithSubNode( SubNode collided )
		{
			print( "Call to CollideWithSubNode" );
			// Set carryNode to collided if: 
			// 		We are empty handed
			//		We are interacting with another node on the same star
			if ( package == null || package.parent == collided.parent )
			{
				print( "picked up new package!" );
				package = collided;
			}
			// Otherwise, check for a matching connection
			// 		If it matches, trigger connection behavior and reset carryNode
			else if ( package == collided )
			{
				print( "package delivered" );
				package = null;
			}
			// 		If it doesn't match, trigger incorrect connection feedback in the collided node
			else
			{
				print( "package delivered to wrong node" );
				// Do we also want to clear the carryNode here?
			}
		}
		
		public void PickUpSubNode( SubNode sub )
		{
			package = sub;
		}
		
		public void DeliverSubNode( SubNode sub )
		{
			package = null;
		}
	}
}