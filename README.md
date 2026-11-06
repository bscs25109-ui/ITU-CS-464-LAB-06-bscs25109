# \# 🎮 Unity 3D Arena Game - Project Documentation

# 

# \## 🏗️ Lecture 07: Base Build (Foundation)

# \*   \*\*Core Mechanics:\*\* Player movement (`Rigidbody`), health system, and UI.

# \*   \*\*Enemies \& Hazards:\*\* Patrolling enemies using waypoints and hazards that deal damage/knockback.

# \*   \*\*Pickups:\*\* Coins (spawning/collecting) and Power-ups (Speed/Shield).

# 

# \## 🏟️ Level 1: "Welcome to the Arena"

# \*   \*\*Objective:\*\* Collect 5 coins to win. No timer, no enemies.

# \*   \*\*Gameplay:\*\* Focuses on learning controls. Touching hazards reduces health/lives. 

# \*   \*\*UI:\*\* Score, Lives, Win/Lose panels. Buttons simply restart the level.

# 

# \## ⏱️ Level 2: "Race the Clock"

# \*   \*\*Objective:\*\* Reach the green Exit Zone before 60 seconds run out.

# \*   \*\*Gameplay:\*\* Features a central maze wall, 3 pulsing hazards, and a patrolling enemy.

# \*   \*\*No Health System:\*\* Instead of taking damage, touching hazards/enemies applies a \*\*massive knockback\*\*, throwing the player across the arena and wasting time.

# \*   \*\*UI:\*\* Countdown timer (turns red under 10s) and Win/Lose panels.

# 

# \---

# 

# \## 📜 Script Directory

# 

# \### Core \& Lecture 7 Scripts

# \*   `PlayerController.cs` - Player movement.

# \*   `PowerUp.cs` - Speed and shield logic.

# \*   `Coin.cs` / `CoinSpawner.cs` - Coin collection and area-based spawning.

# \*   `EnemyPatrol.cs` - Enemy waypoint movement.

# 

# \### Level 1 Scripts

# \*   `GameManager.cs` - Handles Score, Health, and Lives.

# \*   `Health.cs` / `Hazard.cs` - Base health logic and damage/knockback.

# 

# \### Level 2 Scripts

# \*   `Level2Manager.cs` - Handles the 60s timer, Win/Lose UI, and Restart. (Replaces GameManager).

# \*   `Level2ExitZone.cs` - Triggers the Win state when the player enters the green zone.

# \*   `Level2Danger.cs` - Applies massive knockback to the player (replaces Health/Hazard).

# 

# \---

# 

# \## 🕹️ Controls

# \*   \*\*Move:\*\* `W`, `A`, `S`, `D` or Arrow Keys.

# \*   \*\*Interact:\*\* Walk into objects to collect or trigger them.

