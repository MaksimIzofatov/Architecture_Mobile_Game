using CodeBase.Infrastructure.Factory;
using UnityEngine;
using UnityEngine.AI;

namespace CodeBase.Enemy
{
    public class AgentMoveToPlayer : Follow
    {
        public NavMeshAgent Agent;

        private Transform _heroTransform;

        public void Constructor(Transform heroTransform) => 
            _heroTransform = heroTransform;

        private void Update() => 
            SetDestinationForAgent();

        private void SetDestinationForAgent()
        {
            if(_heroTransform)
                Agent.destination = _heroTransform.position + new Vector3(0.5f, 0, 0.5f);
        }
    }
}