using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Services;
using UnityEngine;

namespace CodeBase.Enemy
{
    public class RotateToHero : Follow
    {
        public float Speed;
        
        private Vector3 _positionToLook;
        private Transform _heroTransform;

        public void Constructor(Transform heroTransform) => 
            _heroTransform = heroTransform;
       
        private void Update()
        {
            if (Initialized())
            {
                RotateTowardsHero();
            }
        }
        
        private void RotateTowardsHero()
        {
            UpdatePositionToLookAt();
            
            transform.rotation = SmoothedRotation(transform.rotation, _positionToLook);
        }

        private void UpdatePositionToLookAt()
        {
            Vector3 positionDiff = _heroTransform.position - transform.position;
            _positionToLook = new Vector3(positionDiff.x, transform.position.y, positionDiff.z);    
        }

        private Quaternion SmoothedRotation(Quaternion rotation, Vector3 positionToLook) => 
            Quaternion.Lerp(rotation, TargetToLook(positionToLook), SpeedFactor());

        private Quaternion TargetToLook(Vector3 positionToLook) => 
            Quaternion.LookRotation(positionToLook);

        private float SpeedFactor() => 
            Speed * Time.deltaTime;


        private bool Initialized() => 
            _heroTransform != null;
    }
}