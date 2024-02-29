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
    //subscribe wearpon
    //unsubscribe wearpon
    void UpdateUI()
    {
        ammoText.text = wearpon.clipAmmo + "/" + wearpon.ammo;
        healthText.text = health.hp.ToString();
    }
    public void SubscribeWearpon(Weapon whatWearpon)
    {
        whatWearpon.onShoot.AddListener(UpdateUI);
    }
    public void UnSubscribeWearpon(Weapon whatWearpon)
    {
        whatWearpon.onShoot.RemoveListener(UpdateUI);
    }
}
