using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore;

public class Enemy_MoveState : Enemy_GroundState
{
    public Enemy_MoveState(Enemy enemy, StateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
    {
    }
    public override void Enter()
    {
        base.Enter();
         
        enemy.Flip();
    }
    

    public override void Update()
    {
        base.Update();

        enemy.SetVeloicity(enemy.movespeed * enemy.facingDir, rb.velocity.y);

        if (enemy.groundDetected == false || enemy.wallDetected==true)
            stateMachine.ChangeState(enemy.idleState);
        


    }
    
}
