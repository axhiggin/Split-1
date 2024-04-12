using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    public static SoundEffects AudioManager;
    public AudioSource source;
    public AudioSource bgSource;

    public AudioClip backgroundClip, chugClip, jumpClip;
    // public AudioClip[] particleClips;
     void Awake()
    {
        if (AudioManager == null)
            AudioManager = this;
        else
            Destroy(AudioManager);
    }
    // Start is called before the first frame update
    void Start()
    {
        startBackgroundMusic();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startBackgroundMusic() {
        bgSource.clip = backgroundClip;
        bgSource.Play();
    }

    public void chugMusic() {
        source.clip = chugClip;
        source.Play();
    }

    public void jumpMusic() {
        source.clip = jumpClip;
        source.Play();
    }

    // public void particlesMusic() {
    //     if (particleClips.Length > 0)
    //     {
    //         int randomIndex = Random.Range(0, particleClips.Length);
    //         source.clip  = particleClips[randomIndex];
    //         source.Play();
    //     }
    // }


}
