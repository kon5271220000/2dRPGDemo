using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrimaryAttackState : PlayerStates
{
    private int comboCounter;
    private float lastTimeAttack;
    private float attackWindow = 0.5f;
    public PlayerPrimaryAttackState(Player _player, PlayerStateMachine _stateMachine, string _animBool) : base(_player, _stateMachine, _animBool)
    {
    }

    public override void Enter()
    {
        base.Enter();

        xInput = 0;

        if(comboCounter > 2 || Time.time >= lastTimeAttack + attackWindow) 
        {
            comboCounter=0;
        }

        player.anim.SetInteger("comboCounter", comboCounter);

        float attackDirection = player.FacingDirection;
        if(xInput != 0)
        {
            attackDirection = xInput;
        }

        player.SetVelocity(player.attackMovement[comboCounter].x * attackDirection, player.attackMovement[comboCounter].y);

        timeState = 0.1f;
    }

    public override void Exit()
    {
        base.Exit();

        comboCounter++;
        lastTimeAttack = Time.time;

        player.StartCoroutine("BusyFor", 0.1f);
    }

    public override void Update()
    {
        base.Update();

        if(timeState < 0)
        {
            player.SetZeroVelocity();
        }


        if (triggerCalled && Time.time >= lastTimeAttack + attackWindow)
        {
            stateMachine.ChangeState(player.Idle);
        }
    }
}
