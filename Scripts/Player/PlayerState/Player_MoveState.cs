using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_MoveState : Player_GroundState
{
    public Player_MoveState(Player player, StateMachine stateMachine, string statename) : base(player, stateMachine, statename)
    {
    }
    public override void Update()
    {
        base.Update();

        if (player.moveInput.x == 0 || player.wallDetected)
            stateMachine.ChangeState(player.idleState);

        player.SetVeloicity(player.moveInput.x * player.moveSpeed, rb.velocity.y);
    }
}
