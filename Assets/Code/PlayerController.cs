using UnityEngine;

namespace WordOfTanks
{
    public class PlayerController : MonoBehaviour, IControllable
    {
        [SerializeField] CharacterController controller;
        [SerializeField] float speed;
        [SerializeField] float rotationSpeed;
        private Quaternion startRotation;
        void Start()
        {
            startRotation= transform.rotation;
        }
        public void Move(float axisX, float axisZ)
        {
            var rotateY = Quaternion.AngleAxis(axisX * rotationSpeed, Vector3.up);
            transform.rotation = rotateY * startRotation;
            Vector3 movement = -transform.right * axisZ;
            controller.Move(movement * speed * Time.deltaTime);
        }
    }

}
