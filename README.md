# 🎮 Unity 3D Arena Game

## 🏗️ Lecture 07: Base Build
Core gameplay foundation:
- Player movement using Rigidbody.
- Health and lives system.
- UI for score and health.
- Enemy patrol using waypoints.
- Hazards with damage and knockback.
- Coins and coin spawning.
- Speed and Shield power-ups.

## 🏟️ Level 1: Welcome to the Arena

**Objective:** Collect 5 coins to win.

**Gameplay:**
- No timer or enemies.
- Learn basic player controls.
- Avoid hazards that reduce health/lives.
- Collect all 5 coins.

**UI:**
- Score and Lives.
- Win and Lose panels.
- Restart button.

## ⏱️ Level 2: Race the Clock

**Objective:** Reach the green Exit Zone within 60 seconds.

**Gameplay:**
- Central maze wall.
- 3 pulsing hazards.
- 1 patrolling enemy.
- No health or lives system.
- Hazards and enemies apply massive knockback.

**UI:**
- 60-second countdown timer.
- Timer turns red below 10 seconds.
- Win and Lose panels.
- Restart button.

## 📜 Script Directory

### Core & Lecture 07
- `PlayerController.cs` – Player movement.
- `PowerUp.cs` – Speed and Shield power-ups.
- `Coin.cs` – Coin collection.
- `CoinSpawner.cs` – Coin spawning.
- `EnemyPatrol.cs` – Enemy waypoint movement.

### Level 1
- `GameManager.cs` – Score, health, lives, and game states.
- `Health.cs` – Player health management.
- `Hazard.cs` – Hazard damage and knockback.

### Level 2
- `Level2Manager.cs` – Timer, Win/Lose UI, and restart.
- `Level2ExitZone.cs` – Detects exit and triggers victory.
- `Level2Danger.cs` – Applies massive knockback.

## 🕹️ Controls

- **Move:** `W`, `A`, `S`, `D` or Arrow Keys.
- **Interact:** Walk into objects to collect or trigger them.

## 🎯 Learning Outcomes

- Rigidbody physics and player movement.
- Collision detection and triggers.
- Health and UI management.
- Collectibles and power-ups.
- Enemy AI and waypoint patrol.
- Knockback mechanics.
- Timers and game-state management.
