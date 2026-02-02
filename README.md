# InteractionSystem – Unity Intern Case

This repository contains a modular **Interaction System** developed as part of the **Ludu Arts Unity Intern Case**.  
The goal of the project is to demonstrate clean architecture, extensibility, and proper use of Unity systems such as **Input System**, **UI**, and **component-based design**.

---

## 🎯 Project Goals

- Build a scalable and reusable interaction system
- Avoid hardcoded inputs and logic
- Separate responsibilities between Player, Interactables, and UI
- Demonstrate understanding of Unity best practices
- Integrate UI feedback for player actions

---

## 🧩 Core Features

### Interaction System
- Trigger-based interaction detection
- Interface-driven design (`IInteractable`, `IHoldInteractable`, etc.)
- Nearest interactable selection when multiple objects are in range
- Supports both **press** and **hold-to-interact** behaviors

### Input Handling
- Uses Unity **New Input System**
- Interaction input is configured via `InputActionReference`
- No hardcoded keys (Inspector-driven configuration)

### Implemented Interactables
- **Key (Auto Pickup)**  
  - Collected automatically on trigger enter  
  - Stored in inventory state
- **Locked Door**
  - Requires key to open
  - Displays UI warning if key is missing
- **Chest (Hold-to-Interact)**
  - Requires holding interaction input
  - Progress bar UI feedback
  - Lid opens with pivot-based animation
- **Lever (Toggle Interaction)**
  - Press interaction
  - Toggles a light or target object on/off
  - Visual lever handle animation

### UI Feedback
- Dynamic interaction prompts (e.g. *Press [E] to interact*, *Hold [E] to open chest*)
- Progress bar for hold interactions
- Notification messages for important events
- Inventory UI icon (key collected / consumed)

---

## 🗂️ Project Structure
Assets/
└─ InteractionSystem/
├─ Scripts/
│ └─ Runtime/
│ ├─ Core/ # Interfaces and core contracts
│ ├─ Player/ # Player interaction & inventory
│ ├─ Interactables/ # Door, Chest, Lever, Key logic
│ └─ UI/ # Prompt, progress, notification UI
├─ Settings/ # Input Actions
└─ Scenes/

## 🧠 Design Decisions

- **Trigger-based interaction** was preferred over raycasting for better stability in third-person and proximity-based gameplay.
- **Interface segregation** allows new interactables to be added without modifying existing player logic.
- **Event-based UI updates** were used instead of polling to ensure clean state synchronization.
- **Hold logic** is handled by the PlayerInteractor to keep interactables focused on behavior only.

---

## 🤖 LLM Usage

LLMs (ChatGPT) were used during development to:
- Evaluate architectural approaches
- Compare interaction handling strategies
- Identify edge cases (UI sync, input handling, state management)

All LLM usage is documented in detail in `PROMPTS.md`, including:
- The exact prompts used
- How responses were adapted
- Which suggestions were accepted or rejected

No code was blindly copy-pasted; all outputs were reviewed and integrated consciously.

---

## ▶️ How to Run

1. Open the project in **Unity 6**
2. Make sure **Input System (New)** is enabled
3. Open the main test scene
4. Press Play and interact with objects using the configured interaction input

---

## ✅ Notes

- This project focuses on **architecture and interaction logic**, not art or polish
- All systems are designed to be extendable
- Additional interactables can be added by implementing the relevant interfaces

---

**Author:** Unity Intern Case Candidate  
**Engine:** Unity 6  
**Focus:** Clean code, architecture, interaction systems
