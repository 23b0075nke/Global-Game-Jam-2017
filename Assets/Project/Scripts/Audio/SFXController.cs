using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXController : MonoBehaviour {

    [SerializeField]
    private AudioSource ActivatedNodePlayer;

    //Define Audio Clips
    AudioClip Node_Turn_On_LowC;
    AudioClip Node_Turn_On_D;
    AudioClip Node_Turn_On_E;
    AudioClip Node_Turn_On_F;
    AudioClip Node_Turn_On_G;
    AudioClip Node_Turn_On_A;
    AudioClip Node_Turn_On_B;
    AudioClip Node_Turn_On_HighC;

    private void Start()
    {
        ActivatedNodePlayer.Play();
    }

    void PlayNodeConnectionSound(int ActivatedNodes, int TotalNodes)
    {
        //Play the low C to start with and the high C at the end
        if (ActivatedNodes == TotalNodes)
        {
            ActivatedNodePlayer.clip = Node_Turn_On_LowC;
        } else if (ActivatedNodes == 1)
        {
            ActivatedNodePlayer.clip = Node_Turn_On_HighC;
        }

        ActivatedNodePlayer.Play();
    }

    //Test Playing SFX with left control button
#if UNITY_EDITOR
    int ActivatedNodes = 0;

    public void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ActivatedNodes++;
            PlayNodeConnectionSound(ActivatedNodes, 1);
        }
    }
#endif
}
