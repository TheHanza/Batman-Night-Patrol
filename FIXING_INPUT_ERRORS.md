# Fixing Input System Errors

## The Problem

You're seeing this error:
```
InvalidOperationException: You are trying to read Input using the UnityEngine.Input class,
but you have switched active Input handling to Input System package in Player Settings.
```

This happens because Unity has two input systems, and your project is set to use the new one, but our scripts use the old one.

## Quick Fix (Recommended - 1 minute)

**Change Unity's Input System to "Both" or "Legacy":**

1. In Unity, go to menu: **Edit > Project Settings**
2. In the left panel, click **Player**
3. In the right panel, expand **Other Settings**
4. Scroll down to find **Active Input Handling**
5. Change it from "Input System Package (New)" to **"Both"**
   - This allows both old and new input systems to work
6. Unity will ask to restart - click **"Yes"**
7. Wait for Unity to restart

**That's it! Your errors should be gone.**

---

## Alternative: If You Still Get Errors

If the above doesn't work, try this:

### Option A: Use Legacy Input Only

1. **Edit > Project Settings > Player > Other Settings**
2. **Active Input Handling** → Change to **"Input Manager (Old)"**
3. Restart Unity when prompted

### Option B: Install Input System Package

If you want to keep using the new Input System:

1. **Window > Package Manager**
2. Search for "Input System"
3. Click **Install**
4. Wait for installation

Then we'll need to update the scripts (see below).

---

## Long-Term Solution: Update Scripts for New Input System

If you want to use the new Input System, I can update all scripts. But for this assignment, using "Both" or "Legacy" is perfectly fine and faster.

**The old Input System (`Input.GetKey`, `Input.GetAxis`) is still widely used and completely valid for Unity projects.**

---

## After Fixing

Once you've changed the setting and restarted Unity:

1. ✅ All input errors should be gone
2. ✅ Press Play to test
3. ✅ All controls should work:
   - WASD movement
   - Mouse look
   - C, Space, N keys for states
   - B key for Bat-Signal

---

## Verification

After fixing, test these controls:

- [ ] WASD moves Batman
- [ ] Mouse rotates camera
- [ ] Shift makes Batman run
- [ ] C key activates Stealth
- [ ] Space key activates Alert
- [ ] N key returns to Normal
- [ ] B key toggles Bat-Signal
- [ ] F1 toggles debug info

If all work, you're ready to continue! 🎉

---

## Why This Happened

Unity has two input systems:
1. **Input Manager (Old)**: `Input.GetKey()`, `Input.GetAxis()` - Simple, easy
2. **Input System (New)**: More powerful but complex

Your project template came with the new system enabled, but our scripts use the old system (which is simpler and perfect for this project).

Setting it to "Both" makes everything work! ✅
