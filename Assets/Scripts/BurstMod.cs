using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstMod : MonoBehaviour
{
    public Wearpon wearpon;
    public bool isBurst;

    public void Burst()
    {
        isBurst = !isBurst;
        if (isBurst)
        {
            wearpon.bulletsPerShot = 4;
            wearpon.recoilAngle = 5;
            wearpon.reloadTime = 3;
            wearpon.isAutomatic = false;

        }
        if (!isBurst)
        {
            wearpon.reloadTime = 2;
            wearpon.bulletsPerShot = 1;
            wearpon.recoilAngle = 1;
            wearpon.isAutomatic = true;
        }
    }
}
