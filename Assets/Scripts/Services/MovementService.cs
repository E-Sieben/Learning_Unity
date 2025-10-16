using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    /// <summary>
    ///     Controls a Player
    /// </summary>
    public class MovementService
    {
        /// <summary>Defines the Input that the User has to take for horizontal movement using Unity's Input System</summary>
        private readonly InputAction _movementInput;

        /// <summary>Defines the Players Transform to use for Movement</summary>
        private readonly Transform _playerTransform;

        /// <summary>
        ///     Used to initialize the MovementService by giving it all needed <c>InputActions</c>
        /// </summary>
        /// <param name="movement">Defines the <c>InputAction</c> for horizontal movement</param>
        /// <param name="playerTransform">Defines the transform of the player used for movement</param>
        /// <param name="animationService">Defines an Animation Service to use</param>
        public MovementService(InputAction movement, Transform playerTransform)
        {
            _playerTransform = playerTransform;
            _movementInput = movement;
        }

        /// <summary>
        ///     Moves horizontally using the pre-defined <c>Input Action</c>
        /// </summary>
        /// <param name="movementSpeed">Maximum Movement Speed of the player</param>
        /// <param name="rotationSpeed">Maximum Rotation Speed of the player</param>
        public bool Move(float movementSpeed, float rotationSpeed)
        {
            if (!_movementInput.IsPressed()) return false;
            var movementDirection = _movementInput.ReadValue<Vector2>().normalized;
            var movementDirection3D = new Vector3(movementDirection.x, 0f, movementDirection.y);
            _playerTransform.position += movementDirection3D * movementSpeed;
            _playerTransform.forward = Vector3.Slerp(_playerTransform.forward, movementDirection3D, rotationSpeed);
            return true;
        }
    }
}