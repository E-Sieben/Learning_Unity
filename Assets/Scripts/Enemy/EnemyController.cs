using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private Transform playerTransform;
        public int reward = 1;

        /// <summary>Defines the minimum Speed needed to kill a enemy</summary>
        public float minKillSpeed = 3f;

        private MovementService _movementService;

        private void Start()
        {
            _movementService = new MovementService(GetComponent<NavMeshAgent>());
        }

        private void FixedUpdate()
        {
            _movementService.GoTo(playerTransform.position);
        }
    }
}