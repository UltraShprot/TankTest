using UnityEngine;

namespace WordOfTanks
{
    public class PlayerShootController : MonoBehaviour, IShoot
    {
        [SerializeField] Transform shootPoint1;
        [SerializeField] public GameObject currentBulletPrefab;
        [SerializeField] public float fireRate = 2;
        float timer;

        public void Shoot()
        {
            if (timer > fireRate)
            {
                Instantiate(currentBulletPrefab, shootPoint1.position, shootPoint1.rotation);
                timer= 0;
            }
        }
        public void Update()
        {
            timer += Time.deltaTime;
        }
    }
}
