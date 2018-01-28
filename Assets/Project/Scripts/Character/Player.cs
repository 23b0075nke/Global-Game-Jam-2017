using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Node;

namespace Character
{
	/*
	* TODO - rename
	* Logic for PlayerController to manage connection setup
	*/ 
	public class Player : MonoBehaviour 
	{
		public const string TAG_NAME = "Player";
		public SubNode package; // Subnode the player is carrying to form a connection
		
		// Use this for initialization
		void Start () 
		{
			package = null;
		}
		
		// Update is called once per frame
		void Update () 
		{
			
		}
		
		public void PickUpSubNode( SubNode sub )
		{
			print( "---UPDATE: picked up new package: " + sub.nodeName );
			package = sub;
		}
		
		public void ClearPackage()
		{
			print( "---UPDATE: Package " + package.nodeName + " cleared" );
			package = null;
		}
	}
}