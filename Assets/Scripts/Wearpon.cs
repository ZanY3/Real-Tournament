using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wearpon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject shootParticle;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(bulletPrefab, transform.position, transform.rotation);
            Instantiate(shootParticle, transform.position, transform.rotation);
        }
    }
}
