using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    /// <summary>
    ///     Manages a Player
    /// </summary>
    public class PlayerController : MonoBehaviour
    {
        /// <summary>Defines the Movement Speed of the Player as a Floating Point Number</summary>
        [field: SerializeField]
        private float movementSpeed { get; set; } = 0.2f;

        /// <summary>Defines the Rotation Speed of the Player as a Floating Point Number</summary>
        [field: SerializeField]
        private float rotationSpeed { get; set; } = 0.2f;

        /// <summary>Defines the Input that the User has to take for horizontal movement using Unity's Input System</summary>
        private InputAction _movementInput;

        /// <summary>Defines the Service to Control the Player itself</summary>
        private PlayerService _playerService;

        /// <summary>
        ///     Inits the user inputs and the Player Service
        /// </summary>
        private void Awake()
        {
            _movementInput = InputSystem.actions.FindAction("move");
            _playerService = gameObject.AddComponent<PlayerService>();
            _playerService.Initialize(_movementInput);
        }

        /// <summary>
        ///     Updates the Player on a Fixed Event in sync with the Engine
        /// </summary>
        private void FixedUpdate()
        {
            _playerService.Move(movementSpeed, rotationSpeed);
        }
    }
}