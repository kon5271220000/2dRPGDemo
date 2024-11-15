using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaginataEnemyDeathState : EnemyStates
{
    private NaginataEnemy enemy;
    public NaginataEnemyDeathState(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName, NaginataEnemy enemy) : base(enemyBase, stateMachine, animBoolName)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();

        enemy.anim.SetBool(enemy.lastAnimBoolName, true);
        enemy.anim.speed = 0;
        enemy.cd.enabled = false;

        stateTimer = 0.1f;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if(stateTimer > 0)
        {
            enemy.rb.velocity = new Vector2(0, 10);
        }
    }
}
    

