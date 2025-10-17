using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    public class MovementService
    {
        private readonly NavMeshAgent _agent;

        public MovementService(NavMeshAgent agent)
        {
            _agent = agent;
        }

        public void GoTo(Vector3 goal)
        {
            _agent.destination = goal;
        }
    }
}