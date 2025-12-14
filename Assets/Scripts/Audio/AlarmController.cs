using UnityEngine;

/// <summary>
/// Controls alarm sound effects
/// Used for Alert state audio management
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class AlarmController : MonoBehaviour
{
    [Header("Alarm Settings")]
    [Tooltip("Volume of the alarm")]
    [SerializeField] private float volume = 0.5f;

    [Tooltip("Should the alarm loop?")]
    [SerializeField] private bool loop = true;

    [Tooltip("Pitch of the alarm sound")]
    [SerializeField] private float pitch = 1f;

    // References
    private AudioSource audioSource;

    /// <summary>
    /// Initialization
    /// </summary>
    void Start()
    {
        // Get audio source component
        audioSource = GetComponent<AudioSource>();

        // Configure audio source
        if (audioSource != null)
        {
            audioSource.loop = loop;
            audioSource.volume = volume;
            audioSource.pitch = pitch;
            audioSource.playOnAwake = false;
        }
    }

    /// <summary>
    /// Play the alarm
    /// </summary>
    public void PlayAlarm()
    {
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();
            Debug.Log("Alarm: Playing");
        }
    }

    /// <summary>
    /// Stop the alarm
    /// </summary>
    public void StopAlarm()
    {
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop();
            Debug.Log("Alarm: Stopped");
        }
    }

    /// <summary>
    /// Toggle the alarm on/off
    /// </summary>
    public void ToggleAlarm()
    {
        if (audioSource != null)
        {
            if (audioSource.isPlaying)
            {
                StopAlarm();
            }
            else
            {
                PlayAlarm();
            }
        }
    }

    /// <summary>
    /// Check if alarm is currently playing
    /// </summary>
    public bool IsPlaying()
    {
        return audioSource != null && audioSource.isPlaying;
    }

    /// <summary>
    /// Set the volume of the alarm
    /// </summary>
    public void SetVolume(float newVolume)
    {
        volume = Mathf.Clamp01(newVolume);
        if (audioSource != null)
        {
            audioSource.volume = volume;
        }
    }
}
