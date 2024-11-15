using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerStates
{
    public PlayerJumpState(Player _player, PlayerStateMachine _stateMachine, string _animBool) : base(_player, _stateMachine, _animBool)
    {
    }

    public override void Enter()
    {
        base.Enter();

        player.OnJump();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        player.OnMove(xInput);
        player.ApplyLinearDrag(xInput);

        if (player.canJump)
        {
            player.OnJump();
        }

        if(player.rb.velocity.y <= 0)
        {
            stateMachine.ChangeState(player.OnAir);
        }
    }
}
