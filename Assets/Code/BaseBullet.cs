using UnityEngine;

namespace WordOfTanks
{
    public class BaseBullet: MonoBehaviour
    {
        [SerializeField] Collider collider;
        [SerializeField] MeshRenderer renderer;
        [SerializeField] Rigidbody rb;
        [SerializeField] float speed;
        [SerializeField] float damage = 1;
        private void Start()
        {
            Destroy(this.gameObject, 15f);
        }
        private void FixedUpdate()
        {
            rb.velocity= -transform.right * speed;
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                other.GetComponent<BaseEnemy>().Lives = -damage * other.GetComponent<BaseEnemy>().armor;
                collider.enabled = false;
                renderer.enabled= false;
                Destroy(this.gameObject, 5f);
            }
            if (other.gameObject.CompareTag("Collusion"))
            {
                collider.enabled = false;
                renderer.enabled = false;
                Destroy(this.gameObject, 5f);
            }
        }

    }
}
