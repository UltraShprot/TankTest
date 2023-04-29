using System;
using System.Collections;
using UnityEngine;

namespace WordOfTanks
{
    public class InputSystem : MonoBehaviour
    {
        [SerializeField] GameObject controllableObject;
        private IControllable controlable;
        private  IShoot shootControlable;
        private IWeaponChanger changeWeapon;
        float axisX;
        float axisY;
        bool shoot;

        private void Start()
        {
            controlable = controllableObject.GetComponent<IControllable>();
            shootControlable = controllableObject.GetComponent<IShoot>();
            changeWeapon = controllableObject.GetComponent<IWeaponChanger>();
        }
        void Update()
        {
            axisY = Input.GetAxis("Vertical");
            if (axisY >= 0)
            {
                axisX += Input.GetAxis("Horizontal");
            }
            else
            {
                axisX -= Input.GetAxis("Horizontal");
            }
            shoot = Input.GetKey(KeyCode.X);
            if (axisX != 0 || axisY != 0)
            {
                controlable.Move(axisX, axisY);
            }
            if (shoot)
            {
                shootControlable.Shoot();
            }
            if (Input.GetKeyDown(KeyCode.E)) 
            {
                changeWeapon.Change(0);
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                changeWeapon.Change(-1);
            }
        }
    }
}
