using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioSource trumpetMusic;
    public AudioSource talkAudio;
    public AudioSource villageMusic;
    public AudioSource trumpetFullMusic;

    public AudioMixer mixer;

    public static AudioManager instance;

    private List<AudioSource> musicSources;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        musicSources = new List<AudioSource>()
        {
            trumpetMusic,
            villageMusic,
            trumpetFullMusic,
        };
    }

    public void ChangeMusicVolume(float value)
    {
        if (value == 0)
        {
            mixer.SetFloat("MusicVolume", -80);
        }
        else
        {
            mixer.SetFloat("MusicVolume", Mathf.Lerp(-40, 0, value));
        }
    }

    public void ChangeSoundsVolume(float value)
    {
        if (value == 0)
        {
            mixer.SetFloat("EffectsVolume", -80);
        }
        else
        {
            mixer.SetFloat("EffectsVolume", Mathf.Lerp(-40, 0, value));
        }
    }

    public void PlayTrumpet()
    {
        if (trumpetMusic.isPlaying == false)
        {
            trumpetMusic.Play();
        }
    }

    public void PlayTalk()
    {
        if (talkAudio.isPlaying == false)
        {
            talkAudio.PlayOneShot(talkAudio.clip);
        }
    }

    public void PlayVillage()
    {
        if (villageMusic.isPlaying == false)
        {
            villageMusic.Play();
        }
    }

    public void StopMusic()
    {
        if (villageMusic.isPlaying)
        {
            villageMusic.Stop();
        }

        if (trumpetMusic.isPlaying)
        {
            trumpetMusic.Stop();
        }

        if (trumpetFullMusic.isPlaying)
        {
            trumpetFullMusic.Stop();
        }
    }

    public void PlayTrumpetSong()
    {
        if (trumpetFullMusic.isPlaying == false)
        {
            trumpetFullMusic.Play();
        }
    }
}
