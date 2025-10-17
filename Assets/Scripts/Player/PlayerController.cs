using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    /// <summary>
    ///     Manages a Player
    /// </summary>
    public class PlayerController : MonoBehaviour
    {
        // Movement
        /// <summary>Defines the Movement Speed of the Player as a Floating Point Number</summary>
        [field: SerializeField]
        private float movementSpeed { get; set; } = 0.2f;

        /// <summary>Defines the Rotation Speed of the Player as a Floating Point Number</summary>
        [field: SerializeField]
        private float rotationSpeed { get; set; } = 0.2f;

        /// <summary>Defines the Strength of the Players Magnet</summary>
        [SerializeField] private float magnetStrength = 0.5f;

        // Animation
        /// <summary>Defines the Service to Control Animations</summary>
        private AnimationService _animationService;

        /// <summary>Defines the Service to Control the Player itself</summary>
        private MovementService _movementService;

        /// <summary>Public accessor for the <c>magnetStrength</c></summary>
        public float magnetStrengthPub => magnetStrength;

        /// <summary>
        ///     Inits the user inputs and the Player Service
        /// </summary>
        private void Awake()
        {
            // Movement
            _movementService =
                new MovementService(InputSystem.actions.FindAction("move"), transform);
            // Animation
            _animationService = new AnimationService(GetComponentInChildren<Animator>());
        }

        /// <summary>
        ///     Updates the Player on a Fixed Event in sync with the Engine
        /// </summary>
        private void FixedUpdate()
        {
            if (_movementService.Move(movementSpeed, rotationSpeed))
                _animationService.Walk();
            else
                _animationService.Idle();
        }
    }
}