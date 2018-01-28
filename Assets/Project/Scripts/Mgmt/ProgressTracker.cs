using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Node;
using OmiyaGames;
using OmiyaGames.Menu;

namespace Mgmt
{
	/*
	* Tracks connected CenterNodes
	*/
	public class ProgressTracker : MonoBehaviour 
	{
		private const string NODE_FOLDER = "Flowers";
		public const string TRACKER_NAME = "ProgressTracker";
		
		public HashSet<CenterNode> connected;
		public int starCount; // Number of CenterNodes in scene; must be in Stars folder
		private bool complete;

		public AudioSource audio;
		
		// Use this for initialization
		void Start () 
		{
			complete = false;
			connected = new HashSet<CenterNode>();
			CenterNode[] stars = GameObject.Find( NODE_FOLDER ).GetComponentsInChildren<CenterNode>();
			starCount = stars.Length;

			audio = GameObject.Find ("LevelComplete").GetComponent<AudioSource> ();
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
			connected.Add( node );
			
			if ( allNodesAdded() )
			{
				print( "---UPDATE: CenterNode added to progress tracker." );
				InitComplete();
				return true;
			}
			
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
			// Set completion
			complete = true;

			// Play music
			audio.Play();
			print( "---UPDATE: Level complete!" );

            // Trigger scene transition
            Singleton.Get<MenuManager>().GetMenu<LevelCompleteMenu>().Show();
		}
	}
}
