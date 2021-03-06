using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource[] soundEffects;

    private void Awake() 
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }

    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySFX(int sfxNumber)
    {
        soundEffects[1].Stop();
        soundEffects[sfxNumber].Stop();
        soundEffects[sfxNumber].Play();
    }

    public void PlayComplete()
    {
        soundEffects[13].Stop();
        soundEffects[13].Play();
    }
}
