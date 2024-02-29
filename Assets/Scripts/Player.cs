using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Weapon wearpon;
    public Health health;
    public LayerMask WearponLayer;
    public GameObject grabText;
    public Transform hand;
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
    }    
    void Drop()
    {
        if (wearpon == null) return;
        wearpon.GetComponent<Rigidbody>().isKinematic = false;
        wearpon.transform.parent = null;
        wearpon = null;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            health.Damage(10);
        }
    }
}
