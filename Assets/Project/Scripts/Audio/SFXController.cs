using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXController : MonoBehaviour {

    [SerializeField]
    private AudioSource ActivatedNodePlayer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void PlayNodeConnectionSound(int ActivatedNodes, int TotalNodes)
    {
        //Play the low C to start with and the high C at the end
        if (ActivatedNodes == TotalNodes)
        {
            //Store High C in ActivatedNodePlayer
        } else if (ActivatedNodes == 1)
        {
            //Store Low C in ActivatedNodePlayer
        }

        ActivatedNodePlayer.Play();
    }
}
