using UnityEngine;

/// <summary>
/// Enum defining Batman's different states
/// </summary>
public enum BatmanState
{
    Normal,   // Normal patrol mode
    Stealth,  // Stealth/sneaking mode
    Alert     // Alert/alarm mode
}

/// <summary>
/// Manages Batman's different states: Normal, Stealth, and Alert
/// Each state has different behavior for lights, sounds, and speed
/// </summary>
public class BatmanStateManager : MonoBehaviour
{
    [Header("State Settings")]
    [Tooltip("Current state of Batman")]
    [SerializeField] private BatmanState currentState = BatmanState.Normal;

    [Header("Speed Multipliers")]
    [Tooltip("Speed multiplier in Normal state")]
    [SerializeField] private float normalSpeedMultiplier = 1f;

    [Tooltip("Speed multiplier in Stealth state")]
    [SerializeField] private float stealthSpeedMultiplier = 0.5f;

    [Tooltip("Speed multiplier in Alert state")]
    [SerializeField] private float alertSpeedMultiplier = 1.2f;

    [Header("Lights")]
    [Tooltip("Normal lights (headlights, etc.)")]
    [SerializeField] private Light[] normalLights;

    [Tooltip("Alert lights (red/blue flashing)")]
    [SerializeField] private Light[] alertLights;

    [Header("Audio")]
    [Tooltip("Alarm sound for Alert state")]
    [SerializeField] private AudioSource alarmAudioSource;

    // References
    private BatmanMovement movementController;

    // Flashing lights timer
    private float flashTimer = 0f;
    private float flashInterval = 0.5f;
    private bool lightsOn = false;

    /// <summary>
    /// Initialization
    /// </summary>
    void Start()
    {
        movementController = GetComponent<BatmanMovement>();

        // Initialize to Normal state
        SetState(BatmanState.Normal);
    }

    /// <summary>
    /// Update every frame
    /// </summary>
    void Update()
    {
        HandleStateInput();
        UpdateStateEffects();
    }

    /// <summary>
    /// Handles keyboard input for state changes
    /// C -> Stealth, Space -> Alert, N -> Normal
    /// </summary>
    private void HandleStateInput()
    {
        // C key for Stealth mode
        if (Input.GetKeyDown(KeyCode.C))
        {
            SetState(BatmanState.Stealth);
        }
        // Space key for Alert mode
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            SetState(BatmanState.Alert);
        }
        // N key for Normal mode
        else if (Input.GetKeyDown(KeyCode.N))
        {
            SetState(BatmanState.Normal);
        }
    }

    /// <summary>
    /// Updates effects based on current state
    /// Handles flashing lights in Alert mode
    /// </summary>
    private void UpdateStateEffects()
    {
        // Flash lights in Alert mode
        if (currentState == BatmanState.Alert && alertLights != null && alertLights.Length > 0)
        {
            flashTimer += Time.deltaTime;

            if (flashTimer >= flashInterval)
            {
                flashTimer = 0f;
                lightsOn = !lightsOn;

                // Toggle alert lights
                foreach (Light light in alertLights)
                {
                    if (light != null)
                    {
                        light.enabled = lightsOn;
                    }
                }
            }
        }
    }

    /// <summary>
    /// Sets Batman's state and applies appropriate effects
    /// </summary>
    /// <param name="newState">The new state to set</param>
    public void SetState(BatmanState newState)
    {
        // Exit current state
        ExitState(currentState);

        // Update state
        currentState = newState;

        // Enter new state
        EnterState(currentState);

        Debug.Log($"Batman State Changed: {currentState}");
    }

    /// <summary>
    /// Handles entering a new state
    /// Activates lights, sounds, and adjusts speed
    /// </summary>
    /// <param name="state">The state being entered</param>
    private void EnterState(BatmanState state)
    {
        switch (state)
        {
            case BatmanState.Normal:
                // Enable normal lights
                SetLights(normalLights, true);
                SetLights(alertLights, false);

                // Stop alarm
                if (alarmAudioSource != null)
                {
                    alarmAudioSource.Stop();
                }

                // Reset speed
                if (movementController != null)
                {
                    movementController.SetSpeedMultiplier(normalSpeedMultiplier);
                }
                break;

            case BatmanState.Stealth:
                // Dim or disable normal lights
                SetLights(normalLights, false);
                SetLights(alertLights, false);

                // Stop alarm
                if (alarmAudioSource != null)
                {
                    alarmAudioSource.Stop();
                }

                // Reduce speed
                if (movementController != null)
                {
                    movementController.SetSpeedMultiplier(stealthSpeedMultiplier);
                }
                break;

            case BatmanState.Alert:
                // Disable normal lights
                SetLights(normalLights, false);

                // Start alarm
                if (alarmAudioSource != null && !alarmAudioSource.isPlaying)
                {
                    alarmAudioSource.loop = true;
                    alarmAudioSource.Play();
                }

                // Increase speed slightly
                if (movementController != null)
                {
                    movementController.SetSpeedMultiplier(alertSpeedMultiplier);
                }

                // Reset flash timer
                flashTimer = 0f;
                lightsOn = false;
                break;
        }
    }

    /// <summary>
    /// Handles exiting a state
    /// Cleans up state-specific effects
    /// </summary>
    /// <param name="state">The state being exited</param>
    private void ExitState(BatmanState state)
    {
        switch (state)
        {
            case BatmanState.Alert:
                // Stop flashing lights
                SetLights(alertLights, false);

                // Stop alarm
                if (alarmAudioSource != null)
                {
                    alarmAudioSource.Stop();
                }
                break;
        }
    }

    /// <summary>
    /// Helper method to enable/disable an array of lights
    /// </summary>
    /// <param name="lights">Array of lights to control</param>
    /// <param name="enabled">Whether to enable or disable</param>
    private void SetLights(Light[] lights, bool enabled)
    {
        if (lights == null) return;

        foreach (Light light in lights)
        {
            if (light != null)
            {
                light.enabled = enabled;
            }
        }
    }

    /// <summary>
    /// Get the current state
    /// </summary>
    public BatmanState GetCurrentState()
    {
        return currentState;
    }
}
