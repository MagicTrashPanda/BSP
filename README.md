# BSP - Basic Script Package

The **Basic Script Package (BSP)** is a Unity package designed to streamline development by providing reusable and modular scripts for common gameplay mechanics. This package aims to reduce coding time and improve productivity for Unity developers.

## Features

- **Movement3d**: A robust 3D movement system with support for jumping, sprinting, and speed smoothing.
- **FollowCam**: A simple camera follow script to keep the camera focused on the player.
- **AlwaysUpSprite**: Ensures a sprite always faces upward.

## Installation

1. Clone or download this repository into your Unity project's `Packages` folder.
2. Ensure your Unity version is compatible with the package (minimum version: `6000.0` as per `package.json`).
3. Add the package to your Unity project via the Unity Package Manager.

## Scripts Overview



### 1. Movement3d
A 3D movement system for player-controlled characters.

**Key Features:**
- Directional movement (WASD).
- Jumping and sprinting support.
- Speed smoothing for realistic acceleration and deceleration.

**Usage:**
Attach the `Movement3d` script to a player object with a `Rigidbody` component.

---

### 2. FollowCam
A script to make the camera follow a player object.

**Key Features:**
- Adjustable camera distance.
- Smooth player tracking.

**Usage:**
Attach the `FollowCam` script to a camera object and assign the `player` and `cam` transforms.

---

### 3. AlwaysUpSprite
A utility script to keep a sprite always facing upward.

**Usage:**
Attach the `AlwaysUpSprite` script to any sprite object.

---

## How to Use

1. Import the package into your Unity project.
2. Drag and drop the desired script onto the relevant GameObject.
3. Configure the script's public variables in the Unity Inspector.

## Contributing

Contributions are welcome! If you have ideas for new features or improvements, feel free to submit a pull request or open an issue.