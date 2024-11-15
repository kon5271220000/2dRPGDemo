using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaginataEnemyBattleState : EnemyStates
{
    private Transform player;
    private int moveDirection;
   

    NaginataEnemy enemy;
    public NaginataEnemyBattleState(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName, NaginataEnemy enemy) : base(enemyBase, stateMachine, animBoolName)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();

        player = PlayerManager.instance.player.transform;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        

       
        
        if (player.transform.position.x > enemy.transform.position.x)
        {
            moveDirection = 1;
        }
        else if (player.transform.position.x < enemy.transform.position.x)
        {
            moveDirection = -1;
        }

        enemy.FlipController(moveDirection);
            
        
        enemy.SetVelocity(enemy.walkSpeed * moveDirection, enemy.rb.velocity.y);



        if (enemy.PlayerDetected())
        {
            stateTimer = enemy.battleTime;

            if(enemy.PlayerDetected().distance < enemy.attackDistance)
            {
                if (CanAttack())
                {
                    stateMachine.ChangeState(enemy.Attack);
                }
            }
        }
        else
        {
            if(stateTimer < 0 || Vector2.Distance(player.transform.position, enemy.transform.position) < 20f)
            {
                stateMachine.ChangeState(enemy.Idle);
            }
        }
    }

    private bool CanAttack()
    {
        if(Time.time >= enemy.lastTimeAttack + enemy.attackCooldonw)
        {
            return true;
        }
        return false;
    }
}
