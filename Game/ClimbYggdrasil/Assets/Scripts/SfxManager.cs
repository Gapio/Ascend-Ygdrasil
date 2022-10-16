using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxManager : MonoBehaviour
{

    public AudioSource Audio;

    public AudioClip Dash;
    public AudioClip Fire_Ball;
    public AudioClip Melee;
    public AudioClip death_sound;
    public AudioClip jump;
    public AudioClip skeletor;



    public static SfxManager sfxInstance;

    //SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.YourSound);

    private void Awake()
    {
        if (sfxInstance != null && sfxInstance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        sfxInstance = this;
        DontDestroyOnLoad(this);
    }
}
