using UnityEngine;
using UnityEditor;

/// <summary>
/// Editor script to automatically setup Batman Night Patrol scene
/// Go to Tools > Batman Night Patrol > Setup Scene to use
/// </summary>
public class BatmanSceneSetup : EditorWindow
{
    [MenuItem("Tools/Batman Night Patrol/Setup Scene")]
    static void SetupScene()
    {
        if (EditorUtility.DisplayDialog("Batman Night Patrol Setup",
            "This will create a basic Batman Night Patrol scene setup. Continue?",
            "Yes", "Cancel"))
        {
            CreateBatmanCharacter();
            CreateEnvironment();
            CreateBatSignal();
            SetupLighting();

            Debug.Log("Batman Night Patrol scene setup complete!");
            EditorUtility.DisplayDialog("Setup Complete",
                "Batman Night Patrol scene has been set up!\n\n" +
                "Press Play and use:\n" +
                "WASD - Move\n" +
                "Mouse - Look\n" +
                "Shift - Run\n" +
                "C - Stealth\n" +
                "Space - Alert\n" +
                "N - Normal\n" +
                "B - Bat-Signal",
                "OK");
        }
    }

    static void CreateBatmanCharacter()
    {
        // Create Batman parent object
        GameObject batman = new GameObject("Batman");
        batman.transform.position = new Vector3(0, 1, 0);

        // Add Character Controller
        CharacterController cc = batman.AddComponent<CharacterController>();
        cc.center = new Vector3(0, 1, 0);
        cc.radius = 0.5f;
        cc.height = 2f;

        // Add Batman scripts
        batman.AddComponent<BatmanMovement>();
        BatmanStateManager stateManager = batman.AddComponent<BatmanStateManager>();
        batman.AddComponent<BatmanController>();

        // Create visual body
        GameObject body = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        body.name = "BatmanBody";
        body.transform.parent = batman.transform;
        body.transform.localPosition = new Vector3(0, 1, 0);
        DestroyImmediate(body.GetComponent<Collider>());

        // Create dark material for Batman
        Material batmanMat = new Material(Shader.Find("Universal Render Pipeline/Lit"));
        batmanMat.color = new Color(0.1f, 0.1f, 0.1f);
        body.GetComponent<Renderer>().material = batmanMat;

        // Setup Camera
        Camera mainCam = Camera.main;
        if (mainCam != null)
        {
            mainCam.transform.parent = batman.transform;
            mainCam.transform.localPosition = new Vector3(0, 1.6f, -3);
            mainCam.transform.localRotation = Quaternion.Euler(10, 0, 0);
        }

        // Create normal lights (headlights)
        Light[] normalLights = new Light[2];

        GameObject normalLightLeft = new GameObject("NormalLight_Left");
        normalLightLeft.transform.parent = batman.transform;
        normalLightLeft.transform.localPosition = new Vector3(-0.3f, 0.5f, 0.5f);
        Light leftLight = normalLightLeft.AddComponent<Light>();
        leftLight.type = LightType.Spot;
        leftLight.color = Color.white;
        leftLight.intensity = 3f;
        leftLight.range = 20f;
        leftLight.spotAngle = 60f;
        normalLights[0] = leftLight;

        GameObject normalLightRight = new GameObject("NormalLight_Right");
        normalLightRight.transform.parent = batman.transform;
        normalLightRight.transform.localPosition = new Vector3(0.3f, 0.5f, 0.5f);
        Light rightLight = normalLightRight.AddComponent<Light>();
        rightLight.type = LightType.Spot;
        rightLight.color = Color.white;
        rightLight.intensity = 3f;
        rightLight.range = 20f;
        rightLight.spotAngle = 60f;
        normalLights[1] = rightLight;

        // Create alert lights (red/blue)
        Light[] alertLights = new Light[2];

        GameObject alertLightRed = new GameObject("AlertLight_Red");
        alertLightRed.transform.parent = batman.transform;
        alertLightRed.transform.localPosition = new Vector3(-0.5f, 2f, 0);
        Light redLight = alertLightRed.AddComponent<Light>();
        redLight.type = LightType.Point;
        redLight.color = Color.red;
        redLight.intensity = 5f;
        redLight.range = 15f;
        redLight.enabled = false;
        alertLights[0] = redLight;

        GameObject alertLightBlue = new GameObject("AlertLight_Blue");
        alertLightBlue.transform.parent = batman.transform;
        alertLightBlue.transform.localPosition = new Vector3(0.5f, 2f, 0);
        Light blueLight = alertLightBlue.AddComponent<Light>();
        blueLight.type = LightType.Point;
        blueLight.color = Color.blue;
        blueLight.intensity = 5f;
        blueLight.range = 15f;
        blueLight.enabled = false;
        alertLights[1] = blueLight;

        // Create alarm sound
        GameObject alarmObj = new GameObject("AlarmSound");
        alarmObj.transform.parent = batman.transform;
        alarmObj.transform.localPosition = Vector3.zero;
        AudioSource alarmAudio = alarmObj.AddComponent<AudioSource>();
        alarmAudio.loop = true;
        alarmAudio.playOnAwake = false;
        alarmObj.AddComponent<AlarmController>();

        // Connect everything to state manager
        SerializedObject serializedStateManager = new SerializedObject(stateManager);
        serializedStateManager.FindProperty("normalLights").arraySize = 2;
        serializedStateManager.FindProperty("normalLights").GetArrayElementAtIndex(0).objectReferenceValue = normalLights[0];
        serializedStateManager.FindProperty("normalLights").GetArrayElementAtIndex(1).objectReferenceValue = normalLights[1];
        serializedStateManager.FindProperty("alertLights").arraySize = 2;
        serializedStateManager.FindProperty("alertLights").GetArrayElementAtIndex(0).objectReferenceValue = alertLights[0];
        serializedStateManager.FindProperty("alertLights").GetArrayElementAtIndex(1).objectReferenceValue = alertLights[1];
        serializedStateManager.FindProperty("alarmAudioSource").objectReferenceValue = alarmAudio;
        serializedStateManager.ApplyModifiedProperties();

        Selection.activeGameObject = batman;
    }

