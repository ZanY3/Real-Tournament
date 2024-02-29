using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int hp;
    public int maxHp = 100;
    public bool shouldDestroy = true;

    public GameObject damageEffect;
    public GameObject deathEffect;

    public UnityEvent onDamage;
    public UnityEvent onDie;

    void Start()
    {
        if(hp == 0) hp = maxHp;
    }


    public void Damage(int damage)
    {
        hp -= damage;
        onDamage.Invoke();
        if(damageEffect != null) Instantiate(damageEffect, transform.position, Quaternion.identity);
        if(hp <= 0)
        {
            Die();
        }
        if( hp < 0) hp = 0;
    }

    public void Die()
    {
        onDie.Invoke();
        if(shouldDestroy)Destroy(gameObject);
        if(deathEffect != null) Instantiate(deathEffect, transform.position, Quaternion.identity);
    }
}