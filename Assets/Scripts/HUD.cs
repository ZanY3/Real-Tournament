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
        health.onDamage.AddListener(UpdateUI);
    }
    //subscribe wearpon
    //unsubscribe wearpon
    public void UpdateUI()
    {
        healthText.text = health.hp.ToString();
        if (wearpon != null)
        {
            ammoText.text = wearpon.clipAmmo + "/" + wearpon.ammo;  
        }
        else
        {
            ammoText.text = " ";
        }
    }
}
