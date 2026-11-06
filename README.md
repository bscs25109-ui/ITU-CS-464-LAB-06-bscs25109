# 🎮 Unity 3D Arena Game

## 🏗️ Lecture 07: Base Build
- Rigidbody-based player movement.
- Health and lives system.
- Score and UI management.
- Enemy patrol using waypoints.
- Hazards with damage and knockback.
- Coins and coin spawning.
- Speed and Shield power-ups.

## 🏟️ Level 1: Welcome to the Arena

**Objective:** Collect 5 coins to win.

**Gameplay:**
- No timer or enemies.
- Learn basic movement controls.
- Avoid hazards that reduce health/lives.
- Collect all 5 coins.

**UI:** Score, Lives, Win/Lose panels, Restart button.

## ⏱️ Level 2: Race the Clock

**Objective:** Reach the green Exit Zone within 60 seconds.

**Gameplay:**
- Central maze wall.
- 3 pulsing hazards.
- 3 patrolling enemy.
- No health or lives system.
- Hazards and enemies apply massive knockback.

**UI:** Countdown timer (red below 10 seconds), Win/Lose panels, Restart button.

## 🪙 Level 3: Coin Rush

**Objective:** Collect 10 coins within 45 seconds.

**Gameplay:**
- Arena divided into 4 quadrants using cross-walls.
- 3 patrolling enemies.
- Enemies apply massive knockback.
- Smart coin spawning using `Physics.CheckSphere`.
- Coins spawn only in empty floor spaces without overlapping walls or enemies.

**UI:** Countdown timer, Score tracker (0/10), Win/Lose panels, Restart button.

## 🏃‍♂️ Level 4: Survive the Onslaught

**Objective:** Survive for 45 seconds. When the timer reaches 0, YOU WIN!

**Gameplay:**
- Enemies normally patrol between waypoints.
- Enemies chase the player when they enter their `chaseRange` (6 units).
- Enemies instantly catch the player within `catchRadius` (1.3 units).
- Touching any hazard causes instant death.
- No health or lives system.

**UI:**
- 45-second survival timer.
- Timer turns green below 10 seconds.
- Win Panel: "You Survived!"
- Lose Panel: Displays a custom message depending on the cause of death.

  ## 👑 Level 5: The Final Challenge

**Objective:** Collect 5 coins to unlock the Exit Zone, then reach it within 60 seconds.

**Gameplay:**
- Arena with cross-walls.
- Smart chasing enemies.
- Instant-death hazards.
- Exit Zone remains locked until all 5 coins are collected.
- Reach the unlocked Exit Zone before time runs out to win.

**UI:**
- 60-second countdown timer.
- Coin score tracker (0/5).
- Exit locked/unlocked status.
- Win/Lose panels.

- 
## 📜 Script Directory

### Core & Lecture 07
- `PlayerController.cs` – Player movement.
- `PowerUp.cs` – Speed and Shield power-ups.
- `Coin.cs` – Coin collection.
- `CoinSpawner.cs` – Coin spawning with collision checking.
- `EnemyPatrol.cs` – Enemy waypoint movement.

### Level 1
- `GameManager.cs` – Score, health, lives, and game states.
- `Health.cs` – Player health management.
- `Hazard.cs` – Hazard damage and knockback.

### Level 2
- `Level2Manager.cs` – 60-second timer, Win/Lose UI, and restart.
- `Level2ExitZone.cs` – Detects exit and triggers victory.
- `Level2Danger.cs` – Applies massive knockback.

### Level 3
- `Level3Manager.cs` – 45-second timer, coin score, Win/Lose UI, and restart.
- `Level3Coin.cs` – Adds collected coins to the Level 3 Manager.
- `Level2Danger.cs` – Reused for enemy knockback.

## 📜 Level 4 Scripts

- `Level4Manager.cs` – Handles survival timer, Win/Lose UI, and custom lose messages.
- `Level4EnemyAI.cs` – Controls waypoint patrolling, player chasing, and instant catching.
- `Level4Hazard.cs` – Instantly triggers the Lose panel when the player touches a hazard.

  ## 📜 Level 5 Scripts

- `Level5Manager.cs` – Handles timer, coin score, exit unlocking, Win/Lose UI, and restart.
- `Level5Coin.cs` – Handles coin collection and score updates.
- `Level5ExitZone.cs` – Checks whether the exit is unlocked and triggers victory.
- `Level5EnemyAI.cs` – Controls enemy patrol and smart chasing behavior.
- `Level5Hazard.cs` – Instantly triggers the Lose state when the player touches a hazard.

## 🕹️ Controls
- **Move:** `W`, `A`, `S`, `D` or Arrow Keys.
- **Interact:** Walk into objects to collect or trigger them.

## 🎯 Learning Outcomes
- Rigidbody physics and player movement.
- Collision detection and triggers.
- Health and UI management.
- Collectibles and power-ups.
- Enemy AI and waypoint patrol.
- Physics-based knockback.
- Smart spawning using `Physics.CheckSphere`.
- Countdown timers and game-state management.
