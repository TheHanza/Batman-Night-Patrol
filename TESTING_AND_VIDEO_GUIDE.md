# Testing and Video Recording Guide

## Testing Checklist

Before recording your video, make sure all features work correctly:

### 1. Movement System
- [ ] WASD keys move Batman in all directions
- [ ] Mouse movement rotates the camera
- [ ] Character rotates with horizontal mouse movement
- [ ] Shift key increases movement speed (running)
- [ ] Character doesn't fall through the ground
- [ ] Movement feels smooth and responsive

### 2. State System

#### Normal State (N key)
- [ ] Press N to enter Normal state
- [ ] Normal lights (headlights) are ON
- [ ] Alert lights are OFF
- [ ] Alarm sound is OFF
- [ ] Movement speed is normal

#### Stealth State (C key)
- [ ] Press C to enter Stealth state
- [ ] Normal lights turn OFF or dim
- [ ] Alert lights are OFF
- [ ] Alarm sound is OFF
- [ ] Movement speed is reduced (slower than normal)

#### Alert State (Space key)
- [ ] Press Space to enter Alert state
- [ ] Normal lights turn OFF
- [ ] Alert lights start FLASHING (red and blue alternating)
- [ ] Alarm sound starts PLAYING
- [ ] Movement speed is slightly increased
- [ ] When exiting Alert state, lights and sound stop

### 3. Bat-Signal
- [ ] Press B to toggle Bat-Signal ON
- [ ] Bright yellow/gold light appears in sky
- [ ] Bat-Signal rotates smoothly
- [ ] Bat-Signal oscillates (moves side to side)
- [ ] Press B again to toggle OFF
- [ ] Light disappears when toggled off

### 4. UI and Controls
- [ ] Debug info displays in top-left (if enabled)
- [ ] Current state is shown
- [ ] Current speed is shown
- [ ] Controls list is visible
- [ ] F1 toggles debug info on/off
- [ ] ESC unlocks cursor
- [ ] Clicking re-locks cursor

### 5. Environment
- [ ] Night atmosphere (dark scene)
- [ ] Moonlight visible (dim directional light)
- [ ] Buildings visible in distance
- [ ] Ground is properly textured
- [ ] Fog effect visible (if enabled)

## Video Recording Guide

### What to Include in Your Video

Your video should demonstrate ALL implemented features:

1. **Introduction** (5-10 seconds)
   - Show the full scene
   - Pan camera around to show Gotham environment

2. **Basic Movement** (15-20 seconds)
   - Walk forward, backward, left, right
   - Rotate camera with mouse
   - Show normal walking speed
   - Hold Shift to demonstrate running

3. **Normal State** (10 seconds)
   - Press N for Normal state
   - Show headlights are ON
   - Walk around to demonstrate

4. **Stealth State** (15 seconds)
   - Press C for Stealth mode
   - Show lights turn OFF/dim
   - Walk around slowly
   - Mention reduced speed

5. **Alert State** (20 seconds)
   - Press Space for Alert mode
   - Show flashing red/blue lights
   - Ensure alarm sound is audible in video
   - Walk around in Alert mode
   - Return to Normal (press N) to show lights/sound stop

6. **Bat-Signal** (20 seconds)
   - Press B to turn ON Bat-Signal
   - Show the light in the sky
   - Demonstrate rotation and movement
   - Press B to turn OFF
   - Press B again to turn back ON

7. **State Transitions** (15-20 seconds)
   - Cycle through all states: Normal → Stealth → Alert → Normal
   - Show smooth transitions
   - Demonstrate all effects working

8. **Final Showcase** (10-15 seconds)
   - Enable Alert mode
   - Turn ON Bat-Signal
   - Walk through Gotham with all effects active
   - End with Batman in action pose

### Recording Tips

#### Software Options:
- **OBS Studio** (Free, recommended)
  - Download from obsproject.com
  - Create a "Display Capture" or "Game Capture" source
  - Set resolution to 1920x1080 (Full HD)
  - Record at 30 or 60 fps

- **Windows Game Bar** (Built-in Windows 10/11)
  - Press Win + G
  - Click record button
  - Simple but effective

- **Unity Recorder** (Within Unity)
  - Window > Package Manager
  - Install "Unity Recorder"
  - Window > General > Recorder
  - Great for in-engine recording

#### Recording Settings:
- **Resolution**: 1920x1080 (1080p) recommended
- **Frame Rate**: 30 fps minimum, 60 fps better
- **Length**: 2-4 minutes total
- **Format**: MP4 (most compatible)

#### Before Recording:
1. Clean up Unity editor
2. Enter Play mode
3. Make sure all features work
4. Unlock cursor (ESC) if needed to start recording
5. Re-lock cursor (click) before demonstrating

#### During Recording:
1. Speak clearly (if adding voice-over) or add text captions
2. Move slowly and deliberately to show features
3. Pause briefly between feature demonstrations
4. Make sure effects are visible on camera
5. Don't rush - give viewers time to see each feature

#### Audio:
- Ensure alarm sound is audible
- If using voice-over, explain what you're demonstrating
- Keep background noise minimal
- Test audio levels before final recording

### Video Editing (Optional)

If you want to polish your video:

**Free Editing Software:**
- **DaVinci Resolve** (Professional, free)
- **Shotcut** (Simple, free)
- **Windows Video Editor** (Built-in Windows)

**What to Add:**
- Title screen: "Batman Night Patrol"
- Text labels for each feature
- Slow-motion for key moments
- Background music (optional, Batman theme?)
- End credits with your name

### Checklist Before Final Export

- [ ] Video shows all required features
- [ ] Video is 2-4 minutes long
- [ ] Resolution is at least 720p (preferably 1080p)
- [ ] Audio is clear (alarm sound audible)
- [ ] All state transitions demonstrated
- [ ] Bat-Signal shown working
- [ ] Movement in all directions shown
- [ ] Video file is in common format (MP4, MOV, AVI)

## Uploading Your Video

### Option 1: YouTube (Recommended)
1. Create YouTube account
2. Upload video as "Unlisted" or "Public"
3. Add title: "Batman Night Patrol - Unity Project"
4. Add description with controls and features
5. Copy the link for submission

### Option 2: Google Drive
1. Upload to Google Drive
2. Right-click > Share > "Anyone with link can view"
3. Copy the shareable link

### Option 3: GitHub Repository
1. If video is small (<100MB):
   - Add to repository in a "Demo" folder
   - Commit and push
2. If video is large:
   - Use Git LFS (Large File Storage)
   - Or upload to YouTube/Drive and link in README

### Add Video Link to README

Update your README.md to include:

```markdown
## Demo Video

Watch the demo video here: [Link to Video]

Or view it directly in the repository: `Demo/BatmanNightPatrol_Demo.mp4`
```

## Common Issues and Solutions

### Issue: Alarm sound not working in video
**Solution**:
- Check audio source volume
- Ensure microphone isn't muted in recording software
- Use "Desktop Audio" capture in OBS

### Issue: Video is too dark to see
**Solution**:
- Increase directional light intensity temporarily
- Add post-processing brightness
- Use video editor to brighten

### Issue: Choppy/laggy recording
**Solution**:
- Lower Unity quality settings during recording
- Reduce recording resolution to 720p
- Close other applications
- Use Unity Recorder instead of screen capture

### Issue: File size too large
**Solution**:
- Use MP4 format with H.264 codec
- Reduce resolution to 720p
- Reduce video length
- Use Handbrake to compress

---

Good luck with your testing and recording! Your Batman Night Patrol project is ready to showcase! 🦇
