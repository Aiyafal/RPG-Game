using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class Player_BasicAttackState : PlayerState
{
    private float attackVelocityTimer;


    private bool comboAttackQueued;
    private int attackDir;
    private int comboIndex = 1;
    private int comboLimit = 3;
    private const int FirstComboIndex = 1;   //从数字1开始连击索引，这个参数用于动画器


    private float lastTimeAttacked; 


   

    public Player_BasicAttackState(Player player, StateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
        if (comboLimit != player.attackVelocity.Length)
            comboLimit = player.attackVelocity.Length;
    }

    public override void Enter()
    {
        base.Enter();
        comboAttackQueued = false;
        RestComboIndexIfNeeded();


        //根据输入定义攻击方向 
        attackDir = player.moveInput.x != 0 ?  ((int)player.moveInput.x) :  player.facingDir;  //意思和下面的if语句相同  yes : no

        //if (player.moveInput.x != 0)
        //    attackDir = ((int)player.moveInput.x);
        //else
        //    attackDir = player.facingDir;


        anim.SetInteger("basicAttackIndex", comboIndex);
        ApplyAttackVelocity();

    }

   
    public override void Update()
    {
        base.Update();
        HandleAttackVelocity();

        if (input.Player.Attack.WasPressedThisFrame())
            QueueNextAttack();


        if (triggerCalled)
            HandleStateExit();
        
        
    }

    public override void Exit()
    {
        base.Exit();
        comboIndex++;
        
        //记住攻击时间
        lastTimeAttacked = Time.time;
       
    }
    private void HandleStateExit()
    {
        if (comboAttackQueued)
        {
            anim.SetBool(animBoolName, false);
            player.EnterAttackStateWithDelay();
        }
        else
            stateMachine.ChangeState(player.idleState);
    }


    public void QueueNextAttack()
    {
        if (comboIndex < comboLimit)
            comboAttackQueued = true;
    }


    private void HandleAttackVelocity()
    {
        attackVelocityTimer -= Time.deltaTime;

        if(attackVelocityTimer<0)
          player.SetVeloicity(0, rb.velocity.y);
    }

    private void ApplyAttackVelocity()
    {
        Vector2 attackVelocity = player.attackVelocity[comboIndex - 1];
        
        attackVelocityTimer = player.attackVelocityDuration;
        player.SetVeloicity(attackVelocity.x *attackDir, attackVelocity.y);
    }

    private void RestComboIndexIfNeeded()
    {
        // 若上次攻击间隔过久，则重置连招系数
        if (Time.time > lastTimeAttacked + player.comboRestTime)
            comboIndex = FirstComboIndex;
 
            
        if (comboIndex > comboLimit)
            comboIndex = FirstComboIndex;
    }

}
