# Cs50FinalProject-Arrow-Aim-Trainer
# VIDEO DEMO:
# Description
Ideas & purpose of project:
The idea behind this project was to create a game in Unity, a platform I had a previous interest in but failed to develop, using it to create a game/project I found personally interesting. An arrow aim trainer was chosen as many online aim trainers seem to only focus on hitscan bullets, ignoring modes for projectile weaponry (bows, grenade launchers, etc) seen in games such as Overwatch and Marvel Rivals.
The game retains a simplistic and arcade-style, but with multiple customizable features that add challenge and variety. While tracking score and accuracy.
The two documents here log the brainstorming processes and log of work done on the project.

PLEASE LOOK THROUGH THESE DOCUMENTS AS THEY LIST ANY SOURCES USED TO ASSIST IN DEVELOPMENT. SMALLER HELP, E.G., MODIFICATIONS TO LINES OF CODE CAN BE FOUND WITHIN THE SCRIPT COMMENTS THEMSELVES
Original Plan:
https://docs.google.com/document/d/178bNaOrG9rv8VMFu03LfapBZ89nZCcPksNQyUL_pN-w/edit?tab=t.0
Project Log: (ALSO NOTES THE SOURCES USED, eg, video guides to understand use of Unity and whether AI was used to assist in certain areas, eg, debugging
https://docs.google.com/document/d/1BGw74vBqPUo8az7fUET9cM6GBviog8ETwIGK9uRwt7A/edit?tab=t.0

Considerations of Development


Code explanation:
Arrow Behaviour -
Detects mouse input to fire the arrow with a shoot function, applying a variable force to an instantiated, cloned arrow. The shoot function will use raycast to ensure the arrow travels toward the screen centre, while giving the clone arrow kinematic and gravity properties to ensure it follows proper arrow physics, then calling to another script's function to calc accuracy. The cloned arrows are destroyed after 5 seconds and have a 0.7s interval between shots using allowInvoke.

Player Controller -
Locks the cursor to the crosshair and links mouse X & Y movement to camera movement, with this movement affected by a sensitivity variable. Movement clamped to -90 - 90 degrees vertical to prevent disorientation

Score Controller
- Uses TMPpro to change the UI score and accuracy text values over time (these values are kept as variables); the script's function can be accessed in other scripts as it is a single instance. Add score increases score by 1 on target hit and changes the UI text. Accuracy will update the accuracy text with the function either being passed a hit or miss string that can be compared to increase either hits or fired that are then divided and rounded to find the accuracy percentage(A string passed to the function was chosen instead of using 2 different functions originally for increasing hits and fired and calculating accuracy within both).

- Target Bounds:
- The script is made as an instance and grabs the distance variable from the settings menu script. The get random position will generate a random position for the target to spawn or for it to move for within the bound of a box colliders (collider is turned of within the game object), the minimum and max y and z values within the collider are found, and a random y or z value in returned from their range. Spawn distance is not random, as it's modified in the settings menu

- Target Controller:
- Using a variable speed from the settings menu, the position of the target endpoint is set using GetRandomPosition(). If the target has been set to move in the menu, it will move towards the endpoint according to its speed * Delta. time. When it reaches the endpoint, the endpoint is relocated with GetRandomPosition () (checked with conditional) and the process repeats. The code will also detect if the target has collided with the arrow, calling ScoresController's CalcAccuracy passing a "hit" string and destroying the arrow while using GetRandomPosition() to relocate the target.   A pre-made target with its mesh collider from the Unity assets store was used, as making my own target with its own mesh collider wasn't possible without specific 3D modelling knowledge, while other colliders wouldn't give accurate shapes.

- Target Spawner:
- Uses the target count from the settings menu, as uses this value in a for loop to spawn each target vertically above each other with instatiate as a child of a TargetSystem so each will have a unqiue endpoint that wont move relative to it if it was the targets own child (this method was previously used meaning the target could nether reach the endpoint as the endpoint moved with it, leading it to ifinitley travel).
- The Targets X position is set as -8, so it will spawn within the box collider and is then subtracted by the distance to increase its distance from the player.

- Timer:
- Uses TMPpro to update the timer based on the remaining time value that begins at 60 seconds. Uses Math.f.FloorToInt((remainingTime / 60  or remainingTime % 60) to find both the seconds and minutes remaining, and updates the text of the TMP pro timer text in a 0:00 format. Will load the menu scene once the timer ends, while the game automatically deloads.

- Main Menu:
- The first script that runs on game start will unlock the cursor and make it visible to allow it to move again if returning from the game. Using funcs will load the game scene when the start button is clicked, and quit the application when the quit button is pressed.
- While not in a script itself, the settings button has code set in the editor to make the settings menu active while deactivating the main menu; the exit button in the menu will do the inverse.

Settings Menu:
Each of its variables has been set as public static values so they can be accessed by the scripts, and in the other game scene, the distance and speed sliders change their values based on their max and min defined in the editor, which changes these float variables (set as float for fine control). The dropdown menu for target count changes the int target count, while the movement button changes the movement bool between true and false.







