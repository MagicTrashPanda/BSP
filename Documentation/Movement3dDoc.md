# Movement3d Script Documentation

The `Movement3d` script provides a robust 3D movement system for player-controlled characters in Unity. It supports directional movement, jumping, sprinting, and speed smoothing for realistic acceleration and deceleration.

---

## Features

- **Directional Movement**: Move the player using WASD keys and arrow keys.
- **Jumping**: Allows the player to jump when grounded.
- **Sprinting**: Increases movement speed when the sprint key is held.
- **Speed Smoothing**: Smooth acceleration and deceleration for more realistic movement.

---

## Public Variables

### Modules
- `jumpEnabled` (bool): Enables or disables jumping functionality.
- `sprintEnabled` (bool): Enables or disables sprinting functionality.
- `speedSmoothingEnabled` (bool): Enables or disables speed smoothing.

### Directional Movement
- `forward` (float): The forward movement input value.
- `horizontal` (float): The horizontal movement input value.
- `isMoving` (bool): Indicates whether the player is currently moving.

### Speed Statistics
- `baseSpeed` (float): The base movement speed of the player. Default is `5`.
- `targetSpeed` (float): The calculated target speed based on movement modifiers.

### Movement Modifiers
- `speedMultiplier` (float): A multiplier for movement speed.
- `inertiaMultiplier` (float): Controls the rate of acceleration and deceleration. Default is `1`.
- `jumpForce` (float): The force applied when jumping. Default is `5f`.
- `sprintSpeedMultiplier` (float): A multiplier for sprinting speed. Default is `1f`.
- `sprintPressed` (bool): Indicates whether the sprint key is currently pressed.

### Position Checks
- `grounded` (bool): Indicates whether the player is grounded.
- `mask` (LayerMask): The layer mask used for ground detection.

---

## Methods

### Unity Functions
- `Awake()`: Initializes the `Rigidbody` component.
- `Update()`: Handles input, movement, and optional features like jumping, sprinting, and speed smoothing.

### Core Movement
- `HandleInput()`: Processes player input for movement.
- `SpeedCalculation(float directionalSpeed, string direction)`: Calculates the target speed and applies it to the `Rigidbody`.
- `ApplyMovement()`: Applies movement based on input and speed calculations.

### Optional Movement
- `HandleJump()`: Handles jumping logic when the player is grounded and the jump key is pressed.
- `HandleSprint()`: Handles sprinting logic when the sprint key is held.
- `SpeedSmoothing()`: Smooths acceleration and deceleration based on movement state.

### Checks
- `GetGrounded()`: Uses raycasts to determine if the player is grounded.

---

## Usage

1. Attach the `Movement3d` script to a player GameObject with a `Rigidbody` component.
2. Configure the public variables in the Unity Inspector:
   - Enable or disable jumping, sprinting, and speed smoothing as needed.
   - Adjust movement modifiers like `baseSpeed`, `jumpForce`, and `inertiaMultiplier`.
3. Ensure the `mask` variable is set to the appropriate ground layer(s) for ground detection.

---

## Example Setup

1. Create a new GameObject in your Unity scene and name it `Player`.
2. Add a `Rigidbody` component to the `Player` GameObject.
3. Attach the `Movement3d` script to the `Player` GameObject.
4. Configure the script's public variables in the Inspector:
   - Set `jumpEnabled` to `true` to allow jumping.
   - Set `sprintEnabled` to `true` to allow sprinting.
   - Set `speedSmoothingEnabled` to `true` to allow speed smoothing.
   - Adjust `baseSpeed` to control the player's movement speed.

---

## Key Bindings

- **W**: Move forward.
- **A**: Move left.
- **S**: Move backward.
- **D**: Move right.
- **Space**: Jump (if `jumpEnabled` is true).
- **Left Shift**: Sprint (if `sprintEnabled` is true).

---

## Troubleshooting

- **Player is not moving**:
  - Ensure the `Rigidbody` component is attached to the player GameObject.
  - Check that the `Movement3d` script is enabled.
- **Jumping is not working**:
  - Verify that `jumpEnabled` is set to `true`.
  - Ensure the `mask` variable is set to the correct ground layer(s).
- **Sprinting is not working**:
  - Verify that `sprintEnabled` is set to `true`.

---

## Performance Tips

- Use `FixedUpdate` instead of `Update` for physics-related calculations if needed.

---

## Extending the Script

To add new movement mechanics, extend the `Movement3d` class and override or add new methods. For example, you could add crouching or dashing functionality.

---

## Author

Developed by **Lucas Rachlinski**  
Email: [cmc5039@gmail.com](mailto:cmc5039@gmail.com)