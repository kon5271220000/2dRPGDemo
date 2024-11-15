using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaginataEnemyAttackState : EnemyStates
{
    NaginataEnemy enemy;
    public NaginataEnemyAttackState(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName, NaginataEnemy enemy) : base(enemyBase, stateMachine, animBoolName)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();

        enemy.lastTimeAttack = Time.time;
    }

    public override void Update()
    {
        base.Update();

        enemy.SetZeroVelocity();

        if (triggerCalled)
        {
            stateMachine.ChangeState(enemy.Battle);
        }
    }
}
