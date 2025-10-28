using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager I;
    [Header("SFX")]
    public AudioClip sfxJump;
    public AudioClip sfxPickup;
    public AudioClip sfxHurt;
    public AudioClip sfxGoal;

    [Header("Music")]
    public AudioSource musicSource;
    public AudioSource sfxSource;

    void Awake()
    {
        I = this;
        if (musicSource) musicSource.loop = true;
    }

    public void PlaySFX(AudioClip clip)
    {
        if (clip && sfxSource) sfxSource.PlayOneShot(clip);
    }

    public void PlayJump() => PlaySFX(sfxJump);
    public void PlayPickup() => PlaySFX(sfxPickup);
    public void PlayHurt() => PlaySFX(sfxHurt);
    public void PlayGoal() => PlaySFX(sfxGoal);
}
