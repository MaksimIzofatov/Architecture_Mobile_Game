using System;
using UnityEngine;

namespace CodeBase.Enemy
{
    public class Aggro : MonoBehaviour
    {
        public TriggerObserver TriggerObserver;
        public AgentMoveToPlayer Follow;

        private void Start()
        {
            TriggerObserver.TriggerEnter += TriggerEnter;
            TriggerObserver.TriggerExit += TriggerExit;
            
            Follow.enabled = false;
        }

        private void TriggerExit(Collider obj)
        {
            
        }

        private void TriggerEnter(Collider obj)
        {
            
        }
    }
}