using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    /// <summary>
    ///     Manages a Player
    /// </summary>
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerData playerData;

        // Animation
        /// <summary>Defines the Service to Control Animations</summary>
        private AnimationService _animationService;

        /// <summary>Defines the Service to Control the Player itself</summary>
        private MovementService _movementService;

        /// <summary>
        ///     Inits the user inputs and the Player Service
        /// </summary>
        private void Awake()
        {
            playerData.isReleased = false;
            // Movement
            _movementService =
                new MovementService(
                    InputSystem.actions.FindAction("move"),
                    transform,
                    GetComponent<CapsuleCollider>().radius,
                    GetComponent<CapsuleCollider>().height,
                    playerData.stats
                );
            // Animation
            _animationService = new AnimationService(GetComponentInChildren<Animator>());
        }

        /// <summary>
        ///     Updates the Player on a Fixed Event in sync with the Engine
        /// </summary>
        private void FixedUpdate()
        {
            if (_movementService.Move())
                _animationService.Walk();
            else
                _animationService.Idle();
        }
    }
}