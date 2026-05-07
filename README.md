# Delivery Driver (2D Top-down Simulation)

## Project Overview
**Delivery Driver** is a 2D top-down simulation game developed with Unity. The project focuses on implementing robust 2D physics, responsive vehicle handling, and state-driven gameplay mechanics using optimized C# scripting.

- **Genre:** 2D Top-down / Casual Simulation.
- **Engine:** Unity 2021.3+.
- **Language:** C# Scripting.

---

## 1. Software Architecture
The project is built upon core Object-Oriented Programming (OOP) principles to ensure scalability and maintainability:

* **Encapsulation:** Utilizes the `[SerializeField]` attribute to protect internal data while exposing critical variables like speed and sensitivity to the Unity Inspector. This allows for rapid iteration by Game Designers without modifying the source code.
* **Modularity:** Logic is decoupled into dedicated scripts:
    * `Driver.cs`: Handles locomotion and steering.
    * `Delivery.cs`: Manages pickup/delivery state and inventory logic.
    * `FollowCamera.cs`: Controls the smooth viewport tracking system.

---

## 2. Technical Implementation

### 2.1 Physics 2D & Collision Handling
The game leverages Unity's 2D Physics engine to create a tactile driving experience:
* **Physics Components:** A combination of `Rigidbody 2D`, `BoxCollider2D`, and `CircleCollider2D` is used on the vehicle and environment objects like houses, trees, and rocks to prevent mesh clipping and handle physical boundaries.
* **Collision Detection (OnCollisionEnter2D):**
    * **Implementation:** Triggered when the vehicle bumps into static obstacles.
    * **Logic:** Reverts `moveSpeed` to a `slowSpeed` value, acting as a gameplay penalty for reckless driving.
* **Trigger Events (OnTriggerEnter2D):**
    * **Implementation:** Utilizes specialized Tags such as `Package`, `Customer`, and `Speed up` for non-physical interactions.
    * **Efficiency:** Processes pickup/delivery logic and speed boosts seamlessly without interrupting the vehicle's momentum.

### 2.2 Scripting Lifecycle & Input Management
Optimized script lifecycle management ensures high performance and a jitter-free experience:
* **Input System (Update Lifecycle):** Captures real-time directional input via `Input.GetAxis("Horizontal/Vertical")`, providing instantaneous response to player commands.
* **Smooth Camera Tracking (LateUpdate):** Camera positioning is handled in `LateUpdate()` to ensure the vehicle has completed its transformation for the frame, effectively eliminating camera jitter.
* **Framerate Independence:** Calculations for movement and steering amounts are scaled by `Time.deltaTime` to guarantee consistent speed across varying hardware configurations.

### 2.3 Visual Feedback & State Management
User experience is enhanced through clear visual cues:
* **State-Driven Sprite Swapping:** Employs a `hasPackage` boolean to toggle between the default car sprite and the "carrying" sprite via the `SpriteRenderer`.
* **Object Lifecycle Management:** Implements a `destroyDelay` parameter in the `Destroy()` method to provide a natural transition when items are removed from the scene.

### 2.4 Resource Optimization via Prefabs
* **Prefabricated Systems:** Essential game objects like Packages and Obstacles are organized as Prefabs.
* **Workflow Efficiency:** Enables rapid Level Design. Updates to a base Prefab are automatically propagated to all instances across the scene, ensuring global consistency and memory efficiency.

---

## 3. Source Control & Clean Code Standards

| Category | Standard Applied |
| :--- | :--- |
| **Naming Conventions** | Descriptive naming like `steerSpeed` and `moveSpeed`. PascalCase for Methods and camelCase for private variables. |
| **Directory Structure** | Hierarchical organization: `Scripts/`, `Scenes/`, and `Sprites/Vehicles/`. |
| **Source Control** | Managed via Git/GitHub with a clear `.gitignore` for Unity to maintain a clean repository. |
