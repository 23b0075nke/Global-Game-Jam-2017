using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using OmiyaGames;
using OmiyaGames.Settings;

public class MusicController : MonoBehaviour {

    //Variable Definitions
    private int ActivatedNodes = 0;
    [SerializeField]
    private float fadeInDuration = 0.5f;
    [SerializeField]
    private AudioMixerSnapshot[] snapshots;

    [Header("Bind to Options Menu")]
    [SerializeField]
    private AudioMixer musicMixer;
    [SerializeField]
    private string volumeField = "Volume";
    [SerializeField]
    private float muteVolumeDb = -40;

    private void Start()
    {
        BackgroundMusic.OnGlobalMuteChange += BackgroundMusic_OnGlobalMuteChange;
        BackgroundMusic.OnGlobalVolumePercentChange += BackgroundMusic_OnGlobalVolumePercentChange;

        GameSettings settings = Singleton.Get<GameSettings>();
        UpdateMixer(settings.MusicVolume, settings.IsMusicMuted);
    }

    private void BackgroundMusic_OnGlobalVolumePercentChange(float obj)
    {
        UpdateMixer(obj, Singleton.Get<GameSettings>().IsMusicMuted);
    }

    private void BackgroundMusic_OnGlobalMuteChange(bool obj)
    {
        UpdateMixer(Singleton.Get<GameSettings>().MusicVolume, obj);
    }

    private void UpdateMixer(float volumePercent, bool isMuted)
    {
        float volumeDb = Mathf.Lerp(muteVolumeDb, 0, volumePercent);
        if(isMuted == true)
        {
            volumeDb = muteVolumeDb;
        }
        musicMixer.SetFloat(volumeField, volumeDb);
    }

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
