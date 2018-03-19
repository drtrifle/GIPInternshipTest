Name: Hon Kean Wai
School: National University of Singapore

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

Instructions:

Your objective is to get the highest score before your health runs out.
You accomplish this by spawning bowling pins which will shoot the bowling balls. Try to prevent the bowling balls from reaching the end of the lane!
You spawn bowling pins by clicking on the bowling lane indicated by the green cursor. Watch out as it costs 5 health to spawn a pin!
Every 10 points you earn from killing the bowling balls earns you 1 health allowing you to keep playing longer
Bowling balls can be blocked by placing a pin in front of them. However they will deal contact damage to your pins
All units have short invincibility frames after damage so its recommended to place your pins up and down the lane to maximise your damage

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

Extra Credit:

- Object pool for projectiles

- Implemented gameover screen with ability to restart game

- Implemented sound for various player actions

- Created a main menu UI for the game

- Implemented extra enemy types (enemy that seeks out towers instead of the goal)
    - Forces players to adapt to enemies actively seeking out towers to destroy
    - Towers spaced far apart are harder to defend

- Created a health bar UI that floats over the enemy and tower units
    - To help players visualise how much health the units on the screen have

- Implemented slight screen shake when an enemy reaches the end
    - Player feedback to let them know that they are not doing well

- Implemented towers taking away 5 health from the player when spawned
    - The reason for this is to prevent players from placing too many tower and to encourage some form of strategy to manage their resources

- Implemented invincibility frames for enemy & player units which can be seen in game by the flashing sprites
    - The reason for this is to discourage players spamming towers in one place and instead encourage them to spread the towers

- Increased player health for every 10 points they gain
    - Positive feedback loop for the player allowing them to continue playing longer

- Implemented a custom cursor that changes colour based on whether the player can spawn pins there or not
    - Player feedback

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

Required Features:

- Implemented random units spawning from bottom of screen
- Implemented unit speed, health & attack strength
- Implemented units moving from bottom to top of screen at constant velocity
- Implemented the two types of enemies (Type A: Red Enemy, Type B: Green Enemy)
- Implemented tower spawning when player clicks on the bowling lane
- Implemented tower shooting and tower health
- Implemented enemy damaging the player when they reach the top of the screen
- Implemented game over when player health reaches zero