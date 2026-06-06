using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerState: EntityState
{
    protected Player player;
    protected PlayerInputSet input;


    public PlayerState(Player player, StateMachine stateMachine, string animBoolName):base(stateMachine,animBoolName)
    {
        this.player = player;
      
        anim = player.anim;
        rb = player.rb;
        input = player.input;
    }


    public override void Update()
    {
        base.Update();

        if (input.Player.Dash.WasCompletedThisFrame() && CanDash())
            stateMachine.ChangeState(player.dashState);
    }

    public override void UpdapateAnimationParameters()
    {
        base.UpdapateAnimationParameters();
        anim.SetFloat("yVelocity", rb.velocity.y);
    }
    
    private bool CanDash()
    {
        if (player.wallDetected)
            return false;
        if (stateMachine.currentstate == player.dashState)
            return false;

        return true;


    }
}
