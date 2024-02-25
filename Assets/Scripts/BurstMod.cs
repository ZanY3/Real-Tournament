using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstMod : MonoBehaviour
{

    public Weapon weapon;
    public bool isBursting;

    public void Burst()
    {
        isBursting = !isBursting;

        if (isBursting)
        {
            weapon.bulletsPerShot = 2;
            weapon.spreadAngle = 1.5f;
            weapon.isAutomatic = false;
            weapon.fireInterval = 0.5f;
        }
        else
        {
            weapon.bulletsPerShot = 1;
            weapon.spreadAngle = 2;
            weapon.isAutomatic = true;
        }
    }
}
