using UnityEngine;

/// <summary>
/// Controls the Bat-Signal light in the sky
/// Toggles on/off with B key and provides smooth rotation/movement
/// </summary>
[RequireComponent(typeof(Light))]
public class BatSignalController : MonoBehaviour
{
    [Header("Bat-Signal Settings")]
    [Tooltip("Is the Bat-Signal currently active?")]
    [SerializeField] private bool isActive = false;

    [Tooltip("Rotation speed of the Bat-Signal")]
    [SerializeField] private float rotationSpeed = 10f;

    [Tooltip("Oscillation speed for smooth movement")]
    [SerializeField] private float oscillationSpeed = 0.5f;

    [Tooltip("Oscillation range for smooth movement")]
    [SerializeField] private float oscillationRange = 2f;

    [Header("Light Settings")]
    [Tooltip("Intensity when active")]
    [SerializeField] private float activeIntensity = 8f;

    [Tooltip("Light color")]
    [SerializeField] private Color signalColor = Color.yellow;

    // References
    private Light signalLight;
    private Vector3 initialPosition;
    private float oscillationTimer = 0f;

    /// <summary>
    /// Initialization
    /// </summary>
    void Start()
    {
        // Get light component
        signalLight = GetComponent<Light>();

        // Store initial position
        initialPosition = transform.position;

        // Configure light
        if (signalLight != null)
        {
            signalLight.type = LightType.Spot;
            signalLight.color = signalColor;
            signalLight.intensity = activeIntensity;
            signalLight.spotAngle = 60f;
            signalLight.range = 100f;
            signalLight.enabled = isActive;
        }
    }

    /// <summary>
    /// Update every frame
    /// </summary>
    void Update()
    {
        HandleInput();

        if (isActive)
        {
            AnimateSignal();
        }
    }

    /// <summary>
    /// Handles keyboard input for toggling Bat-Signal
    /// B key toggles the signal on/off
    /// </summary>
    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            ToggleSignal();
        }
    }

    /// <summary>
    /// Toggles the Bat-Signal on/off
    /// </summary>
    public void ToggleSignal()
    {
        isActive = !isActive;

        if (signalLight != null)
        {
            signalLight.enabled = isActive;
        }

        Debug.Log($"Bat-Signal: {(isActive ? "ON" : "OFF")}");
    }

    /// <summary>
    /// Animates the Bat-Signal with rotation and smooth movement
    /// </summary>
    private void AnimateSignal()
    {
        // Rotate the light smoothly
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.World);

        // Oscillate position for smooth movement effect
        oscillationTimer += Time.deltaTime * oscillationSpeed;
        float oscillation = Mathf.Sin(oscillationTimer) * oscillationRange;

        Vector3 newPosition = initialPosition;
        newPosition.x += oscillation;

        transform.position = newPosition;
    }

    /// <summary>
    /// Set the Bat-Signal state
    /// </summary>
    /// <param name="active">Whether to activate or deactivate</param>
    public void SetSignalActive(bool active)
    {
        isActive = active;

        if (signalLight != null)
        {
            signalLight.enabled = isActive;
        }
    }

    /// <summary>
    /// Check if the Bat-Signal is currently active
    /// </summary>
    public bool IsActive()
    {
        return isActive;
    }
}
