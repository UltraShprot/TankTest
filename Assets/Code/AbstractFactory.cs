using UnityEngine;

namespace WordOfTanks
{
    public abstract class AbstractFactory : MonoBehaviour
    {
        public abstract GameObject CreateTypeOneObject();
        public abstract GameObject CreateTypeSecondObject();
        public abstract GameObject CreateTypeThirdObject();
    }
}
