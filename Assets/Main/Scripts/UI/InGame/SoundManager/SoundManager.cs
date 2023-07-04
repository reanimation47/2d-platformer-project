using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private readonly string VolumeKey = "InGameVolumeKey";
    void Awake()
    {
        if (!PlayerPrefs.HasKey(VolumeKey))
        {
            PlayerPrefs.SetFloat(VolumeKey, 0.25f);
            LoadVolumeSetting();
        }
        else
        {
            LoadVolumeSetting();
        }
    }

    private void LoadVolumeSetting()
    {
        AdjustVolume();
    }

    public void AdjustVolume()
    {
        AudioListener.volume = PlayerPrefs.GetFloat(VolumeKey);
    }

}
