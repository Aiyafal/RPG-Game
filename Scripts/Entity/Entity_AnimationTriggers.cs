using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity_AnimationTriggers : MonoBehaviour
{
    private Entity entity;
    private Entity_Combat entityCombat;

    protected virtual void Awake()
    {
        entity = GetComponentInParent<Entity>();
        entityCombat = GetComponentInParent<Entity_Combat>();
    }


    private void CurrentStateTrigger()
    {
        //获取玩家对象并通知当前状态需要退出

        entity.CurrentStateAnimationTrigger();
    }

    protected void AttackTrigger()
    {
        entityCombat.PerformAttack();
    }
}
