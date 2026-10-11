using UnityEngine;

public class AudioController : MonoBehaviour
{
    [Header("Audio Sources")]
    [SerializeField] private AudioSource audioSource;

    [Header("Audio Clips")]
    public AudioClip eatAudio;
    public AudioClip hurtAudio;
    public AudioClip powerupAudio;
    public AudioClip clickAudio;
    public AudioClip hoverAudio;
    public AudioClip footstepAudio;

    public static AudioController Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            Object.DontDestroyOnLoad(gameObject);
        }
        else
        {
            Object.Destroy(gameObject);
        }
    }

    public void PlayAudio(AudioClip clip)
    {
        if(clip != null && audioSource != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}