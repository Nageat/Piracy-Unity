using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] Musics;
    public AudioSource CurrentMusic;
    public GameManager GameManager;
    // Start is called before the first frame update
    void Start()
    {
        CurrentMusic.clip = Musics[0];
        CurrentMusic.Play();
    }

    // Update is called once per frame
    public void AudioSwitch(int music)
    {
        CurrentMusic.clip = Musics[music];
        CurrentMusic.Play();
    }
}
