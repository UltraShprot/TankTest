using System.Collections.Generic;
using UnityEngine;

namespace WordOfTanks
{
    public class OutOfSceneSpawner : MonoBehaviour
    {
        [SerializeField] private Transform spawnPoint;
        private AbstractFactory _factory;
        [SerializeField] public List<BaseEnemy> EnemiesList = new List<BaseEnemy>();
        private void Update()
        {
           if (EnemiesList.Count < 10)
           {
                ChangeSpawnPointPosition(spawnPoint);
                Spawn(spawnPoint);
           }
        }
        private void Spawn(Transform spawnPoint)
        {
            int rnd = UnityEngine.Random.Range(0, 3);
            switch (rnd)
            {
                case 0:
                    _factory = new EnemyFactory(spawnPoint);
                    _factory.CreateTypeOneObject();
                    break;
                case 1:
                    _factory = new EnemyFactory(spawnPoint);
                    _factory.CreateTypeSecondObject();
                    break;
                case 2:
                    _factory = new EnemyFactory(spawnPoint);
                    _factory.CreateTypeThirdObject();
                    break;
            }
        }
        private void ChangeSpawnPointPosition(Transform spawnPoint)
        {
            spawnPoint.localPosition =new Vector3(0,0,0);
            float rndX = UnityEngine.Random.Range(-35, 35);
            float rndZ = 0;
            int up = UnityEngine.Random.Range(0, 2);
            if (rndX > -27.5f && rndX < 27.5f)
            {
                if (up > 0)
                {
                    rndZ = 20;
                }
                else
                {
                    rndZ = -20;
                }
            }
            else
            {
                rndZ = UnityEngine.Random.Range(-20, 20);
            }
            spawnPoint.localPosition = new Vector3(rndX, 0, rndZ);
        }
    }
}
