using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_WallSlideState : PlayerState
{
    public Player_WallSlideState(Player player, StateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }
    public override void Update()
    {
        base.Update();
        HandleWallSlide();

        if (input.Player.Jump.WasPerformedThisFrame())
            stateMachine.ChangeState(player.wallJumpState);

        if (player.wallDetected == false)
            stateMachine.ChangeState(player.fallstate);




        if (player.groundDetected)
        {
            stateMachine.ChangeState(player.idleState);
            
            if(player.facingDir!=player.moveInput.x)
            player.Flip();
        }
    }
    private void HandleWallSlide()
    {
        if (player.moveInput.y < 0)
            player.SetVeloicity(player.moveInput.x, rb.velocity.y);
        else
            player.SetVeloicity(player.moveInput.x, rb.velocity.y * player.wallSlideSlowMultiplier);
    }
    
}
