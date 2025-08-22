# Cs50FinalProject-Arrow-Aim-Trainer

## VIDEO DEMO: <[(https://youtu.be/pcn-HaFTrts)]>

## Description

**Ideas & purpose of project:**

The idea behind this project was to create a game in Unity, a platform I had a previous interest in but failed to develop, using it to create a game/project I found personally interesting. An arrow aim trainer with a focus on improving aim, inspired by various aim trainers online.

The game retains a simplistic and arcade-style, but with multiple customizable features that add challenge and variety. While tracking score and accuracy.

The two documents here log the brainstorming processes and log of work done on the project.

> **PLEASE LOOK THROUGH THESE DOCUMENTS AS THEY LIST ANY SOURCES USED TO ASSIST IN DEVELOPMENT. SMALLER HELP, E.G., MODIFICATIONS TO LINES OF CODE CAN BE FOUND WITHIN THE SCRIPT COMMENTS THEMSELVES**

- **Original Plan:**  
  [Google Doc (Original Plan)](https://docs.google.com/document/d/e/2PACX-1vQj62I7sYeUfw3FF2S6yc89A8JLa1dPV4zUPNbPaciHvoxTC99BYMWhsZZ3UFHlj9HHeWmBw2keRctf/pub)

- **Project Log:** (ALSO NOTES THE SOURCES USED, eg, video guides to understand use of Unity and whether AI was used to assist in certain areas, eg, debugging)  
  [Google Doc (Project Log)](https://docs.google.com/document/d/e/2PACX-1vTl2AZA8W2CqKLjB0I8yRrVyJ8rFtZ_AzvSn7ZmAb-31clnQM_pchyfXNylF85Ac49L7IPT2jZN3-cd/pub)

---

## Considerations of Development

---

## Code explanation

### Arrow Behaviour

Detects mouse input to fire the arrow with a shoot function, applying a variable force to an instantiated, cloned arrow. The shoot function will use raycast to ensure the arrow travels toward the screen center/crosshair.

---

### Player Controller

Locks the cursor to the crosshair and links mouse X & Y movement to camera movement, with this movement affected by a sensitivity variable. Movement clamped to -90 - 90 degrees vertical to prevent disorientation.

---

### Score Controller

- Uses TMPpro to change the UI score and accuracy text values over time (these values are kept as variables); the script's function can be accessed in other scripts as it is a single instance.
- Add score and accuracy logic.

---

### Target Bounds

- The script is made as an instance and grabs the distance variable from the settings menu script.
- The `get random position` will generate a random position for the target to spawn or for it to move for variety.

---

### Target Controller

- Using a variable speed from the settings menu, the position of the target endpoint is set using `GetRandomPosition()`.
- If the target has been set to move in the menu, it will move towards the endpoint.

---

### Target Spawner

- Uses the target count from the settings menu, as uses this value in a for loop to spawn each target vertically above each other with `instantiate` as a child of a TargetSystem so each will have a unique parent.
- The Targets X position is set as -8, so it will spawn within the box collider and is then subtracted by the distance to increase its distance from the player.

---

### Timer

- Uses TMPpro to update the timer based on the remaining time value that begins at 60 seconds.
- Uses `Mathf.FloorToInt((remainingTime / 60) or (remainingTime % 60))` to find both the seconds and minutes remaining.

---

### Main Menu

- The first script that runs on game start will unlock the cursor and make it visible to allow it to move again if returning from the game.
- Using functions will load the game scene when the start button is pressed.
- While not in a script itself, the settings button has code set in the editor to make the settings menu active while deactivating the main menu; the exit button in the menu will do the inverse.

---

### Settings Menu

Each of its variables has been set as public static values so they can be accessed by the scripts, and in the other game scene, the distance and speed sliders change their values based on their max and min.

---







