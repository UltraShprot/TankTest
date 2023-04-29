using UnityEngine;

namespace WordOfTanks
{
    public class RotationEnemy : BaseEnemy
    {
        [SerializeField] private Animator animator;
        public override void Update()
        {
            if (Lives > 0)
            {
                agent.SetDestination(player.transform.position);
                animator.StopPlayback();
            }
        }
    }
}
