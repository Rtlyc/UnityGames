using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    [SerializeField]
    private AudioSource source;

    [SerializeField]
    private AudioClip gameoverclip, jumpclip, extrajumpclip;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null) instance = this;
    }

    public void JumpSound()
    {
        source.clip = jumpclip;
        source.Play();
    }

    public void GameOverSound()
    {
        source.clip = gameoverclip;
        source.Play();
    }

    public void ExtraJumpSound()
    {
        source.clip = extrajumpclip;
        source.Play();
    }


}
