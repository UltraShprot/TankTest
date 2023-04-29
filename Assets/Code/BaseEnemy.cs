using System;
using UnityEngine;
using UnityEngine.AI;

namespace WordOfTanks
{
    public abstract class BaseEnemy: MonoBehaviour
    {
        public event Action livesChanged;
        [SerializeField] protected float speed;
        [SerializeField] private float damage;
        [SerializeField] private float startLives = 5;
        [SerializeField] private float lives;
        [Range(0, 1)] public float armor;
        private OutOfSceneSpawner spawner;
        [SerializeField] private string nameOfMySpawner = "EnemySpawner";
        [SerializeField] private Collider collider;
        [SerializeField] private MeshRenderer renderer;
        protected NavMeshAgent agent;
        protected GameObject player;

        public float Lives 
        {
            get => lives;
            set 
            {
                lives += value;
                if (lives < 0) {lives= 0;}
                livesChanged.Invoke(); 
            }
        }


        private void OnEnable()
        {
            livesChanged += LifeLogic;
        }
        private void Start()
        {
            spawner = GameObject.Find(nameOfMySpawner).GetComponent<OutOfSceneSpawner>();
            spawner.EnemiesList.Add(this);
            Lives = startLives;
            agent = GetComponent<NavMeshAgent>();
            agent.speed = speed;
            player = GameObject.FindGameObjectWithTag("Player");
        }
        public void LifeLogic()
        {
            if (Lives == 0)
            {
                spawner.EnemiesList.Remove(this);
                collider.enabled = false;
                renderer.enabled = false;
                agent.speed = 0;
                Destroy(this.gameObject, 10f);
            }
        }
        public abstract void Update();

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                other.gameObject.GetComponent<PlayerLifeLogic>().Health = -damage * other.gameObject.GetComponent<PlayerLifeLogic>().armor;
                Debug.Log("soujfhvdf");
            }
        }
        private void OnDisable()
        {
            livesChanged -= LifeLogic;
        }
    }
}
