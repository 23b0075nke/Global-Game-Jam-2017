using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Obstacle
{
	/**
	* Defines behavior for meteor obstacle objects
	*/ 
	public class Meteor : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = transform.position;
		transform.position = new Vector3( pos.x, pos.y, pos.z );
	}
}
}
