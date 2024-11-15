using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerStates
{
    public PlayerDashState(Player _player, PlayerStateMachine _stateMachine, string _animBool) : base(_player, _stateMachine, _animBool)
    {
    }

    public override void Enter()
    {
        base.Enter();

        player.skill.cloneSkill.CreateClone(player.transform);

        timeState = player.dashDuration;
    }

    public override void Exit()
    {
        base.Exit();

        player.SetZeroVelocity();
    }

    public override void Update()
    {
        base.Update();

       player.rb.velocity = new Vector2(0, 0);

        player.rb.AddForce(Vector2.right * player.dashSpeed * player.dashDirection, ForceMode2D.Impulse);
        
        if (timeState <= 0)
        {
            stateMachine.ChangeState(player.Idle);
        }

        if(player.IsOnWall() && !player.IsOnGround())
        {
            stateMachine.ChangeState(player.WallSlide);
        }
    }
}
    

