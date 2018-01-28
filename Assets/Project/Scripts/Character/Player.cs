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
		public SubNode startNode; // Subnode the player is carrying to form a connection - instance of original object
		private GameObject package; // Tag-along object; copy of startNode
		
		// Use this for initialization
		void Start () 
		{
			startNode = null;
		}
		
		// Update is called once per frame
		void Update () 
		{
			
		}
		
		public void PickUpSubNode( SubNode sub )
		{
			print( "---UPDATE: picked up new package: " + sub.nodeName );
			startNode = sub;
			package = Instantiate( startNode.gameObject, this.transform.parent );
			package.transform.position = this.transform.position * 1.1f;
			float zPos = this.transform.position.z + 0.75f;
			package.transform.position = new Vector3 (package.transform.position.x, package.transform.position.y, zPos);
		}
		
		public void ClearPackage()
		{
			print( "---UPDATE: Package " + startNode.nodeName + " cleared" );
			startNode = null;
			Destroy (package);
			package = null;
		}
	}
}