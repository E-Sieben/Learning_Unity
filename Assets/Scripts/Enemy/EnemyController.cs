using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private Transform playerTransform;
        [SerializeField] private float noticeDistance = 3f;
        [SerializeField] private Light screenLight;
        public int reward = 1;

        /// <summary>Defines the minimum Speed needed to kill an enemy</summary>
        public float minKillSpeed = 3f; // Todo: SO - Enemy?

        private MovementService _movementService;

        private void Start()
        {
            _movementService = new MovementService(GetComponent<NavMeshAgent>());
        }

        private void FixedUpdate()
        {
            var distance = playerTransform.position - transform.position;
            if (distance.magnitude > noticeDistance)
            {
                screenLight.color = Color.green;
                return;
            }

            screenLight.color = Color.red;
            _movementService.GoTo(playerTransform.position);
        }

        private void OnCollisionEnter(Collision other)
        {
            if (!other.gameObject.CompareTag("Enemy")) return;
            Debug.Log("Game Over!"); //TODO: Implement Game Over Screen
        }
    }
}