using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Node;

namespace Mgmt
{
	/*
	* Tracks connected CenterNodes
	*/
	public class ProgressTracker : MonoBehaviour 
	{
		private const string NODE_FOLDER = "Stars";
		public const string TRACKER_NAME = "ProgressTracker";
		
		private List<CenterNode> connected;
		private int starCount; // Number of CenterNodes in scene; must be in Stars folder
		private bool complete;
		
		// Use this for initialization
		void Start () 
		{
			complete = false;
			connected = new List<CenterNode>();
			CenterNode[] stars = GameObject.Find( NODE_FOLDER ).GetComponentsInChildren<CenterNode>();
			starCount = stars.Length;
		}
		
		// Update is called once per frame
		void Update () 
		{
			
		}
		
		/**
		* Add a completed node 
		*/
		public bool update( CenterNode node )
		{
			if ( node.IsConnected() )
			{
				connected.Add( node );
				
				if ( allNodesAdded() )
				{
					print( "---UPDATE: CenterNode added to progress tracker." );
					InitComplete();
					return true;
				}
			}
			
			print( "///WARNING: Cannot add incomplete center node" );
			return false;
		}
		
		/**
		* Returns true when the number of nodes added equals the total number of nodes in the star group
		*/ 
		private bool allNodesAdded()
		{
			return ( connected.Count == starCount );
		}
		
		/**
		* Trigger completion behavior
		*/
		private void InitComplete()
		{
			complete = true;
			print( "---UPDATE: Level complete!" );
			// TODO - completion vfx/etc
		}
	}
}
