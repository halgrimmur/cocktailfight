using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Audio players components.
    public AudioSource EffectsSource;
    public AudioSource MusicSource;
    public AudioClip[] Melting;
    public AudioClip Drop1;
    public AudioClip Drop2;
    public AudioClip DropCatch;
    public AudioClip Music1;
    public AudioClip Music2;
    public AudioClip Music3;
    public AudioClip Music4;

    //// Random pitch adjustment range.
    //public float LowPitchRange = .95f;
    //public float HighPitchRange = 1.05f;

    // Singleton instance.
    public static SoundManager Instance = null;

    // Initialize the singleton instance.
    private void Awake()
    {
        // If there is not already an instance of SoundManager, set it to this.
        if (Instance == null)
        {
            Instance = this;
        }
        //If an instance already exists, destroy whatever this object is to enforce the singleton.
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        //Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
        DontDestroyOnLoad(gameObject);
        MeltingSound();
    }

    // Play a single clip through the sound effects source.
    private void Play(AudioClip clip)
    {
        EffectsSource.clip = clip;
        EffectsSource.Play();
    }

    // Play a single clip through the music source.
    private void PlayMusic(AudioClip clip)
    {
        MusicSource.clip = clip;
        MusicSource.Play();
    }

    public void PlayBackgroundMusic()
    {
        PlayMusic(Music1);
    }

    public void DropSound()
    {
        StartCoroutine("RoutineDropSound");
    }

    public void MeltingSound()
    {
        Play(Melting[Random.Range(0, Melting.Length)]);
    }

    public void CatchSound()
    {
        StartCoroutine("RoutineCatchSound");
    }

    IEnumerator RoutineDropSound()
    {
        Play(Drop1);
        yield return new WaitForSeconds(0.03f);
        Play(Drop2);
    }

    IEnumerator RoutineCatchSound()
    {
        Play(DropCatch);
        yield return new WaitForSeconds(0.03f);
        Play(DropCatch);
    }

    //// Play a random clip from an array, and randomize the pitch slightly.
    //public void RandomSoundEffect(params AudioClip[] clips)
    //{
    //    int randomIndex = Random.Range(0, clips.Length);
    //    float randomPitch = Random.Range(LowPitchRange, HighPitchRange);

    //    EffectsSource.pitch = randomPitch;
    //    EffectsSource.clip = clips[randomIndex];
    //    EffectsSource.Play();
    //}

}
