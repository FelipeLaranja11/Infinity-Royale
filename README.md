# Infinity Royale – Roguelike City Defense  

**Supercell AI Game Hackathon 2025 Submission**  
Developed by **Felipe Laranja**  

🎮 [Gameplay Presentation #1 (YouTube)](https://www.youtube.com/watch?v=RFJY7ygksBI)  
🎥 [Gameplay Presentation #2 (YouTube)](https://www.youtube.com/watch?v=qDqsLRcTZDE)

---

## 🧠 Overview  

**Infinity Royale** is a Unity-based roguelite survival and building prototype designed for the **Supercell AI Game Hackathon 2025**.  
The project combines **action combat**, **base defense**, and **city management** within an **infinite wave system**.  

The player travels through kingdoms and roads, fighting endless waves of enemies while collecting upgrades, rebuilding cities, and surviving ever-increasing challenges.  

Built entirely by a **solo developer**, Infinity Royale demonstrates deep technical integration between gameplay systems, AI-assisted workflows, and procedural scalability.

---

## ⚙️ Technical Summary  

| Category | Description |
|-----------|-------------|
| **Engine** | Unity 6.2.0 (6000.2.8f1) |
| **Language** | C# |
| **Render Pipeline** | Built-in (2D setup) |
| **AI Tools** | ChatGPT (for code and logic design), Hyper3D (for 3D asset generation) |
| **Scripts Developed** | 40+ fully custom C# scripts |
| **Main Systems** | Combat, Wave Spawning, Health System, Player Controller, City Defense, UI |
| **Repository Size** | ~17 MB |
| **Architecture** | Modular Entity-Component prefabs and serialized event-driven systems |

---

## 🕹️ Gameplay Loop  

1. **Enter the Arena** — the player starts in a central map.  
2. **Survive Enemy Waves** — new enemies spawn every 15 seconds.  
3. **Fight & Evolve** — enemies deal contact damage; player uses abilities like *Zap* to survive.  
4. **Protect Cities** — if the city’s HP reaches zero, upgrades and safety are lost.  
5. **Advance** — move between kingdoms (planned feature) and strengthen your power.  

---

## 💾 Core Systems Breakdown  

### 🎯 `WaveController.cs`  
Manages the wave progression and triggers new enemy spawns.  
- Wave timing control (15s intervals).  
- Dynamic UI updates for wave notifications.  
- Coroutine-driven spawning logic.

### 👾 `WaveEnemySpawner.cs`  
Spawns enemies around the player and scales difficulty per wave.  
- Base count and per-wave increment logic.  
- Randomized spawn radius and player avoidance.  
- Communicates with `WaveController` through event handling.

### ❤️ `Health.cs` & `HealthUI.cs`  
Reusable health and damage system for Player, City, and Enemies.  
- Supports healing, damage, and HP updates in real time.  
- Connects to Unity’s UI `Slider` and TextMeshPro for live display.

### ⚡ `ZapAbility.cs`  
Implements area-of-effect “Zap” magic (inspired by *Clash Royale*).  
- Uses `Physics2D.OverlapCircle` for AoE detection.  
- Plays VFX via the `VFX_ZapRing` prefab.

### 🧱 `DamageCityOnTouch.cs`  
Enemy collision logic that damages the city.  
- Detects collisions and reduces city HP.  
- Works with `Health.cs` for city survival management.

### 🧩 `PlayerController.cs`  
Handles movement and player state.  
- WASD + Shift input support.  
- Rigidbody2D-based smooth motion and collision detection.

### 🖥️ UI Integration  
- **Canvas → CityUI, HPText, TimerText, WaveLabel**: all linked dynamically.  
- Full real-time sync with gameplay systems.

---

## 🧠 AI Integration  

| Tool | Purpose |
|------|----------|
| **ChatGPT (GPT-5)** | Assisted with C# architecture, gameplay scripting, debugging, and refactoring. |
| **Hyper3D (Rodin Gen-2)** | Used for low-poly model generation (FBX import). |
| **Unity AI MCP (Experimental)** | Tested for potential AI-driven gameplay control. |

AI was used as a **design and programming partner**, not a replacement — accelerating iteration and reinforcing best practices in Unity scripting.

---

## 🧱 Project Structure  

Assets/
│
├── Models/
│ └── Hyper3D/ → AI-generated models (.fbx)
│
├── Prefabs/
│ ├── Enemy.prefab
│ ├── Projectile.prefab
│ ├── ZapAbility.asset
│ └── VFX_ZapRing.prefab
│
├── Scenes/
│ ├── Arena.unity → Core gameplay prototype
│ ├── Menu.unity → Title / setup scene
│ └── SampleScene.unity → Early tests
│
├── Scripts/
│ ├── PlayerController.cs
│ ├── WaveController.cs
│ ├── WaveEnemySpawner.cs
│ ├── Health.cs / HealthUI.cs
│ ├── DamageCityOnTouch.cs
│ ├── ZapAbility.cs
│ └── +30 supporting scripts (effects, control, systems)
│
└── Settings/
└── Renderer2D.asset, URPProjectSettings.asset

---

## 🧩 Development Effort  

This project was **entirely developed solo**, from design to coding and integration.  

### Key Achievements:
- 💻 Created and interconnected **40+ unique C# scripts** without using templates.  
- ⚙️ Built **modular prefabs** with dynamic runtime linking.  
- 🧠 Integrated **AI tools (ChatGPT + Hyper3D)** for faster asset and logic creation.  
- 🔄 Implemented **event-driven architecture** across multiple systems.  
- 🏗️ Established foundations for **upgradable cities, procedural maps, and new abilities**.  

---

## 🚀 Future Vision  

- 🏰 Expand cities into upgradable territories.  
- 🌍 Implement travel and exploration between kingdoms.  
- 🤖 Add AI-driven NPCs with **Neocortex SDK** (voice-based dialogue).  
- 🎵 Integrate sound, music, and dynamic ambience.  
- ⚔️ Add elemental spells: Fireball, Freeze, Tornado, Lightning Chain.  

---

## 🧑‍💻 Credits  

| Role | Name |
|------|------|
| **Developer** | [Felipe Laranja](https://github.com/FelipeLaranja11) |
| **Hackathon** | Supercell AI Game Hackathon 2025 |
| **AI Assistants** | ChatGPT (code support), Hyper3D (3D assets) |
| **Engine** | Unity 6.2.0 (Windows Build) |
| **Status** | Playable Prototype – AI-powered game concept |

---

## 📸 Media Links  

🎮 [Gameplay Presentation #1](https://www.youtube.com/watch?v=RFJY7ygksBI)  
🎮 [Gameplay Presentation #2](https://www.youtube.com/watch?v=qDqsLRcTZDE)

---

⭐ *Infinity Royale* explores the synergy between **AI creativity and human game design** — showing how a single developer can craft a scalable, evolving world powered by logic, imagination, and technology.
