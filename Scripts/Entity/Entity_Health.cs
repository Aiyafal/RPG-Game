using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Entity_Health : MonoBehaviour,IDamgeble
{
    private Slider healthBar;
    private Entity_VFX entityVfx;
    private Entity entity;

    [SerializeField] protected float currentHp;
    [SerializeField] protected float maxHp = 100;
    [SerializeField] protected bool isDead;

    [Header("On Damage Knockback")]
    [SerializeField] private Vector2 knockBackPower = new Vector2(1.5f, 2.5f);
    [SerializeField] private Vector2 heavyKnockBackPower = new Vector2(7, 7);
    [SerializeField] private float knockbackDuration=.2f;
    [SerializeField] private float heavyKnockbackDuration = .5f;
 
    [Header("On Heavy Damage")]
    [SerializeField] private float heavyDamageThreshold=.3f;

    protected virtual void Awake()
    {
        entityVfx = GetComponent<Entity_VFX>();
        entity = GetComponent<Entity>();
        healthBar = GetComponentInChildren<Slider>();

        currentHp = maxHp;
        UpdateHealthBar();
    }


    public virtual void TakeDamage(float damage,Transform damageDealer)
    {
        if (isDead)
            return;

        float duration = CaculateDuration(damage);
        Vector2 knockback = CaculateKnockback(damage, damageDealer);

        entityVfx?.PlayOnDamageVfx();
        entity?.ReciveKnockback(knockback,duration);
        ReduceHP(damage);
    }

    protected void ReduceHP(float damage)
    {
        currentHp -= damage;
        UpdateHealthBar();

        if (currentHp <= 0)
            Die();
    }

    private void UpdateHealthBar()
    {
        if (healthBar == null)
            return;

        healthBar.value = currentHp / maxHp;
    }

    private void Die()
    {
        isDead=true;

        entity?.EnitityDeath();
    }

    private Vector2 CaculateKnockback(float damage, Transform damageDealer)
    {
        int direction = transform.position.x > damageDealer.position.x ? 1 : -1;
       
        Vector2 knockback = IsHeavy(damage) ? heavyKnockBackPower : knockBackPower;
        knockback.x *= direction;

        return knockback;
    }

    private float CaculateDuration(float damage)
    {
        return IsHeavy(damage) ? heavyKnockbackDuration : knockbackDuration;
    }

    private bool IsHeavy(float damage) => damage / maxHp >= heavyDamageThreshold;
}
