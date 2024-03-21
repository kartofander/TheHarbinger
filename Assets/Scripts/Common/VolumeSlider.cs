using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private VolumeType volumeType;

    void Start()
    {
        switch (volumeType)
        {
            case VolumeType.Music:
                slider.onValueChanged.AddListener(AudioManager.instance.ChangeMusicVolume);
                break;
            case VolumeType.Sounds:
                slider.onValueChanged.AddListener(AudioManager.instance.ChangeSoundsVolume);
                break;
        }
    }

}

public enum VolumeType
{
    Music = 1,
    Sounds = 2,
}
