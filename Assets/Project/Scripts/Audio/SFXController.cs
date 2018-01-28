using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXController : MonoBehaviour {

    //Add audio sources and audio clips
    [SerializeField]
    private AudioSource ActivatedNodePlayer;
    [SerializeField]
    private AudioClip Node_Turn_On_LowC;
    [SerializeField]
    private AudioClip Node_Turn_On_D;
    [SerializeField]
    private AudioClip Node_Turn_On_E;
    [SerializeField]
    private AudioClip Node_Turn_On_F;
    [SerializeField]
    private AudioClip Node_Turn_On_G;
    [SerializeField]
    private AudioClip Node_Turn_On_A;
    [SerializeField]
    private AudioClip Node_Turn_On_B;
    [SerializeField]
    private AudioClip Node_Turn_On_HighC;

    void PlayNodeConnectionSound(int ActivatedNodes, int TotalNodes)
    {
        //Play the low C to start with and the high C at the end
        if (TotalNodes - ActivatedNodes >= 7)
        {
            ActivatedNodePlayer.clip = Node_Turn_On_LowC;
        }
        else if (TotalNodes - ActivatedNodes == 6)
        {
            ActivatedNodePlayer.clip = Node_Turn_On_D;
        }
        else if (TotalNodes - ActivatedNodes == 5)
        {
            ActivatedNodePlayer.clip = Node_Turn_On_E;
        }
        else if (TotalNodes - ActivatedNodes == 4)
        {
            ActivatedNodePlayer.clip = Node_Turn_On_F;
        }
        else if (TotalNodes - ActivatedNodes == 3)
        {
            ActivatedNodePlayer.clip = Node_Turn_On_G;
        }
        else if (TotalNodes - ActivatedNodes == 2)
        {
            ActivatedNodePlayer.clip = Node_Turn_On_A;
        }
        else if (TotalNodes - ActivatedNodes == 1)
        {
            ActivatedNodePlayer.clip = Node_Turn_On_B;
        }
        else if (TotalNodes == ActivatedNodes)
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
            PlayNodeConnectionSound(ActivatedNodes, 8);
        }
    }
#endif
}
