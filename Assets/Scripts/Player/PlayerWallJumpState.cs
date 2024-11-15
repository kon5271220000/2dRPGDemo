using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallJumpState : PlayerStates
{
    public PlayerWallJumpState(Player _player, PlayerStateMachine _stateMachine, string _animBool) : base(_player, _stateMachine, _animBool)
    {
    }

    public override void Enter()
    {
        base.Enter();

        timeState = 0.4f;

        player.OnWallJump();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        player.OnMove(xInput);

        if(timeState < 0)
        {
            stateMachine.ChangeState(player.OnAir);
        }

        if (player.IsOnGround()) 
        {
            stateMachine.ChangeState(player.Idle);
        }
    }
}
