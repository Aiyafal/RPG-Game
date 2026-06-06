using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_WallJumpState : PlayerState
{
    public Player_WallJumpState(Player player, StateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }
    private bool iswallJumping;
    private float wallJumpTimer;
    public override void Enter()
    {
        base.Enter();

        player.SetVeloicity(player.wallJumpForce.x * -player.facingDir, player.wallJumpForce.y);

        iswallJumping = true;
        wallJumpTimer = 0.1f;
    }

    public override void Update()
    {
        base.Update();

        if (player.wallDetected)
            stateMachine.ChangeState(player.wallslidestate);

        if (rb.velocity.y < 0)
            stateMachine.ChangeState(player.fallstate);

        if (iswallJumping)
        {
            if (wallJumpTimer > 0)
                wallJumpTimer -= Time.deltaTime;
            else
                iswallJumping = false;
            HandleMovementInput();
        }
    }
    public void HandleMovementInput()
    {
        float inputX = Input.GetAxisRaw("Horizontal");

        if (!iswallJumping || wallJumpTimer < 0)
            player.SetVeloicity(inputX * player.moveSpeed, rb.velocity.y);
    }
}
