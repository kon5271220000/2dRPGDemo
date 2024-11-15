using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirState : PlayerStates
{
    public PlayerAirState(Player _player, PlayerStateMachine _stateMachine, string _animBool) : base(_player, _stateMachine, _animBool)
    {

    }

    public override void Enter()
    {
        base.Enter();
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
        

        if (player.IsOnGround()) 
        {
            stateMachine.ChangeState(player.Idle);
        }

        if (player.canJump)
        {
            stateMachine.ChangeState(player.Jump);
        }

        if (player.IsOnWall() && xInput == player.FacingDirection)
        {
            stateMachine.ChangeState(player.WallSlide);
        }
    }
}
