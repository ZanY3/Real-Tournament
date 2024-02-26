using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    [SerializeField] TMP_Text ammoText;
    [SerializeField] TMP_Text healthText;

    public Weapon wearpon;
    public Health health;

    private void Start()
    {
        UpdateUI();
        wearpon.onShoot.AddListener(UpdateUI);
        health.onDamage.AddListener(UpdateUI);
    }

    void UpdateUI()
    {
        ammoText.text = wearpon.clipAmmo + "/" + wearpon.ammo;
        healthText.text = health.hp.ToString();
    }
}
