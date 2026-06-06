using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity_Combat : MonoBehaviour
{
    private Entity_VFX vfx;
    public float damage = 10;


    [Header("target detection")]
    [SerializeField] private Transform targetCheck;
    [SerializeField] private LayerMask whatIsTarget;
    [SerializeField] private float targetCheckRadius;

    private void Awake()
    {
        vfx = GetComponent<Entity_VFX>();
    }

    public void PerformAttack()
    {

        foreach (var target in GetDetectedColliders())
        {
            IDamgeble damgeble = target.GetComponent<IDamgeble>();

            if (damgeble == null)
                continue;
            
            damgeble.TakeDamage(damage, transform);
            vfx.CreateOnHitVFX(target.transform);
        }

    }

    
    protected Collider2D[] GetDetectedColliders()
    {
         return Physics2D.OverlapCircleAll(targetCheck.position, targetCheckRadius, whatIsTarget);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(targetCheck.position, targetCheckRadius);
    }
}
