using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public AudioSource sndEffect;
    public AudioSource music;

    public static SoundManager instance = null;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void PlaySingle(AudioClip clip)
    {
        sndEffect.clip = clip;
        //sndEffect.Play();
        sndEffect.PlayOneShot(clip);
    }

    public void PlayMusic(AudioClip clip)
    {
        music.clip = clip;
        music.Play();
    }

    public void PauseMusic()
    {
        if (music.isPlaying)
        {
            music.Pause();
        }
        else
        {
            music.Play();
        }
    }
}
