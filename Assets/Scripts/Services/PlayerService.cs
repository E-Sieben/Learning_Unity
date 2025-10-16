using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    /// <summary>
    ///     Controls a Player
    /// </summary>
    public class PlayerService : MonoBehaviour
    {
        /// <summary>Defines the Input that the User has to take for horizontal movement using Unity's Input System</summary>
        private InputAction _movementInput;

        /// <summary>
        /// Used to initialize the PlayerService by giving it all needed <c>InputActions</c>
        /// </summary>
        /// <param name="movement">Defines the <c>InputAction</c> for horizontal movement</param>
        public void Initialize(InputAction movement)
        {
            _movementInput = movement;
        }

        /// <summary>
        /// Moves horizontally using the pre-defined <c>Input Action</c>
        /// </summary>
        /// <param name="movementSpeed">The Movement Speed of the player</param>
        public void Move(float movementSpeed)
        {
            if (!_movementInput.IsPressed()) return;
            var movementDirection = _movementInput.ReadValue<Vector2>().normalized;
            transform.position += new Vector3(movementDirection.x, 0f, movementDirection.y) * movementSpeed;
        }
    }
}