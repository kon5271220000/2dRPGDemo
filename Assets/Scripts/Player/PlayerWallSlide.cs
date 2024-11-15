using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallSlide : PlayerStates
{
    public PlayerWallSlide(Player _player, PlayerStateMachine _stateMachine, string _animBool) : base(_player, _stateMachine, _animBool)
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

        player.rb.velocity = new Vector2(0f, player.rb.velocity.y * 0.7f);

        if(player.IsOnGround())
        {
            stateMachine.ChangeState(player.Idle);
        }

        if (player.IsOnWall() && xInput != player.FacingDirection)
        {
            stateMachine.ChangeState(player.OnAir);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            stateMachine.ChangeState(player.WallJump);
            return;
        }
    }
}
