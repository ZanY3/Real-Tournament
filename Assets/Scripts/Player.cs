using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [Header("Settings for wearpon")]
    public Weapon wearpon;
    public LayerMask WearponLayer;
    public Transform hand;
    [Header("Settings for health")]
    public Health health;
    [Header("HUD")]
    public GameObject grabText;
    public HUD hud;

    private void Update()
    {
        var cam = Camera.main.transform;

        var colided = Physics.Raycast(cam.position, cam.forward, out var hit, 2f, WearponLayer);

        grabText.SetActive(colided);

        if(Input.GetKeyDown(KeyCode.E))
        {
            if (wearpon == null && colided)
            {
                Grab(hit.collider.gameObject);
            }
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (wearpon != null)
            {
                Drop();
            }
        }

        if (wearpon == null) return;

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            wearpon.onRightClick.Invoke();
        }

        // manual shooting

        if (!wearpon.isAutomatic && Input.GetKeyDown(KeyCode.Mouse0))
        {
            wearpon.Shoot();
        }

        // automatic shooting
        if (wearpon.isAutomatic && Input.GetKey(KeyCode.Mouse0))
        {
            wearpon.Shoot();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            wearpon.Reload();
        }
        wearpon.fireCooldown -= Time.deltaTime;
    }

    void Grab(GameObject gun)
    {
        if (wearpon != null) Drop();
        wearpon = gun.GetComponent<Weapon>();
        gun.GetComponent<Rigidbody>().isKinematic = true;
        wearpon = gun.GetComponent<Collider>().GetComponent<Weapon>();
        wearpon.transform.position = hand.position;
        wearpon.transform.rotation = hand.rotation;
        wearpon.transform.parent = hand;

        hud.wearpon = wearpon;
        hud.UpdateUI();
        wearpon.onShoot.AddListener(hud.UpdateUI);
        wearpon.onReload.AddListener(hud.UpdateUI);
    }    
    void Drop()
    {
        if (wearpon == null) return;

        wearpon.GetComponent<Rigidbody>().isKinematic = false;
        wearpon.transform.parent = null;

        
        hud.wearpon = null;
        wearpon.onShoot.RemoveListener(hud.UpdateUI);
        wearpon.onReload.RemoveListener(hud.UpdateUI);
        wearpon = null;
        hud.UpdateUI();
        

    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            health.Damage(10);
        }
    }
}
