using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCounterAttackState : PlayerStates
{
    public PlayerCounterAttackState(Player _player, PlayerStateMachine _stateMachine, string _animBool) : base(_player, _stateMachine, _animBool)
    {
    }

    public override void Enter()
    {
        base.Enter();

        

        player.anim.SetBool("successCounterAttack", false);
    }

    public override void Exit()
    {
        base.Exit();

        player.counterAttackDuration = 0.2f;
    }

    public override void Update()
    {
        base.Update();

        player.counterAttackDuration -= Time.deltaTime;

        Debug.Log(player.counterAttackDuration);

        player.rb.velocity = new Vector2(0, 0);

        Collider2D[] colliders = Physics2D.OverlapCircleAll(player.attackCheck.position, player.attackDistanceRadius);

        foreach (var hit in colliders)
        {
            if(hit.GetComponent<Enemy>() != null)
            {
                if (hit.GetComponent<Enemy>().CanBeStun())
                {
                    player.counterAttackDuration = 10f;

                    player.anim.SetBool("successCounterAttack", true);
                }
            }  
        }

        if(player.counterAttackDuration < 0 || triggerCalled)
        {
            stateMachine.ChangeState(player.Idle);
        }
    }
}
