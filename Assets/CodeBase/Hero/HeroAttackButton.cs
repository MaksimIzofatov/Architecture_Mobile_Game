using UnityEngine;

namespace CodeBase.Hero
{
    public class HeroAttackButton : MonoBehaviour
    {
        [SerializeField] private HeroAnimator _heroAnimator;

        public void Fire()
        {
            _heroAnimator.PlayAttack();
        }
    }
}