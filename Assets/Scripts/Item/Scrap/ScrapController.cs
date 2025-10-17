using System;
using Enemy;
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
        /// <summary>Defines the minimum Speed needed to kill a enemy</summary>
        [SerializeField] private float minKillSpeed = 3f;
        /// <summary>Stores the Targeted Player for position and Magnet Strength</summary>
        [SerializeField] private GameObject targetPlayer;

        /// <summary>Stores the Data of the Player for Phase Management and Behaviour</summary>
        [SerializeField] private PlayerData playerData;

        /// <summary>Stores the Rigidbody of the Scrap for movement</summary>
        private Rigidbody _rigidbody;

        /// <summary>
        ///     Start on Awake and initializes the Player Controller, Player Transform and the Rigidbody
        /// </summary>
        private void Awake()
        {
            if (targetPlayer.IsUnityNull()) throw new Exception("Scrap requires a Target Player");
            _rigidbody = GetComponent<Rigidbody>();
        }

        /// <summary>
        ///     Starts on a fixed Update and Moves the Scrap to the targetPlayer
        /// </summary>
        private void FixedUpdate()
        {
            if (!playerData.isReleased) return;
            _rigidbody.useGravity = true;
            var targetPosition = targetPlayer.transform.position;
            var currentPosition = transform.position;
            // Move Scrap
            MovementService.TargetALocation(
                _rigidbody,
                currentPosition,
                targetPosition,
                playerData.stats.magnetStrength
            );
            // Kill Object when in Range
            if (!((currentPosition - targetPosition).magnitude < playerData.stats.pickupRange)) return;
            playerData.items.scraps += 1;
            Destroy(gameObject);
        }

        private void OnCollisionEnter(Collision other)
        {
            if (_rigidbody.linearVelocity.magnitude < minKillSpeed) return;
            if (!other.gameObject.CompareTag("Enemy")) return;
            playerData.items.scraps += other.gameObject.GetComponent<EnemyController>().reward;
            Destroy(other.gameObject);
        }
    }
}