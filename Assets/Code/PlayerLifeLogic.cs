using System;
using UnityEngine;

namespace WordOfTanks
{
    public class PlayerLifeLogic : MonoBehaviour
    {
        [SerializeField] MeshCollider mesh;
        [SerializeField] MeshRenderer renderer;
        [SerializeField] PlayerShootController shootController;
        [SerializeField] PlayerController controller;
        public event Action HealthChanged;
        [SerializeField][Range(0, 1)] public float armor;
        [SerializeField] float health;
        [SerializeField] float startHealth;
        [SerializeField] ChangeWeapon changer;
        [SerializeField] CharacterController characterController;
        public float Health
        {
            get => health;
            set 
            {
                health += value;
                if (health < 0)
                {
                    health = 0;
                }
                HealthChanged?.Invoke(); 
            }
        }
        private void OnEnable()
        {
            HealthChanged += LifeLogic;
        }
        private void Start()
        {
            health = startHealth;
        }
        private void LifeLogic()
        {
          if (Health == 0)
          {
              mesh.enabled= false;
              renderer.enabled= false;
              shootController.enabled= false;
              controller.enabled= false;
              changer.enabled= false;
                characterController.enabled= false;
          }
        }
        private void OnDisable()
        {
            HealthChanged -= LifeLogic;
        }
    }
}
