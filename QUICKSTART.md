# Quick Start Guide

## Fastest Way to Get Started (Automated)

1. Open the project in Unity 2022.3 or later
2. Wait for Unity to import all assets
3. Go to menu: **Tools > Batman Night Patrol > Setup Scene**
4. Click "Yes" to auto-generate the scene
5. Press **Play** button
6. Start patrolling Gotham!

That's it! The automated setup will create everything for you.

## Manual Setup (If Preferred)

If you prefer to set up the scene manually, see [SCENE_SETUP_GUIDE.md](SCENE_SETUP_GUIDE.md)

## Controls Reference

| Key | Action |
|-----|--------|
| **W, A, S, D** | Move Batman |
| **Mouse** | Look around |
| **Shift** | Run/Sprint |
| **C** | Stealth Mode |
| **Space** | Alert Mode |
| **N** | Normal Mode |
| **B** | Toggle Bat-Signal |
| **ESC** | Unlock Cursor |
| **F1** | Toggle Debug Info |

## Features Overview

### States

**Normal Mode (N)**
- Headlights ON
- Normal speed
- Standard patrol

**Stealth Mode (C)**
- Lights OFF/Dim
- Reduced speed
- Silent approach

**Alert Mode (Space)**
- Flashing red/blue lights
- Alarm sound
- Increased speed

### Bat-Signal
- Press **B** to toggle
- Powerful spotlight in sky
- Rotates and oscillates

## Project Structure

```
Batman-Night-Patrol/
├── Assets/
│   ├── Scenes/
│   │   └── SampleScene.unity
│   ├── Scripts/
│   │   ├── BatmanController.cs         # Main controller
│   │   ├── Movement/
│   │   │   └── BatmanMovement.cs       # Character movement
│   │   ├── States/
│   │   │   └── BatmanStateManager.cs   # State management
│   │   ├── Lights/
│   │   │   └── BatSignalController.cs  # Bat-Signal
│   │   ├── Audio/
│   │   │   └── AlarmController.cs      # Alarm sounds
│   │   └── Editor/
│   │       └── BatmanSceneSetup.cs     # Auto-setup tool
│   ├── Materials/
│   ├── Audio/
│   └── Prefabs/
├── README.md                            # Main documentation (Persian/English)
├── QUICKSTART.md                        # This file
├── SCENE_SETUP_GUIDE.md                # Detailed manual setup
└── TESTING_AND_VIDEO_GUIDE.md          # Testing & recording help
```

## Troubleshooting

**Problem: Can't find Tools menu option**
- Make sure Unity has fully imported all scripts
- Check Console for any script errors
- Restart Unity if needed

**Problem: Batman won't move**
- Ensure you're in Play mode
- Check that cursor is locked (click in game window)
- Verify Character Controller is attached

**Problem: No lights/sounds**
- Run the automated setup (Tools > Batman Night Patrol > Setup Scene)
- Or manually assign lights in BatmanStateManager inspector

**Problem: Camera not following**
- Make sure Main Camera is child of Batman object
- Check camera position in automated setup

## Next Steps

1. ✅ Run automated setup
2. ✅ Test all features (see TESTING_AND_VIDEO_GUIDE.md)
3. ✅ Record demo video
4. ✅ Add your own enhancements (optional):
   - Better Batman model
   - More buildings
   - Sound effects
   - Particle effects
   - Batmobile (bonus)

## Need Help?

- See [SCENE_SETUP_GUIDE.md](SCENE_SETUP_GUIDE.md) for detailed setup
- See [TESTING_AND_VIDEO_GUIDE.md](TESTING_AND_VIDEO_GUIDE.md) for testing
- Check Unity Console for error messages
- Review script comments for implementation details

---

**Happy patrolling, Dark Knight!** 🦇
