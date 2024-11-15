using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaginataEnemyIdleState : NaginataEnemyGroundedState
{
    
    public NaginataEnemyIdleState(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName, NaginataEnemy enemy) : base(enemyBase, stateMachine, animBoolName, enemy)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();

        stateTimer = enemy.idleTime;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

       

        if (stateTimer < 0)
        {
            stateMachine.ChangeState(enemy.Walk);
        }
    }
}
    

