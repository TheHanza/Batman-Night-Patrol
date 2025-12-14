using UnityEngine;

/// <summary>
/// Main Batman controller that coordinates all systems
/// This is the central hub for Batman's behavior in Gotham
/// </summary>
public class BatmanController : MonoBehaviour
{
    [Header("Component References")]
    [Tooltip("Reference to the movement controller")]
    public BatmanMovement movementController;

    [Tooltip("Reference to the state manager")]
    public BatmanStateManager stateManager;

    [Header("UI Display")]
    [Tooltip("Show debug information on screen")]
    [SerializeField] private bool showDebugInfo = true;

    // Display current status
    private string statusText = "";

    /// <summary>
    /// Initialization
    /// </summary>
    void Start()
    {
        // Auto-find components if not assigned
        if (movementController == null)
        {
            movementController = GetComponent<BatmanMovement>();
        }

        if (stateManager == null)
        {
            stateManager = GetComponent<BatmanStateManager>();
        }

        UpdateStatusText();
    }

    /// <summary>
    /// Update every frame
    /// </summary>
    void Update()
    {
        UpdateStatusText();

        // Toggle debug info with F1
        if (Input.GetKeyDown(KeyCode.F1))
        {
            showDebugInfo = !showDebugInfo;
        }

        // Unlock cursor with ESC
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        // Re-lock cursor with left mouse click
        if (Input.GetMouseButtonDown(0) && Cursor.lockState == CursorLockMode.None)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    /// <summary>
    /// Update the status text display
    /// </summary>
    private void UpdateStatusText()
    {
        if (stateManager != null)
        {
            statusText = $"Batman State: {stateManager.GetCurrentState()}";

            if (movementController != null)
            {
                statusText += $"\nSpeed: {movementController.GetCurrentSpeed():F1}";
            }
        }
    }

    /// <summary>
    /// Display debug information on screen
    /// </summary>
    void OnGUI()
    {
        if (!showDebugInfo) return;

        // Style for the text
        GUIStyle style = new GUIStyle();
        style.fontSize = 20;
        style.normal.textColor = Color.white;
        style.padding = new RectOffset(10, 10, 10, 10);

        // Draw background box
        GUI.Box(new Rect(10, 10, 300, 200), "");

        // Display title
        GUIStyle titleStyle = new GUIStyle(style);
        titleStyle.fontSize = 24;
        titleStyle.normal.textColor = Color.yellow;
        GUI.Label(new Rect(20, 20, 280, 30), "BATMAN NIGHT PATROL", titleStyle);

        // Display status
        GUI.Label(new Rect(20, 60, 280, 100), statusText, style);

        // Display controls
        GUIStyle controlStyle = new GUIStyle(style);
        controlStyle.fontSize = 14;
        controlStyle.normal.textColor = Color.cyan;

        string controls = "CONTROLS:\n" +
                         "WASD - Move\n" +
                         "Mouse - Look\n" +
                         "Shift - Run\n" +
                         "C - Stealth\n" +
                         "Space - Alert\n" +
                         "N - Normal\n" +
                         "B - Bat-Signal\n" +
                         "ESC - Unlock Cursor\n" +
                         "F1 - Toggle Info";

        GUI.Label(new Rect(20, 120, 280, 300), controls, controlStyle);
    }
}
