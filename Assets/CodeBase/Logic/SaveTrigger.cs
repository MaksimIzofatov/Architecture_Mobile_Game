using System;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.PersistentProgress.SaveLoad;
using UnityEngine;

namespace CodeBase.Logic
{
    public class SaveTrigger : MonoBehaviour
    {
        private ISaveLoadService _saveLoadService;

        public BoxCollider Collider;
        private void Start()
        {
            _saveLoadService = AllServices.Container.Single<ISaveLoadService>();
        }

        private void OnTriggerEnter(Collider other)
        {
            _saveLoadService.SaveProgress();
            Debug.Log("Save");
            gameObject.SetActive(false);
        }

        private void OnDrawGizmos()
        {
            if(!Collider) return;
            
            Gizmos.color = new Color(130, 200, 130, 150f);
            Gizmos.DrawCube(transform.position + Collider.center, Collider.size);
        }
    }
}