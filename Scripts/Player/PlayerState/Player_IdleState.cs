using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_IdleState : Player_GroundState
{
    public Player_IdleState(Player player, StateMachine stateMachine, string statename) : base(player, stateMachine, statename)
    {
    }

    public override void Enter()
    {
        base.Enter();

        player.SetVeloicity(0, rb.velocity.y);
    }
    public override void Update()
    {
        base.Update();

        if (player.moveInput.x == player.facingDir && player.wallDetected)
            return;


        if (player.moveInput.x!=0)
            stateMachine.ChangeState(player.moveState);

        
    }

}
