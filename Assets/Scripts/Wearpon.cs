using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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
    public float bulletsPerShot = 1;
    public float recoilAngle = 5;

    public UnityEvent onRightClick;
    public UnityEvent onShoot;
    public UnityEvent onReload;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            onRightClick.Invoke();
        }

        if (ammo <= 0)
        {
            ammo = 0;
        }
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

    public void Shoot()
    {
        if (isReloading) return;
        if (ammo <= 0)
        {
            if(allAmmo > 0)
            {
                Reload();
                return;
            }
        }
        if (fireCooldown > 0) return;
        onShoot.Invoke();
        ammo--;
        fireCooldown = fireInterval;
        for (int i = 0; i < bulletsPerShot; i++)
        {
            if(ammo > 0)
            {
                var bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
                var offsetX = Random.Range(-recoilAngle, recoilAngle);
                var offsetY = Random.Range(-recoilAngle, recoilAngle);
                bullet.transform.eulerAngles += new Vector3(offsetX, offsetY , 0);

            }
        }
    }

    async void Reload()
    {
        if (ammo == 0 && allAmmo == 0) return;
        if (ammo == maxAmmo) return;
        if (isReloading) return;

        isReloading = true;

        print("Reloading...");
        onReload.Invoke();
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
