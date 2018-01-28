using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;

public class MusicController : MonoBehaviour {

    //Variable Definitions
    private int ActivatedNodes = 0;
    [SerializeField]
    private float fadeInDuration = 0.5f;
    [SerializeField]
    private AudioMixerSnapshot[] snapshots;

    void AddMusicLayer()
    {
        ActivatedNodes += 1;
        if (snapshots.Length > 0)
        {
            int numNodes = Mathf.Clamp(ActivatedNodes, 0, snapshots.Length);
            snapshots[numNodes].TransitionTo(fadeInDuration);
        }
    }

    //Test adding layers by pressing the left control button for now
#if UNITY_EDITOR
    public void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            AddMusicLayer();
        }
    }
#endif
}
