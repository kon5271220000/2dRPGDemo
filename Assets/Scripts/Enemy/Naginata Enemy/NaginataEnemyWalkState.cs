using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaginataEnemyWalkState : NaginataEnemyGroundedState
{
    
    public NaginataEnemyWalkState(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName, NaginataEnemy enemy) : base(enemyBase, stateMachine, animBoolName, enemy)
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

        enemy.SetVelocity(enemy.walkSpeed * enemy.FacingDirection, enemy.rb.velocity.y);

        if (!enemy.IsOnGround() || enemy.IsOnWall())
        {
            enemy.Flip();

            stateMachine.ChangeState(enemy.Idle);
        }
    }
}
