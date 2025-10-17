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

        private readonly float _playerHeight;

        private readonly float _playerRadius;

        /// <summary>Defines the Players Transform to use for Movement</summary>
        private readonly Transform _playerTransform;

        /// <summary>
        ///     Used to initialize the MovementService by giving it all needed <c>InputActions</c>
        /// </summary>
        /// <param name="movement">Defines the <c>InputAction</c> for horizontal movement</param>
        /// <param name="playerTransform">Defines the transform of the player used for movement</param>
        /// <param name="playerRadius"></param>
        /// <param name="playerHeight"></param>
        public MovementService(InputAction movement, Transform playerTransform, float playerRadius, float playerHeight)
        {
            _playerTransform = playerTransform;
            _movementInput = movement;
            _playerRadius = playerRadius;
            _playerHeight = playerHeight;
        }

        /// <summary>
        ///     Moves horizontally using the pre-defined <c>Input Action</c>
        /// </summary>
        /// <param name="movementSpeed">Maximum Movement Speed of the player</param>
        /// <param name="rotationSpeed">Maximum Rotation Speed of the player</param>
        public bool Move(float movementSpeed, float rotationSpeed)
        {
            if (!_movementInput.IsPressed()) return false;
            var movementDirection = _movementInput.ReadValue<Vector2>();
            var movementDirection3D = new Vector3(movementDirection.x, 0f, movementDirection.y);
            if (Physics.CapsuleCast( // Checks whether Character is stuck in Wall
                    _playerTransform.position + new Vector3(0, 1, 0),
                    _playerTransform.position + Vector3.up * _playerHeight,
                    _playerRadius / 2,
                    movementDirection3D,
                    movementSpeed)
               ) return false;
            _playerTransform.position += movementDirection3D * movementSpeed;
            _playerTransform.forward = Vector3.Slerp(_playerTransform.forward, movementDirection3D, rotationSpeed);
            return true;
        }
    }
}