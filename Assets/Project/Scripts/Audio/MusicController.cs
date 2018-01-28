using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;

public class MusicController : MonoBehaviour {

    //Variable Definitions
    int ActivatedNodes;
    public AudioSource ZeroNodes;
    public AudioSource OneNode;
	public AudioSource TwoNodes;
	public AudioSource ThreeNodes;
	public AudioSource FourNodes;
	public AudioSource FiveNodes;

    public void Start()
    {
        //Start out with everything but the "zero nodes" track muted
        ZeroNodes.mute = false;
        OneNode.mute = true;
        TwoNodes.mute = true;
        ThreeNodes.mute = true;
        FourNodes.mute = true;
        FiveNodes.mute = true;
    }

    //Functions
    
    //Plays from all the audio mixers directly
    public void PlayMusic(){
        ZeroNodes.Play ();
		OneNode.Play ();
		TwoNodes.Play ();
		ThreeNodes.Play ();
		FourNodes.Play ();
		FiveNodes.Play ();
	}

	//Stops all the audio mixers directly
	public void StopMusic(){
		ZeroNodes.Stop ();
		OneNode.Stop ();
		TwoNodes.Stop ();
		ThreeNodes.Stop ();
		FourNodes.Stop ();
		FiveNodes.Stop ();
	}

    void AddMusicLayer()
    {
        ActivatedNodes += 1;

        if (ActivatedNodes == 1)
        {
            OneNode.mute = false;

            ZeroNodes.mute = true;
            TwoNodes.mute = true;
            ThreeNodes.mute = true;
            FourNodes.mute = true;
            FiveNodes.mute = true;

        } else if (ActivatedNodes == 2)
        {
            TwoNodes.mute = false;

            ZeroNodes.mute = true;
            OneNode.mute = true;
            ThreeNodes.mute = true;
            FourNodes.mute = true;
            FiveNodes.mute = true;

        } else if (ActivatedNodes == 3)
        {
            ThreeNodes.mute = false;

            ZeroNodes.mute = true;
            OneNode.mute = true;
            TwoNodes.mute = true;
            FourNodes.mute = true;
            FiveNodes.mute = true;

        } else if (ActivatedNodes == 4)
        {
            FourNodes.mute = false;

            ZeroNodes.mute = true;
            OneNode.mute = true;
            TwoNodes.mute = true;
            ThreeNodes.mute = true;
            FiveNodes.mute = true;

        } else if (ActivatedNodes == 5)
        {
            FiveNodes.mute = false;

            ZeroNodes.mute = true;
            OneNode.mute = true;
            TwoNodes.mute = true;
            ThreeNodes.mute = true;
            FourNodes.mute = true;
        }
    }


    //Test adding layers by pressing the left control button for now
    public void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            AddMusicLayer();
            ZeroNodes.Stop();
        }
    }
}
