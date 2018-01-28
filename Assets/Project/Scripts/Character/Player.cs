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
        [SerializeField]
		private Transform packageParent; // Tag-along object; copy of startNode
        private GameObject package;

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
			GameObject package = Instantiate( startNode.gameObject, packageParent );
			package.transform.localPosition = Vector3.zero;
            package.transform.localRotation = Quaternion.identity;
            //package.transform.localScale = Vector3.one;
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