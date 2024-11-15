using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerGroundState : PlayerStates
{
    public PlayerGroundState(Player _player, PlayerStateMachine _stateMachine, string _animBool) : base(_player, _stateMachine, _animBool)
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

        if(Input.GetKeyDown(KeyCode.Mouse1)) 
        {
            stateMachine.ChangeState(player.AimKusarigama);
        }

        if (!player.IsOnGround())
        {
            stateMachine.ChangeState(player.OnAir);
        }

        if(player.canJump) 
        {
            stateMachine.ChangeState(player.Jump);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            stateMachine.ChangeState(player.PrimaryAttack);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            stateMachine.ChangeState(player.CounterAttack);
        }
    }
}
