using UnityEngine;

namespace CodeBase.StaticData
{
    [CreateAssetMenu(fileName = "MonsterData", menuName = "StaticData/Monster")]
    public class MonsterStaticData : ScriptableObject
    {
        public MonsterTypeId MonsterTypeId;    
        [Range(1, 100)]
        public int Hp;
        [Range(1f, 30f)]
        public int Damage;
        [Range(0.5f, 1f)]
        public float EffectiveDistance = 0.6f;
        [Range(0.5f, 1f)]
        public float Cleavage;
        [Range(1f, 10f)]
        public float MoveSpeed = 5f;
        
        public GameObject Prefab;
    }
}