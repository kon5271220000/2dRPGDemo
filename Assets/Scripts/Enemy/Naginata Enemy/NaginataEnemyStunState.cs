using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaginataEnemyStunState : EnemyStates
{
    NaginataEnemy enemy;
    public NaginataEnemyStunState(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName, NaginataEnemy enemy) : base(enemyBase, stateMachine, animBoolName)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();

        enemy.entityFx.InvokeRepeating("RedColorBlink", 0f, 1f);

        stateTimer = enemy.stunDuration;

        enemy.rb.velocity = new Vector2(-enemy.FacingDirection * enemy.stunDirection.x, enemy.stunDirection.y);
    }

    public override void Exit()
    {
        base.Exit();

        enemy.entityFx.Invoke("CancelRedBlink", 0);
    }

    public override void Update()
    {
        base.Update();

        if (stateTimer < 0)
        {
            stateMachine.ChangeState(enemy.Idle);
        }
    }
}
    

