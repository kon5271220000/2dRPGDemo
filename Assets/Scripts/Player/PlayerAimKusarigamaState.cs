using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAimKusarigamaState : PlayerStates
{
    public PlayerAimKusarigamaState(Player _player, PlayerStateMachine _stateMachine, string _animBool) : base(_player, _stateMachine, _animBool)
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

        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            stateMachine.ChangeState(player.Idle);
        }
    }
}
