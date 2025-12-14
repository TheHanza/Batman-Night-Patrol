using UnityEngine;

/// <summary>
/// Controls Batman's movement in the environment
/// This script handles user input and moves the Batman character
/// </summary>
[RequireComponent(typeof(CharacterController))]
public class BatmanMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [Tooltip("Batman's normal walking speed")]
    [SerializeField] private float normalSpeed = 5f;

    [Tooltip("Batman's running/boost speed")]
    [SerializeField] private float runSpeed = 10f;

    [Tooltip("Batman's rotation speed")]
    [SerializeField] private float rotationSpeed = 10f;

    [Header("Camera Settings")]
    [Tooltip("Camera rotation sensitivity")]
    [SerializeField] private float mouseSensitivity = 2f;

    [Tooltip("Vertical camera rotation limit")]
    [SerializeField] private float maxLookAngle = 80f;

    // References to required components
    private CharacterController characterController;
    private Transform cameraTransform;

    // Internal variables
    private float currentSpeed;
    private float cameraPitch = 0f;

    /// <summary>
    /// Initialization
    /// </summary>
    void Start()
    {
        // Get reference to CharacterController
        characterController = GetComponent<CharacterController>();

        // Find the main camera
        if (Camera.main != null)
        {
            cameraTransform = Camera.main.transform;
        }

        // Hide and lock the cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    /// <summary>
    /// Update every frame
    /// </summary>
    void Update()
    {
        HandleMovement();
        HandleRotation();
        HandleCameraLook();
    }

    /// <summary>
    /// Handles Batman's movement
    /// Gets keyboard input and moves the character
    /// </summary>
    private void HandleMovement()
    {
        // Get keyboard input
        float horizontalInput = Input.GetAxis("Horizontal"); // A/D or Left/Right
        float verticalInput = Input.GetAxis("Vertical");     // W/S or Up/Down

        // Detect running state
        bool isRunning = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        currentSpeed = isRunning ? runSpeed : normalSpeed;

        // Calculate movement direction relative to character
        Vector3 moveDirection = transform.right * horizontalInput + transform.forward * verticalInput;
        moveDirection.Normalize();

        // Apply movement
        Vector3 move = moveDirection * currentSpeed * Time.deltaTime;

        // Add simple gravity
        move.y = -2f * Time.deltaTime;

        // Move the character
        characterController.Move(move);
    }

    /// <summary>
    /// Handles Batman's rotation
    /// Rotates character based on horizontal mouse movement
    /// </summary>
    private void HandleRotation()
    {
        // Get horizontal mouse movement
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;

        // Rotate character horizontally
        transform.Rotate(Vector3.up * mouseX);
    }

    /// <summary>
    /// Handles camera look
    /// Vertical camera rotation based on mouse movement
    /// </summary>
    private void HandleCameraLook()
    {
        if (cameraTransform == null) return;

        // Get vertical mouse movement
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Calculate vertical rotation angle
        cameraPitch -= mouseY;
        cameraPitch = Mathf.Clamp(cameraPitch, -maxLookAngle, maxLookAngle);

        // Apply rotation to camera
        cameraTransform.localRotation = Quaternion.Euler(cameraPitch, 0f, 0f);
    }

    /// <summary>
    /// Get Batman's current speed
    /// </summary>
    public float GetCurrentSpeed()
    {
        return currentSpeed;
    }

    /// <summary>
    /// Set speed multiplier (for different states)
    /// </summary>
    public void SetSpeedMultiplier(float multiplier)
    {
        normalSpeed *= multiplier;
        runSpeed *= multiplier;
    }
}
