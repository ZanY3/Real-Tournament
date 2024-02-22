using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wearpon : MonoBehaviour
{
    public GameObject bulletPrefab;

    public int ammo;
    public int maxAmmo = 5; // in clip
    public int allAmmo = 25;
    public bool isReloading;
    public bool isAutomatic;
    public float fireInterval = 0.1f;
    public float fireCooldown;
    public float reloadTime = 2;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            // manual shooting
            if (!isAutomatic && Input.GetKeyDown(KeyCode.Mouse0))
            {
                Shoot();
            }
        // automatic shooting
        if (isAutomatic && Input.GetKey(KeyCode.Mouse0))
        {
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
        fireCooldown -= Time.deltaTime;
    }

    void Shoot()
    {
        if (isReloading) return;
        if (ammo <= 0)
        {
            if(allAmmo > 0)
            {
                Reload();
                Instantiate(bulletPrefab, transform.position, transform.rotation);
                return;
            }
        }
        if (fireCooldown > 0) return;

        ammo--;
        fireCooldown = fireInterval;
        if(allAmmo > 0)
        {
            Instantiate(bulletPrefab, transform.position, transform.rotation);
        }
    }

    async void Reload()
    {
        if (ammo == 0 && allAmmo == 0) return;
        if (ammo == maxAmmo) return;
        if (isReloading) return;

        isReloading = true;

        print("Reloading...");
        await new WaitForSeconds(reloadTime);
        print("Reloaded!");

        
        isReloading = false;
        if(ammo <= 0)
        {
            allAmmo -= maxAmmo;
        }
        if (ammo > 0)
        {
            allAmmo -= maxAmmo - ammo;
        }
        ammo = maxAmmo;
        
    }
}
