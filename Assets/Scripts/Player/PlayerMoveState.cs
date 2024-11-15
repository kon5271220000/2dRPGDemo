using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerGroundState
{
    public PlayerMoveState(Player _player, PlayerStateMachine _stateMachine, string _animBool) : base(_player, _stateMachine, _animBool)
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
        

        if (xInput == 0 || player.IsOnWall())
        {
            stateMachine.ChangeState(player.Idle);
        }
    }
}
