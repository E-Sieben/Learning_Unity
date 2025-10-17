using System;
using Player;
using Unity.VisualScripting;
using UnityEngine;

namespace Scrap
{
    /// <summary>
    ///     Controls the Scraps Behaviour
    /// </summary>
    [RequireComponent(typeof(Rigidbody))]
    public class ScrapController : MonoBehaviour
    {
        /// <summary>Stores the Targeted Player for position and Magnet Strength</summary>
        [SerializeField] private GameObject targetPlayer;

        /// <summary>Stores the Player Controller in order to get the Magnet Strength</summary>
        private PlayerController _playerController;

        /// <summary>Stores the Rigidbody of the Scrap for movement</summary>
        private Rigidbody _rigidbody;

        /// <summary>
        ///     Start on Awake and initializes the Player Controller, Player Transform and the Rigidbody
        /// </summary>
        private void Awake()
        {
            if (targetPlayer.IsUnityNull()) throw new Exception("Scrap requires a Target Player");
            _rigidbody = GetComponent<Rigidbody>();
            _playerController = targetPlayer.GetComponent<PlayerController>();
        }

        /// <summary>
        ///     Starts on a fixed Update and Moves the Scrap to the targetPlayer
        /// </summary>
        private void FixedUpdate()
        {
            var targetPosition = targetPlayer.transform.position;
            var currentPosition = transform.position;
            // Move Scrap
            MovementService.TargetALocation(
                _rigidbody,
                currentPosition,
                targetPosition,
                _playerController.magnetStrengthPub
            );

            // Kill Object when in Range
            if (!((currentPosition - targetPosition).magnitude < _playerController.pickupRangePub)) return;
            Destroy(gameObject);
        }
    }
}