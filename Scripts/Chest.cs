using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour,IDamgeble
{
    public Animator anim => GetComponentInChildren<Animator>();
    public Rigidbody2D rb => GetComponent<Rigidbody2D>();
    public Entity_VFX fx => GetComponent<Entity_VFX>();

    [Header("Open Details")]
    [SerializeField] private Vector2 knockBack;

    public void TakeDamage(float damage, Transform damageDealer)
    {
        fx.PlayOnDamageVfx();
        anim.SetBool("chestOpen", true);

        rb.velocity = knockBack;
        rb.angularVelocity = Random.Range(-200f, 200f);
    }

}
