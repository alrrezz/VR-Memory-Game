# ⭐ VR Memory Game

A Virtual Reality Serious Game for Short-Term Memory Training & Evaluation
Developed in Unity (C#)


---

# 📌 Overview

VR Memory Game is a virtual reality serious game designed to train and evaluate short-term memory.
Each level consists of two phases:

1. Target Presentation – a set of target objects is shown briefly


2. Object Identification – mixed objects appear, and the player must correctly identify only the targets



As the player progresses, difficulty increases by expanding the number of targets, total objects, movement complexity, and cognitive load.

The game is built using Unity, C#, and XR Interaction Toolkit, and runs on Meta Quest / Oculus / PCVR devices.


---

# 🎯 Key Features

✔ Two-Phase Memory Challenge: Target Memorization → Object Recognition

✔ Dynamic Difficulty Scaling across multiple levels

✔ Short-Term Memory Assessment through interactive gameplay

✔ Scoring System including accuracy, time, and remaining lives

✔ Full VR Interaction using Meta Quest controllers

✔ Audio & Visual Feedback Systems (SFX/VFX)

✔ Optimized Performance for VR

✔ Data Logging of final score, total time, and completion date



---

# 🧠 Game Concept

The main objective is to challenge the player's short-term memory capacity through increasing cognitive load:

Gameplay Logic

1. Targets are shown briefly


2. Targets disappear


3. Mixed objects spawn (correct + distractors)


4. The player must hit the correct objects


5. Wrong hits reduce life


6. Completing the sequence progresses to the next level


7. Game ends after losing 3 lives




---

# 🕹 Gameplay Flow

**1. Target Presentation**

A small set of target objects appears for a limited time.

**2. Object Identification Phase**

A larger group of objects spawns; only some of them match the previously shown targets.

**3. Scoring**

Points are awarded for correct hits, and lives are lost for mistakes.

**4. Difficulty Scaling**

Difficulty increses by the time goes.


---

# 🧩 Script Responsibilities

**✔ GameSession.cs**

Manages global game flow, player lives, current level, and final game result.

**✔ LevelManager.cs**

Controls difficulty progression: number of targets, total objects, and speed.

**✔ ObjectManagement.cs**
  
Selects target objects, prepares object lists for each level, and manages phase transitions.

**✔ ObjectSpawner.cs**
  
Spawns objects with specific movement parameters and timing.

**✔ ObjectShredder.cs**
  
Destroys objects leaving the play area to preserve performance.

**✔ Stick.cs**
  
Handles VR collisions and determines whether the player hits a correct or incorrect object.

**✔ ScoreTextUI.cs / TimeTextUI.cs**
  
Updates UI elements for score, time, and game messages.

**✔ DataLogger.cs**
  
Saves Final Score, Total Time, Completion Date


**✔ VFXSystem.cs / SFXPlayer.cs**
  
Provides visual and audio feedback for correct hits, mistakes, and interactions.


---

# 🛠 Technologies Used

Unity (2022 LTS / 2023 LTS)

C#

XR Interaction Toolkit (Unity XR)

Meta Quest / Oculus Integration

Visual Studio / Rider



---

# 🚀 How to Run

Requirements

Unity 2022 LTS or 2023 LTS

XR Plugin Management enabled

OpenXR activated with Meta/Oculus profile

Meta Quest 2/3/Pro (Standalone or Link)


Steps

1. Clone the repo:

git clone https://github.com/alrrezz/VR-Memory-Game


2. Open the project in Unity


3. Enable XR Plugin Management & OpenXR


4. Open the MainScene


5. For Build:

Platform → Android

Target Device → Meta Quest

Architecture → ARM64

Graphics API → OpenGLES3

OpenXR enabled





---

# 📊 Data Logging

After completing a session, the game saves:

Player Score

Total Time

Completion Date (timestamp)


The data can be used to evaluate the player’s performance over time.


---

# 🗺 Roadmap

[ ] Add more environments & themed levels

[ ] Add adaptive difficulty (AI-based performance tracking)

[ ] Add more detailed data logging (reaction times, accuracy, per-level stats)

[ ] Add global player profiles

[ ] Add online leaderboard

[ ] Add more visual effects



---

# 🎓 Academic Context

This project is part of a Bachelor Thesis titled:
“Designing a VR Game for Short-Term Memory Training and Evaluation”


---

# 📜 License

## License
This project is licensed under the **Creative Commons Attribution–NonCommercial 4.0 International (CC BY-NC 4.0)**.

You are free to use, modify, and learn from this project for **non-commercial purposes only**.
Commercial use is **not allowed** without explicit permission from the author.


---

# 👤 Developer

Alireza Pahlevanzadeh
GitHub: https://github.com/alrrezz


---
