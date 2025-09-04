using System;
using CodeBase.Hero;
using UnityEngine;
using UnityEngine.AI;

namespace CodeBase.Enemy
{
    public class AgentMoveToPlayer : MonoBehaviour
    {
        public NavMeshAgent Agent;
        private Transform _heroTransform;

        private void Update()
        {
            if(Vector3.Distance(Agent.destination, transform.position) > 0.1f)
                Agent.destination = _heroTransform.position;
        }
    }
}