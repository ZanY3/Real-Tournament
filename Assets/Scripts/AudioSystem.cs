using UnityEngine;

public class AudioSystem : MonoBehaviour
{
    static AudioSource source;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    public void Play(AudioClip clip)
    {
        source.PlayOneShot(clip);
    }
}
