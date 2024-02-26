using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int hp;
    public int maxHp = 100;
    public bool shouldDestroy;

    public UnityEvent onDie;
    public UnityEvent onDamage;

    public GameObject damageEffect;
    public GameObject deathEffect;

    void Start()
    {
        if (hp == 0) hp = maxHp;
    }

    public void Damage(int damage)
    {
        
        hp -= damage;
        onDamage.Invoke();
        if (hp <= 0)
        {
            Die();
        }
        if (hp < 0) hp = 0;

        if (damageEffect != null) Instantiate(damageEffect, transform.position, Quaternion.identity);
        onDamage.Invoke();
    }

    public void Die()
    {
        if (deathEffect != null) Instantiate(deathEffect, transform.position, Quaternion.identity);
        onDie.Invoke();
        if (shouldDestroy) Destroy(gameObject);
    }
}
