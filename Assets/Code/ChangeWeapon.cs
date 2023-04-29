using System.Collections.Generic;
using UnityEngine;

namespace WordOfTanks
{
    public class ChangeWeapon: MonoBehaviour , IWeaponChanger
    {
        [SerializeField] PlayerShootController shootController;
        [SerializeField] GameObject[] weaponBulletArray;
        [SerializeField] GameObject[] weaponModelArray;
        [SerializeField] float[] fireRate;
        int value;
        public void Start()
        {
            shootController.currentBulletPrefab= weaponBulletArray[0];
            weaponModelArray[0].SetActive(true);
            shootController.fireRate = fireRate[0];
        }
        public void Change(int change)
        {
            if (change == 0)
            {
                if (value == weaponBulletArray.Length - 1)
                {
                    value = 0;
                }
                else
                {
                    value += 1;
                }
                shootController.currentBulletPrefab = weaponBulletArray[value];
                shootController.fireRate = fireRate[value];
                ChangeModel(value);
            }
            else
            {
                if (value == 0)
                {
                    value = weaponBulletArray.Length - 1;
                }
                else
                {
                    value -= 1;
                }
                shootController.currentBulletPrefab = weaponBulletArray[value];
                shootController.fireRate = fireRate[value];
                ChangeModel(value);
            }
        }
        public void ChangeModel(int value)
        {
            foreach (GameObject a in weaponModelArray)
            {
                a.SetActive(false);
            }
            weaponModelArray[value].SetActive(true);
        }
        public void OnDisable()
        {
            foreach (GameObject a in weaponModelArray)
            {
                a.SetActive(false);
            }
        }
    }
}
