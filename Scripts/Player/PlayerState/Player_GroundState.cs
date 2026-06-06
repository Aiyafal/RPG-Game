using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_GroundState : PlayerState
{
    public Player_GroundState(Player player, StateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }
    public override void Update()
    {
        base.Update();

        if (rb.velocity.y < 0 && player.groundDetected==false)
            stateMachine.ChangeState(player.fallstate);

        
        if (input.Player.Jump.WasPressedThisFrame())
            stateMachine.ChangeState(player.jumpstate);

        if (input.Player.Attack.WasPressedThisFrame())
            stateMachine.ChangeState(player.basicAttackState);

        if (input.Player.CounterAttack.WasPressedThisFrame())
            stateMachine.ChangeState(player.counterAttackState);
    }
}
