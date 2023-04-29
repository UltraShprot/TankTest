using UnityEngine;

namespace WordOfTanks
{
    public class FastEnemy : BaseEnemy
    {
        public override void Update()
        {
            if (Lives > 0)
            {
                agent.SetDestination(player.transform.position);
                Vector3 lookAt = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
                transform.LookAt(lookAt);
            }
        }
    }
}
