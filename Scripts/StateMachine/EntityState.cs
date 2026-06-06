using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityState 
{
    protected StateMachine stateMachine;
    protected string animBoolName;

    protected Animator anim;
    protected Rigidbody2D rb;

    protected float stateTimer;
    protected bool triggerCalled;  

    public EntityState(StateMachine stateMachine, string animBoolName)
    {
        this.stateMachine = stateMachine;
        this.animBoolName = animBoolName;
    }

    public virtual void Enter()
    {
        anim.SetBool(animBoolName, true);
        triggerCalled = false;

        //每次更改状态时，enter方法将会被调用
        // Debug.Log("I enter " + animBoolName);
    }

    public virtual void Update()
    {
        stateTimer -= Time.deltaTime;
        UpdapateAnimationParameters();
    }

    public virtual void Exit()
    {
        anim.SetBool(animBoolName, false);

        //每次退出状态并更改新状态时，exit方法将会被调用
        //Debug.Log("I exit " + animBoolName);
    }

    public void AnimationTrigger()
    {
        triggerCalled = true;
    }

    public virtual void UpdapateAnimationParameters()
    {

    }
}
