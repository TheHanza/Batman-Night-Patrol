# Batman Night Patrol - Scene Setup Guide

This guide will help you set up the Unity scene step by step.

## Step 1: Create Batman Character

1. In Unity Hierarchy, right-click and create a new **Empty GameObject**
2. Rename it to "Batman"
3. Add the following components to Batman:
   - **Character Controller** (Component > Physics > Character Controller)
   - **BatmanMovement** script
   - **BatmanStateManager** script
   - **BatmanController** script

4. Configure Character Controller:
   - Center: (0, 1, 0)
   - Radius: 0.5
   - Height: 2

5. Create a visual representation:
   - Right-click Batman > 3D Object > Capsule
   - Rename to "BatmanBody"
   - Remove the Capsule Collider component
   - Position: (0, 1, 0)
   - You can add a dark material (black/dark gray) to make it look like Batman

## Step 2: Create Camera Setup

1. Select the **Main Camera** in the Hierarchy
2. Make it a child of Batman (drag it onto Batman)
3. Set Camera position:
   - Position: (0, 1.6, -3)
   - Rotation: (10, 0, 0)
4. This creates a third-person camera view

## Step 3: Create Ground/Environment

1. Right-click in Hierarchy > 3D Object > Plane
2. Rename to "Ground"
3. Scale it up: (10, 1, 10) for a larger patrol area
4. Position: (0, 0, 0)
5. Create a material:
   - Right-click in Assets/Materials > Create > Material
   - Name it "GroundMaterial"
   - Set color to dark gray or asphalt color
   - Drag it onto the Ground plane

## Step 4: Add Buildings (Optional but Recommended)

1. Create some buildings for Gotham atmosphere:
   - Right-click Hierarchy > 3D Object > Cube
   - Rename to "Building1"
   - Scale: (5, 10, 5) for a tall building
   - Position: (15, 5, 15)
   - Duplicate and create more buildings around the scene

2. Create a dark material for buildings:
   - Assets/Materials > Create > Material
   - Name: "BuildingMaterial"
   - Color: Very dark gray or black
   - Apply to buildings

## Step 5: Setup Lighting for Night Scene

### A. Directional Light (Moonlight)
1. Select **Directional Light** in Hierarchy
2. Configure:
   - Color: Light blue (#B0C4DE or similar)
   - Intensity: 0.3 (dim for night)
   - Rotation: (50, -30, 0) for angled moonlight

### B. Normal Lights (Headlights)
1. Create Batman's normal lights:
   - Right-click Batman > Light > Spot Light
   - Rename to "NormalLight_Left"
   - Position: (-0.3, 0.5, 0.5)
   - Rotation: (0, 0, 0)
   - Color: White or light yellow
   - Intensity: 3
   - Range: 20
   - Spot Angle: 60

2. Duplicate for right light:
   - Right-click NormalLight_Left > Duplicate
   - Rename to "NormalLight_Right"
   - Position: (0.3, 0.5, 0.5)

### C. Alert Lights (Red/Blue Flashing)
1. Create alert light 1:
   - Right-click Batman > Light > Point Light
   - Rename to "AlertLight_Red"
   - Position: (-0.5, 2, 0)
   - Color: Red (#FF0000)
   - Intensity: 5
   - Range: 15
   - Disable it initially (uncheck the component)

2. Create alert light 2:
   - Right-click Batman > Light > Point Light
   - Rename to "AlertLight_Blue"
   - Position: (0.5, 2, 0)
   - Color: Blue (#0000FF)
   - Intensity: 5
   - Range: 15
   - Disable it initially

## Step 6: Setup Bat-Signal

1. Create a new Empty GameObject in Hierarchy (not child of Batman)
2. Rename to "BatSignal"
3. Position it high in the sky: (0, 50, 30)
4. Rotation: (90, 0, 0) - pointing down
5. Add a **Spot Light** component:
   - Color: Yellow (#FFD700)
   - Intensity: 8
   - Range: 100
   - Spot Angle: 60
   - Inner Spot Angle: 30

6. Add the **BatSignalController** script to BatSignal
7. Initially disable the light (you'll toggle it with 'B' key)

## Step 7: Setup Audio for Alarm

1. Create an alarm sound object:
   - Right-click Batman > Create Empty
   - Rename to "AlarmSound"
   - Position: (0, 0, 0)
   - Add **Audio Source** component
   - Add **AlarmController** script

2. For the alarm sound:
   - If you have an alarm audio file (.wav or .mp3):
     - Drag it to Assets/Audio folder
     - Assign it to the Audio Source's "Audio Clip" field
   - If you don't have audio:
     - You can find free alarm sounds online
     - Or the system will work without sound (just lights will flash)

## Step 8: Connect Everything in BatmanStateManager

1. Select the **Batman** GameObject
2. In the **BatmanStateManager** component:
   - Normal Lights: Set size to 2
     - Element 0: Drag NormalLight_Left
     - Element 1: Drag NormalLight_Right
   - Alert Lights: Set size to 2
     - Element 0: Drag AlertLight_Red
     - Element 1: Drag AlertLight_Blue
   - Alarm Audio Source: Drag the AlarmSound's Audio Source component

## Step 9: Configure Skybox for Night

1. Go to **Window > Rendering > Lighting**
2. In the Environment tab:
   - Skybox Material: Use default or set to darker skybox
   - Environment Lighting > Source: Color
   - Ambient Color: Very dark blue (#0A0A20)
   - Fog: Enable it
   - Fog Color: Dark blue-gray
   - Fog Mode: Exponential Squared
   - Fog Density: 0.01

## Step 10: Final Checks

1. Verify Batman components:
   - BatmanMovement script is attached
   - BatmanStateManager script is attached
   - BatmanController script is attached
   - Character Controller is configured

2. Test the scene:
   - Press Play
   - WASD should move Batman
   - Mouse should look around
   - C should enable Stealth mode
   - Space should enable Alert mode (lights flash, alarm plays)
   - N should return to Normal mode
   - B should toggle Bat-Signal

## Additional Enhancements (Optional)

### Add More Atmosphere:
1. Create street lights around the scene
2. Add particle effects for fog/mist
3. Add more buildings to create a city feel
4. Create a Gotham-style atmosphere with dark colors

### For Batmobile (Bonus):
If you want to add a Batmobile instead:
1. Create a vehicle model using cubes/primitives
2. Adjust the BatmanMovement script speeds
3. Add wheel objects as children
4. Create a more vehicle-like appearance

## Troubleshooting

**Problem: Batman doesn't move**
- Check if Character Controller is attached
- Verify BatmanMovement script is attached
- Make sure the ground has a collider

**Problem: Camera doesn't follow**
- Ensure Main Camera is a child of Batman GameObject

**Problem: Lights don't work**
- Verify lights are assigned in BatmanStateManager
- Check if lights have the Light component

**Problem: No sound**
- Make sure Audio Listener is on Main Camera (default)
- Verify audio clip is assigned to Audio Source
- Check volume is not 0

---

You're now ready to patrol Gotham as Batman!
