using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public enum SoundType { BUTTON = 0 };

    private List<AudioSource> source = new List<AudioSource>();
    public int sourceAmount = 3;

    public AudioClip BUTTONSOUND;

    public static float volume = 0.4f;

    public static SoundManager instance;


    private void Start()
    {
        volume = (PlayerPrefs.HasKey("VFX_VOLUME")) ? PlayerPrefs.GetFloat("VFX_VOLUME") : volume;

        for (int i = 0; i < sourceAmount; i++)
        {
            source.Add(gameObject.AddComponent<AudioSource>());
        }

        if (instance == null)
            instance = this;

        foreach (AudioSource aso in instance.source)
        {
            aso.volume = volume;
        }
    }

    public static void ChangeVolume(float newVolume)
    {
        volume = newVolume;
        foreach (AudioSource aso in instance.source)
        {
            aso.volume = volume;
        }
    }

    public static void PlaySound(SoundType type)
    {
        switch (type)
        {
            case (SoundType.BUTTON):
                {
                    PlayLocal(instance.BUTTONSOUND);
                    break;
                }
        }
    }

    public static void PlaySound(AudioClip clip)
    {
        PlayLocal(clip);
    }

    private static void PlayLocal(AudioClip clip)
    {
        for (int i = 0; i < instance.source.Count; i++)
        {
            if (instance.source[i].isPlaying)
                continue;
            instance.source[i].clip = clip;
            instance.source[i].Play();
            return;
        }

        int rand = Random.Range(0, instance.source.Count);
        instance.source[rand].clip = clip;
        instance.source[rand].Play();
    }


}