    static void CreateEnvironment()
    {
        // Create ground
        GameObject ground = GameObject.CreatePrimitive(PrimitiveType.Plane);
        ground.name = "Ground";
        ground.transform.position = Vector3.zero;
        ground.transform.localScale = new Vector3(10, 1, 10);

        Material groundMat = new Material(Shader.Find("Universal Render Pipeline/Lit"));
        groundMat.color = new Color(0.2f, 0.2f, 0.2f);
        ground.GetComponent<Renderer>().material = groundMat;

        // Create some buildings
        CreateBuilding("Building1", new Vector3(15, 5, 15), new Vector3(5, 10, 5));
        CreateBuilding("Building2", new Vector3(-15, 5, 15), new Vector3(4, 12, 4));
        CreateBuilding("Building3", new Vector3(15, 4, -15), new Vector3(6, 8, 6));
        CreateBuilding("Building4", new Vector3(-15, 6, -15), new Vector3(5, 12, 5));
    }

    static void CreateBuilding(string name, Vector3 position, Vector3 scale)
    {
        GameObject building = GameObject.CreatePrimitive(PrimitiveType.Cube);
        building.name = name;
        building.transform.position = position;
        building.transform.localScale = scale;

        Material buildingMat = new Material(Shader.Find("Universal Render Pipeline/Lit"));
        buildingMat.color = new Color(0.15f, 0.15f, 0.15f);
        building.GetComponent<Renderer>().material = buildingMat;
    }

    static void CreateBatSignal()
    {
        GameObject batSignal = new GameObject("BatSignal");
        batSignal.transform.position = new Vector3(0, 50, 30);
        batSignal.transform.rotation = Quaternion.Euler(90, 0, 0);

        Light signalLight = batSignal.AddComponent<Light>();
        signalLight.type = LightType.Spot;
        signalLight.color = new Color(1f, 0.84f, 0f); // Gold/Yellow
        signalLight.intensity = 8f;
        signalLight.range = 100f;
        signalLight.spotAngle = 60f;
        signalLight.innerSpotAngle = 30f;
        signalLight.enabled = false;

        batSignal.AddComponent<BatSignalController>();
    }

    static void SetupLighting()
    {
        // Find or create directional light
        Light dirLight = FindObjectOfType<Light>();
        if (dirLight == null)
        {
            GameObject lightObj = new GameObject("Directional Light");
            dirLight = lightObj.AddComponent<Light>();
            dirLight.type = LightType.Directional;
        }

        // Configure as moonlight
        dirLight.color = new Color(0.69f, 0.77f, 0.87f); // Light blue
        dirLight.intensity = 0.3f;
        dirLight.transform.rotation = Quaternion.Euler(50, -30, 0);

        // Set ambient lighting for night
        RenderSettings.ambientMode = UnityEngine.Rendering.AmbientMode.Flat;
        RenderSettings.ambientLight = new Color(0.04f, 0.04f, 0.12f); // Very dark blue
        RenderSettings.fog = true;
        RenderSettings.fogColor = new Color(0.05f, 0.05f, 0.15f);
        RenderSettings.fogMode = FogMode.ExponentialSquared;
        RenderSettings.fogDensity = 0.01f;
    }
}
