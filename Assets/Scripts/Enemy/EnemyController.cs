using System;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private Transform playerTransform;
        public int reward = 1;
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