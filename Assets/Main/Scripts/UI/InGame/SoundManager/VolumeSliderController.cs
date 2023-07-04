using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSliderController : MonoBehaviour
{
    public Slider VolumeSlider;
    private readonly string VolumeKey = "InGameVolumeKey";

    private void Start()
    {
        //PlayerPrefs.DeleteKey(VolumeKey);
        if (!PlayerPrefs.HasKey(VolumeKey))
        {
            PlayerPrefs.SetFloat(VolumeKey, 0.25f);
            LoadVolumeSetting();
        }else
        {
            LoadVolumeSetting();
        }
    }

    public void AdjustVolume()
    {
        AudioListener.volume = VolumeSlider.value;
        SaveVolumeSetting();
    }

    private void LoadVolumeSetting()
    {
        VolumeSlider.value = PlayerPrefs.GetFloat(VolumeKey);
        AdjustVolume();
    }

    private void SaveVolumeSetting()
    {
        PlayerPrefs.SetFloat(VolumeKey, VolumeSlider.value);
    }
}
