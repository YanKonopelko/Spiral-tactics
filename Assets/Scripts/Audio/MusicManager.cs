using System;
using System.Collections;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    //—крипт вз€тый из старого проекта, будет переделан как только буду объ€вленны задачи
    private AudioSource source_1;
    private AudioSource source_2;

    public AudioClip mainMenuMusic;
    public AudioClip gameplayMusic;

    public static float volume = 0.4f;
    public float changeSpeed = 0.5f; // врем€ смены музыки, в секундах

    private IEnumerator music_ienum;

    public static MusicManager instance;
    private AudioClip currentlyPlaying;

    private void Awake()
    {
        volume = (PlayerPrefs.HasKey("MUSIC_VOLUME")) ? PlayerPrefs.GetFloat("MUSIC_VOLUME") : volume;

        source_1 = gameObject.AddComponent<AudioSource>();
        source_1.playOnAwake = false;
        source_1.volume = volume;
        source_1.loop = true;

        source_2 = gameObject.AddComponent<AudioSource>();
        source_2.playOnAwake = false;
        source_2.volume = volume;
        source_2.loop = true;

        source_1.volume = 0;
        source_2.volume = 0;

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
            Destroy(gameObject);
    }

    public static void ChangeVolume(float newVolume)
    {
        volume = newVolume;
        instance.source_1.volume = volume;
        instance.source_2.volume = volume;
    }

    public static void StopMusic()
    {
        instance.StopAllCoroutines();
        instance.source_1.Stop();
        instance.source_2.Stop();
        instance.currentlyPlaying = null;
    }

    public static void ChangeMusic(AudioClip clip, float speed = 1f)
    {
        if (instance.currentlyPlaying != clip)
        {
            if (instance.music_ienum != null)
                instance.StopCoroutine(instance.music_ienum);
            instance.StartCoroutine(instance.music_ienum = instance.SwapTrack(clip, (speed == 1f) ? instance.changeSpeed : speed));
        }
    }

#if UNITY_EDITOR
    private void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            try
            {
                if (music_ienum != null)
                    StopCoroutine(music_ienum);
                StartCoroutine(music_ienum = SwapTrack(mainMenuMusic, 1f));
            } catch (Exception e)
            {
                print("ћузыку не добавил, а может и нет");
                print(e.ToString());
            }
        }

        if (Input.GetKeyDown("2"))
        {
            try
            {
                if (music_ienum != null)
                    StopCoroutine(music_ienum);
                StartCoroutine(music_ienum = SwapTrack(gameplayMusic, 1f));
            } catch (Exception e)
            {
                print("ћузыку не добавил, а может и нет");
                print(e.ToString());
            }
        }
    }
#endif

    private IEnumerator SwapTrack(AudioClip toClip, float _timetofade = 0.25f)
    {
        if (toClip)
        {
            float timetofade = _timetofade;
            float timeelapsed = 0;
            instance.currentlyPlaying = toClip;

            if (source_1.isPlaying)
            {
                source_2.clip = toClip;
                source_2.volume = 0;
                source_2.Play();

                while (timeelapsed < timetofade)
                {
                    source_2.volume = Mathf.Lerp(0, volume, timeelapsed / timetofade);
                    source_1.volume = Mathf.Lerp(volume, 0, timeelapsed / timetofade);
                    timeelapsed += Time.fixedUnscaledDeltaTime;
                    yield return null;
                }

                source_1.Stop();
            }
            else
            {
                source_1.clip = toClip;
                source_1.volume = 0;
                source_1.Play();

                while (timeelapsed < timetofade)
                {
                    source_1.volume = Mathf.Lerp(0, volume, timeelapsed / timetofade);
                    source_2.volume = Mathf.Lerp(volume, 0, timeelapsed / timetofade);
                    timeelapsed += Time.fixedUnscaledDeltaTime;
                    yield return null;
                }

                source_2.Stop();
            }
        } else
        {
            yield return null;
        }
    }

    private IEnumerator SwapTrack(AudioClip toClip, bool forced = false, float _timetofade = 0.25f)
    {
        if (toClip)
        {
            float timetofade = _timetofade;
            float timeelapsed = 0;
            instance.currentlyPlaying = toClip;

            if (source_1.isPlaying)
            {
                source_2.clip = toClip;
                source_2.volume = 0;
                source_2.Play();

                while (timeelapsed < timetofade)
                {
                    source_2.volume = Mathf.Lerp(0, volume, timeelapsed / timetofade);
                    source_1.volume = Mathf.Lerp(volume, 0, timeelapsed / timetofade);
                    timeelapsed += Time.fixedUnscaledDeltaTime;
                    yield return null;
                }

                source_1.Stop();
            }
            else
            {
                source_1.clip = toClip;
                source_1.volume = 0;
                source_1.Play();

                while (timeelapsed < timetofade)
                {
                    source_1.volume = Mathf.Lerp(0, volume, timeelapsed / timetofade);
                    source_2.volume = Mathf.Lerp(volume, 0, timeelapsed / timetofade);
                    timeelapsed += Time.fixedUnscaledDeltaTime;
                    yield return null;
                }

                source_2.Stop();
            }
        }
        else
        {
            yield return null;
        }
    }
}
