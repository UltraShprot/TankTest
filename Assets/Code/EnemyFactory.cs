using UnityEngine;

namespace WordOfTanks
{
    public class EnemyFactory : AbstractFactory
    {
        private Transform _spawnPoint;
        public EnemyFactory(Transform spawnPoint)
        {
            _spawnPoint = spawnPoint;
        }
        public override GameObject CreateTypeOneObject()
        {
            var _object = Resources.Load<GameObject>("EnemyType1");
            return Instantiate(_object, _spawnPoint.position, _spawnPoint.rotation);
        }

        public override GameObject CreateTypeSecondObject()
        {
            var _object = Resources.Load<GameObject>("EnemyType2");
            return Instantiate(_object, _spawnPoint.position, _spawnPoint.rotation);
        }

        public override GameObject CreateTypeThirdObject()
        {
            var _object = Resources.Load<GameObject>("EnemyType3");
            return Instantiate(_object, _spawnPoint.position, _spawnPoint.rotation);
        }
    }
}
