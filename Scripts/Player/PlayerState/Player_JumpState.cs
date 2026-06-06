using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_JumpState : Player_AirState
{
    public Player_JumpState(Player player, StateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        //物体向上移动时，给予y轴上的速度

        player.SetVeloicity(rb.velocity.x, player.jumpForce);
    }
    public override void Update()
    {
        base.Update();

        //如果y轴的速度下降，即角色在下落，改变至下落状态

        if (rb.velocity.y < 0 && stateMachine.currentstate!= player.jumpAttackState)   // 当转换至下落状态时需要确保不处于下落攻击状态
            stateMachine.ChangeState(player.fallstate);
    }
}
